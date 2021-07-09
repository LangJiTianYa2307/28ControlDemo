#ifndef _X28_ADMIN_H_
#define _X28_ADMIN_H_

#if defined(__cplusplus)
extern "C" {
#endif
#define	X28API  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	#define X28_MAX_OPERATOR_LENGTH				12

	/////////////////////////////////////////////////////////////////////
	//
	//	Definition: ADMIN ONLY 
	//
	/////////////////////////////////////////////////////////////////////

	enum X28_DEVICE_TYPE
	{
		X28_F28,
		X28_F28L,
		X28_FC28L,			// :C28:FC28L
		X28_B28,

		X28_MAX_DEVICE_TYPE
	};

	enum X28_SENSORS_LIST
	{
		X28_SENSOR_DIFF,
		X28_SENSOR_PIEZO_1,
		X28_SENSOR_PIEZO_LINE,

		X28_NB_SENSORS
	};

	enum X28_REG_STEPS
	{
		X28_REG_NO_STEP,
		X28_REG_ZERO_CAPTEUR,
		X28_REG_75_DAC,
		X28_REG_75_VAL,
		X28_REG_TEST_POINT_75,
		X28_REG_25_DAC,
		X28_REG_25_VAL,
		X28_REG_VALID_REGLAGE,

		X28_REG_MAX_STEPS,
	};

	enum X28_COMMAND_REGLAGE
	{
		X28_NO_KEY_COMMAND,
		X28_K_ENTER_COMMAND,
		X28_K_ESCAPE_COMMAND,
		X28_K_STOP_COMMAND,

		X28_MAX_COMMAND
	};

	//Type d'appareils
	enum X28_TYPE_DEVICE
	{
		X28_NO_SERIES_DEVICE,
		X28_F_SERIES_DEVICE,
		X28_D_SERIES_DEVICE,
		X28_G_SERIES_DEVICE,
	};

	enum X28_VOIES_MEASURE
	{
		X28_VOIE_MEASURE_PCAP,			//Voie ACAM
		X28_VOIE_MEASURE_DELTA,			//Voie ltc 
		X28_VOIE_MEASURE_INT_CAPT1,		//Voie interne ADC 1
		X28_VOIE_MEASURE_INT_CAPT2,		//Voie interne ADC 2
		X28_VOIE_MEASURE_CAPT3_PATM,	//Voie lps 1
		X28_VOIE_MEASURE_CAPT3_TEMP,	//Voie lps 2
		X28_VOIE_MEASURE_EXT_I2C,		//Mcp9808
		X28_VOIE_MEASURE_EXT_ANA1,		//Voie externe ADC 3
		X28_VOIE_MEASURE_EXT_ANA2,		//Voie externe ADC 4
		X28_NMAX_VOIES_MEASURE
	};

	enum X28_SENSOR_TYPES
	{
		X28_TYPE_SENSOR_NONE,
		X28_TYPE_SENSOR_ACAM,
		X28_TYPE_SENSOR_DIRECT,
		X28_TYPE_SENSOR_INDIRECT,
		X28_TYPE_SENSOR_PLIGNE,
		X28_TYPE_SENSOR_PATM,
		X28_TYPE_SENSOR_TEMP_INT,
		X28_TYPE_SENSOR_TEMP_EXT,
		X28_TYPE_SENSOR_TEMP_AMBIENT,
		X28_TYPE_SENSOR_TEMP_PART,
		X28_NMAX_TYPES_SENSOR
	};

	enum X28_OUTPUTS_ANA
	{
		X28_OUTPUT_J12,
		X28_OUTPUT_J11,
		X28_OUTPUT_J8,
		X28_OUTPUT_J6,
		X28_NMAX_OUTPUTS_ANA
	};

	enum X28_OUTPUT_ANA_TYPES
	{
		X28_TYPE_OUTPUT_NONE,
		X28_TYPE_OUTPUT_REG1_DIRECT,
		X28_TYPE_OUTPUT_REG1_INDIRECT,
		X28_TYPE_OUTPUT_REG2_DIRECT,
		X28_TYPE_OUTPUT_REG2_INDIRECT,
		X28_TYPE_OUTPUT_PRESSURE_SIGNAL,
		X28_TYPE_OUTPUT_LEAK_SIGNAL,
		X28_NMAX_OUTPUT_ANA_TYPES
	};

	enum X28_OUTPUTS_VANNE
	{
		X28_OUTPUT_PREFILL,
		X28_OUTPUT_FILL,
		X28_OUTPUT_TEST,
		X28_OUTPUT_DUMP,
		X28_NMAX_OUTPUTS_VANNES
	};

	enum X28_INPUTS_TOR
	{
		X28_INPUT_INFO_V1,		//connecteur J1
		X28_INPUT_INFO_V2,		//connecteur J18 
		X28_INPUT_PST,			//connecteur J3
		X28_NMAX_INPUTS_TOR
	};

#pragma pack(push, 1  )

	typedef struct X28_VOIES_SENSOR_CFG
	{
		UCHAR ucSensorType;			// ACAM / DIRECT / INDIRECT / PLIGNE / PATM / TEMP INT / TEMP EXT
		UCHAR ucSensorOpt;			// SENSOR_OPT_ABS / SENSOR_OPT_USE_VACUUM / SENSOR_OPT_USE_PRESSURE
		float fFullScaleReel;
		float fFullScaleCommercial;
	} X28_VOIES_SENSOR_CFG;

	typedef struct X28_OUTPUTS_ANA_CFG
	{
		UCHAR ucTypeOutput;			// REG 1 DIRECT / REG 1 INDIRECT / REG 2 DIRECT / REG 2 INDIRECT / PRESSURE SIGNAL / LEAK SIGNAL
		UCHAR ucSpecificCfg;		// SENSOR_OPT_ABS
		float fFullScale;
	} X28_OUTPUTS_ANA_CFG;

	typedef struct X28_CONFIG_HARD_GENERIC_ITEMS
	{
		X28_VOIES_SENSOR_CFG	stCfgVoie[X28_NMAX_VOIES_MEASURE];
		X28_OUTPUTS_ANA_CFG		stANAOut[X28_NMAX_OUTPUTS_ANA];
		UCHAR					arFctVanne[X28_NMAX_OUTPUTS_VANNES];
		UCHAR					arFctInput[X28_NMAX_INPUTS_TOR];
		UCHAR					ucAlign;
		WORD					wCoeffTemp;
		WORD					wAutoFill;
	} X28_CONFIG_HARD_GENERIC_ITEMS;

	typedef struct X28_DATE_REGLAGE
	{
		UCHAR ucDay;
		UCHAR ucMonth;
		WORD wYear;
	} X28_DATE_REGLAGE;

	typedef struct X28_CALIBRATE_SENSOR
	{
		long lOffset;								//Offset utilisateur
		float fCoeffA;								//Coeff A du polynome
		float fCoeffB;								//Coeff B du polynome
		X28_DATE_REGLAGE date;						//Date de réglage du capteur
		UCHAR szOperator[X28_MAX_OPERATOR_LENGTH];	//Nom de l'opérateur (clé USB ATEQ)
	} X28_CALIBRATE_SENSOR;

	typedef struct X28_SENSOR_VALUES
	{
		float fBruteValue;
		float fReelValue;
		UCHAR ucStatus;
	} X28_SENSOR_VALUES;

	typedef struct X28_REGLAGE_STATUS
	{
		WORD wSensorId;
		WORD wStepId;
		WORD wWaitFlag;
		WORD wEndFlag;
		WORD wErrFlag;
		WORD wDacValue;
		long lValue;
	} X28_REGLAGE_STATUS;

#pragma pack(pop)

#ifdef F28_MODE_ADMIN
	short	X28API X28_EndOfTransfert(short sModuleID);
	short	X28API X28_ExecuteCommand(short sModuleID, short sCommand);
	short	X28API X28_GetCalibrateInfo(short sModuleID, short sSensorID, X28_CALIBRATE_SENSOR* pSensor);
	short	X28API X28_GetReglageStatus(short sModuleID, X28_REGLAGE_STATUS* pStatus);
	short	X28API X28_GetSensorValues(short sModuleID, short sSensorID, X28_SENSOR_VALUES* pValues);
	short	X28API X28_ReadCanObject(short sModuleID, short sObjectID, BYTE* pDest, long lSize);
	short	X28API X28_SetCalibrateInfo(short sModuleID, short sSensorID, X28_CALIBRATE_SENSOR* pSensor);
	short	X28API X28_SetReglageStatus(short sModuleID, X28_REGLAGE_STATUS* pStatus);
	short	X28API X28_SetSerialNumber(short sModuleID, LPSTR szSerialNumber);
	short	X28API X28_StartAdjustSensor(short sModuleID, short sSensor);
	short	X28API X28_WriteCanObject(short sModuleID, short sObjectID, BYTE* pSrc, long lSize);
	short	X28API X28_WriteMemory(short sModuleID, DWORD dwAddr, BYTE* pData, WORD wDataLength);
#endif

#ifdef __cplusplus
}
#endif

#endif