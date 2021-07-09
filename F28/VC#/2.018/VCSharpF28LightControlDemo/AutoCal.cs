// 05/01/16 1.501 If abort cal process -> Send F28_StopAutoCal

using System;

namespace VCSharpF28LightControlDemo 
{   
    class AutoCal
    {

    public enum MODE_AUTO_CAL : byte
    {
        OFFSET,
        OFFSET_VOLUME,
    };

    public enum CAL_AUTO_PHASES : byte
    {
        AUTO_IDDLE,
        AUTO_START_OFFSET,
        AUTO_WAIT_EOC_OFFSET,
        AUTO_WAIT_MASTER_LEAK,
        AUTO_START_VOLUME,
        AUTO_WAIT_EOC_VOLUME,
        AUTO_END,
        AUTO_MAX,
    };

    public string[] arrPhases =
    {
		"Ready",
		"Start Offset calculation",
		"Wait end of Offset calculation",
        "Wait Master",
		"Start Volume calculation",
		"Wait end of volume calculation",
		"End Calibration",
	};

    private F28LightCtrl m_F28;
    private ushort m_wNbCycles = 2, m_wInterCycle = 3000;
    private ushort m_wError = 0;
    private short  m_sModuleId = 0;
    private bool   m_bRunning = false;
    private float  m_fOffsetMax = 0;
    private float  m_fVolumeLeak = 0, m_fVolumePressure = 0, m_fVolumeMin = 0, m_fVolumeMax = 0;

    private CAL_AUTO_PHASES m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE;
    private MODE_AUTO_CAL m_ucMode = MODE_AUTO_CAL.OFFSET;

    /// ************************************************************************************************
    /// <summary>
    /// Update the F28's instance
    /// </summary>
    /// <param name="f28">The F28 instance</param>
    /// ************************************************************************************************
    public void SetF28(ref F28LightCtrl f28)
    {
        m_F28 = f28;
    }

	public ushort GetError()	
    { 
        return m_wError;
    }

	public byte GetPhase()	    
    { 
        return (byte)m_ucPhase;
    }

	public byte GetMode()	    
    {	
        return (byte)m_ucMode;
    }

    public string GetPhaseStr(byte ucPhase)
    {
	    string strRet = Convert.ToString(ucPhase);

        if ((ucPhase >= 0) && (ucPhase < (byte)CAL_AUTO_PHASES.AUTO_MAX))
        {
            strRet += " : " + arrPhases[(byte)ucPhase];
        }

	    return strRet;
    }

    public bool IsCalRunning()
    {
        return m_bRunning;
    }
    
    public bool IsWaitingMasterLeak()
    {
        return (m_ucPhase == CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK);
    }

    //  1.403 :NEW:(4)
    public bool IsRunningVolumeCal()
    {
        return (m_bRunning && (m_ucMode == MODE_AUTO_CAL.OFFSET_VOLUME));
    }



    /// ************************************************************************************************
    /// <summary>
    /// Starts the calibration process
    /// </summary>
    /// <param name="sModuleID">The module identifier.</param>
    /// <param name="ucMode">The calibration mode : Offset/Offset+Volume.</param>
    /// <param name="wNbCycles">The number of cycles.</param>
    /// <param name="wInterCycle">The inter cycle time in ms.</param>
    /// <param name="fOffsetMax">The offset maximum.</param>
    /// <param name="fVolumeLeak">The volume leak.</param>
    /// <param name="fVolumePressure">The volume pressure.</param>
    /// <param name="fVolumeMin">The volume minimum.</param>
    /// <param name="fVolumeMax">The volume maximum.</param>
    /// <returns>true : succed, false : Error</returns>
    /// ************************************************************************************************
    public bool StartCal(short sModuleID, MODE_AUTO_CAL ucMode, ushort wNbCycles, ushort wInterCycle, float fOffsetMax,
										float fVolumeLeak=0, float fVolumePressure=0, float fVolumeMin=0, float fVolumeMax=0)
    {
	    bool bRet = false;

        if ((sModuleID > 0) && !m_F28.Equals(null))     //  && (m_F28 != Nothing))
	    {
		    m_wNbCycles = wNbCycles;
		    m_wInterCycle = wInterCycle;
		    m_fOffsetMax = fOffsetMax;
		    m_fVolumeLeak = fVolumeLeak;
		    m_fVolumePressure = fVolumePressure;
		    m_fVolumeMin = fVolumeMin;
		    m_fVolumeMax = fVolumeMax;

		    m_sModuleId = sModuleID;
		    m_ucMode = ucMode;
		    m_wError = 0;

		    m_ucPhase = CAL_AUTO_PHASES.AUTO_START_OFFSET;
		    m_bRunning = true;

		    bRet = true;
	    }

	    return bRet;
    }

