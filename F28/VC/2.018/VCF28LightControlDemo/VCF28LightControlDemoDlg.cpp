// ******************************************************************************
// VCF28LightControlDemoDlg.cpp : implementation file
// ******************************************************************************
// 03/12/15		1.403 - :ADD: AutoCal Offset + Volume 
//						. Add unit to Pa/s
//						. Add leak correction to Pa/s
// 21/12/15		1.404	. Add continuous communication to avoid disconnection (keep alive)
//						. Add F28_ResetEthernetModule to reconnect after disconnection
// *******************************************************************************
// 23/12/15 1.500    - Add parameters (no size changed)
//                       - Leak units 
//                       - Test type
//                       - Fill mode
//                       - Options
//                   - Electronic Regulator
// ******************************************************************************
// 02/03/17	2.0.0.4	- Add jet check
//					- Add new alarms status
// ******************************************************************************
// 30/06/17	2.0.0.6	- Add leak unit cmH2O
// ******************************************************************************
// 27/11/18	2.0.0.13	- Add Auto-Ratio
// ******************************************************************************
// 26/06/19	2.0.0.16	- Add new fill type
//						- Auto-ratio modification
// ******************************************************************************
// 02/07/19	2.0.0.17	- Add Easy auto learning special cycle
// ******************************************************************************
// 04/11/19	2.0.0.18	- Add leak unit ugH2O
// ******************************************************************************

#include "stdafx.h"
#include <Ws2tcpip.h>

#include <F28LightControl_ETH.h>

#include "VCF28LightControlDemo.h"
#include "VCF28LightControlDemoDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

#define TMR_100_MS		1
#define TMR_1000_MS		2

// CAboutDlg dialog used for App About

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
public:
	virtual BOOL OnInitDialog();
	afx_msg void OnDestroy();
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
	ON_WM_DESTROY()
END_MESSAGE_MAP()

BOOL CAboutDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// TODO:  Add extra initialization here

	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

void CAboutDlg::OnDestroy()
{
	CDialogEx::OnDestroy();
}

// CVCF28LightControlDemoDlg dialog

CVCF28LightControlDemoDlg::CVCF28LightControlDemoDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CVCF28LightControlDemoDlg::IDD, pParent)
	, m_strIPAddr(_T("192.168.1.106"))
	, m_nInterCycle(300)
	, m_nCycleNumber(2)
	, m_fOffsetMax(1.0f)
	, m_fCalLeak(0.0f)
	, m_fCalPress(0.5f)
	, m_fVolumeMax(45.0f)
	, m_fVolumeMin(0.0f)
	, m_strIPAddr1(_T("192.168.1.1"))
	, m_strIPAddr2(_T("192.168.1.2"))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	m_bAPIOpened = FALSE;
	m_bChannelOk = FALSE;
	m_sModuleID = -1;

	m_bRealtimeRunning = FALSE;

	m_pBoldFont = NULL;
}

void CVCF28LightControlDemoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDT_DLL_VER, m_edtDllVer);
	DDX_Control(pDX, IDC_CHK_OPEN, m_chkOpenClose);
	DDX_Control(pDX, IDC_LISTBOX_DSP, m_listBoxDsp);
	DDX_Control(pDX, IDC_CBO_MODULE, m_cboModule);
	DDX_Control(pDX, IDC_CBO_GROUP, m_cboGroup);
	DDX_Text(pDX, IDC_EDT_IP_ADDR, m_strIPAddr);
	DDX_Control(pDX, IDC_STATIC_ATM_U, m_staticATM_U);
	DDX_Control(pDX, IDC_STATIC_ATM_V, m_staticATM_V);
	DDX_Control(pDX, IDC_STATIC_LEAK_U, m_staticLeak_U);
	DDX_Control(pDX, IDC_STATIC_LEAK_V, m_staticLeak_V);
	DDX_Control(pDX, IDC_STATIC_PHASE, m_staticPhase);
	DDX_Control(pDX, IDC_STATIC_PRESSURE_U, m_staticPressure_U);
	DDX_Control(pDX, IDC_STATIC_PRESSURE_V, m_staticPressure_V);
	DDX_Control(pDX, IDC_STATIC_TEMP_U, m_staticTemp_U);
	DDX_Control(pDX, IDC_STATIC_TEMP_V, m_staticTemp_V);
	DDX_Control(pDX, IDC_STATIC_ERROR, m_staticCptErr);
	DDX_Control(pDX, IDC_STATIC_RECEIVE, m_staticCptRec);
	DDX_Control(pDX, IDC_STATIC_TRANSMIT, m_staticCptTrans);
	DDX_Control(pDX, IDC_STATIC_RSLT_CPT, m_staticRsltCount);
	DDX_Control(pDX, IDC_EDT_DUMP_AZ, m_edtDumpTime);
	DDX_Text(pDX, IDC_EDT_INTER_CYC, m_nInterCycle);
	DDX_Text(pDX, IDC_EDT_CYC_NUM, m_nCycleNumber);
	DDX_Text(pDX, IDC_EDT_CAL_LEAK, m_fCalLeak);
	DDX_Text(pDX, IDC_EDT_CAL_PRESS, m_fCalPress);
	DDX_Text(pDX, IDC_EDT_OFFSET_MAX, m_fOffsetMax);
	DDX_Text(pDX, IDC_EDT_VOL_MAX, m_fVolumeMax);
	DDX_Text(pDX, IDC_EDT_VOL_MIN, m_fVolumeMin);
	DDX_Control(pDX, IDC_STATIC_PHASE_CAL, m_staticPhaseCal);
	DDX_Control(pDX, IDC_CHK_FIFO, m_chkFifo);
	DDX_Control(pDX, IDC_CHK_CONNECT, m_chkConnect);
	DDX_Text(pDX, IDC_EDT_IP_ADDR_1, m_strIPAddr1);
	DDX_Text(pDX, IDC_EDT_IP_ADDR_2, m_strIPAddr2);
	DDX_Control(pDX, IDC_STATIC_ERROR_1, m_staticCptErr1);
	DDX_Control(pDX, IDC_STATIC_ERROR_2, m_staticCptErr2);
	DDX_Control(pDX, IDC_STATIC_PHASE_1, m_staticPhase1);
	DDX_Control(pDX, IDC_STATIC_PHASE_2, m_staticPhase2);
	DDX_Control(pDX, IDC_STATIC_RECEIVE_1, m_staticCptRec1);
	DDX_Control(pDX, IDC_STATIC_RECEIVE_2, m_staticCptRec2);
	DDX_Control(pDX, IDC_STATIC_TRANSMIT_1, m_staticCptTrans1);
	DDX_Control(pDX, IDC_STATIC_TRANSMIT_2, m_staticCptTrans2);
	DDX_Control(pDX, IDC_LISTBOX_DSP_1, m_listBoxDsp1);
	DDX_Control(pDX, IDC_CHK_CONNECT_1, m_chkConnect1);
	DDX_Control(pDX, IDC_CHK_CONNECT_2, m_chkConnect2);
}

