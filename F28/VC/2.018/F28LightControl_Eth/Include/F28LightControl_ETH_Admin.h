#ifndef _F28LIGHTCONTROL_ADMIN_H_
#define _F28LIGHTCONTROL_ADMIN_H_

#include "X28_Admin.h"

#if defined(__cplusplus)
extern "C" {
#endif

#define	F28API  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	#define MAX_OPERATOR_LENGTH		X28_MAX_OPERATOR_LENGTH

	/////////////////////////////////////////////////////////////////////
	//
	//	Definition: ADMIN ONLY 
	//
	/////////////////////////////////////////////////////////////////////

	enum F28_DEVICE_TYPE			// Obsolete -> Use X28_DEVICE_TYPE
	{
		F28_F28,
		F28_F28L,

		F28_MAX_DEVICE_TYPE
	};

	enum F28_SENSORS_LIST			// Obsolete -> Use X28_SENSORS_LIST
	{
		F28_SENSOR_DIFF,
		F28_SENSOR_PIEZO_1,
		F28_SENSOR_PIEZO_LINE,

		F28_NB_SENSORS
	};

	enum F28_REG_STEPS				// Obsolete -> Use X28_REG_STEPS
	{
		F28_REG_NO_STEP,
		F28_REG_ZERO_CAPTEUR,
		F28_REG_75_DAC,
		F28_REG_75_VAL,
		F28_REG_TEST_POINT_75,
		F28_REG_25_DAC,
		F28_REG_25_VAL,
		F28_REG_VALID_REGLAGE,

		F28_REG_MAX_STEPS,
	};

	enum F28_COMMAND_REGLAGE		// Obsolete -> Use X28_COMMAND_REGLAGE
	{
		F28_NO_KEY_COMMAND,
		F28_K_ENTER_COMMAND,
		F28_K_ESCAPE_COMMAND,
		F28_K_STOP_COMMAND,

		F28_MAX_COMMAND
	};

	//Type d'appareils
	enum F28_TYPE_DEVICE			// Obsolete -> Use X28_TYPE_DEVICE
	{
		NO_SERIES_DEVICE,
		F_SERIES_DEVICE,
		D_SERIES_DEVICE,
		G_SERIES_DEVICE,
	};

	enum CONFIG_VERSION
	{
		CONFIG_VERSION_V00,
		CONFIG_VERSION_V01,
		CONFIG_VERSION_V02,
		CONFIG_VERSION_V03,
		CONFIG_VERSION_V04,
		CONFIG_VERSION_V05,
		CONFIG_VERSION_V06,
		CONFIG_VERSION_V07,
		CONFIG_VERSION_V08,
		CONFIG_VERSION_V09,
		CONFIG_VERSION_V10,
	};

	enum VOIES_MEASURE				// Obsolete -> Use X28_VOIES_MEASURE
	{
		VOIE_MEASURE_PCAP,			//Voie ACAM
		VOIE_MEASURE_DELTA,			//Voie ltc 
		VOIE_MEASURE_INT_CAPT1,		//Voie interne ADC 1
		VOIE_MEASURE_INT_CAPT2,		//Voie interne ADC 2
		VOIE_MEASURE_CAPT3_PATM,	//Voie lps 1
		VOIE_MEASURE_CAPT3_TEMP,	//Voie lps 2
		VOIE_MEASURE_EXT_I2C,		//Mcp9808
		VOIE_MEASURE_EXT_ANA1,		//Voie externe ADC 3
		VOIE_MEASURE_EXT_ANA2,		//Voie externe ADC 4
		NMAX_VOIES_MEASURE
	};

	enum SENSOR_TYPES				// Obsolete -> Use X28_SENSOR_TYPES
	{
		TYPE_SENSOR_NONE,
		TYPE_SENSOR_ACAM,
		TYPE_SENSOR_DIRECT,
		TYPE_SENSOR_INDIRECT,
		TYPE_SENSOR_PLIGNE,
		TYPE_SENSOR_PATM,
		TYPE_SENSOR_TEMP_INT,
		TYPE_SENSOR_TEMP_EXT,
		TYPE_SENSOR_TEMP_AMBIENT,
		TYPE_SENSOR_TEMP_PART,
		NMAX_TYPES_SENSOR
	};

	enum OUTPUTS_ANA				// Obsolete -> Use X28_OUTPUTS_ANA
	{
		OUTPUT_J12,
		OUTPUT_J11,
		OUTPUT_J8,
		OUTPUT_J6,
		NMAX_OUTPUTS_ANA
	};

	enum OUTPUT_ANA_TYPES			// Obsolete -> Use X28_OUTPUT_ANA_TYPES
	{
		TYPE_OUTPUT_NONE,
		TYPE_OUTPUT_REG1_DIRECT,
		TYPE_OUTPUT_REG1_INDIRECT,
		TYPE_OUTPUT_REG2_DIRECT,
		TYPE_OUTPUT_REG2_INDIRECT,
		TYPE_OUTPUT_PRESSURE_SIGNAL,
		TYPE_OUTPUT_LEAK_SIGNAL,
		NMAX_OUTPUT_ANA_TYPES
	};

	enum OUTPUTS_VANNE				// Obsolete -> Use X28_OUTPUTS_VANNE
	{
		OUTPUT_PREFILL,
		OUTPUT_FILL,
		OUTPUT_TEST,
		OUTPUT_DUMP,
		NMAX_OUTPUTS_VANNES
	};

	enum INPUTS_TOR					// Obsolete -> Use X28_INPUTS_TOR
	{
		INPUT_INFO_V1,		//connecteur J1
		INPUT_INFO_V2,		//connecteur J18 
		INPUT_PST,			//connecteur J3
		NMAX_INPUTS_TOR
	};

#pragma pack(push, 1  )

	#define VOIES_SENSOR_CFG			X28_VOIES_SENSOR_CFG			// Obsolete -> Use X28_INPUTS_TOR
	#define OUTPUTS_ANA_CFG				X28_OUTPUTS_ANA_CFG				// Obsolete -> Use X28_INPUTS_TOR
	#define CONFIG_HARD_GENERIC_ITEMS	X28_CONFIG_HARD_GENERIC_ITEMS	// Obsolete -> Use X28_CONFIG_HARD_GENERIC_ITEMS
	#define T_OBJ_CONFIG_HARD_VF1XX		F28_T_OBJ_CONFIG_HARD_VF1XX		// Obsolete -> Use X28_T_OBJ_CONFIG_HARD_VF1XX
	#define T_OBJ_CONFIG_HARD_VD2XX		F28_T_OBJ_CONFIG_HARD_VD2XX		// Obsolete -> Use X28_T_OBJ_CONFIG_HARD_VD2XX
	#define T_OBJ_CONFIG_HARD_VG3XX		F28_T_OBJ_CONFIG_HARD_VG3XX		// Obsolete -> Use X28_T_OBJ_CONFIG_HARD_VG3XX

	#define CONFIG_OPT_ABS_SENSOR		8								// Index option absolute sensor (nouvelle struture arOptions)

	typedef struct F28_T_OBJ_CONFIG_HARD_VF1XX
	{
		X28_CONFIG_HARD_GENERIC_ITEMS	tGenericItems;
		UCHAR							arOptions[16];		//Options Bits field (16)	
		WORD							wTypeDevice;		//MODE_STANDARD / MODE_POC
	} F28_T_OBJ_CONFIG_HARD_VF1XX;

	typedef struct F28_T_OBJ_CONFIG_HARD_VD2XX
	{
		X28_CONFIG_HARD_GENERIC_ITEMS	tGenericItems;
		UCHAR							arOptions[16];		//Options Bits field	
	} F28_T_OBJ_CONFIG_HARD_VD2XX;

	typedef struct F28_T_OBJ_CONFIG_HARD_VG3XX
	{
		X28_CONFIG_HARD_GENERIC_ITEMS	tGenericItems;
		UCHAR							arOptions[16];		//Options Bits field	
	} F28_T_OBJ_CONFIG_HARD_VG3XX;

	typedef struct F28_CONFIGURATION_HARD
	{
		union
		{
			WORD	wId;				//High Byte = Device Type (0x01 = F, 0x02 = D, 0x03 = G ....) / Low Byte Version structure config
			struct
			{
				UCHAR ucDeviceID;		// F_SERIES / D_SERIES / G_SERIES
				UCHAR ucVersionCfg;		// Configuration version
			};
		};
		WORD	wLength;				//Structure length

		union
		{
			//Tronc commun de la config hard a tous les appareils
			struct
			{
				CONFIG_HARD_GENERIC_ITEMS tGenericItems;
			};
			
			T_OBJ_CONFIG_HARD_VF1XX	ObjCfgF;
			T_OBJ_CONFIG_HARD_VD2XX	ObjCfgD;
			T_OBJ_CONFIG_HARD_VG3XX	ObjCfgG;
			//reserve totale de la config hard
			UCHAR	arReserved[200];
		};

		WORD	wCrc;

	} F28_CONFIGURATION_HARD;

	typedef struct F28_CONFIGURATION_HARD_OLD
	{
		float   fFullScaleLeak;     //Acam (50/500/5000)
		float   fFullScalePressure; // (Keller/Panasonic test/Panasonic line/IN_ANA1/IN_ANA2)
		UCHAR   ucPressureSensor;   //Selection du capteur de pression  (Keller/Panasonic test/Panasonic line/IN_ANA1/IN_ANA2)
		UCHAR   ucPresencePLine;    //Presence capteur Pression ligne: 0 (none) else 10000hpa
		UCHAR   ucPresencePAtm;     //Presence capteur Pression Atmosphérique
		UCHAR   ucPresenceTemp;     //Presence capteur Température interne(I2C MCP9808)
		float   fFullScaleKeller;   //Full scale capteur Keller
		float   fFullScalePanasonic;//Panasonic
		float   fFullScaleMassflow; //Option Massflow
		WORD    wCoeffTemp;         //coeff. mode correction de température sur Diff
		WORD    wAutoFill;          //Enum paramètre auto-fill (mm). si 0 pas d'autofill
		WORD    wTempIntFixValue;   //Valeur fixe pour la température interne si pas de présence capteur
		WORD    wPAtmFixValue;      //Valeur fixe pour PATM si pas de capteur
		UCHAR   ucDiffMode;         //Mode capteur diff (STANDARD/OIL)
		UCHAR   ucExterneANA1;      //None/Temp1 Ext/MassFlow
		UCHAR   ucExterneANA2;      //None/Temp2 Ext/MassFlow
		//-------------------------------------------------------------------
		UCHAR   ucPressureSensor2;   //Selection du capteur de pression 2(Keller/Panasonic test/Panasonic line/IN_ANA1/IN_ANA2)
		float   fFullScalePressure2; //Keller or Panasonic

		// <SL> 1.400 Update structure p/r à F28Light
		long	lTempIntOffset;		 //Offset temperature interne en 0.1 degre

		WORD	bVacuumOnlyPressSensor1 : 1,
				bPressAndVacuumPressSensor1 : 1,
				bVacuumOnlyPressSensor2 : 1,
				bPressAndVacuumPressSensor2 : 1,
				bResrevedACAM : 4,
				bOptAbsSensor : 1,
				bUnused : 7;

		// V1.500
		UCHAR	ucDeviceType;
		UCHAR	ucAttrModeRegulator1;
		float	fFullScaleRegulator1;
		//		UCHAR	ucDummy;
	} F28_CONFIGURATION_HARD_OLD;

	typedef struct T_DATE_REGLAGE
	{
		UCHAR ucDay;
		UCHAR ucMonth;
		WORD wYear;
	} T_DATE_REGLAGE;

	#define F28_CALIBRATE_SENSOR	X28_CALIBRATE_SENSOR
	#define F28_SENSOR_VALUES		X28_SENSOR_VALUES
	#define F28_REGLAGE_STATUS		X28_REGLAGE_STATUS

#pragma pack(pop)

#ifdef F28_MODE_ADMIN

	short	F28API  F28_ReadCanObject(short sModuleID, short sObjectID, BYTE* pDest, long lSize);		// Obsolete -> use X28_ version
	short	F28API  F28_WriteCanObject(short sModuleID, short sObjectID, BYTE* pSrc, long lSize);		// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Module serial number (ADMIN ONLY)
	//-------------------------------------------------
	short F28API F28_SetSerialNumber(short sModuleID, LPSTR szSerialNumber);							// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Upgrade software (ADMIN ONLY)
	//-------------------------------------------------
	short F28API F28_WriteMemory(short sModuleID, DWORD dwAddr, BYTE* pData, WORD wDataLength);			// Obsolete -> use X28_ version
	short F28API F28_EndOfTransfert(short sModuleID);													// Obsolete -> use X28_ version

	//-------------------------------------------------
	// configuration hardware (ADMIN ONLY)
	//-------------------------------------------------
	short 	F28API	F28_SetHardwareConfiguration(short sModuleID, F28_CONFIGURATION_HARD* pConfigHard);
	short 	F28API	F28_GetHardwareConfiguration(short sModuleID, F28_CONFIGURATION_HARD* pConfigHard);

	short	F28API	F28_GetCalibrateInfo(short sModuleID, short sSensorID, F28_CALIBRATE_SENSOR* pSensor);			// Obsolete -> use X28_ version
	short	F28API	F28_SetCalibrateInfo(short sModuleID, short sSensorID, F28_CALIBRATE_SENSOR* pSensor);			// Obsolete -> use X28_ version
	short	F28API  F28_GetSensorValues(short sModuleID, short sSensorID, F28_SENSOR_VALUES* pValues);				// Obsolete -> use X28_ version

	//-------------------------------------------------
	// Reglage capteurs (ADMIN ONLY)
	//-------------------------------------------------
	short	F28API	F28_StartAdjustSensor(short sModuleID, short sSensor);							// Obsolete -> use X28_ version
	short	F28API	F28_ExecuteCommand(short sModuleID, short sCommand);							// Obsolete -> use X28_ version
	short	F28API	F28_GetReglageStatus(short sModuleID, F28_REGLAGE_STATUS* pStatus);				// Obsolete -> use X28_ version
	short	F28API	F28_SetReglageStatus(short sModuleID, F28_REGLAGE_STATUS* pStatus);				// Obsolete -> use X28_ version

#endif

#ifdef __cplusplus
}
#endif

#endif