    /// ************************************************************************************************
    /// /// <summary>
    /// Stops the calibration process
    /// </summary>
    /// <returns>true : command sent with success, false : No send or error </returns>
    /// ************************************************************************************************
    public bool StopCal()
    {
	    short sRet = F28LightCtrl.F28_FAIL;

        if ((m_sModuleId > 0) && (m_ucPhase != CAL_AUTO_PHASES.AUTO_IDDLE) && !m_F28.Equals(null))
	    {
		    sRet = m_F28.StopAutoCal(m_sModuleId);
	    }

	    m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE;
	    m_bRunning = false;

	    return (sRet == F28LightCtrl.F28_OK) ? true:false;
    }


    /// ************************************************************************************************
    /// <summary>
    /// Continue the volume calibration 
    /// </summary>
    /// <param name="bForward">if set to <c>true : continue volume calibration</c> [b forward].</param>
    /// <returns></returns>
    /// ************************************************************************************************
    public bool RunCalContinue(bool bForward)
    {
	    bool bRet = false;
	    if (bForward)
	    {
		    bRet = true;
		    m_ucPhase = CAL_AUTO_PHASES.AUTO_START_VOLUME;
	    }
	    else
	    {
		    m_wError = (ushort)m_ucPhase;

            // 1.501 If abort cal process -> Send F28_StopAutoCal
            StopCal();

		    m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE;
		    m_bRunning = false;

		    //StopCal();
	    }
	    return bRet;
    }


    /// ************************************************************************************************
    /// <summary>
    /// Gets the calibration alarm.
    /// </summary>
    /// <returns> 0 : No alrm, >0: Alarm </returns>
    /// ************************************************************************************************
    public byte GetCalAlarm()
    {
        byte ucAlarm = 0;
        if ((m_sModuleId > 0) && !m_F28.Equals(null)) 
        {
            ucAlarm = m_F28.GetAutoCalAlarm(m_sModuleId);
        }
        return ucAlarm;
    }


    /// ************************************************************************************************
    /// <summary>
    /// Runs the calibration process.
    /// </summary>
    /// <returns>True  : EOC calibration, False : Running</returns>
    /// ************************************************************************************************
    public bool RunCal()
    {
	    short sRet;

	    bool bReturn = false;

	    switch (m_ucPhase)
	    {
            case CAL_AUTO_PHASES.AUTO_START_OFFSET:			// Start auto Cal     
                if (m_ucMode == MODE_AUTO_CAL.OFFSET)
		        {
                    sRet = m_F28.StartAutoCalOffsetOnly(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fOffsetMax);
		        }
		        else
		        {
			        sRet = m_F28.StartAutoCalOffset(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fOffsetMax);
		        }

                if (sRet == F28LightCtrl.F28_OK)
		        {
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_WAIT_EOC_OFFSET;
		        }
		        else
		        {
                    m_wError = (ushort)m_ucPhase;
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_END;
		        }
		        break;
            case CAL_AUTO_PHASES.AUTO_WAIT_EOC_OFFSET:		// Wait EOC Offset
		        if (m_F28.GetEOCOffset(m_sModuleId) > 0)
		        {
                    if (m_ucMode == MODE_AUTO_CAL.OFFSET)
			        {
				        m_wError = 0;			//' Pas d'erreur
                        m_ucPhase = CAL_AUTO_PHASES.AUTO_END;
			        }
			        else
			        {
                        m_wError = (ushort)m_ucPhase;
                        m_ucPhase = CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK;
			        }
		        }
		        break;

            case CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK:		// Waiting master leak

		        // Wait validation from user
		        // Do nothing

		        break;

            case CAL_AUTO_PHASES.AUTO_START_VOLUME:			// Start auto volume
		        if (m_F28.StartAutoCalVolume(m_sModuleId, m_wNbCycles, m_wInterCycle,
                    m_fVolumeLeak, m_fVolumePressure, m_fVolumeMin, m_fVolumeMax) == F28LightCtrl.F28_OK)
		        {
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_WAIT_EOC_VOLUME;
		        }
		        else
		        {
                    m_wError = (ushort)m_ucPhase;
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_END;
		        }
		        break;

            case CAL_AUTO_PHASES.AUTO_WAIT_EOC_VOLUME:		// Wait EOC Auto volume
                if (m_F28.GetEOCVolume(m_sModuleId) > 0)
		        {
			        m_wError = 0;			// Pas d'erreur
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_END;
		        }
		        break;

             case CAL_AUTO_PHASES.AUTO_END:				    // End of auto calibration
                m_wError = (ushort)m_ucPhase;
                m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE;
		        m_bRunning = false;
		        bReturn = true;
		        break;

            case CAL_AUTO_PHASES.AUTO_IDDLE:				// Ready do nothing

		        // Do nothing
		        break;

	    }
	    return bReturn;
    }

    }
}