BEGIN_MESSAGE_MAP(CVCF28LightControlDemoDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BTN_ADD_MODULE, &CVCF28LightControlDemoDlg::OnClickedBtnAddModule)
	ON_BN_CLICKED(IDC_CHK_OPEN, &CVCF28LightControlDemoDlg::OnClickedChkOpen)
	ON_BN_CLICKED(IDC_BTN_PARAMETER, &CVCF28LightControlDemoDlg::OnBnClickedBtnParameter)
	ON_BN_CLICKED(IDC_BTN_START, &CVCF28LightControlDemoDlg::OnBnClickedBtnStart)
	ON_BN_CLICKED(IDC_BTN_RESET, &CVCF28LightControlDemoDlg::OnBnClickedBtnReset)
	ON_BN_CLICKED(IDC_BTN_LAST_RSLT, &CVCF28LightControlDemoDlg::OnBnClickedBtnLastRslt)
	ON_BN_CLICKED(IDC_BTN_START_GROUP, &CVCF28LightControlDemoDlg::OnBnClickedBtnStartGroup)
	ON_BN_CLICKED(IDC_BTN_RESET_GROUP, &CVCF28LightControlDemoDlg::OnBnClickedBtnResetGroup)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_BTN_READ_PARAMETER, &CVCF28LightControlDemoDlg::OnBnClickedBtnReadParameter)
	ON_BN_CLICKED(IDC_BTN_CLEAR, &CVCF28LightControlDemoDlg::OnBnClickedBtnClear)
	ON_BN_CLICKED(IDC_BTN_RESET_FIFO, &CVCF28LightControlDemoDlg::OnBnClickedBtnResetFifo)
	ON_BN_CLICKED(IDC_BTN_READ_FIFO, &CVCF28LightControlDemoDlg::OnBnClickedBtnReadFifo)
	ON_BN_CLICKED(IDC_BTN_AUTO_ZERO, &CVCF28LightControlDemoDlg::OnBnClickedBtnAutoZero)
	ON_BN_CLICKED(IDC_BTN_REG_ADJUST, &CVCF28LightControlDemoDlg::OnBnClickedBtnRegAdjust)
	ON_BN_CLICKED(IDC_BTN_OFFSET, &CVCF28LightControlDemoDlg::OnBnClickedBtnOffset)
	ON_BN_CLICKED(IDC_BTN_VOLUME_OFFSET, &CVCF28LightControlDemoDlg::OnBnClickedBtnVolumeOffset)
	ON_BN_CLICKED(IDC_BTN_STOP_CAL, &CVCF28LightControlDemoDlg::OnBnClickedBtnStopCal)
	ON_BN_CLICKED(IDC_BTN_ADD_MODULE_1, &CVCF28LightControlDemoDlg::OnBnClickedBtnAddModule1)
	ON_BN_CLICKED(IDC_BTN_ADD_MODULE_2, &CVCF28LightControlDemoDlg::OnBnClickedBtnAddModule2)
	ON_BN_CLICKED(IDC_BTN_START_ALL, &CVCF28LightControlDemoDlg::OnBnClickedBtnStartAll)
	ON_BN_CLICKED(IDC_BTN_OFFSET_ALL, &CVCF28LightControlDemoDlg::OnBnClickedBtnOffsetAll)
	ON_BN_CLICKED(IDC_BTN_REG_ELECT, &CVCF28LightControlDemoDlg::OnBnClickedBtnRegElect)
	ON_BN_CLICKED(IDC_BTN_REMOVE_MODULE, &CVCF28LightControlDemoDlg::OnBnClickedBtnRemoveModule)
	ON_BN_CLICKED(IDC_BTN_JET_CHECK, &CVCF28LightControlDemoDlg::OnBnClickedBtnJetCheck)
	ON_BN_CLICKED(IDC_BTN_AUTO_RATIO, &CVCF28LightControlDemoDlg::OnBnClickedBtnAutoRatio)
	ON_BN_CLICKED(IDC_BTN_AUTO_RATIO_ALL, &CVCF28LightControlDemoDlg::OnBnClickedBtnAutoRatioAll)
	ON_BN_CLICKED(IDC_BTN_EASY_AUTO_LEARNING, &CVCF28LightControlDemoDlg::OnBnClickedBtnEasyAutoLearning)
	ON_BN_CLICKED(IDC_BTN_EASY_AUTO_LEARNING_ALL, &CVCF28LightControlDemoDlg::OnBnClickedBtnEasyAutoLearningAll)
END_MESSAGE_MAP()

// CVCF28LightControlDemoDlg message handlers

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnInitDialog()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	BOOL
//  
//		
//  ************************************************************************************
BOOL CVCF28LightControlDemoDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	CString	strTitle;

	GetWindowText(strTitle);
#ifdef _64BITS
	strTitle.Replace(_T("Demo"), _T("Demo 64Bits"));
#else
	strTitle.Replace(_T("Demo"), _T("Demo 32Bits"));
#endif
	SetWindowText(strTitle);

	m_pBoldFont = new CFont;
	m_pBoldFont->CreateFont(24,
		0, 0, 0,
		FW_BOLD,
		FALSE,
		FALSE,
		0,
		ANSI_CHARSET,              // nCharSet
		OUT_DEFAULT_PRECIS,        // nOutPrecision
		CLIP_DEFAULT_PRECIS,       // nClipPrecision
		DEFAULT_QUALITY,           // nQuality
		DEFAULT_PITCH | FF_SWISS,  // nPitchAndFamily
		_T("MS Sans Serif"));

	m_staticATM_U.SetFont(m_pBoldFont);
	m_staticATM_V.SetFont(m_pBoldFont);
	m_staticLeak_U.SetFont(m_pBoldFont);
	m_staticLeak_V.SetFont(m_pBoldFont);
	m_staticPhase.SetFont(m_pBoldFont);
	m_staticPressure_U.SetFont(m_pBoldFont);
	m_staticPressure_V.SetFont(m_pBoldFont);
	m_staticTemp_U.SetFont(m_pBoldFont);
	m_staticTemp_V.SetFont(m_pBoldFont);

	m_staticPhase.SetFont(m_pBoldFont);
	m_staticPhase.SetTextAlign(1);

	m_staticPhaseCal.SetFont(m_pBoldFont);
	m_staticPhaseCal.SetTextAlign(1);

	// Display DLL version at start up
	long lMajor = F28_GetDllMajorVersion();
	long lMinor = F28_GetDllMinorVersion();
	CString strVersion;
	strVersion.Format(_T("%1d.%02d"), lMajor, lMinor);
	m_edtDllVer.SetWindowText(strVersion);

	m_edtDumpTime.SetWindowText(_T("1"));
	m_chkFifo.SetCheck(1);

	// Load parameter from File
	m_F28Light.ReadFile();

	// Activate timer watchdog connection
	SetTimer(TMR_1000_MS, 1000, NULL);

	// Activate 100 ms timer cycle
	SetTimer(TMR_100_MS, 100, NULL);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CVCF28LightControlDemoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CVCF28LightControlDemoDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CVCF28LightControlDemoDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnDestroy()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnDestroy()
{
	CWaitCursor theCursor;

	if (m_bAPIOpened)
	{
		m_bAPIOpened = FALSE;

		F28_RemoveAllModules();

		F28_Close();
	}


	// 2- Release Font
	if (m_pBoldFont)
	{
		delete m_pBoldFont;

		m_pBoldFont = NULL;
	}


	CDialogEx::OnDestroy();
}




