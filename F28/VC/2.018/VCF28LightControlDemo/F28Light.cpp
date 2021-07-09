#include "stdafx.h"
#include <Ws2tcpip.h>
#include "F28Light.h"
#include "VCF28LightControlDemo.h"
#include "dlgpar.h"

CF28Light::CF28Light()
{
	m_strParaFile  = _T("F28L_para.cfg");

	::ZeroMemory(&m_Result, sizeof(m_Result));
	::ZeroMemory(&m_Realtime, sizeof(m_Realtime));
	::ZeroMemory(&m_rCptComm, sizeof(m_rCptComm));

	SetDefaultPara();

}

CF28Light::~CF28Light()
{

}

//  ************************************************************************************
//  CF28Light::SetDefaultPara()
//  
//  Purpose:
//  
//  Parameters:
//		[nLeakUnit] :
//		[fVolume] :
//		[fOffset_sccm] :
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CF28Light::SetDefaultPara(int nLeakUnit)
{
	if (nLeakUnit == -1)
	{
		m_Para.wTypeTest = LEAK_TEST;
		m_Para.wTpsFillVol = 100;           // 1 s
		m_Para.wTpsTransfert = 100;         // 1 s

		m_Para.wTpsFill = 300;
		m_Para.wTpsStab = 300;
		m_Para.wTpsTest = 500;
		m_Para.wTpsDump = 200;

		m_Para.wPress1Unit = PRESS_mBAR;	// mBar
		m_Para.fPress1Min = -2000;
		m_Para.fPress1Max = 200000;

		m_Para.fSetFillP1 = 0;				// mode auto-fill
		m_Para.fRatioMax = 0;
		m_Para.fRatioMin = 0;
		m_Para.wFillMode = 0;				// 1.500 See F28_ENUM_FILL_MODE

		m_Para.wLeakUnit = LEAK_SCCM;       // See F28_LEAK_UNITS

		m_Para.wRejectCalc = 1;				// Pa or Pa/s
		m_Para.wVolumeUnit = VOLUME_CM3;	// See F28_ENUM_VOLUME_UNIT 
		m_Para.fVolume = 15;

		m_Para.fRejectMin = 0;
		m_Para.fRejectMax = 10;

		m_Para.fCoeffAutoFill = 0;
		m_Para.wOptions = 0;			

		m_Para.fPatmSTD = 1013.0f;			// Patm  standard condition (hPa)
		m_Para.fTempSTD = 0.0f;				// Temperature standard condition (en °C)
		m_Para.fFilterTime = 0;				//  en (s)

		m_Para.fOffsetLeak = 0;				// 1.300
	}
}

CString CF28Light::GetOffsetVolumeStr()
{
	CString str;

	str.Format(_T("Offset = %.4f - Volume = %.2f"), m_Para.fOffsetLeak, m_Para.fVolume);

	return str;
}

CString CF28Light::GetRatioStr()
{
	CString str;

	str.Format(_T("Ratio max. = %.3f - Ratio min. = %.3f"), m_Para.fRatioMax, m_Para.fRatioMin);

	return str;
}

//  ************************************************************************************
//  CF28Light::WriteFile()
//  
//  Purpose:
//		- Write parameters to file
//  
//  Parameters:
//		[pCfg] : parameter's structure
//  
//  Returns:	int
//  
//		- F28_OK/F28_FAIL
//
//  ************************************************************************************
int CF28Light::WriteFile(F28_PARAMETERS* pCfg)
{
	CFile	file;
	int	nRet = F28_FAIL;
	if (file.Open(m_strParaFile, CFile::modeReadWrite | CFile::modeNoTruncate | CFile::modeCreate) != FALSE)
	{
		if (pCfg)
			file.Write(pCfg, sizeof(F28_PARAMETERS));
		else
			file.Write(&m_Para, sizeof(F28_PARAMETERS));

		file.Close();

		nRet = F28_OK;
	}
	return(nRet);
}

