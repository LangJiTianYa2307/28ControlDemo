#pragma once
class CAutoCal
{
public:
	CAutoCal();
	~CAutoCal();

	enum MODE_AUTO_CAL
	{
		MODE_OFFSET,
		MODE_OFFSET_VOLUME
	};

	enum CAL_AUTO_PHASES
	{
		AUTO_IDDLE,
		AUTO_START_OFFSET,
		AUTO_WAIT_EOC_OFFSET,
		AUTO_WAIT_MASTER_LEAK,
		AUTO_START_VOLUME,
		AUTO_WAIT_EOC_VOLUME,
		AUTO_END
	};

	void Initialize();
	CString GetPhaseStr(BYTE ucPhase);
	BYTE GetAlarm();
	BOOL StartCal(short sModuleID, BYTE ucMode, WORD wNbCycles, WORD wInterCycle, float fOffsetMax,
		float fVolumeLeak = 0,
		float fVolumePressure = 0,
		float fVolumeMin = 0,
		float fVolumeMax = 0);

	BOOL StopCal();
	BOOL RunCalContinue(BOOL bForward);
	BOOL RunCal();


protected:
	WORD m_wNbCycles;
	WORD m_wInterCycle;
	float m_fOffsetMax;
	float m_fVolumeLeak;
	float m_fVolumePressure;
	float m_fVolumeMin;
	float m_fVolumeMax;

	WORD m_wError;
	BYTE m_ucPhase;
	BYTE m_ucMode;
	short m_sModuleId;
	BOOL m_bRunning;

public:
	inline WORD GetError()	{ return m_wError;}
	inline BYTE GetPhase()	{ return m_ucPhase;}
	inline BYTE GetMode()	{ return m_ucMode;}

	BOOL IsCalRunning()			{ return m_bRunning;}
	BOOL IsWaitingMasterLeak() 	{ return (m_ucPhase == AUTO_WAIT_MASTER_LEAK);}

	//  1.403 :NEW:(4)
	BOOL IsRunningVolumeCal()	
	{
		return (m_bRunning && (m_ucMode == MODE_OFFSET_VOLUME));
	}

};