// **************************************************************************************
// CVCF28LightControlDemoDlg::DisplayF28Para()
// 
// Purpose       : Display parameters
// 
// Parameters    : 
//         [p] : parameter pointer
// 
// Return        : void
// 
// **************************************************************************************
void CVCF28LightControlDemoDlg::DisplayF28Para(F28_PARAMETERS* p)
{
	CString str;


	str = _T("   ......................");
	DisplayTxt(str);


	str.Format(_T("wTypeTest = %d"), p->wTypeTest);
	DisplayTxt(str);

	str.Format(_T("wTpsFillVol = %d"), p->wTpsFillVol);
	DisplayTxt(str);
	str.Format(_T("wTpsTransfert = %d"), p->wTpsTransfert);
	DisplayTxt(str);

	str.Format(_T("wTpsFill	= %d"), p->wTpsFill);
	DisplayTxt(str);
	str.Format(_T("wTpsStab	= %d"), p->wTpsStab);
	DisplayTxt(str);
	str.Format(_T("wTpsTest = %d"), p->wTpsTest);
	DisplayTxt(str);
	str.Format(_T("wTpsDump = %d"), p->wTpsDump);
	DisplayTxt(str);

	str.Format(_T("wPress1Unit = %d"), p->wPress1Unit);
	DisplayTxt(str);
	str.Format(_T("fPress1Min = %.3f"), p->fPress1Min);
	DisplayTxt(str);
	str.Format(_T("fPress1Max= %.3f"), p->fPress1Max);
	DisplayTxt(str);
	str.Format(_T("fSetFillP1= %.3f"), p->fSetFillP1);
	DisplayTxt(str);
	str.Format(_T("fRatioMax= %.3f"), p->fRatioMax);
	DisplayTxt(str);
	str.Format(_T("fRatioMin= %.3f"), p->fRatioMin);
	DisplayTxt(str);
	str.Format(_T("wFillMode= %d"), p->wFillMode);
	DisplayTxt(str);


	str.Format(_T("wLeakUnit = %d"), p->wLeakUnit);
	DisplayTxt(str);
	str.Format(_T("wRejectCalc = %d"), p->wRejectCalc);
	DisplayTxt(str);
	str.Format(_T("wVolumeUnit = %d"), p->wVolumeUnit);
	DisplayTxt(str);
	str.Format(_T("fVolume= %.3f"), p->fVolume);
	DisplayTxt(str);
	str.Format(_T("fRejectMin= %.3f"), p->fRejectMin);
	DisplayTxt(str);
	str.Format(_T("fRejectMax= %.3f"), p->fRejectMax);
	DisplayTxt(str);

	str.Format(_T("fCoeffAutoFill= %.3f"), p->fCoeffAutoFill);
	DisplayTxt(str);
	str.Format(_T("wOptions = %d"), p->wOptions);
	DisplayTxt(str);

	str.Format(_T("fPatmSTD= %.3f"), p->fPatmSTD);
	DisplayTxt(str);
	str.Format(_T("fTempSTD= %.3f"), p->fTempSTD);
	DisplayTxt(str);

	str.Format(_T("fFilterTime= %.3f"), p->fFilterTime);
	DisplayTxt(str);
	str.Format(_T("fOffsetLeak= %.4f"), p->fOffsetLeak);
	DisplayTxt(str);

	str = _T("   ......................");
	DisplayTxt(str);


}



