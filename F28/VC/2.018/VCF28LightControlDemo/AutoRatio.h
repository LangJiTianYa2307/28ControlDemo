#pragma once
class CAutoRatio
{
public:
	CAutoRatio();
	~CAutoRatio();

	enum AUTO_RATIO_PHASES
	{
		AUTO_RATIO_IDDLE,
		AUTO_RATIO_START,
		AUTO_RATIO_WAIT_EOC,
		AUTO_RATIO_END
	};

	void		Initialize				(void);
	CString		GetPhaseStr				(BYTE ucPhase);
	BYTE		GetAlarm				(void);
	BOOL		StartAutoRatio			(short sModuleID, WORD wNbCycles, WORD wInterCycle, float fRatiotMax, float fRatioMin);
	BOOL		StopAutoRatio			(void);
	BOOL		RunAutoRatio			(void);
	inline WORD GetError				(void)		{ return m_wError;}
	inline BYTE GetPhase				(void)		{ return m_ucPhase;}
	BOOL		IsAutoRatioRunning		(void)		{ return m_bRunning;}

protected:
	WORD	m_wNbCycles;
	WORD	m_wInterCycle;
	float	m_fRatioMax;
	float	m_fRatioMin;
	WORD	m_wError;
	BYTE	m_ucPhase;
	short	m_sModuleId;
	BOOL	m_bRunning;
};

