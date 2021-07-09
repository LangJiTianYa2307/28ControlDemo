// ******************************************************************************
// DlgPar.cpp : implementation file
// 23/12/15 1.500 - Add Electronic Regulator
//						. Test type
//						. Fill mode
// ******************************************************************************

#include "stdafx.h"
#include "VCF28LightControlDemo.h"
#include "F28Light.h"
#include "DlgPar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define	MASK(i)				(1<<(i))		// conversion bit--> masque
#define	BIT(x,n)			(((x) & MASK(n)) >> (n))

// 1.500 Uses with "wOptions" parameter
enum eOptions
{
	BIT_SIGN = 0,					// Sign
	BIT_NO_NEGATIVE,				// No Negative
	BIT_MODE_INDIRECT,				// Reserved
	BIT_AUTOZERO_PIEZO2,			// Reserved
	BIT_PRESSURE_COMP,				// Pressure compensation
	BIT_ELECTRONIC_REGULATOR		// 1.500 Electronic Regulator in use
};

// 1.500  Uses with "wFillMode" parameter
enum eFillMode
{
	FILL_STANDARD,
	FILL_AUTO,
	FILL_INSTRUCTION,
	FILL_RAMP,						// Fill with Ramp
	FILL_RAMP_CONTROL,
	FILL_EASY,
	FILL_EASY_AUTO,
};

/////////////////////////////////////////////////////////////////////////////
// CDlgPar dialog


CDlgPar::CDlgPar(CWnd* pParent /*=NULL*/)
	: CDialog(CDlgPar::IDD, pParent)
	, m_bSign(FALSE)
	, m_bPressureCorr(FALSE)
	, m_bNoNegative(FALSE)
	, m_bElectronicRegulator(FALSE)
{
	//{{AFX_DATA_INIT(CDlgPar)
	m_fLeakMax = 0.0f;
	m_fLeakMin = 0.0f;
	m_fP1Max = 0.0f;
	m_fP1Min = 0.0f;
	m_fStabTime = 0.0f;
	m_fTestTime = 0.0f;
	m_fVolume = 0.0f;
	m_fDumpTime = 0.0f;
	m_fFillTime = 0.0f;
	m_fAtmStd = 0.0f;
	m_fFilterTime = 0.0f;
	m_fTempStd = 0.0f;
	//}}AFX_DATA_INIT
	m_fLeakOffset = 0.0f;
	m_fRatioMax = 0.0f;
	m_fRatioMin = 0.0f;
	m_fCoeffMax = 0.0f;
	m_fCoeffMin = 0.0f;
	m_fNominalValue = 0.0f;
	m_fSetFill = 0.0f;
	m_fFillVolumeTime = 0.0f;
	m_fTransfertTime = 0.0f;
}

void CDlgPar::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CDlgPar)
	DDX_Control(pDX, IDOK, m_btnOk);
	DDX_Control(pDX, IDCANCEL, m_btnCancel);
	DDX_Control(pDX, IDC_CBO_UNIT_V, m_cboUnitVolume);
	DDX_Control(pDX, IDC_CBO_UNIT_P, m_cboUnitPress);
	DDX_Control(pDX, IDC_CBO_UNIT_L, m_cboUnitLeak);
	DDX_Control(pDX, IDC_CBO_TYPE, m_cboTypeTest);
	DDX_Control(pDX, IDC_CBO_CALC, m_cboCalcVol);
	DDX_Text(pDX, IDC_EDT_LEAK_MAX, m_fLeakMax);
	DDX_Text(pDX, IDC_EDT_LEAK_MIN, m_fLeakMin);
	DDX_Text(pDX, IDC_EDT_P1_MAX, m_fP1Max);
	DDX_Text(pDX, IDC_EDT_P1_MIN, m_fP1Min);
	DDX_Text(pDX, IDC_EDT_STAB_TIME, m_fStabTime);
	DDX_Text(pDX, IDC_EDT_TEST_TIME, m_fTestTime);
	DDX_Text(pDX, IDC_EDT_VOLUME, m_fVolume);
	DDX_Text(pDX, IDC_EDT_DUMP_TIME, m_fDumpTime);
	DDX_Text(pDX, IDC_EDT_FILL_TIME, m_fFillTime);
	DDX_Text(pDX, IDC_EDT_ATM_STD, m_fAtmStd);
	DDX_Text(pDX, IDC_EDT_FILTER_TIME, m_fFilterTime);
	DDX_Text(pDX, IDC_EDT_TEMP_STD, m_fTempStd);
	//}}AFX_DATA_MAP
	DDX_Text(pDX, IDC_EDT_OFFSET, m_fLeakOffset);
	DDX_Control(pDX, IDC_CBO_FILL_TYPE, m_cboFillType);
	DDX_Text(pDX, IDC_EDT_RATIO_MAX, m_fRatioMax);
	DDX_Text(pDX, IDC_EDT_RATIO_MIN, m_fRatioMin);
	DDX_Text(pDX, IDC_EDT_COEFF_MAX, m_fCoeffMax);
	DDX_Text(pDX, IDC_EDT_COEFF_MIN, m_fCoeffMin);
	DDX_Text(pDX, IDC_EDT_NOMINAL_VALUE, m_fNominalValue);
	DDX_Text(pDX, IDC_EDT_SET_FILL, m_fSetFill);
	DDX_Text(pDX, IDC_EDT_FILL_VOL_TIME, m_fFillVolumeTime);
	DDX_Text(pDX, IDC_EDT_TRANSFERT_TIME, m_fTransfertTime);
	DDX_Control(pDX, IDC_STATIC_LEAK, m_staticSepLeak);
	DDX_Control(pDX, IDC_STATIC_PRESS, m_staticPressSep);
	DDX_Control(pDX, IDC_STATIC_TIME, m_staticTimePress);
	DDX_Control(pDX, IDC_STATIC_VOLUME, m_staticVolSep);
	DDX_Check(pDX, IDC_CHK_NO_NEG, m_bNoNegative);
	DDX_Check(pDX, IDC_CHK_PRESS_COMP, m_bPressureCorr);
	DDX_Check(pDX, IDC_CHK_SIGN, m_bSign);
	DDX_Check(pDX, IDC_CHK_ELEC_REG, m_bElectronicRegulator);
}


