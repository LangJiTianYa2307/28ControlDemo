#ifndef _B28CONTROL_H_
#define _B28CONTROL_H_

#include "X28.h"

#if defined(__cplusplus)
extern "C" {
#endif

	#define	B28API  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	//----------------------------------------
	// Results status code
	//----------------------------------------
	enum B28_RESULT_STATUS_CODE
	{
		B28_STATUS_GOOD_PART,
		B28_STATUS_TEST_FAIL_PART,
		B28_STATUS_VOLTAGE_OUT,
		B28_STATUS_ALARM_EEEE,
		B28_STATUS_ALARM_PST,

		B28_NMAX_STATUS_CODE
	};

	//----------------------------------------
	// Parameters definition
	//----------------------------------------
	enum B28_TYPE_TEST			// Uses with "wTypeTest" parameter
	{
		B28_UNDEFINED_TEST,
		B28_IONIQ,
	};

	enum B28_VOLTAGE_UNITS
	{
		B28_VOLTAGE_VOLT = 0,
		B28_VOLTAGE_POINTS,

		B28_NMAX_VOLTAGE_UNITS
	};

	enum B28_MEASUREMENT_UNITS			// Uses with "wMeasurementtUnit" parameter
	{
		B28_MEASUREMENT_POINTS = 0,
		B28_MEASUREMENT_RAW_POINTS,

		B28_NMAX_MEASUREMENT_UNITS
	};

	enum B28_ENUM_STEP_CODE
	{
		B28_NO_STEP,
		B28_RISE_STEP,
		B28_NO_STEP2,
		B28_TEST_STEP,
		B28_FALL_STEP
	};

#pragma pack(push, 1 )  // uses for visual basic

	typedef struct B28_RESULT
	{
		UCHAR ucStatus;
		float fVoltageValue;
		float fMeasurementValue;
		UCHAR ucUnitVoltage;
		UCHAR ucUnitMeasurement;
		BYTE ucGroupID;
		BYTE ucModuleAddr;
		X28_DATE dateReceived;
	} B28_RESULT;

	typedef struct B28_REALTIME_CYCLE
	{
		UCHAR ucEndCycle;
		UCHAR ucStatus;
		float fVoltageValue;
		float fMeasurementValue;
		UCHAR ucUnitVoltage;
		UCHAR ucUnitMeasurement;
		float fInternalTemperature;
		float fPatm;
	} B28_REALTIME_CYCLE;

	//Uses with "wOptions" parameter
	#define B28_PEAK_MODE		1

	/////////////////////////////////////////////////////////////////////
	//
	//	Definition 
	//
	/////////////////////////////////////////////////////////////////////

	typedef struct B28_PARAMETERS
	{
		WORD	wTypeTest;
		WORD	wTestTime;				// Temps de test
		WORD	wFallTime;				// Temps de descente
		float	fVoltageSetPoint;		// Consigne en volt	(Exemple 500 = 500V)
		WORD	wVoltageUnit;			// Unite pour la tension
		float	fMeasurementMax;		// Niveau de rejet pour la mesure
		WORD	wMeasurementUnit;		// Unite de rejet mesure
		WORD	wRiseTime;				// Temps montée
		WORD	wOptions;				// Option
		long	lPressureMin;			// Pression minimum (Pa)
		long	lPressureMax;			// Pression maximum (Pa)
	} B28_PARAMETERS;

	#pragma pack(pop)

	//-------------------------------------------------
	// Create/Search F28 modules 
	//-------------------------------------------------
	short	B28API	B28_AddModule(ULONG ulIP, BYTE ucModuleAddr, BYTE ucGroupID, BYTE ucTimeout);

	//-------------------------------------------------
	// Edit programs/Parameters
	//-------------------------------------------------
	short 	B28API	B28_GetModuleParameters(short sModuleID, B28_PARAMETERS* pPara);
	short 	B28API	B28_SetModuleParameters(short sModuleID, B28_PARAMETERS* pPara);

	//-------------------------------------------------
	// Results - FIFO
	//-------------------------------------------------
	short 	B28API B28_GetRealTimeData(short sModuleID, B28_REALTIME_CYCLE* pCycle);
	short 	B28API B28_GetLastResult(short sModuleID, B28_RESULT* pResult);
	short	B28API B28_ClearFIFOResults(short sModuleID);
	WORD	B28API B28_GetResultsCount(short sModuleID);
	short 	B28API B28_GetNextResult(short sModuleID, B28_RESULT* pResult);

	//-------------------------------------------------
	// Special cycle
	//-------------------------------------------------
	short 	B28API B28_StartVoltageAdjust(short sModuleID);
	short 	B28API B28_RegulatorAdjust(short sModuleID);
	short 	B28API B28_StartAZPiezzo(short sModuleID, WORD wDumpTime);

#ifdef __cplusplus
}
#endif

#endif