#ifndef _I28CONTROL_H_
#define _I28CONTROL_H_

#include "X28.h"

#if defined(__cplusplus)
extern "C" {
#endif

	#define	I28API  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	//----------------------------------------
	// Results status code
	//----------------------------------------
	enum I28_RESULT_STATUS_CODE
	{
		I28_STATUS_GOOD_PART,
		I28_STATUS_TEST_FAIL_PART,
		I28_STATUS_NU,
		I28_STATUS_ALARM_EEEE,

		I28_NMAX_STATUS_CODE
	};

	//----------------------------------------
	// Parameters definition
	//----------------------------------------
	enum I28_TYPE_TEST			// Uses with "wTypeTest" parameter
	{
		I28_UNDEFINED_TEST,
		I28_TYPE_TEST_NU1,
		I28_TYPE_TEST_NU2,
		I28_INSULATION,
		I28_TYPE_TEST_NU3
	};

	enum I28_VOLTAGE_UNITS
	{
		I28_VOLTAGE_NONE,
		I28_VOLTAGE_POINTS		= 6,
		I28_NMAX_VOLTAGE_UNITS
	};

	enum I28_CURRENT_UNITS			// Uses with "wCurrentUnit" parameter
	{
		I28_CURRENT_NONE,
		I28_CURRENT_POINTS = 25,
		I28_NMAX_CURRENT_UNITS,
	};

	enum I28_ENUM_STEP_CODE
	{
		I28_NO_STEP,
		I28_NO_STEP1,
		I28_NO_STEP2,
		I28_TEST_STEP,
		I28_DUMP_STEP
	};

#pragma pack(push, 1 )  // uses for visual basic

	typedef struct I28_RESULT
	{
		UCHAR ucStatus;
		float fVoltageValue;
		float fCurrentValue;
		UCHAR ucUnitVoltage;
		UCHAR ucUnitCurrent;
		BYTE ucGroupID;
		BYTE ucModuleAddr;
		X28_DATE dateReceived;
	} I28_RESULT;

	typedef struct I28_REALTIME_CYCLE
	{
		UCHAR ucEndCycle;
		UCHAR ucStatus;
		float fVoltageValue;
		float fCurrentValue;
		UCHAR ucUnitVoltage;
		UCHAR ucUnitCurrent;
		float fNU1;
		float fNU2;
	} I28_REALTIME_CYCLE;


	/////////////////////////////////////////////////////////////////////
	//
	//	Definition 
	//
	/////////////////////////////////////////////////////////////////////

	typedef struct I28_PARAMETERS
	{
		WORD	wTypeTest;
		WORD	wTestTime;				// Temps de test
		WORD	wFallTime;				// Temps de descente
		float	fVoltageSetPoint;		// Consigne en volt	(Exemple 500 = 500V)
		WORD	wVoltageUnit;			// Unite pour la tension = PRESS_POINTS = 6 (Volt pour i28)
		float	fCurrentMax;			// Niveau de rejet pour le courant en nA(Exemple 1000 = 1000 nA)
		WORD	wCurrentUnit;			// Unite de rejet courant = LEAK_POINTS = 25 (nA pour i28)
	} I28_PARAMETERS;

	#pragma pack(pop)

	//-------------------------------------------------
	// Create/Search F28 modules 
	//-------------------------------------------------
	short	I28API	I28_AddModule(ULONG ulIP, BYTE ucModuleAddr, BYTE ucGroupID, BYTE ucTimeout);

	//-------------------------------------------------
	// Edit programs/Parameters
	//-------------------------------------------------
	short 	I28API	I28_GetModuleParameters(short sModuleID, I28_PARAMETERS* pPara);
	short 	I28API	I28_SetModuleParameters(short sModuleID, I28_PARAMETERS* pPara);

	//-------------------------------------------------
	// Results - FIFO
	//-------------------------------------------------
	short 	I28API I28_GetRealTimeData(short sModuleID, I28_REALTIME_CYCLE* pCycle);
	short 	I28API I28_GetLastResult(short sModuleID, I28_RESULT* pResult);
	short	I28API I28_ClearFIFOResults(short sModuleID);
	WORD	I28API I28_GetResultsCount(short sModuleID);
	short 	I28API I28_GetNextResult(short sModuleID, I28_RESULT* pResult);


#ifdef __cplusplus
}
#endif

#endif