#pragma once
class CEasyAutoLearning
{
public:
	CEasyAutoLearning();
	~CEasyAutoLearning();

	enum EASY_AUTO_PHASES
	{
		EASY_AUTO_IDDLE,
		EASY_AUTO_START,
		EASY_AUTO_WAIT_EOC,
		EASY_AUTO_END
	};

	void		Initialize					(void);
	CString		GetPhaseStr					(BYTE ucPhase);
	BYTE		GetAlarm					(void);
	BOOL		StartEasyAutoLearning		(short sModuleID, WORD wNbCycles, WORD wInterCycle);
	BOOL		StopEasyAutoLearning		(void);
	BOOL		RunEasyAutoLearning			(void);
	inline WORD GetError					(void)		{ return m_wError;}
	inline BYTE GetPhase					(void)		{ return m_ucPhase;}
	BOOL		IsEasyAutoLearningRunning	(void)		{ return m_bRunning;}

protected:
	WORD	m_wNbCycles;
	WORD	m_wInterCycle;
	WORD	m_wError;
	BYTE	m_ucPhase;
	short	m_sModuleId;
	BOOL	m_bRunning;
};

