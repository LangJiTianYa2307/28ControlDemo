#ifndef _X28_H_
#define _X28_H_

#if defined(__cplusplus)
extern "C" {
#endif
#define	X28API  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	#define	X28_FAIL				-1
	#define	X28_OK					 0

	#define X28_MAX_LENGTH_SERIALNUMBER		20

	#define X28_MODE_BOOT					1
	#define X28_MODE_APPLICATION			2

	#define X28_OFFLINE						0
	#define X28_CONNECTED					1

	enum X28_GROUP_ENUM
	{
		X28_GROUP_1 = 1,
		X28_GROUP_2,
		X28_GROUP_3,
		X28_GROUP_4,
		X28_GROUP_5,
		X28_GROUP_6,
		X28_GROUP_7,
		X28_GROUP_8,
		X28_GROUP_9,
		X28_GROUP_10,
		X28_GROUP_11,
		X28_GROUP_12,
		X28_GROUP_13,
		X28_GROUP_14,
		X28_GROUP_15
	};

	enum X28_MODULE_ADDR_ENUM
	{
		X28_MODULE_ADDR_0,
		X28_MODULE_ADDR_1,
		X28_MODULE_ADDR_2,
		X28_MODULE_ADDR_3,
		X28_MODULE_ADDR_4,
		X28_MODULE_ADDR_5,
		X28_MODULE_ADDR_6,
		X28_MODULE_ADDR_7,
		X28_MODULE_ADDR_8,
		X28_MODULE_ADDR_9,
		X28_MODULE_ADDR_10,
		X28_MODULE_ADDR_11,
		X28_MODULE_ADDR_12,
		X28_MODULE_ADDR_13,
		X28_MODULE_ADDR_14,
		X28_MODULE_ADDR_15,
		X28_MAX_MODULES_BY_GROUP
	};

	//Sensor List (Uses for SensorID parameter)
	enum X28_SENSOR_ENUM
	{
		X28_ACAM_MESURE,			// Mesure capteur capacitif ACAM 
		X28_KELLER_MESURE,			// Mesure voie capteur Keller (Delta sigma)
		X28_PANASONIC_MESURE,		// Mesure voie capteur PANASONIC (Pression de test)
		X28_P_LIGNE_MESURE,			// Pression de ligne
		X28_PATM_MESURE,			// Pression atmosphérique
		X28_TEMP_INTERNE_MESURE,    // Température interne (composant de la PATM)
		X28_TEMP_DEPORTE_MESURE,    // Température déportée (I2C)
		X28_EXTERNE1_MESURE,		// Voie externe 1
		X28_EXTERNE2_MESURE,		// Voie externe 2
		X28_MAX_VOIE_MESURE
	};

	enum X28_TYPE_TEST			// Uses with "wTypeTest" parameter
	{
		X28_UNDEFINED_TEST,
		X28_LEAK_TEST,
		X28_SEALED_COMPONENT_TEST,
		X28_MODE_D,
		X28_FLOW_TEST,

		X28_NB_TYPE_TEST
	};

	//----------------------------------------
	// Results status code
	//----------------------------------------
	enum X28_RESULT_STATUS_CODE
	{
		X28_STATUS_GOOD_PART,
		X28_STATUS_TEST_FAIL_PART,
		X28_STATUS_REF_FAIL_PART,
		X28_STATUS_ALARM_EEEE,
		X28_STATUS_ALARM_MMMM,
		X28_STATUS_ALARM_PPPP,
		X28_STATUS_ALARM_MPPP,
		X28_STATUS_ALARM_OFFD_LEAK,
		X28_STATUS_ALARM_OFFD_PRESSURE,
		X28_STATUS_ALARM_PST,
		X28_STATUS_ALARM_MPST,
		X28_STATUS_ALARM_CS_VOLUME_LOW,
		X28_STATUS_ALARM_CS_VOLUME_HIGH,
		X28_STATUS_ALARM_ERROR_PRESS_CALIBRATION,
		X28_STATUS_ALARM_ERROR_LEAK_CALIBRATION,
		X28_STATUS_ALARM_ERROR_LINE_PRESS_CALIBRATION,
		X28_STATUS_ALARM_APPR_REG_ELEC_ERROR,
		X28_STATUS_ALARM_TEST_PART_LARGE_LEAK,
		X28_STATUS_ALARM_REF_SIDE_LARGE_LEAK,
		X28_STATUS_ALARM_P_TOO_LARGE_FILL,
		X28_STATUS_ALARM_P_TOO_LOW_FILL,
		X28_STATUS_ALARM_JET_CHECK_FAIL,
		X28_STATUS_ALARM_JET_CHECK_PASS,
		X28_STATUS_ALARM_INCOMPATIBLE_DEVICE,

		X28_NMAX_STATUS_CODE
	};

#pragma pack(push, 1  )

	typedef struct X28_DATE
	{
		WORD wYear;
		WORD wMonth;
		WORD wDay;
		WORD wHour;
		WORD wMinute;
		WORD wSecond;
	} X28_DATE;

	typedef struct X28_REGLAGE
	{
		long lOffset;
		float fCoeffA;
		float fCoeffB;
		X28_DATE date;
		LPSTR lpOperator;
	} X28_REGLAGE;

	typedef struct X28_RESULT
	{
		UCHAR ucStatus;
		float fPressureValue;
		float fLeakValue;
		UCHAR ucUnitPressure;
		UCHAR ucUnitLeak;
		BYTE ucGroupID;
		BYTE ucModuleAddr;
		X28_DATE dateReceived;
	} X28_RESULT;

	typedef struct X28_REALTIME_CYCLE
	{
		UCHAR ucEndCycle;
		UCHAR ucStatus;
		float fPressureValue;
		float fLeakValue;
		UCHAR ucUnitPressure;
		UCHAR ucUnitLeak;
		float fInternalTemperature;
		float fPatm;
	} X28_REALTIME_CYCLE;

	typedef struct X28_CYCLE_STATISTICS
	{
		DWORD dwTotalCycles;
		DWORD dwFailCycles;
		DWORD dwSuccessCycles;
	} X28_CYCLE_STATISTICS;

	typedef struct X28_COMMUNICATION_STATISTICS
	{
		DWORD dwTransmited;
		DWORD dwReceived;
		DWORD dwErrors;
	} X28_COMMUNICATION_STATISTICS;

	typedef struct X28_VOLUME_LEARNING_TEST
	{
		WORD	wTempsRempTestVolumeLearn;
		WORD	wTempsTransfertTestVolumeLearn;
		float	fVolumePressCC;
		float	fVolumeMin;
		float	fVolumeMax;
	} X28_VOLUME_LEARNING_TEST;

#pragma pack(pop)

	/////////////////////////////////////////////////////////////////////
	//
	//		EXPORT FUNCTIONS
	//
	/////////////////////////////////////////////////////////////////////
	unsigned short 	X28API	X28_GetDllMajorVersion(void);
	unsigned short	X28API	X28_GetDllMinorVersion(void);

	//-------------------------------------------------
	//Connection
	//-------------------------------------------------
	short	X28API X28_Init(void);
	short	X28API X28_OpenChannel();
	void	X28API X28_Close(void);

	//-------------------------------------------------
	// Create/Search F28 modules 
	//-------------------------------------------------
	short	X28API X28_ReconnectModule(short sModuleID);
	short	X28API X28_RemoveModule(short sModuleID);
	short	X28API X28_RemoveAllModules(void);
	short 	X28API X28_ResetEthernetModule(short sModuleID);
	short 	X28API X28_IsModuleConnected(short sModuleID);

	//-------------------------------------------------
	// F28 Informations
	//-------------------------------------------------
	short	X28API X28_RefreshModuleInformations(short sModuleID);
	short	X28API X28_GetSerialNumber(short sModuleID, LPSTR szSerialNumber, unsigned short wLength);
	short	X28API X28_GetModuleSoftVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
	short	X28API X28_GetModuleHardVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
	short	X28API X28_GetModuleBootVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
	short	X28API X28_GetModuleCANAddress(short sModuleID);
	short	X28API X28_GetAddressIP(short sModuleID, ULONG* pAddressIP);
	short	X28API X28_GetETHSoftVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
	short	X28API X28_GetETHHardVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
	short	X28API X28_GetSubnetMask(short sModuleID, ULONG* pAddressIP);
	short	X28API X28_GetGatewayAddressIP(short sModuleID, ULONG* pAddressIP);
	short	X28API X28_GetMACAddress(short sModuleID, LPSTR szMAC, unsigned short wLength);

	//-------------------------------------------------
	// F28 Control
	//-------------------------------------------------
	short 	X28API X28_JumpApplicationMode(short sModuleID);
	short 	X28API X28_JumpBootMode(short sModuleID);
	short 	X28API X28_GetMode(short sModuleID);
	short	X28API X28_GetReglageSensor(short sModuleID, unsigned short wSensorID, X28_REGLAGE* pReglage);

	//-------------------------------------------------
	// Real Time cycle 
	//-------------------------------------------------
	short 	X28API X28_StartCycle(short sModuleID);
	short 	X28API X28_StopCycle(short sModuleID);
	short 	X28API X28_GetRealTimeData(short sModuleID, X28_REALTIME_CYCLE* pCycle);

	//-------------------------------------------------
	// Gestion Group
	//-------------------------------------------------
	short 	X28API X28_StartCycleByGroup(BYTE ucGroupID);
	short 	X28API X28_StopCycleByGroup(BYTE ucGroupID);

	//-------------------------------------------------
	// Results - FIFO
	//-------------------------------------------------
	short 	X28API X28_GetLastResult(short sModuleID, X28_RESULT* pResult);
	short	X28API X28_ClearFIFOResults(short sModuleID);
	WORD	X28API X28_GetResultsCount(short sModuleID);
	short 	X28API X28_GetNextResult(short sModuleID, X28_RESULT* pResult);

	//-------------------------------------------------
	// Special cycle
	//-------------------------------------------------
	short 	X28API X28_StartAutoZeroPressure(short sModuleID, float fDumpTime);
	short 	X28API X28_StartLearningRegulator(short sModuleID, float fDumpTime);
	short 	X28API X28_StartRegulatorAdjust(short sModuleID);
	short 	X28API X28_StartJetCheck(short sModuleID);
	short 	X28API X28_StartVolumeLearning(short sModuleID, X28_VOLUME_LEARNING_TEST* pPara, BOOL bTest);
	short 	X28API X28_StartVidageInfini(short sModuleID);

	//-------------------------------------------------
	// Statistics/Counters
	//-------------------------------------------------
	short 	X28API X28_GetCycleStatistics(short sModuleID, X28_CYCLE_STATISTICS* pInfo);
	short 	X28API X28_GetCommunicationStatistics(short sModuleID, X28_COMMUNICATION_STATISTICS* pInfo);

	//-------------------------------------------------
	// Auto-Cal V1.304
	//-------------------------------------------------
	UCHAR	X28API X28_GetEOCOffset(short sModuleID);
	UCHAR	X28API X28_GetEOCVolume(short sModuleID);
	UCHAR	X28API X28_GetEOCRatio(short sModuleID);
	UCHAR	X28API X28_GetEOCEasyAutoLearning(short sModuleID);
	UCHAR	X28API X28_GetAutoCalAlarm(short sModuleID);
	short 	X28API X28_StartAutoCalOffsetOnly(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fOffsetMax);
	short 	X28API X28_StartAutoCalOffset(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fOffsetMax);
	short 	X28API X28_StartAutoCalVolume(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fLeak, float fPressure, float fVolMin, float fVolMax);
	short 	X28API X28_StopAutoCal(short sModuleID);
	short 	X28API X28_StartAutoRatio(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fRatioMax, float fRatioMin);
	short 	X28API X28_StopAutoRatio(short sModuleID);
	short 	X28API X28_StartEasyAutoLearning(short sModuleID, WORD wNbCycles, WORD wInterCycleTime);
	short 	X28API X28_StopEasyAutoLearning(short sModuleID);

#ifdef __cplusplus
}
#endif

#endif