//  ************************************************************************************
//  CF28Light::ReadFile
//  
//  Purpose:
//		- Read parameter from file
//  
//  Parameters:
//		[pCfg] :
//  
//  Returns:	int
//  
//		- F28_OK/F28_FAIL
//
//  ************************************************************************************
int CF28Light::ReadFile(F28_PARAMETERS* pCfg)
{
	CFile	file;
	int 	nRet = F28_FAIL;
	if (file.Open(m_strParaFile, CFile::modeReadWrite | CFile::modeNoTruncate) != FALSE)
	{
		if (pCfg)
			file.Read(pCfg, sizeof(F28_PARAMETERS));
		else
			file.Read(&m_Para, sizeof(F28_PARAMETERS));

		file.Close();

		nRet = F28_OK;
	}
	else
	{
		WriteFile();
	}
	return(nRet);
}




//  ************************************************************************************
//  CF28Light::GetPhaseStr()
//  
//  Purpose: Get cycle phase string
//  
//  Parameters:
//		[ucPhase] : phase code
//  
//  Returns:	CString
//  
//		
//  ************************************************************************************
LPCTSTR CF28Light::GetPhaseStr(BYTE ucPhase)
{
	LPCTSTR strRet = _T("????");

	switch (ucPhase)
	{
	case FILL_STEP:
		strRet = _T("FILL");
		break;
	case STAB_STEP:
		strRet = _T("STABILISATION");
		break;
	case TEST_STEP:
		strRet = _T("TEST");
		break;

	case DUMP_STEP:
		strRet = _T("DUMP");
		break;

	case NO_STEP:
		strRet = _T("Ready");
		break;
	}
	return strRet;
}



//  ************************************************************************************
//  CF28Light::GetLeakUnitStr()
//  
//  Purpose: Get Leak unit string
//  
//  Parameters:
//		[ucUnit] : unit code
//  
//  Returns:	CString
//  
//		
//  ************************************************************************************
LPCTSTR CF28Light::GetLeakUnitStr(BYTE ucUnit)
{
	LPCTSTR strRet = _T("????");

	switch (ucUnit)
	{
	case LEAK_PA:
		strRet = _T("Pa");
		break;
	case LEAK_PASEC:
		strRet = _T("Pa/s");
		break;
	case LEAK_PA_HR:
		strRet = _T("Pa(Hr)");
		break;
	case LEAK_PASEC_HR:
		strRet = _T("Pa(Hr)/s");
		break;
	case LEAK_CAL_PA:
		strRet = _T("Cal Pa");
		break;
	case LEAK_CAL_PASEC:
		strRet = _T("Cal-Pa/s");
		break;
	case LEAK_CCMIN:
		strRet = _T("cc/mn");
		break;
	case LEAK_CCSEC:
		strRet = _T("cc/s");
		break;
	case LEAK_CCH:
		strRet = _T("cc/h");
		break;
	case LEAK_MM3SEC:
		strRet = _T("mm3/s");
		break;
	case LEAK_CM3_SEC:
		strRet = _T("cm3/s");
		break;
	case LEAK_CM3_MIN:
		strRet = _T("cm3/mn");
		break;
	case LEAK_CM3_H:
		strRet = _T("cm3/h");
		break;
	case LEAK_ML_SEC:
		strRet = _T("ml/s");
		break;
	case LEAK_ML_MIN:
		strRet = _T("ml/mn");
		break;
	case LEAK_ML_H:
		strRet = _T("ml/h");
		break;
	case LEAK_INCH3_SEC:
		strRet = _T("inch3/s");
		break;
	case LEAK_INCH3_MIN:
		strRet = _T("inch3/mn");
		break;
	case LEAK_INCH3_H:
		strRet = _T("inch3/h");
		break;
	case LEAK_FT3_SEC:
		strRet = _T("ft3/s");
		break;
	case LEAK_FT3_MIN:
		strRet = _T("ft3/mn");
		break;
	case LEAK_FT3_H:
		strRet = _T("ft3/h");
		break;
	case LEAK_MMCE:
		strRet = _T("mmCE");
		break;
	case LEAK_MMCE_SEC:
		strRet = _T("mmCE/s");
		break;
	case LEAK_SCCM:
		strRet = _T("sccm");
		break;
	case LEAK_POINTS:
		strRet = _T("Pts");
		break;

	// 1.500 Leak units
	case LEAK_KPA:
		strRet = _T("kPa");
		break;
	case LEAK_MPA:
		strRet = _T("MPa");
		break;
	case LEAK_BAR:
		strRet = _T("bar");
		break;
	case LEAK_mBAR:
		strRet = _T("mbar");
		break;
	case LEAK_PSI:
		strRet = _T("PSI");
		break;
	case LEAK_L_MIN:
		strRet = _T("l/mn");
		break;
	// end 1.500

// V2.0.0.4
	case LEAK_JET_CHECK:
		strRet = _T("mm");
		break;
// V2.0.0.4
// V2.0.0.6
	case LEAK_CM_H2O:
		strRet = _T("cmH2O");
		break;
// V2.0.0.6
	case LEAK_UG_H2O:
		strRet = _T("ugH2O");
		break;
	}

	return strRet;
}

