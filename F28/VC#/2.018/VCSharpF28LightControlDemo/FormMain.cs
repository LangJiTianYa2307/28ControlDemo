// *******************************************************************************************
// 17/12/15 1.404   - Auto cal intercycle parameter changed from ms to 0.01s
//                  - Keep alive - Continuous communation with module to remain disconnection
//                  - Add ResetEthernet function if the connection is lost
// *******************************************************************************************
// 23/12/15 1.500    - Add parameters (no size changed)
//                       - Leak units 
//                       - Test type
//                       - Fill mode
//                       - Options
//                   - Learn Electronic Regulator
// *******************************************************************************************
// 21/07/16 1.504    - Add capability to use AddModule after RemoveModule, RemoveAllModule
//                   without InitModule 
//                   - Add button RemoveModule
//                   - :FIX: Warning in debug mode 'f28 addmodule' has unbalanced the stack
//                       . Replace all functions declarations from ULong to UInteger,  
// *******************************************************************************************
// 02/03/17 2.0.0.4 - Add jet check
//                  - Add new alarms status
// *******************************************************************************************
// 03/07/17 2.0.0.4 - Add leak unit cm2H2O
// *******************************************************************************************
// 30/11/18 2.0.0.13 - Add Auto-Ratio
// *******************************************************************************************
// 20/06/19 2.0.0.16 - Modif auto ratio
//                   - New Fill mode
// *******************************************************************************************
// 28/06/19 2.0.0.17 - Add special cycle easy auto learning
// *******************************************************************************************
// 04/11/19 2.0.0.18 - Add leak unit ug2H2O
// *******************************************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace VCSharpF28LightControlDemo
{
    public partial class FormMain : Form
    {
        private F28LightCtrl F28 = new F28LightCtrl();   
        private F28LightCtrl.F28_RESULT tLastResult = new F28LightCtrl.F28_RESULT();

        // 1.402
        private F28LightCtrl.F28_PARAMETERS tPara = new F28LightCtrl.F28_PARAMETERS();
        private AutoCal tAutocal = new AutoCal();
        private AutoRatio tAutoratio = new AutoRatio();
        private EasyAutoLearning tEasyAuto = new EasyAutoLearning();
        private byte m_ucCpt = 0;

        private byte m_bEndCycle = 0;
        private bool m_bAPIOpened = false;
          
        public FormMain()
        {
            InitializeComponent();

            // Update Ateq unit to autoCal
            tAutocal.SetF28(ref F28);
            tAutoratio.SetF28(ref F28);
            tEasyAuto.SetF28(ref F28);

            // Update Parameters
            tPara.usTypeTest = (ushort)F28LightCtrl.F28_TYPE_TEST.LEAK_TEST;
            tPara.usTpsFillVol = 100;           // 1 s
            tPara.usTpsTransfert = 100;         // 1 s

            tPara.usTpsFill = 100;
            tPara.usTpsStab = 200;
            tPara.usTpsTest = 200;
            tPara.usTpsDump = 100;

            tPara.usPress1Unit = (ushort)F28LightCtrl.F28_PRESS_UNITS.PRESS_mBAR;	// mBar
            tPara.fPress1Min = -2000;
            tPara.fPress1Max = 200000;

            tPara.fSetFillP1 = 0;				// mode auto-fill
            tPara.fRatioMax = 0;
            tPara.fRatioMin = 0;
            tPara.usFillMode = 0;				// STD_FILL_MODE / AUTOFILL_MODE
            tPara.wLastConsigneDacEasy = 0;

            tPara.usLeakUnit = (ushort)F28LightCtrl.F28_LEAK_UNITS.LEAK_SCCM;      // See F28_LEAK_UNITS

            tPara.usRejectCalc = 1;				// Pa/s
            tPara.usVolumeUnit = (ushort)F28LightCtrl.F28_ENUM_VOLUME_UNIT.VOLUME_CM3;	// See F28_ENUM_VOLUME_UNIT 
            tPara.fVolume = 15;

            tPara.fRejectMin = 0;
            tPara.fRejectMax = 10;

            tPara.fCoeffAutoFill = 0;
            tPara.usOptions = 0;			    

            tPara.fPatmSTD = 1013.0f;		    // Patm  standard condition (hPa)
            tPara.fTempSTD = 0.0f;		        // Temperature standard condition (en °C)
            tPara.fFilterTime = 0;		        //  en (s)

            tPara.fOffsetLeak = 0;

            tPara.fVolumeRef = 0;

            tPara.wTpsTestCompTemp = 0;
            tPara.wPourcCompTemp = 0;
            tPara.wTpsWaitingTime = 0;

            tPara.fNominalValue = 0.0f;
            tPara.fCoeffMax = 0.0f;
            tPara.fCoeffMin = 0.0f;

            // 1.402
            buttonRegAdjust.Enabled = false;
            buttonReadParameters.Enabled = false;
            btnStopAutoCal.Enabled = false;
            btnOffsetOnly.Enabled = false;
            btnAutoVolume.Enabled = false;
            btnAutoRatio.Enabled = false;
            // End 1.402

            m_bEndCycle = 0;

            btnRemoveModule.Enabled = false;
            buttonAddModule.Enabled = false;
            buttonParameters.Enabled = false;
            buttonReset.Enabled = false;
            buttonStart.Enabled = false;
            buttonResetGroup.Enabled = false;
            buttonStartGroup.Enabled = false;
            buttonLastResult.Enabled = false;
            buttonClearFifo.Enabled = false;
            buttonReadFifo.Enabled = false;
            buttonClearFifo.Enabled = false;
            buttonReadFifo.Enabled = false;
            buttonAutoZero.Enabled = false;

            comboBoxGroup.SelectedIndex = 0;
            textBoxModuleID.Text = "-1";
            textBoxResultCount.Text = "0";
            textBoxAZDumpTime.Text = "1";

#if _64BITS
            string strTitle = Application.ProductName + " 64Bits (Ver " + Application.ProductVersion + ") 04/11/19 (DLL ver >= 2.017)-> Ethernet interface";
#else
            string strTitle = Application.ProductName + " 32Bits (Ver " + Application.ProductVersion + ") 04/11/19 (DLL ver >= 2.017)-> Ethernet interface";
#endif

            this.Text = strTitle;

            if (F28.Init() == F28LightCtrl.F28_OK)
            {
                AddMessage("F28LightControl_ETH.dll initialized");
                textBoxDLLVersion.Text = F28.GetDllMajorVersion().ToString("D1") + "." + F28.GetDllMinorVersion().ToString("D3");
                AddMessage("Dll Version : " + textBoxDLLVersion.Text);
            }
            else
            {
                AddMessage("Error initializing F28LightControl_ETH.dll !");
                AddMessage("Check F28LightControl_ETH.dll and restart !");
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            short sModule = GetModule();

            if (sModule != -1)
            {
                F28.RemoveModule(sModule);
            }

            F28.Close();
        }

        private short GetModule() { return short.Parse(textBoxModuleID.Text); }
        private byte GetGroup() { return byte.Parse(comboBoxGroup.Text); }

        /// ************************************************************************************************
        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="strMessage">The string message.</param>
        /// ************************************************************************************************
        private void AddMessage(String strMessage)
        {
            listBoxMessage.Items.Add(strMessage);
            listBoxMessage.SetSelected(listBoxMessage.Items.Count - 1, true);
            listBoxMessage.SetSelected(listBoxMessage.Items.Count - 1, false);
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxOpenClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void checkBoxOpenClose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOpenClose.Checked)
            {
                F28.Init();

                if (F28.OpenChannel() == F28LightCtrl.F28_OK)
                {
                    AddMessage("Ethernet port opened");
                    buttonAddModule.Enabled = true;
                    btnRemoveModule.Enabled = true;

                    m_bAPIOpened = true;
                }
                else
                {
                    checkBoxOpenClose.Checked = false;
                    AddMessage("Error opening port !");

                    m_bAPIOpened = false;

                }
            }
            else
            {
                short sModule = GetModule();

                if (sModule != -1)
                {
                    timerRealTime.Enabled = false;
                    timerCounters.Enabled = false;
                    F28.RemoveModule(sModule);
                    textBoxModuleID.Text = "-1";
                }

                // 1.404
                listBox2Heads.Items.Clear();

                F28.Close();

                m_bAPIOpened = false;

                AddMessage("Ethernet port closed");
                buttonAddModule.Enabled = false;
                buttonParameters.Enabled = false;
                buttonReset.Enabled = false;
                buttonStart.Enabled = false;
                buttonResetGroup.Enabled = false;
                buttonStartGroup.Enabled = false;
                buttonLastResult.Enabled = false;
                buttonClearFifo.Enabled = false;
                buttonReadFifo.Enabled = false;
                buttonAutoZero.Enabled = false;

                textBoxModuleID.Text = "-1";
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonAddModule control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonAddModule_Click(object sender, EventArgs e)
        {
            IPAddress   IPAddress   = IPAddress.Parse(textBoxAddressIP.Text);
            uint        ulAddress   = BitConverter.ToUInt32(IPAddress.GetAddressBytes(), 0);            // 1.504
            byte        bGroup      = byte.Parse(comboBoxGroup.Text);
            short       sModule     = GetModule();

            if (m_bAPIOpened && (sModule != -1))
            {
                timerRealTime.Enabled = false;
                timerCounters.Enabled = false;

                F28.RemoveModule(sModule);
            }

            sModule = F28.AddModule(ulAddress, 1, bGroup, 3);

            if (sModule != F28LightCtrl.F28_FAIL)
            {
                AddMessage("Module added");

                // 1.402
                buttonRegAdjust.Enabled = true;
                buttonReadParameters.Enabled = true;
                btnStopAutoCal.Enabled = true;
                btnOffsetOnly.Enabled = true;
                btnAutoVolume.Enabled = true;
                btnAutoRatio.Enabled = true;

                buttonParameters.Enabled = true;
                buttonReset.Enabled = true;
                buttonStart.Enabled = true;
                buttonResetGroup.Enabled = true;
                buttonStartGroup.Enabled = true;
                buttonLastResult.Enabled = true;
                buttonClearFifo.Enabled = true;
                buttonReadFifo.Enabled = true;
                buttonAutoZero.Enabled = true;

                DisplayInfo(sModule);

                timerRealTime.Enabled = true;
                timerCounters.Enabled = true;
            }
            else
            {
                AddMessage("Error adding module !");
            }

            textBoxModuleID.Text = sModule.ToString();
        }

        // ****************************************************************
        // 1.504 RemoveModule
        // ****************************************************************
        private void btnRemoveModule_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (m_bAPIOpened && (sModule != -1))
            {
                timerRealTime.Enabled = false;
                timerCounters.Enabled = false;

                if (F28.RemoveModule(sModule) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Removing module OK !!!");

                    textBoxModuleID.Text = "-1";
                }
                else
                {
                    AddMessage("Error removing module !!!");
                }
            }
        }

        /// <summary>
        /// Displays the information.
        /// </summary>
        /// <param name="sModule">The s module.</param>
        private void DisplayInfo(short sModule)
        {
            if (F28.RefreshModuleInformations(sModule) == F28LightCtrl.F28_OK)
            {
                uint ulIP = 0;                  // 1.504
                string strMACAddress = "";
                string strVersion = "";

                if (F28.GetAddressIP(sModule, ref ulIP) == F28LightCtrl.F28_OK && F28.GetMACAddress(sModule, ref strMACAddress)==F28LightCtrl.F28_OK)
                {
                    IPAddress IPAddress = new IPAddress((long)ulIP);

                    AddMessage("Connection to " + IPAddress.ToString()+"  ("+strMACAddress+")");
                }

                if (F28.GetModuleHardVersion(sModule, ref strVersion) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Sensor hard version : " + strVersion);
                }
                else
                {
                    AddMessage("Sensor hard version unknown");
                }

                if (F28.GetModuleSoftVersion(sModule, ref strVersion) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Sensor soft version : " + strVersion);
                }
                else
                {
                    AddMessage("Sensor soft version unknown");
                }

                if (F28.GetETHHardVersion(sModule, ref strVersion) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Ethernet hard version : " + strVersion);
                }
                else
                {
                    AddMessage("Ethernet hard version unknown");
                }

                if (F28.GetETHSoftVersion(sModule, ref strVersion) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Ethernet soft version : " + strVersion);
                }
                else
                {
                    AddMessage("Ethernet soft version unknown");
                }

                if (F28.GetSerialNumber(sModule, ref strVersion) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Serial number : " + strVersion);
                }
                else
                {
                    AddMessage("Serial number unknown");
                }
            }
            else
            {
                AddMessage("Error reading module informations");
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonStartGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonStartGroup_Click(object sender, EventArgs e)
        {
            if (F28.StartCycleByGroup(GetGroup()) == F28LightCtrl.F28_OK)
            {
                AddMessage("Start cycle on group " + GetGroup().ToString());
            }
            else
            {
                AddMessage("Error starting cycle on group " + GetGroup().ToString());
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonResetGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonResetGroup_Click(object sender, EventArgs e)
        {
            if (F28.StopCycleByGroup(GetGroup()) == F28LightCtrl.F28_OK)
            {
                AddMessage("Reset cycle on group " + GetGroup().ToString());
            }
            else
            {
                AddMessage("Error reseting cycle on group " + GetGroup().ToString());
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (F28.StartCycle(GetModule()) == F28LightCtrl.F28_OK)
            {
                AddMessage("Start cycle on module");
            }
            else
            {
                AddMessage("Error starting cycle on module");
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (F28.StopCycle(GetModule()) == F28LightCtrl.F28_OK)
            {
                AddMessage("Reset cycle on module");
            }
            else
            {
                AddMessage("Error reseting cycle on module");
            }

            Status.Text = "...";

        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonLastResult control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonLastResult_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (sModule != -1)
            {
                F28LightCtrl.F28_RESULT tResult = new F28LightCtrl.F28_RESULT();

                if (F28.GetLastResult(sModule, ref tResult) == F28LightCtrl.F28_OK)
                {
                    DisplayResult(ref tResult, false);
                }
            }
            else
            {
                AddMessage("Error reading last result !");
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Displays the result.
        /// </summary>
        /// <param name="tResult">The t result.</param>
        /// <param name="bFIFO">if set to <c>true</c> [b fifo].</param>
        /// ************************************************************************************************
        private void DisplayResult(ref F28LightCtrl.F28_RESULT tResult, bool bFIFO)
        {
            string strMsg = "Last result at ";

            if (bFIFO)
            {
                strMsg = "Result FIFO at ";
            }

            AddMessage(strMsg +
                        tResult.dateReceived.usHour.ToString() + ":" + tResult.dateReceived.usMinute.ToString("D2") + ":" + tResult.dateReceived.usSecond.ToString("D2") +
                        " on " + tResult.dateReceived.usYear.ToString("D2") + "-" + tResult.dateReceived.usMonth.ToString("D2") + "-" + tResult.dateReceived.usDay.ToString("D2"));
            AddMessage("  - Pressure : " + tResult.fPressureValue.ToString("F2") + " " + F28.F28_STR_PRESS_UNITS[tResult.bUnitPressure]);
            if (tResult.bUnitLeak == (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_SCCM)
            {
                AddMessage("  - Leak     : " + tResult.fLeakValue.ToString("F4") + " " + F28.F28_STR_LEAK_UNITS[tResult.bUnitLeak]);
            }
            // V2.0.0.4
            else if (tResult.bUnitLeak == (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_JET_CHECK)
            {
                AddMessage("  - Leak     : " + tResult.fLeakValue.ToString("F2") + " " + F28.F28_STR_LEAK_JET_CHECK);
            }
            // V2.0.0.4
            else
            {
                AddMessage("  - Leak     : " + tResult.fLeakValue.ToString("F2") + " " + F28.F28_STR_LEAK_UNITS[tResult.bUnitLeak]);
            }
            AddMessage("  - Status  : " + F28.F28_RESULT_STR_STATUS[tResult.bStatus]);
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonParameters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonParameters_Click(object sender, EventArgs e)
        {
            FormPara frmPara = new FormPara();

            short sModule = GetModule();

           if (sModule > 0) // F28.GetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
           {
                frmPara.SetParameters(ref tPara);

                if (frmPara.ShowDialog() == DialogResult.OK)
                {
                    tPara = frmPara.GetParameters();

                    if(F28.SetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
                    {
                        F28.GetModuleParameters(sModule, ref tPara);    // Read parameters to update some parameters in the structure
                        AddMessage("New parameters list writen");
                    }
                    else
                    {
                        AddMessage("Error writink new parameters list !");
                    }
                }
           }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonClearFifo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonClearFifo_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (F28.ClearFIFOResults(sModule) == F28LightCtrl.F28_OK)
            {
                AddMessage("Results FIFO cleared");
            }
            else
            {
                AddMessage("Error clearing results FIFO !");
            }

            DisplayResultCount();
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonReadFifo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonReadFifo_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();
            F28LightCtrl.F28_RESULT tResult = new F28LightCtrl.F28_RESULT();

            while (F28.GetResultsCount(sModule) > 0)
            {
                if (F28.GetNextResult(sModule, ref tResult) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Results FIFO read");
                    DisplayResult(ref tResult, true);
                }
                else
                {
                    AddMessage("Error reading results FIFO !");
                }
            }

            DisplayResultCount();
        }

        /// ************************************************************************************************
        /// <summary>
        /// Displays the result count.
        /// </summary>
        /// ************************************************************************************************
        private void DisplayResultCount()
        {
            short sModule = GetModule();

            if (sModule > 0)
            {
                textBoxResultCount.Text = F28.GetResultsCount(sModule).ToString();
            }
        }

        /// ************************************************************************************************
        // 1.403 Display frame
        /// <summary>
        /// Displays the result frame.
        /// </summary>
        /// <param name="tR">The t r.</param>
        /// ************************************************************************************************
        private void DisplayResultFrame(ref F28LightCtrl.F28_RESULT tR)
        {
            string str;
            str = tR.bGroupID.ToString() + "; " + tR.bModuleAddr.ToString() + "; " +
                    tR.dateReceived.usYear.ToString() + "/" + tR.dateReceived.usMonth.ToString("D2") + "/" + tR.dateReceived.usDay.ToString("D2") + "; " +
                    tR.dateReceived.usHour.ToString("D2") + ":" + tR.dateReceived.usMinute.ToString("D2") + ":" + tR.dateReceived.usSecond.ToString("D2") + "; " +
                    F28.F28_RESULT_STR_STATUS[tR.bStatus] + "; " +
                    tR.fPressureValue.ToString("F3") + "; " +  F28.F28_STR_PRESS_UNITS[tR.bUnitPressure] + "; ";
            if (tR.bUnitLeak == (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_SCCM)
            {
                str += tR.fLeakValue.ToString("F4") + "; " + F28.F28_STR_LEAK_UNITS[tR.bUnitLeak];
            }
            // V2.0.0.4
            else if (tR.bUnitLeak == (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_JET_CHECK)
            {
                str += tR.fLeakValue.ToString("F2") + "; " + F28.F28_STR_LEAK_JET_CHECK;
            }
            // V2.0.0.4
            else
            {
                str += tR.fLeakValue.ToString("F2") + "; " + F28.F28_STR_LEAK_UNITS[tR.bUnitLeak];
            }

            AddMessage(str);
        }

        /// ************************************************************************************************
        // Special cycles
        /// <summary>
        /// Handles the Click event of the buttonAutoZero control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonAutoZero_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (sModule > 0)
            {
                if (F28.StartAutoZeroPressure(sModule, float.Parse(textBoxAZDumpTime.Text)) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Start Auto-zero on module");
                }
                else
                {
                    AddMessage("Error starting Auto-zero");
                }
            }
        }

        // ************************************************************************************************
        // 100 ms Realtime timer : Read status + real time measurement
        // *************************************************************************************************

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Tick event of the timerRealTime control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void timerRealTime_Tick(object sender, EventArgs e)
        {
            const string EMPTY_FIELD = "------";
            short sModule = GetModule();

            if (sModule != -1)
            {
                string str;
                byte ucPhaseAutoRatio = tAutoratio.GetPhase();

                // 1- Run Auto-Ratio
                if (tAutoratio.IsAutoRatioRunning())       // (ucPhaseCal != AutoRatio.AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE)
                {
                    // Display phase
                    str = tAutoratio.GetPhaseStr(ucPhaseAutoRatio);
                    m_labelCal.Text = str;

                    // Running End auto calibration ?
                    if (tAutoratio.RunAutoRatio())
                    {
                        // ' 1- Read auto ratio errcode
                        if (tAutoratio.GetAutoRatioAlarm() > 0)
                        {
                            str = "Auto-Ratio Alarm !!!";
                            AddMessage(str);
                            m_labelCal.Text = str;
                        }
                        else
                        {
                            //' 2- if no erreur -> Read & Save parameters
                            AddMessage("F28_GetModuleParameters !!!");

                            if (F28.GetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
                            {
                                str = "Nominal value = " + tPara.fNominalValue.ToString("F3") + " - Ratio max. = " + tPara.fRatioMax.ToString("F3") + " - Ratio min. = " + tPara.fRatioMin.ToString("F3");
                            }
                            else
                            {
                                str = "Read parameters error !!!";
                            }

                            AddMessage(str);
                            m_labelCal.Text = str;
                        }
                    }
                }

                byte ucPhaseCal = tAutocal.GetPhase();

                // 2- Run Auto Calibration Offset + Volume
                if (tAutocal.IsCalRunning())       // (ucPhaseCal != AutoCal.CAL_AUTO_PHASES.AUTO_IDDLE)
                {
                    // Display phase
                    str = tAutocal.GetPhaseStr(ucPhaseCal);
                    m_labelCal.Text = str;

                    // Waiting Master leak
                    if (tAutocal.IsWaitingMasterLeak())    //(ucPhaseCal == AutoCal.CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK)
                    {
                        timerRealTime.Stop();

                        string message = "Put master leak\n\nOK to Continue, Cancel to abort ? ";
                        string caption = "Master leak";

		                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
		                DialogResult result;

		                // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);

		                if (result == System.Windows.Forms.DialogResult.OK)
		                {
                            tAutocal.RunCalContinue(true);
                        }
                        else
                        {
                            tAutocal.RunCalContinue(false);
                        }

                        ucPhaseCal = tAutocal.GetPhase();

                        str = tAutocal.GetPhaseStr(ucPhaseCal);

                        m_labelCal.Text = str;

                        timerRealTime.Start();
                    }

                    // Running End auto calibration ?
                    if (tAutocal.RunCal())		
                    {
                        // ' 1- Read auto calibration errcode
                        if (tAutocal.GetCalAlarm() > 0)
                        {
                            str = "Calibration Alarm !!!";
                            AddMessage(str);
                            m_labelCal.Text = str;
                        }
                        else
                        {
                            //' 2- if no erreur -> Read & Save parameters
                            AddMessage("F28_GetModuleParameters !!!");

                            if (F28.GetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
                            {
                                str = "Offset = " + tPara.fOffsetLeak.ToString("F4") + " - Volume = " + tPara.fVolume.ToString("F2");
                            }
                            else
                            {
                                str = "Read parameters error !!!";
                            }

                            AddMessage(str);
                            m_labelCal.Text = str;
                        }
                    }
                }

                byte ucPhaseEasyAuto = tEasyAuto.GetPhase();

                // 3- Easy Auto Learning
                if (tEasyAuto.IsEasyAutoLearningRunning())
                {
                    // Display phase
                    str = tEasyAuto.GetPhaseStr(ucPhaseEasyAuto);
                    m_labelCal.Text = str;

                    // Running End easy auto learning ?
                    if (tEasyAuto.RunEasyAutoLearning())
                    {
                        // ' 1- Read errcode
                        if (tEasyAuto.GetEasyAutoLearningAlarm() > 0)
                        {
                            str = "Easy Auto Learning Alarm !!!";
                            AddMessage(str);
                            m_labelCal.Text = str;
                        }
                        else
                        {
                            //' 2- if no erreur -> Read & Save parameters
                            AddMessage("F28_GetModuleParameters !!!");

                            if (F28.GetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
                            {
                                str = "Read parameters OK.";
                            }
                            else
                            {
                                str = "Read parameters error !!!";
                            }

                            AddMessage(str);
                            m_labelCal.Text = str;
                        }
                    }
                }

                // 4- Real time measurement

                F28LightCtrl.F28_REALTIME_CYCLE tResult = new F28LightCtrl.F28_REALTIME_CYCLE();

                if (F28.GetRealTimeData(sModule, ref tResult) == F28LightCtrl.F28_OK)
                {
                    m_ucCpt++;

                    // 1.403 :NEW:(1)
                    if (tAutocal.IsRunningVolumeCal())
                    {
                        tResult.fLeakValue *= 1000.0f;
                        tResult.bUnitLeak = (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_PASEC;
                    }

                    // Check end of cycle
                    if (tResult.bEndCycle == 1)
                    {
                        if (m_bEndCycle == 0)
                        {
                            if (F28.GetLastResult(sModule, ref tLastResult) == F28LightCtrl.F28_OK)
                            {
                                // 1.403 :NEW:(2)
                                if (tAutocal.IsRunningVolumeCal())
                                {
                                    tLastResult.fLeakValue *= 1000.0f;
                                    tLastResult.bUnitLeak = (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_PASEC;
                                }

                                DisplayResultFrame(ref tLastResult);

                                DisplayResultCount();
                            }
                        }

                        tResult.fPressureValue = tLastResult.fPressureValue;
                        tResult.bUnitPressure = tLastResult.bUnitPressure;
                        tResult.fLeakValue = tLastResult.fLeakValue;
                        tResult.bUnitLeak = tLastResult.bUnitLeak;
                    }

                    m_bEndCycle = tResult.bEndCycle;

                    // Display pressure
                    Pressure.Text = tResult.fPressureValue.ToString("F2");
                    if (tResult.bUnitPressure < (byte)F28LightCtrl.F28_PRESS_UNITS.NMAX_PRESS_UNITS)
                    {
                        PressureUnit.Text = F28.F28_STR_PRESS_UNITS[tResult.bUnitPressure];
                    }
                    else
                    {
                        LeakUnit.Text = EMPTY_FIELD;
                    }

                    // Leak
                    if (tResult.bUnitLeak == (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_SCCM)
                    {
                        Leak.Text = tResult.fLeakValue.ToString("F4");
                    }
                    else
                    {
                        Leak.Text = tResult.fLeakValue.ToString("F2");
                    }

                    if (tResult.bUnitLeak < (byte)F28LightCtrl.F28_LEAK_UNITS.NMAX_LEAK_UNITS)
                    {
                        LeakUnit.Text = F28.F28_STR_LEAK_UNITS[tResult.bUnitLeak];
                    }
                    // V2.0.0.4
                    else if (tResult.bUnitLeak == (byte)F28LightCtrl.F28_LEAK_UNITS.LEAK_JET_CHECK)
                    {
                        LeakUnit.Text = F28.F28_STR_LEAK_JET_CHECK;
                    }
                    // V2.0.0.4
                    else
                    {
                        LeakUnit.Text = EMPTY_FIELD;
                    }

                    // Status back color
                    if (tResult.bStatus > (byte)F28LightCtrl.F28_STATUS.F28_STATUS_READY)
                    {
                        Status.BackColor = Color.FromArgb(0, 128, 255);
                    }
                    else
                    {
                        // V2.0.0.4
                        if (tLastResult.bStatus == (byte)F28LightCtrl.F28_RESULT_STATUS_CODE.STATUS_GOOD_PART ||
                            tLastResult.bStatus == (byte)F28LightCtrl.F28_RESULT_STATUS_CODE.STATUS_ALARM_JET_CHECK_PASS)
                        {
                            Status.BackColor = Color.FromArgb(0, 128, 0);
                        }
                        else if (tLastResult.bStatus == (byte)F28LightCtrl.F28_RESULT_STATUS_CODE.STATUS_REF_FAIL_PART || tLastResult.bStatus == (byte)F28LightCtrl.F28_RESULT_STATUS_CODE.STATUS_TEST_FAIL_PART)
                        {
                            Status.BackColor = Color.FromArgb(200, 0, 0);
                        }
                        else
                        {
                            Status.BackColor = Color.FromArgb(245, 100, 10);
                        }
                    }

                    Status.Text = "<Eoc:" + tResult.bEndCycle.ToString()+ "> " + tResult.bStatus.ToString() + "->";
                    
                    if (tResult.bStatus != 0xFF)
                    {
                        if (tResult.bStatus <= (byte)F28LightCtrl.F28_STATUS.F28_STATUS_MAX)
                        {
                            Status.Text += F28.F28_STR_STATUS[tResult.bStatus];
                        }
                        else
                        {
                            Status.Text += EMPTY_FIELD;
                        }
                    }
                    else
                    {
                            Status.Text += EMPTY_FIELD;
                    }

                    PAtm.Text = tResult.fPatm.ToString("F2");
                    Temperature.Text = tResult.fInternalTemperature.ToString("F2");
                }
                else
                {
                    Pressure.Text = EMPTY_FIELD;
                    PressureUnit.Text = EMPTY_FIELD;
                    Leak.Text = EMPTY_FIELD;
                    LeakUnit.Text = EMPTY_FIELD;
                    Status.Text = EMPTY_FIELD;
                    PAtm.Text = EMPTY_FIELD;
                    Temperature.Text = EMPTY_FIELD;
                }
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonRegAdjust control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonRegAdjust_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (sModule > 0)
            {
                if (F28.StartRegulatorAdjust(sModule) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Start Regulator Adjust OK !!!");
                }
                else
                {
                    AddMessage("Start Regulator Adjust Error !!!");
                }
            }
        }

        private bool IsMsgPutMasterNoLeakOk()
        {
            bool bRet = false;
            string message = "Put master No leak\n\nOK to Continue, Cancel to abort ? ";
            string caption = "Master No leak";

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                bRet = true;
            }

            return bRet;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnOffsetOnly control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnOffsetOnly_Click(object sender, EventArgs e)
        {
            ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
            ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);
            float fOffsetMax = Convert.ToSingle(textBoxOffset.Text);

            short sModule = GetModule();

            // 1.501 Wait message No leak
            if ((sModule > 0) && IsMsgPutMasterNoLeakOk())
            {

                string str;
                bool bRet = tAutocal.StartCal(sModule, AutoCal.MODE_AUTO_CAL.OFFSET, wNbCycles, wInterCycle, fOffsetMax);
                if (bRet)
                {
                    str = "Start Offset Cal Ok !!";
                }
                else
                {
                    str = "Start Offset Cal Error!!";
                }

                m_labelCal.Text = str;
                AddMessage(str);

            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnAutoVolume control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnAutoVolume_Click(object sender, EventArgs e)
        {
            ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
            ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);
            float fOffsetMax = Convert.ToSingle(textBoxOffset.Text);

            float fVolumeLeak = Convert.ToSingle(textBoxLeakCal.Text);
            float fVolumePressure = Convert.ToSingle(textBoxPressureCal.Text);
            float fVolumeMin = Convert.ToSingle(textBoxVolMinCal.Text);
            float fVolumeMax = Convert.ToSingle(textBoxVolMaxCal.Text);

            short sModule = GetModule();
            // 1.501 Wait message No leak
            if ((sModule > 0) && IsMsgPutMasterNoLeakOk())
            {
                string str;

                bool bRet = tAutocal.StartCal(sModule, AutoCal.MODE_AUTO_CAL.OFFSET_VOLUME, wNbCycles, wInterCycle, fOffsetMax,
                            fVolumeLeak,
                            fVolumePressure,
                            fVolumeMin,
                            fVolumeMax);
                if (bRet)
                {
                    str = "Start Offset + Volume Cal Ok !!";
                }
                else
                {
                    str = "Start Offset + Volume Cal Error!!";
                }

                m_labelCal.Text = str;
                AddMessage(str);
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnStopAutoCal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnStopAutoCal_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();
            if (sModule > 0)
            {
                string str;

                if (tAutocal.IsCalRunning())
                {
                    bool bRet = tAutocal.StopCal();

                    if (bRet)
                    {
                        byte ucPhaseCal = tAutocal.GetPhase();
                        str = tAutocal.GetPhaseStr(ucPhaseCal);
                    }
                    else
                    {
                        str = "Stop Cal Error!!";
                    }

                    AddMessage(str);
                    m_labelCal.Text = str;
                }

                if (tAutoratio.IsAutoRatioRunning())
                {
                    bool bRet = tAutoratio.StopAutoRatio();

                    if (bRet)
                    {
                        byte ucPhase = tAutoratio.GetPhase();
                        str = tAutoratio.GetPhaseStr(ucPhase);
                    }
                    else
                    {
                        str = "Stop Auto-Ratio Error!!";
                    }

                    AddMessage(str);
                    m_labelCal.Text = str;
                }

                if (tEasyAuto.IsEasyAutoLearningRunning())
                {
                    bool bRet = tEasyAuto.StopEasyAutoLearning();

                    if (bRet)
                    {
                        byte ucPhase = tEasyAuto.GetPhase();
                        str = tEasyAuto.GetPhaseStr(ucPhase);
                    }
                    else
                    {
                        str = "Stop Easy Auto Learning Error!!";
                    }

                    AddMessage(str);
                    m_labelCal.Text = str;
                }
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the buttonReadParameters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void buttonReadParameters_Click(object sender, EventArgs e)
        {
            FormPara frmPara = new FormPara();

            short sModule = GetModule();

            if (F28.GetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
            {
                AddMessage ("Read parameters list OK");

                frmPara.SetParameters(ref tPara);

                if (frmPara.ShowDialog() == DialogResult.OK)
                {
                    tPara = frmPara.GetParameters();

                    if (F28.SetModuleParameters(sModule, ref tPara) == F28LightCtrl.F28_OK)
                    {
                        F28.GetModuleParameters(sModule, ref tPara);    // Read parameters to update some parameters in the structure
                        AddMessage("New parameters list writen");
                    }
                    else
                    {
                        AddMessage("Error writink new parameters list !");
                    }
                }
            }
            else
            {
                    AddMessage ("Error reading parameters list !");
            }
       }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClearListbox_Click(object sender, EventArgs e)
        {
            listBoxMessage.Items.Clear();
        }

        /// ************************************************************************************************
        /// 1.404 How to Start autocal Offset for several modules
        /// ************************************************************************************************

        /// ************************************************************************************************
        /// <summary>
        /// Adds the module2.
        /// </summary>
        /// <param name="bGroup">The b group.</param>
        /// <param name="ucIdxNumber">The uc index number.</param>
        /// <param name="strIP">The string ip.</param>
        /// <returns></returns>
        /// ************************************************************************************************
        private short AddModule2(byte bGroup, byte ucIdxNumber, string strIP)
        {
            IPAddress IPAddress = IPAddress.Parse(strIP);
            uint ulAddress = BitConverter.ToUInt32(IPAddress.GetAddressBytes(), 0);             // 1.504
            short sModuleId = -1;


            if (!m_bAPIOpened) return sModuleId;

            sModuleId = F28.AddModule(ulAddress, ucIdxNumber, bGroup, 3);

            AddMessage("---------------------");

            if (sModuleId != F28LightCtrl.F28_FAIL)
            {
                AddMessage("Module added ->" + sModuleId.ToString());
                DisplayInfo(sModuleId);
            }
            else
            {
                AddMessage("Error adding module !");
            }

            return sModuleId;
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnHead1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnHead1_Click(object sender, EventArgs e)
        {
            byte ucGroup = 1;
            byte ucIdxNumber = 2;

            short sModuleId1 = AddModule2(ucGroup, ucIdxNumber, textBoxIPHead1.Text);
            if (sModuleId1 > 0)
            {
                listBox2Heads.Items.Add(sModuleId1.ToString());

                timerHead1.Start();

                timerCounters.Enabled = true;

            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnHead2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnHead2_Click(object sender, EventArgs e)
        {
            byte ucGroup = 1;
            byte ucIdxNumber = 3;

            short sModuleId2 = AddModule2(ucGroup, ucIdxNumber, textBoxIPHead2.Text);
            if (sModuleId2 > 0)
            {
                listBox2Heads.Items.Add(sModuleId2.ToString());

                timerHead2.Start();

                timerCounters.Enabled = true;

            }
         }
   
        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnStart2Heads control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnStart2Heads_Click(object sender, EventArgs e)
        {
            string strBuff;
            short sModuleId, sRet;

            int n = listBox2Heads.Items.Count;

            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    strBuff = listBox2Heads.Items[i].ToString();

                    sModuleId = Convert.ToInt16(strBuff);

                    if (m_bAPIOpened && (F28.IsModuleConnected(sModuleId) == F28LightCtrl.F28_CONNECTED))
                    {
                        sRet = F28.StartCycle(sModuleId);

                        if (sRet == F28LightCtrl.F28_OK)
                        {
                            AddMessage("Start Ok -> " + sModuleId.ToString());
                        }
                        else
                        {
                            AddMessage("Start error -> " + sModuleId.ToString());
                        }
                    }
                }
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Click event of the btnStartOffset2Heads control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void btnStartOffset2Heads_Click(object sender, EventArgs e)
        {
            string strBuff;
            short sModuleId;
            short sRet;

            // Get all autocal Offset parameters
            ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
            ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);
            float fOffsetMax = Convert.ToSingle(textBoxOffset.Text);

            // Check the head numbers in the networks
            int n = listBox2Heads.Items.Count;

            if (n > 0)
            {
                // Repeat for each head, send AutoCal Offset
                for (int i = 0; i < n ; i++)
                {
                    strBuff = listBox2Heads.Items[i].ToString();

                    sModuleId = Convert.ToInt16(strBuff);

                    if (m_bAPIOpened && (F28.IsModuleConnected(sModuleId) == F28LightCtrl.F28_CONNECTED))
                    {
                        sRet = F28.StartAutoCalOffsetOnly(sModuleId, wNbCycles, wInterCycle, fOffsetMax);
                            
                        if (sRet == F28LightCtrl.F28_OK)
                        {
                            AddMessage("Start Auto Cal Offset only Ok -> " + sModuleId.ToString());
                        }
                        else
                        {
                            AddMessage("Start Auto Cal Offset only error -> " + sModuleId.ToString());
                        }
                    }
                }
            }
        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Tick event of the timerHead1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void timerHead1_Tick(object sender, EventArgs e)
        {
            int n = listBox2Heads.Items.Count;

            if (n > 0)
            {
                string strBuff;
                strBuff = listBox2Heads.Items[0].ToString();
                short sModuleId = Convert.ToInt16(strBuff);

                if (sModuleId > 0)
                {
                    F28LightCtrl.F28_REALTIME_CYCLE tRealtime = new F28LightCtrl.F28_REALTIME_CYCLE();

                    if (F28.GetRealTimeData(sModuleId, ref tRealtime) == F28LightCtrl.F28_OK)
                    {
                        labelStateHead1.Text = sModuleId.ToString() + ":<Eoc:" + tRealtime.bEndCycle.ToString() + ">" + tRealtime.bStatus.ToString() + ":"; 

                        if (tRealtime.bStatus != 0xFF)
                        {
                            if (tRealtime.bStatus <= (byte)F28LightCtrl.F28_STATUS.F28_STATUS_MAX)
                            {
                                labelStateHead1.Text += F28.F28_STR_STATUS[tRealtime.bStatus];
                            }
                            else
                            {
                                labelStateHead1.Text += "";
                            }
                        }
                        else
                        {
                            labelStateHead1.Text += "";
                        }
                    }

                    F28LightCtrl.F28_COMMUNICATION_STATISTICS tStat = new F28LightCtrl.F28_COMMUNICATION_STATISTICS();

                    if (F28.GetCommunicationStatistics(sModuleId, ref tStat) == F28LightCtrl.F28_OK)
                    {
                        label1T.Text = tStat.uiTransmited.ToString();
                        label1R.Text = tStat.uiReceived.ToString();
                        label1E.Text = tStat.uiErrors.ToString();
                    }
                }
            }

        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Tick event of the timerHead2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void timerHead2_Tick(object sender, EventArgs e)
        {
            int n = listBox2Heads.Items.Count;

            if (n > 1)
            {
                string strBuff;
                strBuff = listBox2Heads.Items[1].ToString();
                short sModuleId = Convert.ToInt16(strBuff);

                if (sModuleId > 0)
                {
                    F28LightCtrl.F28_REALTIME_CYCLE tRealtime = new F28LightCtrl.F28_REALTIME_CYCLE();

                    if (F28.GetRealTimeData(sModuleId, ref tRealtime) == F28LightCtrl.F28_OK)
                    {
                        labelStateHead2.Text = sModuleId.ToString() + ":<Eoc:" + tRealtime.bEndCycle.ToString() + ">" + tRealtime.bStatus.ToString() +":";

                        if (tRealtime.bStatus != 0xFF)
                        {
                            if (tRealtime.bStatus <= (byte)F28LightCtrl.F28_STATUS.F28_STATUS_MAX)
                            {
                                labelStateHead2.Text += F28.F28_STR_STATUS[tRealtime.bStatus];
                            }
                            else
                            {
                                labelStateHead2.Text += "";
                            }
                        }
                        else
                        {
                            labelStateHead2.Text += "";
                        }
                    }

                    F28LightCtrl.F28_COMMUNICATION_STATISTICS tStat = new F28LightCtrl.F28_COMMUNICATION_STATISTICS();

                    if (F28.GetCommunicationStatistics(sModuleId, ref tStat) == F28LightCtrl.F28_OK)
                    {
                        label2T.Text = tStat.uiTransmited.ToString();
                        label2R.Text = tStat.uiReceived.ToString();
                        label2E.Text = tStat.uiErrors.ToString();
                    }
                }
            }

        }

        /// ************************************************************************************************
        /// <summary>
        /// Handles the Tick event of the timerCounters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// ************************************************************************************************
        private void timerCounters_Tick(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (m_bAPIOpened && (sModule != -1))
            {
                short sConnect = F28.IsModuleConnected(sModule);

                // If module is disconnected
                if (sConnect != F28LightCtrl.F28_CONNECTED)
                {
                    // 1.404 Reset ethernet module to reconnect
                    chkConnected.Checked = false;

                    F28.ResetEthernetModule(sModule);
                }
                else
                {
                    // Read & display counter

                    F28LightCtrl.F28_COMMUNICATION_STATISTICS tStat = new F28LightCtrl.F28_COMMUNICATION_STATISTICS();

                    chkConnected.Checked = true;

                    if (F28.GetCommunicationStatistics(sModule, ref tStat) == F28LightCtrl.F28_OK)
                    {
                        labelTransmit.Text = tStat.uiTransmited.ToString();
                        labelReceive.Text = tStat.uiReceived.ToString();
                        labelError.Text = tStat.uiErrors.ToString();
                    }
                }
            }

            // 1.404 - Keep alive module 1 & 2
            {
                string strBuff;

                // Check the head numbers in the networks
                int n = listBox2Heads.Items.Count;

                if (n > 0)
                {
                    // Repeat for each head, send AutoCal Offset
                    for (int i = 0; i < n; i++)
                    {
                        strBuff = listBox2Heads.Items[i].ToString();
                        sModule = Convert.ToInt16(strBuff);

                        short sConnect = F28.IsModuleConnected(sModule);

                        // If module is disconnected
                        if (sConnect != F28LightCtrl.F28_CONNECTED)
                        {
                            // 1.404 Reset ethernet module to reconnect
                            if (i == 0)
                                chkConnected1.Checked = false;
                            else
                                chkConnected2.Checked = false;

                            F28.ResetEthernetModule(sModule);
                        }
                        else
                        {
                            if (i == 0)
                                chkConnected1.Checked = true;
                            else
                                chkConnected2.Checked = true;

                        }

                    }
                }
            }
        }

        // 1.500 Electronic regulator learn
        private void buttonElecRegLearn_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (sModule > 0)
            {
                if (F28.StartLearningRegulator(sModule, float.Parse(textBoxAZDumpTime.Text)) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Start Electronic regulator learn OK !!!");
                }
                else
                {
                    AddMessage("Start Electronic regulator learn Error !!!");
                }
            }
        }

        // V2.0.0.4
        private void buttonJetCheck_Click(object sender, EventArgs e)
        {
            short sModule = GetModule();

            if (sModule > 0)
            {
                if (F28.StartJetCheck(sModule) == F28LightCtrl.F28_OK)
                {
                    AddMessage("Start Jet check OK !!!");
                }
                else
                {
                    AddMessage("Start Start jet check Error !!!");
                }
            }
        }

        private void btnAutoRatio_Click(object sender, EventArgs e)
        {
            ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
            ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);
            float fRatioMax = tPara.fCoeffMax;
            float fRatioMin = tPara.fCoeffMin;

            short sModule = GetModule();

            if (sModule > 0)
            {
                string str;
                bool bRet = tAutoratio.StartAutoRatio(sModule, wNbCycles, wInterCycle, fRatioMax, fRatioMin);
                if (bRet)
                {
                    str = "Start Auto-Ratio Ok !!";
                }
                else
                {
                    str = "Start Auto-Ratio Error!!";
                }

                m_labelCal.Text = str;
                AddMessage(str);
            }
        }

        private void btnStartAutoRatio2Heads_Click(object sender, EventArgs e)
        {
            string strBuff;
            short sModuleId, sRet;

            int n = listBox2Heads.Items.Count;

            if (n > 0)
            {
                ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
                ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);
                float fRatioMax = tPara.fCoeffMax;
                float fRatioMin = tPara.fCoeffMin;
                
                for (int i = 0; i < n; i++)
                {
                    strBuff = listBox2Heads.Items[i].ToString();

                    sModuleId = Convert.ToInt16(strBuff);

                    if (m_bAPIOpened && (F28.IsModuleConnected(sModuleId) == F28LightCtrl.F28_CONNECTED))
                    {
                        sRet = F28.StartAutoRatio(sModuleId, wNbCycles, wInterCycle, fRatioMax, fRatioMin);

                        if (sRet == F28LightCtrl.F28_OK)
                        {
                            AddMessage("Start Auto-Ratio -> " + sModuleId.ToString());
                        }
                        else
                        {
                            AddMessage("Start Auto-Ratio error -> " + sModuleId.ToString());
                        }
                    }
                }
            }
        }

        private void btnEasyAutoLearning_Click(object sender, EventArgs e)
        {
            ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
            ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);

            short sModule = GetModule();

            if (sModule > 0)
            {
                string str;
                bool bRet = tEasyAuto.StartEasyAutoLearning(sModule, wNbCycles, wInterCycle);

                if (bRet)
                {
                    str = "Start Easy Auto Learning Ok !!";
                }
                else
                {
                    str = "Start Easy Auto Learning Error!!";
                }

                m_labelCal.Text = str;
                AddMessage(str);
            }
        }

        private void btnStartEasyAuto2Heads_Click(object sender, EventArgs e)
        {
            string strBuff;
            short sModuleId, sRet;

            int n = listBox2Heads.Items.Count;

            if (n > 0)
            {
                ushort wNbCycles = Convert.ToUInt16(textBoxCycleNumber.Text);
                ushort wInterCycle = Convert.ToUInt16(textBoxIntercycle.Text);

                for (int i = 0; i < n; i++)
                {
                    strBuff = listBox2Heads.Items[i].ToString();

                    sModuleId = Convert.ToInt16(strBuff);

                    if (m_bAPIOpened && (F28.IsModuleConnected(sModuleId) == F28LightCtrl.F28_CONNECTED))
                    {
                        sRet = F28.StartEasyAutoLearning(sModuleId, wNbCycles, wInterCycle);

                        if (sRet == F28LightCtrl.F28_OK)
                        {
                            AddMessage("Start Easy Auto Learning -> " + sModuleId.ToString());
                        }
                        else
                        {
                            AddMessage("Start Easy Auto Learning error -> " + sModuleId.ToString());
                        }
                    }
                }
            }

        }    
    }
}
