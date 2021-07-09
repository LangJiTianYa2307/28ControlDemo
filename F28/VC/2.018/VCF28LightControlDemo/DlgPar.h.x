#pragma once


// CDlgPar dialog

class CDlgPar : public CDialogEx
{
	DECLARE_DYNAMIC(CDlgPar)

public:
	CDlgPar(CWnd* pParent = NULL);   // standard constructor
	virtual ~CDlgPar();

// Dialog Data
	enum { IDD = IDD_DLG_PAR };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
};