BEGIN_MESSAGE_MAP(CDlgPar, CDialog)
	//{{AFX_MSG_MAP(CDlgPar)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDlgPar message handlers

BOOL CDlgPar::OnInitDialog() 
{
	CDialog::OnInitDialog();

	m_cboUnitVolume.ResetContent();
	m_cboUnitPress.ResetContent();
	m_cboUnitLeak.ResetContent();
	m_cboTypeTest.ResetContent();
	m_cboCalcVol.ResetContent();

	m_cboFillType.ResetContent();

	int i = 0;

	// 1.500 Test type
	m_cboTypeTest.AddString(_T("UNDEFINED_TEST"));
	m_cboTypeTest.AddString(_T("LEAK_TEST"));
	m_cboTypeTest.AddString(_T("SEALED_COMPONENT_TEST"));
	m_cboTypeTest.AddString(_T("DESENSITIZED_TEST"));

	i = 0;
	m_cboCalcVol.AddString(_T("Pa"));
	m_cboCalcVol.AddString(_T("Pa/s"));

	for (i =0; i < NMAX_PRESS_UNITS; i++)
	{
		m_cboUnitPress.AddString(m_pAteq->GetPressureUnitStr(i));
	}

	for (i =0; i < NMAX_LEAK_UNITS; i++)
	{
		m_cboUnitLeak.AddString(m_pAteq->GetLeakUnitStr(i));
	}

	for (i =0; i < NMAX_VOLUME_UNITS; i++)
	{
		m_cboUnitVolume.AddString(m_pAteq->GetVolumeUnitStr(i));
	}

	// 1.500 Fill mode
	m_cboFillType.AddString(_T("Standard"));
	m_cboFillType.AddString(_T("Auto"));
	m_cboFillType.AddString(_T("Instruction"));
	m_cboFillType.AddString(_T("Ramp"));
	m_cboFillType.AddString(_T("Ramp Control"));
	m_cboFillType.AddString(_T("Easy"));
	m_cboFillType.AddString(_T("Easy Auto"));

	// Load parameters 
	m_cboUnitVolume.SetCurSel(m_pPar->wVolumeUnit);
	m_cboUnitPress.SetCurSel(m_pPar->wPress1Unit);
	m_cboUnitLeak.SetCurSel(m_pPar->wLeakUnit);

	m_cboTypeTest.SetCurSel(m_pPar->wTypeTest);
	m_cboCalcVol.SetCurSel(m_pPar->wRejectCalc);
	m_cboFillType.SetCurSel(m_pPar->wFillMode);		// 1.301

	m_fRatioMax = m_pPar->fRatioMax;				// 1.301
	m_fRatioMin = m_pPar->fRatioMin;
	m_fCoeffMax = m_pPar->fCoeffMax;
	m_fCoeffMin = m_pPar->fCoeffMin;
	m_fNominalValue = m_pPar->fNominalValue;
	m_fSetFill = m_pPar->fSetFillP1;

	m_fFillVolumeTime = m_pPar->wTpsFillVol;		// 1.301
	m_fTransfertTime = m_pPar->wTpsTransfert;

	m_fFillTime = m_pPar->wTpsFill;				
	m_fStabTime = m_pPar->wTpsStab;
	m_fTestTime = m_pPar->wTpsTest;
	m_fDumpTime = m_pPar->wTpsDump;

	m_fLeakMax = m_pPar->fRejectMax;
	m_fLeakMin = m_pPar->fRejectMin;

	m_fP1Max = m_pPar->fPress1Max;
	m_fP1Min = m_pPar->fPress1Min;
	m_fVolume = m_pPar->fVolume;

	m_fAtmStd = m_pPar->fPatmSTD;				// 1.2xx
	m_fTempStd = m_pPar->fTempSTD;
	m_fFilterTime = m_pPar->fFilterTime;

	m_fLeakOffset = m_pPar->fOffsetLeak;		// 1.3xx

	// 1.400 Options
	m_bSign = BIT(m_pPar->wOptions, BIT_SIGN);
	m_bNoNegative = BIT(m_pPar->wOptions, BIT_NO_NEGATIVE);
	m_bPressureCorr = BIT(m_pPar->wOptions, BIT_PRESSURE_COMP);


	// 1.500 Elec. Reg.
	m_bElectronicRegulator = BIT(m_pPar->wOptions, BIT_ELECTRONIC_REGULATOR);

	UpdateData(FALSE);

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

// **************************************************************************************
// Set bit On/off
// **************************************************************************************
void CDlgPar::SetBit(WORD& wOption, int nNum, BOOL bState)
{
	if (bState)
		wOption |= MASK(nNum);
	else
		wOption &= ~MASK(nNum);
}




// **************************************************************************************
// CDlgPar::SetPara()
// 
// Purpose       : 
// 
// Parameters    : 
//         [pAteq] : 
//         [pPar] : 
// 
// Return        : void
// 
// **************************************************************************************
void CDlgPar::SetPara(CF28Light* pAteq, F28_PARAMETERS* pPar)
{ 
	m_pAteq = pAteq;
	m_pPar	= pPar;
}


void CDlgPar::OnCancel() 
{
	// TODO: Add extra cleanup here
	
	CDialog::OnCancel();
}


// **************************************************************************************
// CDlgPar::OnOK()
// 
// Purpose       : 
// 
// Parameters    : 
// 
// Return        : void
// 
// **************************************************************************************
void CDlgPar::OnOK() 
{
	UpdateData();

	m_pPar->wVolumeUnit = m_cboUnitVolume.GetCurSel();
	m_pPar->wPress1Unit = m_cboUnitPress.GetCurSel();
	m_pPar->wLeakUnit = m_cboUnitLeak.GetCurSel();
	m_pPar->wTypeTest = m_cboTypeTest.GetCurSel();
	m_pPar->wRejectCalc = m_cboCalcVol.GetCurSel();

	m_pPar->wFillMode = m_cboFillType.GetCurSel();		// 1.301

	m_pPar->fRatioMax = m_fRatioMax;					// 1.301
	m_pPar->fRatioMin = m_fRatioMin;
	m_pPar->fCoeffMax = m_fCoeffMax;
	m_pPar->fCoeffMin = m_fCoeffMin;
	m_pPar->fNominalValue = m_fNominalValue;
	m_pPar->fSetFillP1= m_fSetFill;

	m_pPar->wTpsFillVol = (WORD)m_fFillVolumeTime;		// 1.301
	m_pPar->wTpsTransfert = (WORD)m_fTransfertTime;

	m_pPar->wTpsFill = (WORD)m_fFillTime;
	m_pPar->wTpsStab = (WORD)m_fStabTime;
	m_pPar->wTpsTest = (WORD)m_fTestTime;
	m_pPar->wTpsDump = (WORD)m_fDumpTime;

	m_pPar->fRejectMax = m_fLeakMax;
	m_pPar->fRejectMin = m_fLeakMin;

	m_pPar->fPress1Max = m_fP1Max;
	m_pPar->fPress1Min = m_fP1Min;

	m_pPar->fVolume = m_fVolume;

	m_pPar->fPatmSTD = m_fAtmStd;
	m_pPar->fTempSTD = m_fTempStd;
	m_pPar->fFilterTime = m_fFilterTime;

	m_pPar->fOffsetLeak = m_fLeakOffset;	// 1.3xx

	// 1.400 Options
	SetBit(m_pPar->wOptions, BIT_SIGN, m_bSign);
	SetBit(m_pPar->wOptions, BIT_NO_NEGATIVE, m_bNoNegative);
	SetBit(m_pPar->wOptions, BIT_PRESSURE_COMP, m_bPressureCorr);

	// 1.500 Elec Reg.
	SetBit(m_pPar->wOptions, BIT_ELECTRONIC_REGULATOR, m_bElectronicRegulator);
	
	CDialog::OnOK();
}
