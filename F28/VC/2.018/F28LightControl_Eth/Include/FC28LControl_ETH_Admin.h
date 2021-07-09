#ifndef _FC28LCONTROL_ADMIN_H_
#define _FC28LCONTROL_ADMIN_H_

#include "X28_Admin.h"

#if defined(__cplusplus)
extern "C" {
#endif

#define	FC28LAPI  __stdcall		//For visualBasic client

	/////////////////////////////////////////////////////////////////////
	//
	//	Constants
	//
	/////////////////////////////////////////////////////////////////////

	#define FC28L_MAX_OPERATOR_LENGTH		X28_MAX_OPERATOR_LENGTH

	enum FC28L_CONFIG_VERSION
	{
		FC28L_CONFIG_VERSION_V00,
		FC28L_CONFIG_VERSION_V01,
		FC28L_CONFIG_VERSION_V02,
		FC28L_CONFIG_VERSION_V03,
		FC28L_CONFIG_VERSION_V04,
		FC28L_CONFIG_VERSION_V05,
		FC28L_CONFIG_VERSION_V06,
		FC28L_CONFIG_VERSION_V07,
		FC28L_CONFIG_VERSION_V08,
		FC28L_CONFIG_VERSION_V09,
		FC28L_CONFIG_VERSION_V10,
	};

	/////////////////////////////////////////////////////////////////////
	//
	//	Definition: ADMIN ONLY 
	//
	/////////////////////////////////////////////////////////////////////

#pragma pack(push, 1  )

	typedef struct FC28L_T_OBJ_CONFIG_HARD_VF1XX
	{
		X28_CONFIG_HARD_GENERIC_ITEMS	tGenericItems;
		UCHAR							arOptions[16];		//Options Bits field	
		WORD							wTypeDevice;		//MODE_STANDARD / MODE_POC
		float	fVolumeIntReferenceCC;
		float	fVolumeIntTestCC;
		float	fCaracCapillaire;
		float	fCoeffK;
	} FC28L_T_OBJ_CONFIG_HARD_VF1XX;

	typedef struct FC28L_T_OBJ_CONFIG_HARD_VD2XX
	{
		X28_CONFIG_HARD_GENERIC_ITEMS	tGenericItems;
		UCHAR							arOptions[16];		//Options Bits field	
	} FC28L_T_OBJ_CONFIG_HARD_VD2XX;

	typedef struct FC28L_T_OBJ_CONFIG_HARD_VG3XX
	{
		X28_CONFIG_HARD_GENERIC_ITEMS	tGenericItems;
		UCHAR							arOptions[16];		//Options Bits field	
	} FC28L_T_OBJ_CONFIG_HARD_VG3XX;

	typedef struct FC28L_CONFIGURATION_HARD
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
				X28_CONFIG_HARD_GENERIC_ITEMS tGenericItems;
			};
			
			FC28L_T_OBJ_CONFIG_HARD_VF1XX	ObjCfgF;
			FC28L_T_OBJ_CONFIG_HARD_VD2XX	ObjCfgD;
			FC28L_T_OBJ_CONFIG_HARD_VG3XX	ObjCfgG;
			//reserve totale de la config hard
			UCHAR	arReserved[200];
		};

		WORD	wCrc;

	} FC28L_CONFIGURATION_HARD;

	typedef struct FC28L_CONFIGURATION_HARD_OLD
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
				bUnused : 12;
		// V1.500
		UCHAR	ucDeviceType;
		UCHAR	ucAttrModeRegulator1;
		float	fFullScaleRegulator1;
		// :C28:
		float	fVolumeIntReferenceCC;
		float	fVolumeIntTestCC;
		float	fCaracCapillaire;
		float	fCoeffK;

	} FC28L_CONFIGURATION_HARD_OLD;

#define FC28L_REGLAGE_STATUS	X28_REGLAGE_STATUS

#pragma pack(pop)

#ifdef F28_MODE_ADMIN

	//-------------------------------------------------
	// configuration hardware (ADMIN ONLY)
	//-------------------------------------------------
	short 	FC28LAPI	FC28L_SetHardwareConfiguration(short sModuleID, FC28L_CONFIGURATION_HARD* pConfigHard);
	short 	FC28LAPI	FC28L_GetHardwareConfiguration(short sModuleID, FC28L_CONFIGURATION_HARD* pConfigHard);

#endif

#ifdef __cplusplus
}
#endif

#endif