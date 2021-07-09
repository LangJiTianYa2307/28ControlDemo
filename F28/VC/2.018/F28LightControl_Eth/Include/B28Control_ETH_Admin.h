#ifndef _B28LIGHTCONTROL_ADMIN_H_
#define _B28LIGHTCONTROL_ADMIN_H_

#include "X28_Admin.h"

#if defined(__cplusplus)
extern "C" {
#endif

#define	B28API  __stdcall		//For visualBasic client

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

#pragma pack(push, 1  )

	typedef struct B28_CONFIGURATION_HARD
	{
		UCHAR	ucDeviceType;
		UCHAR	ucDummy;
		float	fFullScalePressure;
		WORD	bPressControl : 1;
		WORD	bUnused : 15;

	} B28_CONFIGURATION_HARD;

#pragma pack(pop)

#ifdef B28_MODE_ADMIN

	//-------------------------------------------------
	// configuration hardware (ADMIN ONLY)
	//-------------------------------------------------
	short 	B28API	B28_SetHardwareConfiguration(short sModuleID, B28_CONFIGURATION_HARD* pConfigHard);
	short 	B28API	B28_GetHardwareConfiguration(short sModuleID, B28_CONFIGURATION_HARD* pConfigHard);

#endif

#ifdef __cplusplus
}
#endif

#endif