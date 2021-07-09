// 28/06/19 2.017

using System;

namespace VCSharpF28LightControlDemo 
{
    class EasyAutoLearning
    {
        public enum EASY_AUTO_LEARNING_PHASES : byte
        {
            EASY_AUTO_IDDLE,
            EASY_AUTO_START,
            EASY_AUTO_WAIT_EOC,
            EASY_AUTO_END,
            EASY_AUTO_MAX,
        };

        public string[] arrPhases =
        {
		    "Ready",
		    "Start Easy auto learning calculation",
		    "Wait end of Easy auto learning calculation",
		    "End Auto-Ratio",
	    };

        private F28LightCtrl m_F28;
        private ushort m_wNbCycles = 2, m_wInterCycle = 3000;
        private ushort m_wError = 0;
        private short m_sModuleId = 0;
        private bool m_bRunning = false;

        private EASY_AUTO_LEARNING_PHASES m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_IDDLE;

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

            if ((ucPhase >= 0) && (ucPhase < (byte)EASY_AUTO_LEARNING_PHASES.EASY_AUTO_MAX))
            {
                strRet += " : " + arrPhases[(byte)ucPhase];
            }

            return strRet;
        }

        public bool IsEasyAutoLearningRunning()
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
        /// <returns>true : succed, false : Error</returns>
        /// ************************************************************************************************
        public bool StartEasyAutoLearning(short sModuleID, ushort wNbCycles, ushort wInterCycle)
        {
            bool bRet = false;

            if ((sModuleID > 0) && !m_F28.Equals(null))     //  && (m_F28 != Nothing))
            {
                m_wNbCycles = wNbCycles;
                m_wInterCycle = wInterCycle;

                m_sModuleId = sModuleID;
                m_wError = 0;

                m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_START;
                m_bRunning = true;

                bRet = true;
            }

            return bRet;
        }

        /// ************************************************************************************************
        /// /// <summary>
        /// Stops the easy auto learning process
        /// </summary>
        /// <returns>true : command sent with success, false : No send or error </returns>
        /// ************************************************************************************************
        public bool StopEasyAutoLearning()
        {
            short sRet = F28LightCtrl.F28_FAIL;

            if ((m_sModuleId > 0) && (m_ucPhase != EASY_AUTO_LEARNING_PHASES.EASY_AUTO_IDDLE) && !m_F28.Equals(null))
            {
                sRet = m_F28.StopEasyAutoLearning(m_sModuleId);
            }

            m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_IDDLE;
            m_bRunning = false;

            return (sRet == F28LightCtrl.F28_OK) ? true : false;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Continue the easy auto learning
        /// </summary>
        /// <returns></returns>
        /// ************************************************************************************************
        public bool RunEasyAutoLearningContinue()
        {
            bool bRet = false;
            m_wError = (ushort)m_ucPhase;

            StopEasyAutoLearning();

            m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_IDDLE;
            m_bRunning = false;

            return bRet;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Gets the easy auto learning alarm.
        /// </summary>
        /// <returns> 0 : No alrm, >0: Alarm </returns>
        /// ************************************************************************************************
        public byte GetEasyAutoLearningAlarm()
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
        /// Runs the easy auto learning process.
        /// </summary>
        /// <returns>True  : EOC easy auto learning, False : Running</returns>
        /// ************************************************************************************************
        public bool RunEasyAutoLearning()
        {
            short sRet;

            bool bReturn = false;

            switch (m_ucPhase)
            {
                case EASY_AUTO_LEARNING_PHASES.EASY_AUTO_START:			// Start
                    sRet = m_F28.StartEasyAutoLearning(m_sModuleId, m_wNbCycles, m_wInterCycle);

                    if (sRet == F28LightCtrl.F28_OK)
                    {
                        m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_WAIT_EOC;
                    }
                    else
                    {
                        m_wError = (ushort)m_ucPhase;
                        m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_END;
                    }
                    break;
                case EASY_AUTO_LEARNING_PHASES.EASY_AUTO_WAIT_EOC:		// Wait EOC
                    if (m_F28.GetEOCEasyAutoLearning(m_sModuleId) > 0)
                    {
                        m_wError = 0;			//' Pas d'erreur
                        m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_END;
                    }
                    break;

                case EASY_AUTO_LEARNING_PHASES.EASY_AUTO_END:				    // End
                    m_wError = (ushort)m_ucPhase;
                    m_ucPhase = EASY_AUTO_LEARNING_PHASES.EASY_AUTO_IDDLE;
                    m_bRunning = false;
                    bReturn = true;
                    break;

                case EASY_AUTO_LEARNING_PHASES.EASY_AUTO_IDDLE:				// Ready do nothing
                    // Do nothing
                    break;
            }
            return bReturn;
        }
    }
}
