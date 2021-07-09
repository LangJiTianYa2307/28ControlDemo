
// VCF28LightControlDemo.h : main header file for the PROJECT_NAME application
//

#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"		// main symbols


// CVCF28LightControlDemoApp:
// See VCF28LightControlDemo.cpp for the implementation of this class
//

class CVCF28LightControlDemoApp : public CWinApp
{
public:
	CVCF28LightControlDemoApp();

// Overrides
public:
	virtual BOOL InitInstance();

// Implementation

	DECLARE_MESSAGE_MAP()
};

extern CVCF28LightControlDemoApp theApp;