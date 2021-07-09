
#include "stdafx.h"
#include <F28LightControl_ETH.h>
#include "AutoRatio.h"

CAutoRatio::CAutoRatio()
{
	Initialize();
}

CAutoRatio::~CAutoRatio()
{
}

void CAutoRatio::Initialize(void)
{
	m_wNbCycles		= 2;
	m_wInterCycle	= 3000;		// 3 sec
	m_fRatioMax		= 0.1f;
	m_fRatioMin		= 1.0f;
	m_wError		= 0;
	m_sModuleId		= 0;
	m_bRunning		= FALSE;
	m_ucPhase		= AUTO_RATIO_IDDLE; 
}

CString CAutoRatio::GetPhaseStr(BYTE ucPhase)
{
	CString strRet = _T("????");
	strRet.Format(_T("<%d>: "), ucPhase);

	switch (ucPhase)
	{
	case AUTO_RATIO_IDDLE:
		strRet += _T("Ready");
		break;

	case AUTO_RATIO_START:
		strRet += _T("Start Auto-Ratio calculation");
		break;

	case AUTO_RATIO_WAIT_EOC:
		strRet += _T("Wait end of Auto-Ratio calculation");
		break;

	case AUTO_RATIO_END:
		strRet += _T("End Auto-Ratio");
		break;
	}

	return strRet;
}

BYTE CAutoRatio::GetAlarm()
{
	BYTE ucAlarm = 0;
	if (m_sModuleId > 0)
	{
		ucAlarm = F28_GetAutoCalAlarm(m_sModuleId);
	}
	return ucAlarm;
}

BOOL CAutoRatio::StartAutoRatio(short sModuleID, WORD wNbCycles, WORD wInterCycle, float fRatioMax, float fRatioMin)
{
	BOOL bRet = FALSE;

	if (sModuleID > 0)
	{
		m_wNbCycles = wNbCycles;
		m_wInterCycle = wInterCycle;
		m_fRatioMax = fRatioMax;
		m_fRatioMin = fRatioMin;

		m_sModuleId = sModuleID;
		m_wError = 0;
		m_ucPhase = AUTO_RATIO_START;
		m_bRunning = TRUE;

		bRet = TRUE;
	}

	return bRet;
}

BOOL CAutoRatio::StopAutoRatio()
{
	short sRet = F28_FAIL;

	if ((m_sModuleId > 0) && (m_ucPhase != AUTO_RATIO_IDDLE))
	{
		sRet = F28_StopAutoRatio(m_sModuleId);
	}

	m_ucPhase = AUTO_RATIO_IDDLE;
	m_bRunning = FALSE;

	return (sRet == F28_OK) ? TRUE:FALSE;
}

//' *****************************************************
//' Purpose   : Run Auto-Ratio
//' Return    :
//'               - True  : EOC Auto-Ratio
//'               - False : Running
//' *****************************************************
BOOL CAutoRatio::RunAutoRatio()
{
	short sRet;

	BOOL bReturn = FALSE;

	switch (m_ucPhase)
	{
	case AUTO_RATIO_START:			// Start Auto-Ratio
		sRet = F28_StartAutoRatio(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fRatioMax, m_fRatioMin);

		if (sRet == F28_OK)
		{
			m_ucPhase = AUTO_RATIO_WAIT_EOC;
		}
		else
		{
			m_wError = m_ucPhase;
			m_ucPhase = AUTO_RATIO_END;
		}
		break;
	case AUTO_RATIO_WAIT_EOC:		// Wait EOC Offset
		if (F28_GetEOCRatio(m_sModuleId) > 0)
		{
			m_wError = 0;			// Pas d'erreur
			m_ucPhase = AUTO_RATIO_END;
		}
		break;

	case AUTO_RATIO_END:					// End of auto ratio
		m_wError = m_ucPhase;
		m_ucPhase = AUTO_RATIO_IDDLE;
		m_bRunning = FALSE;
		bReturn = TRUE;
		break;

	case AUTO_RATIO_IDDLE:				// Ready do nothing

		// Do nothing
		break;
	}

	return bReturn;
}
