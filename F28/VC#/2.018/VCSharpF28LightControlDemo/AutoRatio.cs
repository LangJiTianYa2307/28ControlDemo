// 03/12/18 2.013 

using System;

namespace VCSharpF28LightControlDemo 
{
    class AutoRatio
    {
        public enum AUTO_RATIO_PHASES : byte
        {
            AUTO_RATIO_IDDLE,
            AUTO_RATIO_START,
            AUTO_RATIO_WAIT_EOC,
            AUTO_RATIO_END,
            AUTO_RATIO_MAX,
        };

        public string[] arrPhases =
        {
		    "Ready",
		    "Start Auto-Ratio calculation",
		    "Wait end of Auto-Ratio calculation",
		    "End Auto-Ratio",
	    };

        private F28LightCtrl m_F28;
        private ushort m_wNbCycles = 2, m_wInterCycle = 3000;
        private ushort m_wError = 0;
        private short m_sModuleId = 0;
        private bool m_bRunning = false;
        private float m_fRatioMax = 0.2f;
        private float m_fRatioMin = 1.0f;

        private AUTO_RATIO_PHASES m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE;

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

        public string GetPhaseStr(byte ucPhase)
        {
            string strRet = Convert.ToString(ucPhase);

            if ((ucPhase >= 0) && (ucPhase < (byte)AUTO_RATIO_PHASES.AUTO_RATIO_MAX))
            {
                strRet += " : " + arrPhases[(byte)ucPhase];
            }

            return strRet;
        }

        public bool IsAutoRatioRunning()
        {
            return m_bRunning;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Starts the calibration process
        /// </summary>
        /// <param name="sModuleID">The module identifier.</param>
        /// <param name="wNbCycles">The number of cycles.</param>
        /// <param name="wInterCycle">The inter cycle time in ms.</param>
        /// <param name="fRatioMax">The ration max
        /// <param name="fRatioMin">The ration min
        /// <returns>true : succed, false : Error</returns>
        /// ************************************************************************************************
        public bool StartAutoRatio(short sModuleID, ushort wNbCycles, ushort wInterCycle, float fRatioMax, float fRatioMin)
        {
            bool bRet = false;

            if ((sModuleID > 0) && !m_F28.Equals(null))     //  && (m_F28 != Nothing))
            {
                m_wNbCycles = wNbCycles;
                m_wInterCycle = wInterCycle;
                m_fRatioMax = fRatioMax;
                m_fRatioMin = fRatioMin;

                m_sModuleId = sModuleID;
                m_wError = 0;

                m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_START;
                m_bRunning = true;

                bRet = true;
            }

            return bRet;
        }

        /// ************************************************************************************************
        /// /// <summary>
        /// Stops the Auto-Ratio process
        /// </summary>
        /// <returns>true : command sent with success, false : No send or error </returns>
        /// ************************************************************************************************
        public bool StopAutoRatio()
        {
            short sRet = F28LightCtrl.F28_FAIL;

            if ((m_sModuleId > 0) && (m_ucPhase != AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE) && !m_F28.Equals(null))
            {
                sRet = m_F28.StopAutoRatio(m_sModuleId);
            }

            m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE;
            m_bRunning = false;

            return (sRet == F28LightCtrl.F28_OK) ? true : false;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Continue the Auto-Ratio
        /// </summary>
        /// <returns></returns>
        /// ************************************************************************************************
        public bool RunAutoRatioContinue()
        {
            bool bRet = false;
            m_wError = (ushort)m_ucPhase;

            StopAutoRatio();

            m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE;
            m_bRunning = false;

            return bRet;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Gets the Auto-Ratio alarm.
        /// </summary>
        /// <returns> 0 : No alrm, >0: Alarm </returns>
        /// ************************************************************************************************
        public byte GetAutoRatioAlarm()
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
        /// Runs the Auto-Ratio process.
        /// </summary>
        /// <returns>True  : EOC auto-ratio, False : Running</returns>
        /// ************************************************************************************************
        public bool RunAutoRatio()
        {
            short sRet;

            bool bReturn = false;

            switch (m_ucPhase)
            {
                case AUTO_RATIO_PHASES.AUTO_RATIO_START:			// Start auto ratio
                    sRet = m_F28.StartAutoRatio(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fRatioMax, m_fRatioMin);

                    if (sRet == F28LightCtrl.F28_OK)
                    {
                        m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_WAIT_EOC;
                    }
                    else
                    {
                        m_wError = (ushort)m_ucPhase;
                        m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_END;
                    }
                    break;
                case AUTO_RATIO_PHASES.AUTO_RATIO_WAIT_EOC:		// Wait EOC Auto-Ratio
                    if (m_F28.GetEOCRatio(m_sModuleId) > 0)
                    {
                        m_wError = 0;			//' Pas d'erreur
                        m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_END;
                    }
                    break;

                case AUTO_RATIO_PHASES.AUTO_RATIO_END:				    // End of auto ratio
                    m_wError = (ushort)m_ucPhase;
                    m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE;
                    m_bRunning = false;
                    bReturn = true;
                    break;

                case AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE:				// Ready do nothing
                    // Do nothing
                    break;
            }
            return bReturn;
        }
    }
}