//  ************************************************************************************
//  CF28Light::GetPressureUnitStr()
//  
//  Purpose: Get pressure unit string
//  
//  Parameters:
//		[ucUnit] : unit code
//  
//  Returns:	LPCTSTR
//  
//		
//  ************************************************************************************
LPCTSTR CF28Light::GetPressureUnitStr(BYTE ucUnit)
{
	LPCTSTR strRet = _T("????");

	switch (ucUnit)
	{
	case PRESS_PA:
		strRet = _T("Pa");
		break;
	case PRESS_MPA:
		strRet = _T("MPa");
		break;
	case PRESS_KPA:
		strRet = _T("KPa");
		break;
	case PRESS_mBAR:
		strRet = _T("mBar");
		break;
	case PRESS_BAR:
		strRet = _T("Bar");
		break;
	case PRESS_PSI:
		strRet = _T("PSI");
		break;
	case PRESS_POINTS:
		strRet = _T("Pts");
		break;
	}

	return strRet;
}

// **************************************************************************************
// CF28Light::GetVolumeUnitStr()
// 
// Purpose       : Gat volum unit string
// 
// Parameters    : 
//         [ucUnit] : unit code
// 
// Return        : LPCTSTR
// 
// **************************************************************************************

LPCTSTR CF28Light::GetVolumeUnitStr(BYTE ucUnit)
{
	LPCTSTR strRet = _T("????");

	switch (ucUnit)
	{
	case VOLUME_CM3:
		strRet = _T("cm3");
		break;
	case VOLUME_MM3:
		strRet = _T("mm3");
		break;
	case VOLUME_ML:
		strRet = _T("ml");
		break;
	case VOLUME_LITRE:
		strRet = _T("l");
		break;
	case VOLUME_INCH3:
		strRet = _T("inch3");
		break;
	case VOLUME_FT3:
		strRet = _T("ft3");
		break;
	}

	return strRet;
}

/* Result code

STATUS_GOOD_PART							PASS
STATUS_TEST_FAIL_PART						TEST FAIL
STATUS_REF_FAIL_PART						REF FAIL
STATUS_ALARM_EEEE							TEST OVER FULL SCALE : GROSS LEAK
STATUS_ALARM_MMMM							REF OVER FULL SCALE : GROSS LEAK
STATUS_ALARM_PPPP							PRESS.SIGNAL at VMax : PRESS.SENSOR DEFAULT
STATUS_ALARM_MPPP							PRESS.SIGNAL at Vmin : PRESS.SENSOR DEFAULT
STATUS_ALARM_OFFD_							FUITE DIFF AZ DEFAULT : DIFF SENSOR DEFAULT
STATUS_ALARM_OFFD_PRESSION					PRESS AZ DEFAULT : PRESS SENSOR DEFAULT
STATUS_ALARM_PST							PRESSURE TOO HIGH
STATUS_ALARM_MPST							PRESSURE TOO LOW
STATUS_ALARM_CS_VOLUME_PETIT				SEALED VOLUME TOO LOW
STATUS_ALARM_CS_VOLUME_GRAND				FAIL SEALED VOLUME(TOO HIGH)
STATUS_ALARM_ERROR_PRESS_CALIBRATION		DEF PRESS CALIB
STATUS_ALARM_ERROR_LEAK_CALIBRATION			DEF DIFF CALIB
STATUS_ALARM_ERROR_LINE_PRESS_CALIBRATION	DEF LINE CALIB
STATUS_ALARM_OFFD_PRESS_PIEZO_2				P2 AZ DEFAULT : P2 SENSOR DEFAULT
STATUS_ALARM_PPPP_PIEZO_2					PRESS.SIGNAL at VMax : P2 SENSOR DEFAULT
STATUS_ALARM_MPPP_PIEZO_2					PRESS.SIGNAL at Vmin : P2 SENSOR DEFAULT
STATUS_ALARM_PST_PIEZO_2					P2 TOO HIGH
STATUS_ALARM_MPST_PIEZO_2					P2 TOO LOW

*/

