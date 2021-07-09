
// 05/01/16 1.501 if Abort Cal process -> Send F28_StopAutoCal



#include "stdafx.h"
#include <F28LightControl_ETH.h>
#include "AutoCal.h"


CAutoCal::CAutoCal()
{
	Initialize();
}


CAutoCal::~CAutoCal()
{
}


void CAutoCal::Initialize()
{
	m_wNbCycles = 2;
	m_wInterCycle = 3000;		// 3 sec
	m_fOffsetMax = 0;

	m_fVolumeLeak = 0;
	m_fVolumePressure = 0;
	m_fVolumeMin = 0;
	m_fVolumeMax = 0;

	m_wError = 0;
	m_sModuleId = 0;
	m_bRunning = FALSE;

	m_ucPhase = AUTO_IDDLE; 
	m_ucMode = MODE_OFFSET;
}

CString CAutoCal::GetPhaseStr(BYTE ucPhase)
{
	CString strRet = _T("????");
	strRet.Format(_T("<%d>: "), ucPhase);

	switch (ucPhase)
	{
	case AUTO_IDDLE:
		strRet += _T("Ready");
		break;

	case AUTO_START_OFFSET:
		strRet += _T("Start Offset calculation");
		break;

	case AUTO_WAIT_EOC_OFFSET:
		strRet += _T("Wait end of Offset calculation");
		break;

	case AUTO_WAIT_MASTER_LEAK:
		strRet += _T("Wait Master");
		break;

	case AUTO_START_VOLUME:
		strRet += _T("Start Volume calculation");
		break;

	case AUTO_WAIT_EOC_VOLUME:
		strRet += _T("Wait end of volume calculation");
		break;

	case AUTO_END:
		strRet += _T("End Calibration");
		break;
	}

	return strRet;
}

BYTE CAutoCal::GetAlarm()
{
	BYTE ucAlarm = 0;
	if (m_sModuleId > 0)
	{
		ucAlarm = F28_GetAutoCalAlarm(m_sModuleId);
	}
	return ucAlarm;
}

BOOL CAutoCal::StartCal(short sModuleID, BYTE ucMode, WORD wNbCycles, WORD wInterCycle, float fOffsetMax,
										float fVolumeLeak, float fVolumePressure, float fVolumeMin, float fVolumeMax)
{
	BOOL bRet = FALSE;

	if (sModuleID > 0)
	{

		m_wNbCycles = wNbCycles;
		m_wInterCycle = wInterCycle;
		m_fOffsetMax = fOffsetMax;
		m_fVolumeLeak = fVolumeLeak;
		m_fVolumePressure = fVolumePressure;
		m_fVolumeMin = fVolumeMin;
		m_fVolumeMax = fVolumeMax;

		m_sModuleId = sModuleID;
		m_ucMode = ucMode;
		m_wError = 0;
		m_ucPhase = AUTO_START_OFFSET;
		m_bRunning = TRUE;

		bRet = TRUE;
	}

	return bRet;
}

BOOL CAutoCal::StopCal()
{
	short sRet = F28_FAIL;

	if ((m_sModuleId > 0) && (m_ucPhase != AUTO_IDDLE))
	{
		sRet = F28_StopAutoCal(m_sModuleId);
	}

	m_ucPhase = AUTO_IDDLE;
	m_bRunning = FALSE;

	return (sRet == F28_OK) ? TRUE:FALSE;

}


BOOL CAutoCal::RunCalContinue(BOOL bForward)
{
	BOOL bRet = FALSE;
	if (bForward)
	{
		bRet = TRUE;
		m_ucPhase = AUTO_START_VOLUME;
	}
	else
	{

		m_wError = m_ucPhase;


		// 1.501 if Abort Cal process -> Send F28_StopAutoCal
		StopCal();

		m_ucPhase = AUTO_IDDLE;
		m_bRunning = FALSE;

		//StopCal();
	}

	return bRet;
}


//' *****************************************************
//' Purpose   : Run Calibration
//' Return    :
//'               - True  : EOC calibration
//'               - False : Running
//' *****************************************************
BOOL CAutoCal::RunCal()
{
	short sRet;

	BOOL bReturn = FALSE;

	switch (m_ucPhase)
	{
	case AUTO_START_OFFSET:			// Start auto Cal     
		if (m_ucMode == MODE_OFFSET)
		{
			sRet = F28_StartAutoCalOffsetOnly(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fOffsetMax);
		}
		else
		{
			sRet = F28_StartAutoCalOffset(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fOffsetMax);
		}

		if (sRet == F28_OK)
		{
			m_ucPhase = AUTO_WAIT_EOC_OFFSET;
		}
		else
		{
			m_wError = m_ucPhase;
			m_ucPhase = AUTO_END;
		}
		break;
	case AUTO_WAIT_EOC_OFFSET:		// Wait EOC Offset
		if (F28_GetEOCOffset(m_sModuleId) > 0)
		{
			if (m_ucMode == MODE_OFFSET)
			{
				m_wError = 0;			//' Pas d'erreur
				m_ucPhase = AUTO_END;
			}
			else
			{
				m_wError = m_ucPhase;
				m_ucPhase = AUTO_WAIT_MASTER_LEAK;
			}
		}
		break;

	case AUTO_WAIT_MASTER_LEAK:		// Waiting master leak

		// Wait validation from user
		// Do nothing

		break;

	case AUTO_START_VOLUME:			// Start auto volume
		if (F28_StartAutoCalVolume(m_sModuleId, m_wNbCycles, m_wInterCycle,
			m_fVolumeLeak, m_fVolumePressure, m_fVolumeMin, m_fVolumeMax) == F28_OK)
		{
			m_ucPhase = AUTO_WAIT_EOC_VOLUME;
		}
		else
		{
			m_wError = m_ucPhase;
			m_ucPhase = AUTO_END;
		}
		break;

	case AUTO_WAIT_EOC_VOLUME:		// Wait EOC Auto volume
		if (F28_GetEOCVolume(m_sModuleId) > 0)
		{
			m_wError = 0;			// Pas d'erreur
			m_ucPhase = AUTO_END;
		}
		break;

	case AUTO_END:					// End of auto calibration
		m_wError = m_ucPhase;
		m_ucPhase = AUTO_IDDLE;
		m_bRunning = FALSE;
		bReturn = TRUE;
		break;

	case AUTO_IDDLE:				// Ready do nothing

		// Do nothing
		break;

	}

	return bReturn;

}
