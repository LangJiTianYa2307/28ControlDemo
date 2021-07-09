#pragma once


/////////////////////////////////////////////////////////////////////////////
// CDlgPar dialog

class CDlgPar : public CDialog
{
// Construction
public:
	CDlgPar(CWnd* pParent = NULL);   // standard constructor
	void SetPara(CF28Light*	pAteq, F28_PARAMETERS* pPar);// { m_pPar = pPar;}


// Dialog Data
	//{{AFX_DATA(CDlgPar)
	enum { IDD = IDD_DLG_PAR };
	CButton	m_btnOk;
	CButton	m_btnCancel;
	CComboBox	m_cboUnitVolume;
	CComboBox	m_cboUnitPress;
	CComboBox	m_cboUnitLeak;
	CComboBox	m_cboTypeTest;
	CComboBox	m_cboCalcVol;
	float	m_fLeakMax;
	float	m_fLeakMin;
	float	m_fP1Max;
	float	m_fP1Min;
	float	m_fStabTime;
	float	m_fTestTime;
	float	m_fVolume;
	float	m_fDumpTime;
	float	m_fFillTime;
	float	m_fAtmStd;
	float	m_fFilterTime;
	float	m_fTempStd;
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CDlgPar)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	void SetBit(WORD& wOption, int nNum, BOOL bState);

	// Generated message map functions
	//{{AFX_MSG(CDlgPar)
	virtual BOOL OnInitDialog();
	virtual void OnCancel();
	virtual void OnOK();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()


private:
	F28_PARAMETERS* m_pPar;
	CF28Light*		m_pAteq;

public:
	float m_fLeakOffset;
	CComboBox m_cboFillType;
	float m_fRatioMax;
	float m_fRatioMin;
	float m_fCoeffMax;
	float m_fCoeffMin;
	float m_fNominalValue;
	float m_fSetFill;
	float m_fFillVolumeTime;
	float m_fTransfertTime;

	CStatic m_staticSepLeak;
	CStatic m_staticPressSep;
	CStatic m_staticTimePress;
	CStatic m_staticVolSep;
//	CStatic m_staticAteq;
	BOOL m_bSign;
	BOOL m_bPressureCorr;
	BOOL m_bNoNegative;
	BOOL m_bElectronicRegulator;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

