#ifndef _F28LIGHTCONTROL_H_
#define _F28LIGHTCONTROL_H_

#include "X28.h"

#if defined(__cplusplus)
extern "C" {
#endif

	#define	F28API  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	#define	F28_FAIL				X28_FAIL
	#define	F28_OK					X28_OK

	enum F28_GROUP_ENUM					// Obsolete -> Use X28_GROUP_ENUM
	{
		F28_GROUP_1 = 1,
		F28_GROUP_2,
		F28_GROUP_3,
		F28_GROUP_4,
		F28_GROUP_5,
		F28_GROUP_6,
		F28_GROUP_7,
		F28_GROUP_8,
		F28_GROUP_9,
		F28_GROUP_10,
		F28_GROUP_11,
		F28_GROUP_12,
		F28_GROUP_13,
		F28_GROUP_14,
		F28_GROUP_15
	};

	enum F28_MODULE_ADDR_ENUM			// Obsolete -> Use X28_MODULE_ADDR_ENUM
	{
		F28_MODULE_ADDR_0,
		F28_MODULE_ADDR_1,
		F28_MODULE_ADDR_2,
		F28_MODULE_ADDR_3,
		F28_MODULE_ADDR_4,
		F28_MODULE_ADDR_5,
		F28_MODULE_ADDR_6,
		F28_MODULE_ADDR_7,
		F28_MODULE_ADDR_8,
		F28_MODULE_ADDR_9,
		F28_MODULE_ADDR_10,
		F28_MODULE_ADDR_11,
		F28_MODULE_ADDR_12,
		F28_MODULE_ADDR_13,
		F28_MODULE_ADDR_14,
		F28_MODULE_ADDR_15,
		F28_MAX_MODULES_BY_GROUP
	};

	#define F28_MAX_LENGTH_SERIALNUMBER		X28_MAX_LENGTH_SERIALNUMBER

	#define F28_MODE_BOOT					X28_MODE_BOOT
	#define F28_MODE_APPLICATION			X28_MODE_APPLICATION

	#define F28_OFFLINE						X28_OFFLINE
	#define F28_CONNECTED					X28_CONNECTED

	//----------------------------------------
	// Results status code
	//----------------------------------------
	enum F28_RESULT_STATUS_CODE				// Obsolete, use X28_RESULT_STATUS_CODE
	{
		STATUS_GOOD_PART,
		STATUS_TEST_FAIL_PART,
		STATUS_REF_FAIL_PART,
		STATUS_ALARM_EEEE,
		STATUS_ALARM_MMMM,
		STATUS_ALARM_PPPP,
		STATUS_ALARM_MPPP,
		STATUS_ALARM_OFFD_LEAK,
		STATUS_ALARM_OFFD_PRESSURE,
		STATUS_ALARM_PST,
		STATUS_ALARM_MPST,
		STATUS_ALARM_CS_VOLUME_LOW,
		STATUS_ALARM_CS_VOLUME_HIGH,
		STATUS_ALARM_ERROR_PRESS_CALIBRATION,
		STATUS_ALARM_ERROR_LEAK_CALIBRATION,
		STATUS_ALARM_ERROR_LINE_PRESS_CALIBRATION,
		STATUS_ALARM_APPR_REG_ELEC_ERROR,
		STATUS_ALARM_TEST_PART_LARGE_LEAK,
		STATUS_ALARM_REF_SIDE_LARGE_LEAK,
		STATUS_ALARM_P_TOO_LARGE_FILL,
		STATUS_ALARM_P_TOO_LOW_FILL,
		STATUS_ALARM_JET_CHECK_FAIL,
		STATUS_ALARM_JET_CHECK_PASS,
		NMAX_STATUS_CODE
	};

	//----------------------------------------
	// Parameters definition
	//----------------------------------------
	enum F28_TYPE_TEST			// Uses with "wTypeTest" parameter
	{
		UNDEFINED_TEST,
		LEAK_TEST,
		SEALED_COMPONENT_TEST,
		MODE_D
	};

	enum F28_PRESS_UNITS
	{
		PRESS_PA,
		PRESS_KPA,
		PRESS_MPA,
		PRESS_BAR,
		PRESS_mBAR,
		PRESS_PSI,
		PRESS_POINTS,
		NMAX_PRESS_UNITS
	};

	enum F28_LEAK_UNITS		// Uses with "wLeakUnit" parameter
	{
		LEAK_PA,
		LEAK_PASEC,
		LEAK_PA_HR,
		LEAK_PASEC_HR,

		LEAK_CAL_PA,
		LEAK_CAL_PASEC,

		LEAK_CCMIN,
		LEAK_CCSEC,
		LEAK_CCH,
		LEAK_MM3SEC,
		LEAK_CM3_SEC,
		LEAK_CM3_MIN,
		LEAK_CM3_H,

		LEAK_ML_SEC,
		LEAK_ML_MIN,
		LEAK_ML_H,
		//USA------------------
		LEAK_INCH3_SEC,
		LEAK_INCH3_MIN,
		LEAK_INCH3_H,
		LEAK_FT3_SEC,
		LEAK_FT3_MIN,
		LEAK_FT3_H,
		LEAK_MMCE,
		LEAK_MMCE_SEC,
		LEAK_SCCM,
		LEAK_POINTS,
		//V1.500
		LEAK_KPA,
		LEAK_MPA,
		LEAK_BAR,
		LEAK_mBAR,
		LEAK_PSI,
		LEAK_L_MIN,
		LEAK_CM_H2O,
		LEAK_UG_H2O,

		NMAX_LEAK_UNITS,

		LEAK_JET_CHECK	= 0xff		// F28 check jet unit
	};

	enum F28_ENUM_VOLUME_UNIT	// Uses with "wVolumeUnit" parameter
	{
		VOLUME_CM3,
		VOLUME_MM3,
		VOLUME_ML,
		VOLUME_LITRE,
		VOLUME_INCH3,
		VOLUME_FT3,
		NMAX_VOLUME_UNITS
	};

	enum F28_ENUM_FILL_MODE		// Uses with "wFillMode" parameter
	{
		STD_FILL_MODE,
		AUTOFILL_MODE,
		// V1.400
		INSTRUCTION,
		// V1.400
		// V1.500
		RAMP,
		// V1.500
		RAMP_CONTROL,
		NMAX_FILL_MODE
	};

	enum F28_ENUM_STEP_CODE
	{
		NO_STEP,
		FILL_STEP,
		STAB_STEP,
		TEST_STEP,
		DUMP_STEP,
		FILL_VOLUME_STEP,
		TRANSFERT_STEP,
	};

	//Uses with "wOptions" parameter
	#define F28_SIGNE_OPTION					1
	#define F28_NO_NEGATIVE_VALUE_OPTION		2
	//#define F28_MODE_INDIRECT_OPTION			3
	//#define F28_AUTOZERO_PIEZO2_OPTION		4
	#define F28_TEST_PRESSURE_COMP				5
	#define F28_ELECTRONIC_REGULATOR			6

	//Sensor List (Uses for SensorID parameter)
	enum F28_SENSOR_ENUM
	{
		ACAM_MESURE,			// Mesure capteur capacitif ACAM 
		KELLER_MESURE,			// Mesure voie capteur Keller (Delta sigma)
		PANASONIC_MESURE,		// Mesure voie capteur PANASONIC (Pression de test)
		P_LIGNE_MESURE,			// Pression de ligne
		PATM_MESURE,			// Pression atmosphérique
		TEMP_INTERNE_MESURE,    // Température interne (composant de la PATM)
		TEMP_DEPORTE_MESURE,    // Température déportée (I2C)
		EXTERNE1_MESURE,		// Voie externe 1
		EXTERNE2_MESURE,		// Voie externe 2
		MAX_VOIE_MESURE
	};

	/////////////////////////////////////////////////////////////////////
	//
	//	Definition 
	//
	/////////////////////////////////////////////////////////////////////

	#pragma pack(push, 1 )  // uses for visual basic

	typedef struct F28_PARAMETERS
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
		/*		//V1.500
		WORD	wIndirectFillMode;	//STD_FILL_MODE / AUTOFILL_MODE
		WORD	wTpsPartFill;
		WORD	wIndirectUnitePression;
		float	fIndirectPressMin;
		float	fIndirectPressMax;
		float	fIndirectSetFill;	//consigne mode indirect
	*/
	} F28_PARAMETERS;

	#define F28_DATE						X28_DATE
	#define F28_REGLAGE						X28_REGLAGE
	#define F28_RESULT						X28_RESULT
	#define F28_REALTIME_CYCLE				X28_REALTIME_CYCLE
	#define F28_CYCLE_STATISTICS			X28_CYCLE_STATISTICS
	#define F28_COMMUNICATION_STATISTICS	X28_COMMUNICATION_STATISTICS

	#pragma pack(pop)

	/////////////////////////////////////////////////////////////////////
	//
	//		EXPORT FUNCTIONS
	//
	/////////////////////////////////////////////////////////////////////
	unsigned short 	F28API	F28_GetDllMajorVersion(void);			// Obsolete -> use X28_GetDllMajorVersion
	unsigned short	F28API	F28_GetDllMinorVersion(void);			// Obsolete -> use X28_GetDllMinorVersion

	//-------------------------------------------------
	//Connection
	//-------------------------------------------------
	short	F28API F28_Init(void);									// Obsolete -> use X28_Init
	short	F28API F28_OpenChannel();								// Obsolete -> use X28_OpenChannel
	void	F28API F28_Close(void);									// Obsolete -> use X28_Close

	//-------------------------------------------------
	// Create/Search F28 modules 
	//-------------------------------------------------
	short	F28API  F28_AddModule(ULONG ulIP, BYTE ucModuleAddr, BYTE ucGroupID, BYTE ucTimeout);
	short 	F28API	F28_ReconnectModule(short sModuleID);											// Obsolete -> use X28_ version
	short 	F28API	F28_RemoveModule(short sModuleID);												// Obsolete -> use X28_ version
	short 	F28API	F28_RemoveAllModules(void);														// Obsolete -> use X28_ version
	short 	F28API	F28_ResetEthernetModule(short sModuleID);										// Obsolete -> use X28_ version
	short 	F28API	F28_IsModuleConnected(short sModuleID);											// Obsolete -> use X28_ version

	//-------------------------------------------------
	// F28 Informations
	//-------------------------------------------------
	short	F28API	F28_RefreshModuleInformations(short sModuleID);													// Obsolete -> use X28_ version
	short	F28API	F28_GetSerialNumber(short sModuleID, LPSTR szSerialNumber, unsigned short wLength);				// Obsolete -> use X28_ version
	short	F28API	F28_GetModuleSoftVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);				// Obsolete -> use X28_ version
	short	F28API	F28_GetModuleHardVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);				// Obsolete -> use X28_ version
	short	F28API	F28_GetModuleBootVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);				// Obsolete -> use X28_ version
	short	F28API	F28_GetModuleCANAddress(short sModuleID);														// Obsolete -> use X28_ version
	short	F28API	F28_GetAddressIP(short sModuleID, ULONG* pAddressIP);											// Obsolete -> use X28_ version
	short	F28API	F28_GetETHSoftVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);				// Obsolete -> use X28_ version
	short	F28API	F28_GetETHHardVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);				// Obsolete -> use X28_ version
	short	F28API	F28_GetSubnetMask(short sModuleID, ULONG* pAddressIP);											// Obsolete -> use X28_ version
	short	F28API	F28_GetGatewayAddressIP(short sModuleID, ULONG* pAddressIP);									// Obsolete -> use X28_ version
	short	F28API	F28_GetMACAddress(short sModuleID, LPSTR szMAC, unsigned short wLength);						// Obsolete -> use X28_ version

	//-------------------------------------------------
	// F28 Control
	//-------------------------------------------------
	short 	F28API	F28_JumpApplicationMode(short sModuleID);													// Obsolete -> use X28_ version
	short 	F28API	F28_JumpBootMode(short sModuleID);															// Obsolete -> use X28_ version
	short 	F28API	F28_GetMode(short sModuleID);																// Obsolete -> use X28_ version
	short	F28API	F28_GetReglageSensor(short sModuleID, unsigned short wSensorID, F28_REGLAGE* pReglage);		// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Edit programs/Parameters
	//-------------------------------------------------
	short 	F28API	F28_GetModuleParameters(short sModuleID, F28_PARAMETERS* pPara);
	short 	F28API	F28_SetModuleParameters(short sModuleID, F28_PARAMETERS* pPara);

	//-------------------------------------------------
	// Real Time cycle 
	//-------------------------------------------------
	short 	F28API	F28_StartCycle(short sModuleID);										// Obsolete -> use X28_ version
	short 	F28API	F28_StopCycle(short sModuleID);											// Obsolete -> use X28_ version
	short 	F28API	F28_GetRealTimeData(short sModuleID, F28_REALTIME_CYCLE* pCycle);		// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Gestion Group
	//-------------------------------------------------
	short 	F28API	F28_StartCycleByGroup(BYTE ucGroupID);					// Obsolete -> use X28_ version
	short 	F28API	F28_StopCycleByGroup(BYTE ucGroupID);					// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Results - FIFO
	//-------------------------------------------------
	short 	F28API	F28_ClearFIFOResults(short sModuleID);									// Obsolete -> use X28_ version
	WORD	F28API	F28_GetResultsCount(short sModuleID);									// Obsolete -> use X28_ version
	short 	F28API	F28_GetNextResult(short sModuleID, F28_RESULT* pResult);				// Obsolete -> use X28_ version
	short 	F28API	F28_GetLastResult(short sModuleID, F28_RESULT* pResult);				// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Special cycle
	//-------------------------------------------------
	short 	F28API	F28_StartAutoZeroPressure(short sModuleID, float fDumpTime);				// Obsolete -> use X28_ version
	short 	F28API	F28_StartRegulatorAdjust(short sModuleID);									// Obsolete -> use X28_ version
	short 	F28API	F28_StartLearningRegulator(short sModuleID, float fDumpTime);				// Obsolete -> use X28_ version
	short 	F28API	F28_StartJetCheck(short sModuleID);											// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Statistics/Counters
	//-------------------------------------------------
	short 	F28API	F28_GetCycleStatistics(short sModuleID, F28_CYCLE_STATISTICS* pInfo);						// Obsolete -> use X28_ version
	short 	F28API	F28_GetCommunicationStatistics(short sModuleID, F28_COMMUNICATION_STATISTICS* pInfo);		// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Auto-Cal V1.304
	//-------------------------------------------------
	UCHAR	F28API	F28_GetEOCOffset(short sModuleID);																											// Obsolete -> use X28_ version
	UCHAR	F28API	F28_GetEOCVolume(short sModuleID);																											// Obsolete -> use X28_ version
	UCHAR	F28API	F28_GetEOCRatio(short sModuleID);																											// Obsolete -> use X28_ version
	UCHAR	F28API	F28_GetEOCEasyAutoLearning(short sModuleID);																								// Obsolete -> use X28_ version
	UCHAR	F28API	F28_GetAutoCalAlarm(short sModuleID);																										// Obsolete -> use X28_ version
	short 	F28API	F28_StartAutoCalOffsetOnly(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fOffsetMax);										// Obsolete -> use X28_ version
	short 	F28API	F28_StartAutoCalOffset(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fOffsetMax);											// Obsolete -> use X28_ version
	short 	F28API	F28_StartAutoCalVolume(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fLeak, float fPressure, float fVolMin, float fVolMax);	// Obsolete -> use X28_ version
	short 	F28API	F28_StopAutoCal(short sModuleID);																											// Obsolete -> use X28_ version
	short 	F28API	F28_StartAutoRatio(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fRatioMax, float fRatioMin);								// Obsolete -> use X28_ version
	short 	F28API	F28_StopAutoRatio(short sModuleID);																											// Obsolete -> use X28_ version
	short 	F28API	F28_StartEasyAutoLearning(short sModuleID, WORD wNbCycles, WORD wInterCycleTime);															// Obsolete -> use X28_ version
	short 	F28API	F28_StopEasyAutoLearning(short sModuleID);																									// Obsolete -> use X28_ version

#ifdef __cplusplus
}
#endif

#endif