// *************************************************************
// VCF28LightControlDemoDlg.h : header file
// *************************************************************

#pragma once

#include "F28Light.h"

#include "afxwin.h"
#include "GradientStatic.h"
#include "AutoCal.h"		// 1.400
#include "AutoRatio.h"		// 2.013
#include "EasyAutoLearning.h"

#define COLOR_WHITE			RGB(255, 255, 255)
#define COLOR_BLACK			RGB(0, 0, 0)
#define COLOR_RED			RGB(255, 0, 0)
#define COLOR_DKRED			RGB(128, 0, 0)
#define COLOR_BLUE			RGB(0, 0, 255)
#define COLOR_DKBLUE		RGB(0, 0, 128)
#define COLOR_CYAN			RGB(0, 255, 255)
#define COLOR_DKCYAN		RGB(0, 128, 128)
#define COLOR_GREEN			RGB(0, 255, 0)
#define COLOR_DKGREEN		RGB(0, 128, 0)
#define COLOR_MAGENTA		RGB(255, 0, 255)

// CVCF28LightControlDemoDlg dialog
class CVCF28LightControlDemoDlg : public CDialogEx
{
// Construction
public:
	CVCF28LightControlDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_F28LCTRL_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support

// Implementation
protected:
	HICON m_hIcon;
	CFont*	m_pBoldFont;

	CAutoCal m_autocal;				// 1.400 Auto Calibration
	CAutoRatio m_autoratio;			// 2.013 Auto Ratio
	CEasyAutoLearning m_easyauto;

	CF28Light m_F28Light;
	short	m_sModuleID;
	BOOL	m_bAPIOpened;
	BOOL	m_bChannelOk;
	BOOL	m_bRealtimeRunning;

	void DisplayCounter(F28_COMMUNICATION_STATISTICS* p, CStatic& staticCptTrans, CStatic& staticCptRec, CStatic& staticCptErr);
	void DisplayF28RealTime(F28_REALTIME_CYCLE* p);
	void DisplayF28Result(int nCode, F28_RESULT* pR);
	void DisplayTxt(LPCTSTR szBuff);
	void DisplayF28Para(F28_PARAMETERS* p);

	short GetModuleInfo(short sModuleID);
	short AddModule(LPCTSTR szIPAddr, BYTE  ucGroup, BYTE ucModule, short* psModule=NULL);
	short GetEthernetInformation(short sModuleID);
	void SetRealTime(BOOL bActivate);

	BOOL KeepAlive(short sModuleID, CStatic& staticCptTrans, CStatic& staticCptRec, CStatic& staticCptErr);

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnClickedBtnAddModule();
	afx_msg void OnClickedChkOpen();
	afx_msg void OnBnClickedBtnParameter();
	afx_msg void OnBnClickedBtnStart();
	afx_msg void OnBnClickedBtnReset();
	afx_msg void OnBnClickedBtnLastRslt();
	afx_msg void OnBnClickedBtnStartGroup();
	afx_msg void OnBnClickedBtnResetGroup();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnBnClickedBtnReadParameter();
	afx_msg void OnBnClickedBtnClear();
	afx_msg void OnBnClickedBtnResetFifo();
	afx_msg void OnBnClickedBtnReadFifo();
	afx_msg void OnBnClickedBtnAutoZero();
	afx_msg void OnBnClickedBtnRegAdjust();
	afx_msg void OnBnClickedBtnOffset();
	afx_msg void OnBnClickedBtnVolumeOffset();
	afx_msg void OnBnClickedBtnStopCal();
	afx_msg void OnBnClickedBtnAddModule1();
	afx_msg void OnBnClickedBtnAddModule2();
//	afx_msg void OnBnClickedBtnRemoveModules();
	afx_msg void OnBnClickedBtnStartAll();
	afx_msg void OnBnClickedBtnOffsetAll();
	afx_msg void OnBnClickedBtnRegElect();
	afx_msg void OnBnClickedBtnRemoveModule();
	afx_msg void OnBnClickedBtnJetCheck();
	afx_msg void OnBnClickedBtnAutoRatio();
	afx_msg void OnBnClickedBtnAutoRatioAll();
	afx_msg void OnBnClickedBtnEasyAutoLearning();
	DECLARE_MESSAGE_MAP()
private:
	CEdit m_edtDllVer;
	afx_msg void OnDestroy();
	CButton m_chkOpenClose;
	CListBox m_listBoxDsp;
	CComboBox m_cboModule;
	CComboBox m_cboGroup;
	CString m_strIPAddr;
	CStatic m_staticATM_U;
	CStatic m_staticATM_V;
	CStatic m_staticLeak_U;
	CStatic m_staticLeak_V;
	CGradientStatic m_staticPhase;
	CStatic m_staticPressure_U;
	CStatic m_staticPressure_V;
	CStatic m_staticTemp_U;
	CStatic m_staticTemp_V;
	CStatic m_staticCptErr;
	CStatic m_staticCptRec;
	CStatic m_staticCptTrans;
	CStatic m_staticRsltCount;
	CEdit m_edtDumpTime;
	int m_nInterCycle;
	int m_nCycleNumber;
	float m_fCalLeak;
	float m_fCalPress;
	float m_fOffsetMax;
	float m_fVolumeMax;
	float m_fVolumeMin;
	CGradientStatic m_staticPhaseCal;
	CButton m_chkFifo;
	CButton m_chkConnect;
	CString m_strIPAddr1;
	CString m_strIPAddr2;
	CStatic m_staticCptErr1;
	CStatic m_staticCptErr2;
	CStatic m_staticPhase1;
	CStatic m_staticPhase2;
	CStatic m_staticCptRec1;
	CStatic m_staticCptRec2;
	CStatic m_staticCptTrans1;
	CStatic m_staticCptTrans2;
	CListBox m_listBoxDsp1;
	CButton m_chkConnect1;
	CButton m_chkConnect2;
public:
	afx_msg void OnBnClickedBtnEasyAutoLearningAll();
};