//  ************************************************************************************
//  CVCF28LightControlDemoDlg::DisplayRealTime()
//  
//  Purpose: Display realtime measure
//  
//  Parameters:
//		[p] : real time result pointer
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::DisplayF28RealTime(F28_REALTIME_CYCLE* p)
{
	
	CString str;
	str.Format(_T("%7.2f"), p->fPressureValue);
	m_staticPressure_V.SetWindowText(str);
	m_staticPressure_U.SetWindowText(m_F28Light.GetPressureUnitStr(p->ucUnitPressure));

	// 1.500
	if (p->ucUnitLeak == LEAK_PA)
		str.Format(_T("%7.2f"), p->fLeakValue);
	else
		str.Format(_T("%7.4f"), p->fLeakValue);
	m_staticLeak_V.SetWindowText(str);

	str.Format(_T("%s"), m_F28Light.GetLeakUnitStr(p->ucUnitLeak));
	m_staticLeak_U.SetWindowText(str);

	m_staticPhase.SetWindowText(m_F28Light.GetPhaseStr(p->ucStatus));


	str.Format(_T("%7.2f"), p->fInternalTemperature);
	m_staticTemp_V.SetWindowText(str);
	m_staticTemp_U.SetWindowText(_T("°C"));

	str.Format(_T("%7.2f"), p->fPatm);
	m_staticATM_V.SetWindowText(str);
	m_staticATM_U.SetWindowText(_T("hPa"));

}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::DisplayCounter()
//  
//  Purpose:
//  
//  Parameters:
//		[p]				: counter pointer
//		[staticCptTrans]: field to display
//		[staticCptRec]: field to display
//		[staticCptErr]: field to display
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::DisplayCounter(F28_COMMUNICATION_STATISTICS* p, CStatic& staticCptTrans, CStatic& staticCptRec, CStatic& staticCptErr)
{
	CString str;

	str.Format(_T("%ld"), p->dwTransmited);
	staticCptTrans.SetWindowText(str);	

	str.Format(_T("%ld"), p->dwReceived);
	staticCptRec.SetWindowText(str);		

	str.Format(_T("%ld"), p->dwErrors);
	staticCptErr.SetWindowText(str);		
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::DisplayF28Result()
//  
//  Purpose:
//  
//  Parameters:
//		[ucCode] : 0 -> Last result, 1:fifo result
//		[pR] : Result
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::DisplayF28Result(int ucCode, F28_RESULT* pR)
{
	CString str;

	if ((ucCode == 0) || (ucCode > 1))
	{
		if (pR->ucStatus != 0xFF)
		{
			str.Format(_T("%7.2f"), pR->fPressureValue);
			m_staticPressure_V.SetWindowText(str);
			m_staticPressure_U.SetWindowText(m_F28Light.GetPressureUnitStr(pR->ucUnitPressure));

			if (pR->ucUnitLeak == LEAK_PA)
				str.Format(_T("%7.2f"), pR->fLeakValue);
			else
				str.Format(_T("%7.4f"), pR->fLeakValue);
			m_staticLeak_V.SetWindowText(str);
			m_staticLeak_U.SetWindowText(m_F28Light.GetLeakUnitStr(pR->ucUnitLeak));

			switch (pR->ucStatus)
			{
// V2.0.0.4
			case STATUS_ALARM_JET_CHECK_PASS:
// V2.0.0.4
			case STATUS_GOOD_PART:
				m_staticPhase.SetTextColor(COLOR_DKGREEN);
				break;
			case STATUS_TEST_FAIL_PART:
			case STATUS_REF_FAIL_PART:
			default:
				m_staticPhase.SetTextColor(COLOR_RED);
				break;
			}

			m_staticPhase.SetWindowText(m_F28Light.GetResultStr(pR->ucStatus));
		}
		else
		{
			str = _T("----.--");
			m_staticPressure_V.SetWindowText(str);
			m_staticPressure_U.SetWindowText(str);

			str = _T("-----");
			m_staticLeak_V.SetWindowText(str);
			m_staticLeak_U.SetWindowText(str);
			m_staticPhase.SetWindowText(str);
		}
	}

	if (ucCode >= 1)
	{
		CString strTmp;
		str.Format(_T("%d; %d; %04d/%02d/%02d; %02d:%02d:%02d; "),
			pR->ucGroupID,
			pR->ucModuleAddr,
			pR->dateReceived.wYear,
			pR->dateReceived.wMonth,
			pR->dateReceived.wDay,
			pR->dateReceived.wHour,
			pR->dateReceived.wMinute,
			pR->dateReceived.wSecond);

		str += m_F28Light.GetResultStr(pR->ucStatus);
		str += _T(";");
		strTmp.Format(_T("%7.2f; "), pR->fPressureValue);
		strTmp += m_F28Light.GetPressureUnitStr(pR->ucUnitPressure);
		str += strTmp;
		str += _T(";");

		strTmp.Format(_T("%7.4f; "), pR->fLeakValue);
		strTmp += m_F28Light.GetLeakUnitStr(pR->ucUnitLeak);

		str += strTmp;
		str += ";";

		DisplayTxt(str);
	}

}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::DisplayTxt()
//  
//  Purpose:
//  
//  Parameters:
//		[szBuff] :
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::DisplayTxt(LPCTSTR szBuff)
{
	if (m_listBoxDsp.GetCount() > 10000)	// 10000 lignes
	{
		m_listBoxDsp.DeleteString(0);
	}
	m_listBoxDsp.AddString(szBuff);
	m_listBoxDsp.SetCurSel(m_listBoxDsp.GetCount() - 1);
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::GetModuleInfo()
//  
//  Purpose: Read & display module information 
//  
//  Parameters:
//		[sModuleID] : module to read 
//
//  Returns:	
//  
//		- F28_OK/F28_FAIL
//
//  ************************************************************************************
short CVCF28LightControlDemoDlg::GetModuleInfo(short sModuleID)
{
	short sRetCode;
	char szBuff[100];
	CString strMsg;

	USES_CONVERSION;

	sRetCode = F28_RefreshModuleInformations(sModuleID);

	if (sRetCode == F28_OK)
	{
		memset(szBuff, 0, sizeof(szBuff));
		sRetCode = F28_GetSerialNumber(sModuleID, szBuff, 20);
		if (sRetCode == F28_OK)
		{
			strMsg = _T("   . Serial number : ");
			strMsg += szBuff;
			DisplayTxt(strMsg);
		}
	}

	if (sRetCode == F28_OK)
	{
		memset(szBuff, 0, sizeof(szBuff));
		sRetCode = F28_GetModuleHardVersion(sModuleID, szBuff, 20);

		if (sRetCode == F28_OK)
		{
			strMsg.Format(_T("   . Module harware version : %s"), A2W(szBuff));
			DisplayTxt(strMsg);
		}
	}

	if (sRetCode == F28_OK)
	{
		sRetCode = F28_GetModuleSoftVersion(sModuleID, szBuff, 20);
		if (sRetCode == F28_OK)
		{
			strMsg.Format(_T("   . Module software version : %s"), A2W(szBuff));
			DisplayTxt(strMsg);
		}
	}

	return sRetCode;
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::GetEthernetInformation()
//  
//  Purpose: Read & display Ethernet information 
//  
//  Parameters:
//		[sModuleID] : module to read 
//
//  Returns:	
//  
//		- F28_OK/F28_FAIL
//
//  ************************************************************************************
short CVCF28LightControlDemoDlg::GetEthernetInformation(short sModuleID)
{
	CString strMsg;
	short sRet = F28_OK;
	ULONG ulIP = 0;

	USES_CONVERSION;

	strMsg = _T("   ......................");
	DisplayTxt(strMsg);


	if (sRet == F28_OK)
	{
		char szBuff[100];
		memset(szBuff, 0, sizeof(szBuff));
		sRet = F28_GetETHSoftVersion(sModuleID, szBuff, 30);
		if (sRet == F28_OK)
		{
			strMsg.Format(_T("   . Ethernet soft version : %s"), A2W(szBuff));
			DisplayTxt(strMsg);
		}
	}

	if (sRet == F28_OK)
	{
		char szBuff[100];
		memset(szBuff, 0, sizeof(szBuff));
		sRet = F28_GetETHHardVersion(sModuleID, szBuff, 30);
		if (sRet == F28_OK)
		{
			strMsg.Format(_T("   . Ethernet hard version : %s"), A2W(szBuff));
			DisplayTxt(strMsg);
		}
	}

	if (sRet == F28_OK)
	{
		ulIP = 0;
		sRet = F28_GetAddressIP(sModuleID, &ulIP);
		if (sRet == F28_OK)
		{
#if 1
			TCHAR cIPBuf[100];
			IN_ADDR	address = { 0 };
			address.S_un.S_addr = ulIP;
			InetNtop(AF_INET, &address, cIPBuf, sizeof(cIPBuf) / sizeof(TCHAR));
			strMsg.Format(_T("   . Ethernet IP address : %s"), cIPBuf);
#else
			char cIPBuf[100];
			unsigned short a, b, c, d;
			a = (ulIP & (0xff << 24)) >> 24;
			b = (ulIP & (0xff << 16)) >> 16;
			c = (ulIP & (0xff << 8)) >> 8;
			d = ulIP & 0xff;
			sprintf_s(cIPBuf, _countof(cIPBuf), "%hu.%hu.%hu.%hu", d, c, b, a);
			strMsg.Format(_T("   . Ethernet IP address : %s"), A2W(cIPBuf));
#endif
			DisplayTxt(strMsg);
		}
	}

	if (sRet == F28_OK)
	{
		ulIP = 0;
		sRet = F28_GetSubnetMask(sModuleID, &ulIP);
		if (sRet == F28_OK)
		{
			IN_ADDR	address = { 0 };

			TCHAR cIPBuf[100];

			address.S_un.S_addr = ulIP;
			InetNtop(AF_INET, &address, cIPBuf, sizeof(cIPBuf) / sizeof(TCHAR));

			strMsg.Format(_T("   . Ethernet Subnet mask : %s"), cIPBuf);
			DisplayTxt(strMsg);

		}
	}

	if (sRet == F28_OK)
	{
		ulIP = 0;
		sRet = F28_GetGatewayAddressIP(sModuleID, &ulIP);
		if (sRet == F28_OK)
		{
			IN_ADDR	address = { 0 };
			TCHAR cIPBuf[100];

			address.S_un.S_addr = ulIP;
			InetNtop(AF_INET, &address, cIPBuf, sizeof(cIPBuf) / sizeof(TCHAR));

			strMsg.Format(_T("   . Ethernet Gateway : %s"), cIPBuf);
			DisplayTxt(strMsg);
		}
	}


	if (sRet == F28_OK)
	{
		char szBuff[100];
		memset(szBuff, 0, sizeof(szBuff));

		sRet = F28_GetMACAddress(sModuleID, szBuff, 30);
		if (sRet == F28_OK)
		{
			strMsg.Format(_T("   . Ethernet MAC addr : %s"), A2W(szBuff));
			DisplayTxt(strMsg);
		}
	}

	strMsg = _T("   ......................");
	DisplayTxt(strMsg);

	return sRet;
}



//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnClickedChkOpen()
//  
//  Purpose: Open API (must call before use)
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnClickedChkOpen()
{
	CWaitCursor theCursor;

	if (!m_chkOpenClose.GetCheck())
	{
		// Close
		DisplayTxt(_T("API Closed !!"));

		m_bAPIOpened = FALSE;
		m_bChannelOk = FALSE;

		m_sModuleID = -1;
		m_cboModule.ResetContent();
		m_cboGroup.ResetContent();

		m_listBoxDsp1.ResetContent();


		F28_Close();
	}
	else
	{
		short sRetCode=F28_FAIL;

		// Open
		DisplayTxt(_T("F28_Init"));

		sRetCode = F28_Init();

		m_bAPIOpened = (sRetCode != F28_FAIL);

		if (m_bAPIOpened)
		{
			DisplayTxt(_T("F28_OpenChannel"));

			sRetCode = F28_OpenChannel();
			m_bChannelOk = (sRetCode == F28_OK);

			if (m_bChannelOk)
				DisplayTxt(_T("Channel opened Ok !!!"));
			else
				DisplayTxt(_T("Channel opened error !!!"));
		}
		else
		{
			DisplayTxt(_T("Driver initialization failed !!!"));
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::AddModule()
//  
//  Purpose: Add module to network 
//  
//  Parameters:
//		[szIPAddr] : IP adress 
//		[ucGroup]  : Group # 
//		[ucModule] : Module # 
//  
//  Returns:	
//  
//		- Number of module added (1 = OK)
//
//  ************************************************************************************
short CVCF28LightControlDemoDlg::AddModule(LPCTSTR szIPAddr, BYTE  ucGroup, BYTE ucModule, short* psModule)
{
	short sRetCode, sRet;
	short sModuleId;
	BYTE  ucTimeout;
	CString strBuff;
	ULONG ulIP;

	// Group = 1, Module = 1, Timeout = 3 sec
	ucTimeout = 3;

	// Get IP Address string
	IN_ADDR	address = { 0 };
	InetPton(AF_INET, szIPAddr, &address);
	ulIP = address.S_un.S_addr;

	//	 Add module 
	sModuleId = F28_AddModule(ulIP, ucModule, ucGroup, ucTimeout);

	strBuff.Format(_T("  . sModuleID #%d  : IP = %ld, Group #%d, Unit #%d, Timeout #%d(s)"), sModuleId, ulIP, ucGroup, ucModule, ucTimeout);
	DisplayTxt(strBuff);

	sRet = 0;
	if (sModuleId > 0)
	{
		// Get & display module info
		sRetCode = GetModuleInfo(sModuleId);

		if (sRetCode == F28_OK)
		{
			if (psModule)
			{
				*psModule = sModuleId;
			}

			sRet = sRet + 1;
		}

		// Get & Display Ethernet info 
		if (sRetCode == F28_OK)
		{
			sRetCode = GetEthernetInformation(sModuleId);
		}
	}
	return sRet;
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnRemoveModule()
//  
//  Purpose: Add module to network 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnRemoveModule()
{
	short sRet;

	m_cboModule.ResetContent();
	m_cboGroup.ResetContent();

	UpdateData();

	if (m_bChannelOk && m_sModuleID > 0)
	{
		sRet = F28_RemoveModule(m_sModuleID);

		if (sRet == F28_OK)
		{
			DisplayTxt(_T("Remove module OK !!!"));
			m_sModuleID = -1;
		}
		else
		{
			DisplayTxt(_T("Remove module Error !!!"));
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnClickedBtnAddModule()
//  
//  Purpose: Add module to network 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnClickedBtnAddModule()
{
	short sRet;

	m_cboModule.ResetContent();
	m_cboGroup.ResetContent();

	UpdateData();

	if (m_bChannelOk)
	{
		DisplayTxt(_T("Add modules to channel !!!"));

		sRet = AddModule(m_strIPAddr, F28_GROUP_1, F28_MODULE_ADDR_1, &m_sModuleID);

		CString str;
		if (sRet > 0)
		{
			str.Format(_T("%d"), F28_GROUP_1);
			m_cboGroup.AddString(str);

			str.Format(_T("%d"), m_sModuleID);
			m_cboModule.AddString(str);

		}

		str.Format(_T("-> Modules found = %d"), sRet);
		DisplayTxt(str);

		if (m_cboModule.GetCount() > 0)
		{
			m_cboModule.SetCurSel(0);
		}

		if (m_cboGroup.GetCount() > 0)
		{
			m_cboGroup.SetCurSel(0);
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnParameter()
//  
//  Purpose: Edit parameters 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnParameter()
{
	// Edit parameters
	int nRet = m_F28Light.Edit(FALSE);

	if ((nRet == F28_OK) && m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		// Write parameters to F28

		DisplayTxt(_T("F28_SetModuleParameters !!!"));

		F28_PARAMETERS* p = m_F28Light.GetPtrPara();

		short sRet = F28_SetModuleParameters(m_sModuleID, p);

		F28_GetModuleParameters(m_sModuleID, p);		// Read after write to update some parameters
	}
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnReadParameter()
//  
//  Purpose: Read & display parameters
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnReadParameter()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		F28_PARAMETERS* p = m_F28Light.GetPtrPara();

		DisplayTxt(_T("F28_GetModuleParameters !!!"));

		// Read parameters f
		short sRet = F28_GetModuleParameters(m_sModuleID, p);

		if (sRet == F28_OK)
		{
			// Display 
			DisplayF28Para(p);

			// Edit parameters
			int nRet = m_F28Light.Edit(FALSE);

			if ((nRet == F28_OK) && m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
			{
				// Write parameters to F28
				DisplayTxt(_T("F28_SetModuleParameters !!!"));

				F28_PARAMETERS* p = m_F28Light.GetPtrPara();

				short sRet = F28_SetModuleParameters(m_sModuleID, p);
				F28_GetModuleParameters(m_sModuleID, p);		// Read after write to update some parameters
			}
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnStart()
//  
//  Purpose: Start cycle current module 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnStart()
{
	CString str;

	USES_CONVERSION;

	if (m_cboModule.GetCount() < 1) return;

	m_cboModule.GetLBText(0, str);
	m_sModuleID = atoi(W2A(str));

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		if (F28_StartCycle(m_sModuleID) == F28_OK)
		{
			str.Format(_T(" -> Start Cycle sModuleID # %d"), m_sModuleID);
			DisplayTxt(str);

			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			m_staticPhase.SetTextColor(COLOR_BLACK);

		}
		else
		{
			str.Format(_T(" -> Not connected sModuleID # %d"), m_sModuleID);
			DisplayTxt(str);
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnReset()
//  
//  Purpose: Reset cycle current module 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnReset()
{
	CString str;

	USES_CONVERSION;

	if (m_cboModule.GetCount() < 1) return;


	m_cboModule.GetLBText(0, str);
	m_sModuleID = atoi(W2A(str));

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		F28_StopCycle(m_sModuleID);

		m_bRealtimeRunning = FALSE;

		str.Format(_T(" -> Stop Cycle sModuleID # %d"), m_sModuleID);

		m_staticPhase.SetTextColor(COLOR_BLACK);

		str = _T("----.--");
		m_staticPressure_V.SetWindowText(str);
		m_staticPressure_U.SetWindowText(str);

		str = _T("-----");
		m_staticLeak_V.SetWindowText(str);
		m_staticLeak_U.SetWindowText(str);
		m_staticPhase.SetWindowText(str);
	}
	else
	{
		str.Format(_T(" -> Not connected sModuleID # %d"), m_sModuleID);
	}

	DisplayTxt(str);

}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnLastRslt()
//  
//  Purpose: Read & display last result 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnLastRslt()
{
	short sRetCode = F28_FAIL;

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		F28_RESULT*	pR = m_F28Light.GetPtrResult();

		sRetCode = F28_GetLastResult(m_sModuleID, pR);

		if (sRetCode == F28_OK)
		{
			DisplayF28Result(1, pR);
		}
	}
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnStartGroup()
//  
//  Purpose: Start cycle for selected group 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************

void CVCF28LightControlDemoDlg::OnBnClickedBtnStartGroup()
{
	short sGroup, sRetCode;
	CString str, strErr;

	USES_CONVERSION;

	m_cboGroup.GetLBText(0, str);
	sGroup = atoi(W2A(str));

	if (sGroup > 0)
	{
		sRetCode = F28_StartCycleByGroup((BYTE)sGroup);
		strErr = (sRetCode == F28_OK) ? _T("   -> Ok") : _T("   -> Error");

		str.Format(_T(" -> Start Cycle, channel # %d %s"), sGroup, strErr);
		DisplayTxt(str);
	}
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnResetGroup()
//  
//  Purpose: Reset cycle for selected group 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnResetGroup()
{
	short sGroup, sRetCode;
	CString str, strErr;

	USES_CONVERSION;

	m_cboGroup.GetLBText(0, str);
	sGroup = atoi(W2A(str));

	if (sGroup > 0)
	{
		sRetCode = F28_StopCycleByGroup((BYTE)sGroup);
		strErr = (sRetCode == F28_OK) ? _T("   -> Ok") : _T("   -> Error");

		str.Format(_T(" -> Stop Cycle, channel # %d %s"), sGroup, strErr);
		DisplayTxt(str);
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnClear()
//  
//  Purpose: Read & display parameters
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************

void CVCF28LightControlDemoDlg::OnBnClickedBtnClear()
{
	m_listBoxDsp.ResetContent();	
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnResetFifo()
//  
//  Purpose: Reset fifo 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnResetFifo()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		short sRetCode = F28_ClearFIFOResults(m_sModuleID);

		// Count = 1 if fifo has result

		WORD wCount = F28_GetResultsCount(m_sModuleID);

		CString str;

		str.Format(_T("%d"), wCount);
	
		m_staticRsltCount.SetWindowText(str);
	}
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnReadFifo()
//  
//  Purpose: Read fifo 
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnReadFifo()
{

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		WORD wCount = F28_GetResultsCount(m_sModuleID);

		F28_RESULT*	pR = m_F28Light.GetPtrResult();

		//' Read fifo if demands
		if (wCount > 0)
		{
			short sRetCode = F28_GetNextResult(m_sModuleID, pR);
			CString str;

			if (sRetCode == F28_OK)
			{
				DisplayF28Result(1, pR);
			}

			wCount = F28_GetResultsCount(m_sModuleID);

			str.Format(_T("%d"), wCount);
			m_staticRsltCount.SetWindowText(str);
		}
		else
		{
			DisplayTxt(_T("No fifo Result avaible !!!"));
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnAutoZero()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnAutoZero()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		CString str;
		m_edtDumpTime.GetWindowText(str);

		USES_CONVERSION;

		float fDumpTime = (float)atof(W2A(str));

		short sRetCode = F28_StartAutoZeroPressure(m_sModuleID, fDumpTime);

		if (sRetCode != F28_OK)
		{
			DisplayTxt(_T("Auto zero error !!!"));
		}
		else
		{
			DisplayTxt(_T("Auto zero OK !!!"));
		}

	}
}

// 1.402 Regulator Adjust
//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnRegAdjust()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnRegAdjust()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		short sRetCode = F28_StartRegulatorAdjust(m_sModuleID);

		if (sRetCode == F28_OK)
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			DisplayTxt(_T("Start Regulator Adjust Ok !!"));
		}
		else
		{
			DisplayTxt(_T("Start Regulator Adjust Error !!"));
		}
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnOffset()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnOffset()
{
	UpdateData();

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{

		// 1.501 Display message before Start
		if (!AfxMessageBox(_T("Put master No leak\n OK to Continue, Cancel to abort"), MB_OKCANCEL | MB_ICONQUESTION) != IDOK) return;


		BOOL bRet = m_autocal.StartCal(m_sModuleID, m_autocal.MODE_OFFSET, (WORD)m_nCycleNumber, (WORD)m_nInterCycle, m_fOffsetMax);

		if (bRet)
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			DisplayTxt(_T("Start Offset Cal Ok !!"));
		}
		else
		{
			DisplayTxt(_T("Start Offset Cal Error!!"));
		}

		m_staticPhase.SetTextColor(COLOR_BLACK);

	}
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnVolumeOffset()
//  
//  Purpose:
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnVolumeOffset()
{
	UpdateData();

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{

		// 1.501 Display message before Start
		if (!AfxMessageBox(_T("Put master No leak\n OK to Continue, Cancel to abort"), MB_OKCANCEL | MB_ICONQUESTION) != IDOK) return;


		BOOL bRet = m_autocal.StartCal(m_sModuleID, m_autocal.MODE_OFFSET_VOLUME, (WORD)m_nCycleNumber, (WORD)m_nInterCycle, m_fOffsetMax,
										m_fCalLeak, m_fCalPress, m_fVolumeMin, m_fVolumeMax);	

		if (bRet)
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;


			DisplayTxt(_T("Start Offset + Volume Cal Ok !!"));
		}
		else
		{
			DisplayTxt(_T("Start Offset + Volume Cal Error!!"));
		}

		m_staticPhase.SetTextColor(COLOR_BLACK);

	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnStopCal()
//  
//  Purpose: Abort Calibration
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnStopCal()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		CString str;

		if (m_autocal.IsCalRunning())
		{
			BOOL bRet = m_autocal.StopCal();

			if (bRet)
			{
				DisplayTxt(_T("Abort Cal Ok !!"));

				BYTE ucPhaseCal = m_autocal.GetPhase();
				str = m_autocal.GetPhaseStr(ucPhaseCal);
			}
			else
			{
				str = _T("...");
				DisplayTxt(_T("Abort Cal Error!!"));

			}
			m_staticPhaseCal.SetWindowText(str);
		}
		if (m_autoratio.IsAutoRatioRunning())
		{
			BOOL bRet = m_autoratio.StopAutoRatio();

			if (bRet)
			{
				DisplayTxt(_T("Abort Auto-Ratio Ok !!"));

				BYTE ucPhaseAutoRatio = m_autoratio.GetPhase();
				str = m_autoratio.GetPhaseStr(ucPhaseAutoRatio);
			}
			else
			{
				str = _T("...");
				DisplayTxt(_T("Abort Auto-Ratio Error!!"));
			}
			m_staticPhaseCal.SetWindowText(str);
		}
		if (m_easyauto.IsEasyAutoLearningRunning())
		{
			BOOL bRet = m_easyauto.StopEasyAutoLearning();

			if (bRet)
			{
				DisplayTxt(_T("Abort Easy Auto Learning Ok !!"));

				BYTE ucPhaseEasyAuto = m_easyauto.GetPhase();
				str = m_easyauto.GetPhaseStr(ucPhaseEasyAuto);
			}
			else
			{
				str = _T("...");
				DisplayTxt(_T("Abort Easy Auto Learning Error!!"));
			}
			m_staticPhaseCal.SetWindowText(str);
		}

	}
}

// **************************************************************************************
// CVCF28LightControlDemoDlg::OnTimer()
// 
// Purpose       : Cyclic Timer 
//				- 100 ms timer, Run AutoCal + Realtime measurement
//				- 1000 ms timer keep alicve
// 
// Parameters    : 
//         
// 
// Return        : void
// 
// **************************************************************************************
void CVCF28LightControlDemoDlg::OnTimer(UINT_PTR nIDEvent)
{
	// 1.404 - Timer 1000 ms to check connection, if lost -> Reset ethernet board
	// 1.404 - Keep Alive function
	if (nIDEvent == TMR_1000_MS)
	{
		if (m_bChannelOk && (m_sModuleID > 0))
		{
			BOOL bOn = KeepAlive(m_sModuleID, m_staticCptTrans, m_staticCptRec, m_staticCptErr);
			if (bOn)
				m_chkConnect.SetCheck(1);
			else
				m_chkConnect.SetCheck(0);

		}

		// Keep alive modules #1 & #2
		int n = m_listBoxDsp1.GetCount();
		if (n > 0)
		{
			CString strBuff;
			short sModuleId = 0;
			BOOL bOn = FALSE;

			USES_CONVERSION;

			for (int i = 0; i < n; i++)
			{
				m_listBoxDsp1.GetText(i, strBuff);
				sModuleId = atoi(W2A(strBuff));

				if (!i)
				{
					bOn = KeepAlive(sModuleId, m_staticCptTrans1, m_staticCptRec1, m_staticCptErr1);
					if (bOn)
						m_chkConnect1.SetCheck(1);
					else
						m_chkConnect1.SetCheck(0);
				}
				else
				{
					bOn = KeepAlive(sModuleId, m_staticCptTrans2, m_staticCptRec2, m_staticCptErr2);
					if (bOn)
						m_chkConnect2.SetCheck(1);
					else
						m_chkConnect2.SetCheck(0);

				}
			}
		}
	}
	// Timer cycle 100 ms
	else if (nIDEvent == TMR_100_MS)
	{
		if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
		{
			CString str;
			if (m_bRealtimeRunning)
			{
				// 2.013 AutoRatio
				// 1- Run Auto Ratio
				BYTE ucPhaseAutoRatio = m_autoratio.GetPhase();

				if (m_autoratio.IsAutoRatioRunning())
				{
					m_staticPhase.SetTextColor(COLOR_BLACK);

					str = m_autoratio.GetPhaseStr(ucPhaseAutoRatio);
					m_staticPhaseCal.SetWindowText(str);

					if (m_autoratio.RunAutoRatio())		// End auto ratio
					{
						// ' 1- Read auto rati errcode
						if (m_autoratio.GetAlarm() > 0)
						{
							str = _T("Auto-Ratio Alarm !!!");
							DisplayTxt(str);
							m_staticPhaseCal.SetWindowText(str);
						}
						else
						{
							//' 2- if no erreur -> Read & Save parameters

							F28_PARAMETERS* p = m_F28Light.GetPtrPara();

							DisplayTxt(_T("F28_GetModuleParameters !!!"));

							// Read parameters f
							short sRet = F28_GetModuleParameters(m_sModuleID, p);

							str = m_F28Light.GetRatioStr();

							DisplayTxt(str);
							m_staticPhaseCal.SetWindowText(str);
						}
					}
				}

				// 2- Run Easy Auto Learning
				BYTE ucPhaseEasyAuto = m_easyauto.GetPhase();

				if (m_easyauto.IsEasyAutoLearningRunning())
				{
					m_staticPhase.SetTextColor(COLOR_BLACK);

					str = m_easyauto.GetPhaseStr(ucPhaseEasyAuto);
					m_staticPhaseCal.SetWindowText(str);

					if (m_easyauto.RunEasyAutoLearning())		// End easy auto learning
					{
						// ' 1- Read errcode
						if (m_easyauto.GetAlarm() > 0)
						{
							str = _T("Easy Auto Learning Alarm !!!");
							DisplayTxt(str);
							m_staticPhaseCal.SetWindowText(str);
						}
						else
						{
							//' 2- if no erreur -> Read & Save parameters

							F28_PARAMETERS* p = m_F28Light.GetPtrPara();

							DisplayTxt(_T("F28_GetModuleParameters !!!"));

							// Read parameters f
							short sRet = F28_GetModuleParameters(m_sModuleID, p);

							str = m_F28Light.GetRatioStr();

							DisplayTxt(str);
							m_staticPhaseCal.SetWindowText(str);
						}
					}
				}

				// 1.402 AutoCal Offset + Volume
				// 3- Run Auto Calibration

				BYTE ucPhaseCal = m_autocal.GetPhase();

				if (m_autocal.IsCalRunning())					// (ucPhaseCal != m_autocal.AUTO_IDDLE)
				{
					m_staticPhase.SetTextColor(COLOR_BLACK);

					str = m_autocal.GetPhaseStr(ucPhaseCal);
					m_staticPhaseCal.SetWindowText(str);

					if (m_autocal.IsWaitingMasterLeak())		// (ucPhaseCal == m_autocal.AUTO_WAIT_MASTER_LEAK)
					{
						KillTimer(TMR_100_MS);

						if (AfxMessageBox(_T("Put master leak\n OK to Continue, Cancel to abort"), MB_OKCANCEL | MB_ICONQUESTION) == IDOK)
						{
							m_autocal.RunCalContinue(TRUE);
						}
						else
						{
							m_autocal.RunCalContinue(FALSE);
						}

						ucPhaseCal = m_autocal.GetPhase();

						str = m_autocal.GetPhaseStr(ucPhaseCal);
						m_staticPhaseCal.SetWindowText(str);

						SetTimer(TMR_100_MS, 100, NULL);
					}

					if (m_autocal.RunCal())		// End auto calibration
					{
						// ' 1- Read auto calibration errcode
						if (m_autocal.GetAlarm() > 0)
						{
							str = _T("Calibration Alarm !!!");
							DisplayTxt(str);
							m_staticPhaseCal.SetWindowText(str);
						}
						else
						{
							//' 2- if no erreur -> Read & Save parameters

							F28_PARAMETERS* p = m_F28Light.GetPtrPara();

							DisplayTxt(_T("F28_GetModuleParameters !!!"));

							// Read parameters f
							short sRet = F28_GetModuleParameters(m_sModuleID, p);

							str = m_F28Light.GetOffsetVolumeStr();

							DisplayTxt(str);
							m_staticPhaseCal.SetWindowText(str);
						}
					}
				}

				// 4- Read & display realtime Data for m_sModuleID

				F28_REALTIME_CYCLE* p = m_F28Light.GetPtrRealTime();
				F28_RESULT*	pR = m_F28Light.GetPtrResult();

				short sRetCode = F28_GetRealTimeData(m_sModuleID, p);

				if (sRetCode == F28_OK)
				{
					// 1.403 :NEW:(1)
					if (m_autocal.IsRunningVolumeCal())
					{
						p->fLeakValue *= 1000.0;
						p->ucUnitLeak = LEAK_PASEC;
					}

					DisplayF28RealTime(p);

					static BOOL bReadLastRslt = FALSE;

					// End of cycle
					if (p->ucEndCycle == FLAG_END_OF_CYCLE)					// > 0
					{
						// 1.400 - Stop real time reading at EOC
						if (ucPhaseCal == m_autocal.AUTO_IDDLE && ucPhaseAutoRatio == m_autoratio.AUTO_RATIO_IDDLE && ucPhaseEasyAuto == m_easyauto.EASY_AUTO_IDDLE)
						{
							m_bRealtimeRunning = FALSE;
						}

						if (!bReadLastRslt)
						{
							bReadLastRslt = TRUE;

							// Read & display last result
							sRetCode = F28_GetLastResult(m_sModuleID, pR);
							if (sRetCode == F28_OK)
							{
								// 1.403 :NEW:(2)
								if (m_autocal.IsRunningVolumeCal())
								{
									pR->fLeakValue *= 1000.0;
									pR->ucUnitLeak = LEAK_PASEC;
								}

								DisplayF28Result(0, pR);
							}
						}

						WORD wCount = F28_GetResultsCount(m_sModuleID);
						str.Format(_T("%d"), wCount);
						m_staticRsltCount.SetWindowText(str);

						// Read fifo if demands
						if (m_chkFifo.GetCheck() && (wCount > 0))
						{
							short sRetCode = F28_GetNextResult(m_sModuleID, pR);
							CString str;

							if (sRetCode == F28_OK)
							{
								// 1.403 :NEW:(3)
								if (m_autocal.IsRunningVolumeCal())
								{
									pR->fLeakValue *= 1000.0;
									pR->ucUnitLeak = LEAK_PASEC;
								}

								DisplayF28Result(1, pR);
							}

							wCount = F28_GetResultsCount(m_sModuleID);
							str.Format(_T("%d"), wCount);
							m_staticRsltCount.SetWindowText(str);
						}
					}
					else
					{
						bReadLastRslt = FALSE;
					}
				}
			}
		}

		// 1.404 - Cycle modules #1 & #2, display status only
		int n = m_listBoxDsp1.GetCount();
		if (n > 0)
		{
			CString strBuff;
			short sModuleId = 0;
			BOOL bOn = FALSE;

			USES_CONVERSION;

			for (int i = 0; i < n; i++)
			{
				m_listBoxDsp1.GetText(i, strBuff);
				sModuleId = atoi(W2A(strBuff));

				F28_REALTIME_CYCLE r = { 0 };
				short sRetCode = F28_GetRealTimeData(sModuleId, &r);
				if (sRetCode == F28_OK)
				{
					CString str;
					str.Format(_T("<%d>:EOC=%d->%s"), sModuleId, r.ucEndCycle, m_F28Light.GetPhaseStr(r.ucStatus));
					if (!i)
						m_staticPhase1.SetWindowText(str);
					else
						m_staticPhase2.SetWindowText(str);
				}

			}
		}
	}

	CDialogEx::OnTimer(nIDEvent);
}

// *************************************************************************************
// 1.404 
// *************************************************************************************

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::KeepAlive()
//  
//  Purpose: Run continuos communication to keep alive, if coonexion is lost -> send F28_ResetEthernetModule
//  
//  Parameters:
//		[sModuleID] :
//		[staticCptTrans] :
//		[staticCptRec] :
//		[staticCptErr] :
//  
//  Returns:	BOOL
//  
//		
//  ************************************************************************************
BOOL CVCF28LightControlDemoDlg::KeepAlive(short sModuleID, CStatic& staticCptTrans, CStatic& staticCptRec, CStatic& staticCptErr)
{
	BOOL bRet = FALSE;

	if (m_bChannelOk && (sModuleID > 0))
	{
		if (!F28_IsModuleConnected(sModuleID))
		{
			bRet = FALSE;

			// Reset ethernet module
			F28_ResetEthernetModule(sModuleID);
		}
		else
		{
			bRet = TRUE;

			F28_COMMUNICATION_STATISTICS rCpt = { 0 };
			short sRetCode = F28_GetCommunicationStatistics(sModuleID, &rCpt);
			if (sRetCode == F28_OK)
			{
				CString str;
				str.Format(_T("%ld"), rCpt.dwTransmited);
				staticCptTrans.SetWindowText(str);

				str.Format(_T("%ld"), rCpt.dwReceived);
				staticCptRec.SetWindowText(str);

				str.Format(_T("%ld"), rCpt.dwErrors);
				staticCptErr.SetWindowText(str);
			}
		}
	}
	return bRet;
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnAddModule1()
//  
//  Purpose: Add Module 1 to network
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnAddModule1()
{
	short sModuleID = 0;

	UpdateData();

	if (m_bChannelOk)
	{
		DisplayTxt(_T("Add module #1 to network !!!"));

		short sRet = AddModule(m_strIPAddr1, F28_GROUP_1, F28_MODULE_ADDR_2, &sModuleID);

		CString str;
		if (sRet > 0)
		{
			str.Format(_T("%d"), sModuleID);
			m_listBoxDsp1.AddString(str);
		}

		str.Format(_T("-> Modules found = %d"), sRet);
		DisplayTxt(str);
	}
}


//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnAddModule2()
//  
//  Purpose: Add Module 2 to network
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnAddModule2()
{
	short sModuleID = 0;

	UpdateData();

	if (m_bChannelOk)
	{
		DisplayTxt(_T("Add module #2 to network !!!"));

		short sRet = AddModule(m_strIPAddr2, F28_GROUP_1, F28_MODULE_ADDR_3, &sModuleID);

		CString str;
		if (sRet > 0)
		{
			str.Format(_T("%d"), sModuleID);
			m_listBoxDsp1.AddString(str);
		}

		str.Format(_T("-> Modules found = %d"), sRet);
		DisplayTxt(str);
	}
}



//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnStartAll()
//  
//  Purpose: Start cycle for several heads
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnStartAll()
{
	CString strBuff;
	short sModuleId, sRet;
	
	USES_CONVERSION;
	
	if (!m_bChannelOk) return;
	
	int n = m_listBoxDsp1.GetCount();
	
	if (n > 0)
	{
		for (int i = 0; i < n; i++)
		{
			m_listBoxDsp1.GetText(i, strBuff);
			sModuleId = atoi(W2A(strBuff));

			if (F28_IsModuleConnected(sModuleId))
			{
				sRet = F28_StartCycle(sModuleId);

				if (sRet == F28_OK)
				{
					strBuff.Format(_T("Start Ok -> %d"), sModuleId);
				}
				else
				{
					strBuff.Format(_T("Start error -> %d "), sModuleId);
				}
				DisplayTxt(strBuff);
			}
		}
	}
}

//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnOffsetAll()
//  
//  Purpose: Start offset calibration for several heads
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnOffsetAll()
{
	CString strBuff;
	short sModuleId, sRet;

	UpdateData();

	USES_CONVERSION;

	if (!m_bChannelOk) return;

	int n = m_listBoxDsp1.GetCount();

	if (n > 0)
	{
		for (int i = 0; i < n; i++)
		{
			m_listBoxDsp1.GetText(i, strBuff);
			sModuleId = atoi(W2A(strBuff));

			if (F28_IsModuleConnected(sModuleId))
			{
				sRet = F28_StartAutoCalOffsetOnly(sModuleId, (WORD)m_nCycleNumber, (WORD)m_nInterCycle, m_fOffsetMax);

				if (sRet == F28_OK)
				{
					strBuff.Format(_T("Start Ok -> %d"), sModuleId);
				}
				else
				{
					strBuff.Format(_T("Start error -> %d "), sModuleId);
				}
				DisplayTxt(strBuff);
			}
		}
	}
}

// 1.500 - Electronic Regulator learn with Auto zero
//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnRegElect()
//  
//  Purpose: Start Electronoic regulator learn + Auto zero
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnRegElect()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		CString str;

		// Get auto zero dump time
		m_edtDumpTime.GetWindowText(str);

		USES_CONVERSION;

		float fDumpTime = (float)atof(W2A(str));

		short sRetCode = F28_StartLearningRegulator(m_sModuleID, fDumpTime);

		if (sRetCode != F28_OK)
		{
			DisplayTxt(_T("Electronic regulator learning error !!!"));
		}
		else
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			DisplayTxt(_T("Electronic regulator learning OK !!!"));
			m_staticPhase.SetTextColor(COLOR_BLACK);
		}
	}
}

// V2.0.0.4
//  ************************************************************************************
//  CVCF28LightControlDemoDlg::OnBnClickedBtnJetCheck()
//  
//  Purpose: Start jet check
//  
//  Parameters:
//  
//  Returns:	none
//  
//		
//  ************************************************************************************
void CVCF28LightControlDemoDlg::OnBnClickedBtnJetCheck()
{
	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		CString str;

		short sRetCode = F28_StartJetCheck(m_sModuleID);

		if (sRetCode != F28_OK)
		{
			DisplayTxt(_T("Jet check error !!!"));
		}
		else
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			DisplayTxt(_T("Jet check OK !!!"));
			m_staticPhase.SetTextColor(COLOR_BLACK);
		}
	}
}

void CVCF28LightControlDemoDlg::OnBnClickedBtnAutoRatio()
{
	UpdateData();

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		F28_PARAMETERS*	pPara	= m_F28Light.GetPtrPara();

		BOOL bRet = m_autoratio.StartAutoRatio(m_sModuleID, (WORD)m_nCycleNumber, (WORD)m_nInterCycle, pPara->fCoeffMax, pPara->fCoeffMin);

		if (bRet)
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			DisplayTxt(_T("Start Auto-Ratio Ok !!"));
		}
		else
		{
			DisplayTxt(_T("Start Auto-Ratio Error!!"));
		}

		m_staticPhase.SetTextColor(COLOR_BLACK);
	}
}

void CVCF28LightControlDemoDlg::OnBnClickedBtnAutoRatioAll()
{
	CString strBuff;
	short sModuleId;
	short sRet;

	UpdateData();

	USES_CONVERSION;

	if (!m_bChannelOk) return;

	int n = m_listBoxDsp1.GetCount();

	if (n > 0)
	{
		for (int i = 0; i < n; i++)
		{
			m_listBoxDsp1.GetText(i, strBuff);
			sModuleId = atoi(W2A(strBuff));

			if (F28_IsModuleConnected(sModuleId))
			{
				F28_PARAMETERS*	pPara = m_F28Light.GetPtrPara();

				sRet = F28_StartAutoRatio(sModuleId, (WORD)m_nCycleNumber, (WORD)m_nInterCycle, pPara->fCoeffMax, pPara->fCoeffMin);

				if (sRet == F28_OK)
				{
					strBuff.Format(_T("Start Auto-Ratio Ok -> %d"), sModuleId);
				}
				else
				{
					strBuff.Format(_T("Start Auto-Ratio error -> %d "), sModuleId);
				}
				DisplayTxt(strBuff);
			}
		}
	}
}

void CVCF28LightControlDemoDlg::OnBnClickedBtnEasyAutoLearning()
{
	UpdateData();

	if (m_bChannelOk && F28_IsModuleConnected(m_sModuleID))
	{
		BOOL bRet = m_easyauto.StartEasyAutoLearning(m_sModuleID, (WORD)m_nCycleNumber, (WORD)m_nInterCycle);

		if (bRet)
		{
			// Start timer & Real time
			m_bRealtimeRunning = TRUE;

			DisplayTxt(_T("Start Easy Auto Learning Ok !!"));
		}
		else
		{
			DisplayTxt(_T("Start Easy Auto Learning Error!!"));
		}

		m_staticPhase.SetTextColor(COLOR_BLACK);
	}
}

void CVCF28LightControlDemoDlg::OnBnClickedBtnEasyAutoLearningAll()
{
	CString strBuff;
	short sModuleId;
	short sRet;

	UpdateData();

	USES_CONVERSION;

	if (!m_bChannelOk) return;

	int n = m_listBoxDsp1.GetCount();

	if (n > 0)
	{
		for (int i = 0; i < n; i++)
		{
			m_listBoxDsp1.GetText(i, strBuff);
			sModuleId = atoi(W2A(strBuff));

			if (F28_IsModuleConnected(sModuleId))
			{
				sRet = F28_StartEasyAutoLearning(sModuleId, (WORD)m_nCycleNumber, (WORD)m_nInterCycle);

				if (sRet == F28_OK)
				{
					strBuff.Format(_T("Start Easy Auto Learning Ok -> %d"), sModuleId);
				}
				else
				{
					strBuff.Format(_T("Start Easy Auto Learning error -> %d "), sModuleId);
				}
				DisplayTxt(strBuff);
			}
		}
	}
}
