
#include "stdafx.h"
#include <F28LightControl_ETH.h>
#include "EasyAutoLearning.h"

CEasyAutoLearning::CEasyAutoLearning()
{
	Initialize();
}

CEasyAutoLearning::~CEasyAutoLearning()
{
}

void CEasyAutoLearning::Initialize(void)
{
	m_wNbCycles		= 2;
	m_wInterCycle	= 3000;		// 3 sec
	m_wError		= 0;
	m_sModuleId		= 0;
	m_bRunning		= FALSE;
	m_ucPhase		= EASY_AUTO_IDDLE; 
}

CString CEasyAutoLearning::GetPhaseStr(BYTE ucPhase)
{
	CString strRet = _T("????");
	strRet.Format(_T("<%d>: "), ucPhase);

	switch (ucPhase)
	{
	case EASY_AUTO_IDDLE:
		strRet += _T("Ready");
		break;

	case EASY_AUTO_START:
		strRet += _T("Start Easy Auto Learning calculation");
		break;

	case EASY_AUTO_WAIT_EOC:
		strRet += _T("Wait end of Easy Auto Learning calculation");
		break;

	case EASY_AUTO_END:
		strRet += _T("End Easy Auto Learning");
		break;
	}

	return strRet;
}

BYTE CEasyAutoLearning::GetAlarm()
{
	BYTE ucAlarm = 0;
	if (m_sModuleId > 0)
	{
		ucAlarm = F28_GetAutoCalAlarm(m_sModuleId);
	}
	return ucAlarm;
}

BOOL CEasyAutoLearning::StartEasyAutoLearning(short sModuleID, WORD wNbCycles, WORD wInterCycle)
{
	BOOL bRet = FALSE;

	if (sModuleID > 0)
	{
		m_wNbCycles = wNbCycles;
		m_wInterCycle = wInterCycle;

		m_sModuleId = sModuleID;
		m_wError = 0;
		m_ucPhase = EASY_AUTO_START;
		m_bRunning = TRUE;

		bRet = TRUE;
	}

	return bRet;
}

BOOL CEasyAutoLearning::StopEasyAutoLearning()
{
	short sRet = F28_FAIL;

	if ((m_sModuleId > 0) && (m_ucPhase != EASY_AUTO_IDDLE))
	{
		sRet = F28_StopEasyAutoLearning(m_sModuleId);
	}

	m_ucPhase = EASY_AUTO_IDDLE;
	m_bRunning = FALSE;

	return (sRet == F28_OK) ? TRUE:FALSE;
}

//' *****************************************************
//' Purpose   : Run Easy Auto Learning
//' Return    :
//'               - True  : EOC Easy auto learning
//'               - False : Running
//' *****************************************************
BOOL CEasyAutoLearning::RunEasyAutoLearning()
{
	short sRet;

	BOOL bReturn = FALSE;

	switch (m_ucPhase)
	{
	case EASY_AUTO_START:			// Start Easy auto learning
		sRet = F28_StartEasyAutoLearning(m_sModuleId, m_wNbCycles, m_wInterCycle);

		if (sRet == F28_OK)
		{
			m_ucPhase = EASY_AUTO_WAIT_EOC;
		}
		else
		{
			m_wError = m_ucPhase;
			m_ucPhase = EASY_AUTO_END;
		}
		break;
	case EASY_AUTO_WAIT_EOC:		// Wait EOC
		if (F28_GetEOCRatio(m_sModuleId) > 0)
		{
			m_wError = 0;			// Pas d'erreur
			m_ucPhase = EASY_AUTO_END;
		}
		break;

	case EASY_AUTO_END:					// End of easy auto learning
		m_wError = m_ucPhase;
		m_ucPhase = EASY_AUTO_IDDLE;
		m_bRunning = FALSE;
		bReturn = TRUE;
		break;

	case EASY_AUTO_IDDLE:				// Ready do nothing

		// Do nothing
		break;
	}

	return bReturn;
}
