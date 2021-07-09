#pragma once

#include <F28LightControl_ETH.h>

// uchar ucEndOfCycle

#define FLAG_END_OF_CYCLE			1

// *****************************************************************************************************
// Class F28Light 
// *****************************************************************************************************
class CF28Light
{
public:
	CF28Light();
	virtual ~CF28Light();

	int WriteFile(F28_PARAMETERS* pCfg = NULL);
	int ReadFile(F28_PARAMETERS* pCfg = NULL);

	LPCTSTR GetLeakUnitStr(BYTE ucUnit);
	LPCTSTR GetPhaseStr(BYTE ucPhase);
	LPCTSTR GetResultStr(BYTE ucRslt);
	LPCTSTR GetPressureUnitStr(BYTE ucUnit);
	LPCTSTR GetVolumeUnitStr(BYTE ucUnit);

	CString GetOffsetVolumeStr();
	CString GetRatioStr();

	inline F28_PARAMETERS*		GetPtrPara()				{ return &m_Para; }
	inline F28_REALTIME_CYCLE*	GetPtrRealTime()			{ return &m_Realtime; }
	inline F28_RESULT*			GetPtrResult()				{ return &m_Result; }
	inline F28_COMMUNICATION_STATISTICS* GetComCounter()	{ return &m_rCptComm; }

	int		Edit(BOOL bRead);

private:
	void SetDefaultPara(int nLeakUnit = -1);

protected:
	CString							m_strParaFile;
	F28_PARAMETERS					m_Para;
	F28_REALTIME_CYCLE				m_Realtime;
	F28_RESULT						m_Result;
	F28_COMMUNICATION_STATISTICS	m_rCptComm;
};

