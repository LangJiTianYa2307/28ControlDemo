#ifndef _FC28LCONTROL_H_
#define _FC28LCONTROL_H_

#include "X28.h"

#if defined(__cplusplus)
extern "C" {
#endif

	#define	FC28LAPI  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	//----------------------------------------
	// Results status code
	//----------------------------------------
	enum FC28L_RESULT_STATUS_CODE
	{
		FC28L_STATUS_GOOD_PART,
		FC28L_STATUS_TEST_FAIL_PART,
		FC28L_STATUS_REF_FAIL_PART,
		FC28L_STATUS_ALARM_EEEE,
		FC28L_STATUS_ALARM_MMMM,
		FC28L_STATUS_ALARM_PPPP,
		FC28L_STATUS_ALARM_MPPP,
		FC28L_STATUS_ALARM_OFFD_LEAK,
		FC28L_STATUS_ALARM_OFFD_PRESSURE,
		FC28L_STATUS_ALARM_PST,
		FC28L_STATUS_ALARM_MPST,
		FC28L_STATUS_ALARM_CS_VOLUME_LOW,
		FC28L_STATUS_ALARM_CS_VOLUME_HIGH,
		FC28L_STATUS_ALARM_ERROR_PRESS_CALIBRATION,
		FC28L_STATUS_ALARM_ERROR_LEAK_CALIBRATION,
		FC28L_STATUS_ALARM_ERROR_LINE_PRESS_CALIBRATION,
		FC28L_STATUS_ALARM_APPR_REG_ELEC_ERROR,
		FC28L_STATUS_ALARM_TEST_PART_LARGE_LEAK,
		FC28L_STATUS_ALARM_REF_SIDE_LARGE_LEAK,
		FC28L_STATUS_ALARM_P_TOO_LARGE_FILL,
		FC28L_STATUS_ALARM_P_TOO_LOW_FILL,
		FC28L_STATUS_ALARM_JET_CHECK_FAIL,
		FC28L_STATUS_ALARM_JET_CHECK_PASS,
		FC28L_NMAX_STATUS_CODE
	};

	//----------------------------------------
	// Parameters definition
	//----------------------------------------
	enum FC28L_TYPE_TEST			// Uses with "wTypeTest" parameter
	{
		FC28L_UNDEFINED_TEST,
		FC28L_LEAK_TEST,
		FC28L_SEALED_COMPONENT_TEST,
		FC28L_MODE_D,
		FC28L_TEST_FLOW
	};

	enum FC28L__PRESS_UNITS
	{
		FC28L_PRESS_PA,
		FC28L_PRESS_KPA,
		FC28L_PRESS_MPA,
		FC28L_PRESS_BAR,
		FC28L_PRESS_mBAR,
		FC28L_PRESS_PSI,
		FC28L_PRESS_POINTS,
		FC28L_NMAX_PRESS_UNITS
	};

	enum FC28L_LEAK_UNITS		// Uses with "wLeakUnit" parameter
	{
		FC28L_LEAK_PA,
		FC28L_LEAK_PASEC,
		FC28L_LEAK_PA_HR,
		FC28L_LEAK_PASEC_HR,

		FC28L_LEAK_CAL_PA,
		FC28L_LEAK_CAL_PASEC,

		FC28L_LEAK_CCMIN,
		FC28L_LEAK_CCSEC,
		FC28L_LEAK_CCH,
		FC28L_LEAK_MM3SEC,
		FC28L_LEAK_CM3_SEC,
		FC28L_LEAK_CM3_MIN,
		FC28L_LEAK_CM3_H,

		FC28L_LEAK_ML_SEC,
		FC28L_LEAK_ML_MIN,
		FC28L_LEAK_ML_H,
		//USA------------------
		FC28L_LEAK_INCH3_SEC,
		FC28L_LEAK_INCH3_MIN,
		FC28L_LEAK_INCH3_H,
		FC28L_LEAK_FT3_SEC,
		FC28L_LEAK_FT3_MIN,
		FC28L_LEAK_FT3_H,
		FC28L_LEAK_MMCE,
		FC28L_LEAK_MMCE_SEC,
		FC28L_LEAK_SCCM,
		FC28L_LEAK_POINTS,
		//V1.500
		FC28L_LEAK_KPA,
		FC28L_LEAK_MPA,
		FC28L_LEAK_BAR,
		FC28L_LEAK_mBAR,
		FC28L_LEAK_PSI,
		FC28L_LEAK_L_MIN,
		FC28L_LEAK_CM_H2O,
		FC28L_LEAK_UG_H2O,

		FC28L_NMAX_LEAK_UNITS,

		FC28L_LEAK_JET_CHECK = 0xff		// F28 check jet unit
	};

	enum FC28L_ENUM_VOLUME_UNIT	// Uses with "wVolumeUnit" parameter
	{
		FC28L_VOLUME_CM3,
		FC28L_VOLUME_MM3,
		FC28L_VOLUME_ML,
		FC28L_VOLUME_LITRE,
		FC28L_VOLUME_INCH3,
		FC28L_VOLUME_FT3,
		FC28L_NMAX_VOLUME_UNITS
	};

	enum FC28L_ENUM_FILL_MODE		// Uses with "wFillMode" parameter
	{
		FC28L_STD_FILL_MODE,
		FC28L_AUTOFILL_MODE,
		FC28L_INSTRUCTION,
		FC28L_RAMP,
		FC28L_RAMP_CONTROL,
		FC28L_NMAX_FILL_MODE
	};

	enum FC28L_ENUM_STEP_CODE
	{
		FC28L_NO_STEP,
		FC28L_FILL_STEP,
		FC28L_STAB_STEP,
		FC28L_TEST_STEP,
		FC28L_DUMP_STEP
	};

	//Uses with "wOptions" parameter
	#define FC28L_SIGNE_OPTION					1
	#define FC28L_NO_NEGATIVE_VALUE_OPTION		2
	#define FC28L_TEST_PRESSURE_COMP			5
	#define FC28L_ELECTRONIC_REGULATOR			6
	#define FC28L_TEMPERATURE_COMP				8

	/////////////////////////////////////////////////////////////////////
	//
	//	Definition 
	//
	/////////////////////////////////////////////////////////////////////

	#pragma pack(push, 1 )  // uses for visual basic

	typedef struct FC28L_PARAMETERS
	{
		WORD	wTypeTest;		// STANDARD or LARGE LEAK (Sealed) or LARGE LEAK TEST (sealed + test)
		WORD	wTpsFillVol;
		WORD	wTpsTransfert;
		WORD	wTpsFill;
		WORD	wTpsStab;
		WORD	wTpsTest;
		WORD	wTpsDump;
		WORD	wPress1Unit;		// See F28_PRESS_UNITS
		float	fPress1Min;
		float	fPress1Max;
		float	fSetFillP1;			//consigne mode auto-fill
		float	fRatioMax;			//LARGE LEAK mode only
		float	fRatioMin;			//LARGE LEAK mode only
		WORD	wFillMode;			//STD_FILL_MODE / AUTOFILL_MODE
		WORD	wLeakUnit;			// See F28_LEAK_UNITS
		WORD	wRejectCalc;		// Pa or Pa/s
		WORD	wVolumeUnit;		// See F28_ENUM_VOLUME_UNIT 
		float	fVolume;
		float	fRejectMin;
		float	fRejectMax;
		float   fCoeffAutoFill;		//
		WORD	wOptions;			// SIGNE(NO/YES)
		//V1.200
		float	fPatmSTD;			//Patm  standard condition (hPa)
		float	fTempSTD;			//Temperature standard condition (en °C)
		float	fFilterTime;		//  en (s)
		//V1.300
		float	fOffsetLeak;		//Offset sur la fuite
		float	fVolumeRef;			//Nouveau parametre pour le C28
		WORD	wTpsTestCompTemp;
		WORD	wPourcCompTemp;
		WORD	wTpsWaitingTime;
		//F28_LIGHT_V104
		WORD	wLastConsigneDacEasy;
		float	fNominalValue;
		float	fCoeffMin;
		float	fCoeffMax;
	} FC28L_PARAMETERS;

	#pragma pack(pop)

	//-------------------------------------------------
	// Create/Search F28 modules 
	//-------------------------------------------------
	short	FC28LAPI	FC28L_AddModule(ULONG ulIP, BYTE ucModuleAddr, BYTE ucGroupID, BYTE ucTimeout);
	//-------------------------------------------------
	// Edit programs/Parameters
	//-------------------------------------------------
	short 	FC28LAPI	FC28L_GetModuleParameters(short sModuleID, FC28L_PARAMETERS* pPara);
	short 	FC28LAPI	FC28L_SetModuleParameters(short sModuleID, FC28L_PARAMETERS* pPara);

#ifdef __cplusplus
}
#endif

#endif