//  ************************************************************************************
//  CF28Light::GetResultStr()
//  
//  Purpose:
//  
//  Parameters:
//		[ucRslt] :
//  
//  Returns:	LPCTSTR
//  
//		
//  ************************************************************************************
LPCTSTR CF28Light::GetResultStr(BYTE ucRslt)
{
	LPCTSTR strRet = _T("????");

	switch (ucRslt)
	{
	case STATUS_GOOD_PART:
		strRet = _T("PASS");
		break;

	case STATUS_TEST_FAIL_PART:
		strRet = _T("TEST FAIL");
		break;

	case STATUS_REF_FAIL_PART:
		strRet = _T("REF FAIL");
		break;
	case STATUS_ALARM_EEEE:
		strRet = _T("TEST OVER FULL SCALE : GROSS LEAK");
		break;

	case STATUS_ALARM_MMMM:
		strRet = _T("REF OVER FULL SCALE : GROSS LEAK");
		break;

	case STATUS_ALARM_PPPP:
		strRet = _T("PRESS.SIGNAL at VMax : PRESS.SENSOR DEFAULT");
		break;

	case STATUS_ALARM_MPPP:
		strRet = _T("PRESS.SIGNAL at Vmin : PRESS.SENSOR DEFAULT");
		break;
	
	case STATUS_ALARM_OFFD_LEAK:
		strRet = _T("OFFD LEAK");
		break;

	case STATUS_ALARM_OFFD_PRESSURE:
		strRet = _T("OFFD PRESS");
		break;

	case STATUS_ALARM_PST:
		strRet = _T("PRESSURE TOO HIGH");
		break;

	case STATUS_ALARM_MPST:
		strRet = _T("PRESSURE TOO LOW");
		break;

	case STATUS_ALARM_CS_VOLUME_LOW:
		strRet = _T("SEALED VOLUME TOO LOW");
		break;

	case STATUS_ALARM_CS_VOLUME_HIGH:
		strRet = _T("FAIL SEALED VOLUME(TOO HIGH)");
		break;

	case STATUS_ALARM_ERROR_PRESS_CALIBRATION:
		strRet = _T("DEF PRESS CALIB");
		break;

	case STATUS_ALARM_ERROR_LEAK_CALIBRATION:
		strRet = _T("DEF DIFF CALIB");
		break;
	case STATUS_ALARM_ERROR_LINE_PRESS_CALIBRATION:
		strRet = _T("ERR CAL P LINE");
		break;
// V2.0.0.4
	case STATUS_ALARM_APPR_REG_ELEC_ERROR:
		strRet = _T("ELECTRONIC REG LEARNING FAIL");
		break;
	case STATUS_ALARM_TEST_PART_LARGE_LEAK:
		strRet = _T("TEST PART LARGE LEAK ALARM");
		break;
	case STATUS_ALARM_REF_SIDE_LARGE_LEAK:
		strRet = _T("REFERENCE SIDE LARGE LEAK ALARM");
		break;
	case STATUS_ALARM_P_TOO_LARGE_FILL:
		strRet = _T("PRESSURE TOO HIGH FILL TIME");
		break;
	case STATUS_ALARM_P_TOO_LOW_FILL:
		strRet = _T("PRESSURE TOO LOW FILL TIME");
		break;
	case STATUS_ALARM_JET_CHECK_FAIL:
		strRet = _T("JET CHECK FAIL");
		break;
	case STATUS_ALARM_JET_CHECK_PASS:
		strRet = _T("JET CHECK PASS");
		break;
// V2.0.0.4

	}

	return strRet;
}



//  ************************************************************************************
//  CF28Light::Edit()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	int
//  
//		
//  ************************************************************************************
int	CF28Light::Edit(BOOL bRead)
{
	int nRet = F28_FAIL;

	if (bRead)
	{
		ReadFile();
	}
	
	CDlgPar dlg;
	dlg.SetPara(this, &m_Para);

	if (dlg.DoModal() == IDOK)
	{
		WriteFile();

		nRet = F28_OK;
	}

	return nRet;
}

