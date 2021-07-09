' ******************************************************************************************
' 15/07/15 1.000    - Original version CAN INTERFACE
' ******************************************************************************************
' ******************************************************************************************
' 13/10/15  1.300   - Add support Ethernet (Library Ethernet)
' ******************************************************************************************
' 19/10/15  1.301   - :Add: Get Ethernet info
'                   - :FIX: Warning compilation when use obsolete IPAdress.Address
' 02/11/15  1.302   - :Add: Auto zero button
'                   - Delete CAN interface from example
' *******************************************************************************************
' 19/11/15  1.400   - Add auto calibration functions 
' 01/12/15  1.403   - Correction auto volume + Offset real time measurement
' *******************************************************************************************
' 03/12/05  1.404   - Example how to start cycle/Start Calibration for 3 heads
'                   - WatchDog every 2 sec to communicate continously when the unit is not use 
'                   - Use of F28_ResetEthernetModule, to Reset Ethernet module if the connection 
'                     is lost
'                   - Intercycle time, for auto calibration, changed from ms to cs (0.01s)
' ********************************************************************************************
' 23/12/15 1.500    - Add parameters (no size changed)
'                       - Leak units 
'                       - Test type
'                       - Fill mode
'                       - Options
'                   - Electronic Regulator
' *******************************************************************************************
' 05/01/16 1.501    - if Abort Cal process -> Send F28_StopAutoCal see RunContinue(false)
' *******************************************************************************************
' 21/07/16 1.504    - Add capability to use AddModule after RemoveModule, RemoveAllModule
'                   without InitModule 
'                   - Add button RemoveModule
'                   - :FIX: Warning in debug mode 'f28 addmodule' has unbalanced the stack
'                       . Replace all functions declarations from ULong to UInteger,  
' *******************************************************************************************
' 02/03/17 2.0.0.4  - Add Jet check
'                   - Add new alarms status
' *******************************************************************************************
' 30/06/17 2.0.0.6  - Add leak unit cmH2O
' *******************************************************************************************
' 26/11/18 2.0.0.13  - Add Auto-Ratio
' *******************************************************************************************
' 12/04/19 2.0.0.15 - Add Flow test (FC28L)
'                   - Add special cycle learning volume test
'                   - Add special cycle learning volume reference
'                   - Add special cycle infinite dump
' *******************************************************************************************
' 24/06/19 2.0.0.16 - Modif auto ratio
'                   - New Fill mode
' *******************************************************************************************
' 01/07/19 2.0.0.17 - Add special cycle Easy Auto Learning
' *******************************************************************************************
' 04/11/19 2.0.0.18  - Add leak unit ugH2O
' *******************************************************************************************

Imports VBF28LightControlDemo.F28LightControl
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Globalization

Public Class mainForm

    Public m_sModuleID As Short
    Public m_bAPIOpened As Boolean
    Public m_bChannelOk As Boolean
    Public m_realTime As F28_REALTIME_CYCLE
    Public m_Result As F28_RESULT
    Public m_rCptComm As F28_COMMUNICATION_STATISTICS

    ' 1.301 19/10/15 Get Ethernet info
    Public m_deviceEthernetInfo As T_ETH_INFO

    ' 1.400 Auto Calibration
    Public m_autocal As New AutoCal
    Public m_autoratio As New AutoRatio
    Public m_easyauto As New EasyAutoLearning

    ' *******************************************************************
    ' Functions
    ' *******************************************************************

    '
    ' ------------------------------------------------------------------
    ' Get cycle phase string
    ' ------------------------------------------------------------------
    '
    Private Function GetPhaseStr(ucPhase As Byte) As String
        Dim strRet As String

        strRet = "????"
        Select Case ucPhase
            Case F28_ENUM_STEP_CODE.FILL_STEP
                strRet = "FILL"
            Case F28_ENUM_STEP_CODE.STAB_STEP
                strRet = "STABILISATION"
            Case F28_ENUM_STEP_CODE.TEST_STEP
                strRet = "TEST"
            Case F28_ENUM_STEP_CODE.DUMP_STEP
                strRet = "DUMP"
            Case F28_ENUM_STEP_CODE.FILL_VOLUME_STEP
                strRet = "FILL VOLUME"
            Case F28_ENUM_STEP_CODE.TRANSFERT_STEP
                strRet = "TRANSFERT"
            Case F28_ENUM_STEP_CODE.NO_STEP
                strRet = "READY"
        End Select

        GetPhaseStr = strRet

    End Function

    '
    ' ------------------------------------------------------------------
    ' Get leak unit string
    ' ------------------------------------------------------------------
    '
    Private Function GetLeakUnitStr(ucUnit As Byte) As String
        Dim strRet As String

        strRet = "????"
        Select Case ucUnit
            Case F28_LEAK_UNITS.LEAK_PA
                strRet = "Pa"
            Case F28_LEAK_UNITS.LEAK_PASEC
                strRet = "Pa/s"
            Case F28_LEAK_UNITS.LEAK_PA_HR
                strRet = "Pa(Hr)"
            Case F28_LEAK_UNITS.LEAK_PASEC_HR
                strRet = "Pa/s(Hr)"
            Case F28_LEAK_UNITS.LEAK_CAL_PA
                strRet = "Pa"
            Case F28_LEAK_UNITS.LEAK_CAL_PASEC
                strRet = "Pa/s"
            Case F28_LEAK_UNITS.LEAK_CCMIN
                strRet = "cc/mn"
            Case F28_LEAK_UNITS.LEAK_CCSEC
                strRet = "cc/s"
            Case F28_LEAK_UNITS.LEAK_CCH
                strRet = "cc/h"
            Case F28_LEAK_UNITS.LEAK_MM3SEC
                strRet = "mm3/s"
            Case F28_LEAK_UNITS.LEAK_CM3_SEC
                strRet = "cm3/s"
            Case F28_LEAK_UNITS.LEAK_CM3_MIN
                strRet = "cm3/mn"
            Case F28_LEAK_UNITS.LEAK_CM3_H
                strRet = "cm3/h"
            Case F28_LEAK_UNITS.LEAK_ML_SEC
                strRet = "ml/s"
            Case F28_LEAK_UNITS.LEAK_ML_MIN
                strRet = "ml/mn"
            Case F28_LEAK_UNITS.LEAK_ML_H
                strRet = "ml/h"
            Case F28_LEAK_UNITS.LEAK_INCH3_SEC
                strRet = "inch3/s"
            Case F28_LEAK_UNITS.LEAK_INCH3_MIN
                strRet = "inch3/mn"
            Case F28_LEAK_UNITS.LEAK_INCH3_H
                strRet = "inch3/h"
            Case F28_LEAK_UNITS.LEAK_FT3_SEC
                strRet = "ft3/s"
            Case F28_LEAK_UNITS.LEAK_FT3_MIN
                strRet = "ft3/mn"
            Case F28_LEAK_UNITS.LEAK_FT3_H
                strRet = "ft3/h"
            Case F28_LEAK_UNITS.LEAK_MMCE
                strRet = "mmCE"
            Case F28_LEAK_UNITS.LEAK_MMCE_SEC
                strRet = "mmCE/s"
            Case F28_LEAK_UNITS.LEAK_SCCM
                strRet = "sccm"
            Case F28_LEAK_UNITS.LEAK_POINTS
                strRet = "Pts"
                '  1.500 Leak units
            Case F28_LEAK_UNITS.LEAK_KPA
                strRet = "kPa"
            Case F28_LEAK_UNITS.LEAK_MPA
                strRet = "MPa"
            Case F28_LEAK_UNITS.LEAK_BAR
                strRet = "bar"
            Case F28_LEAK_UNITS.LEAK_mBAR
                strRet = "mbar"
            Case F28_LEAK_UNITS.LEAK_PSI
                strRet = "PSI"
            Case F28_LEAK_UNITS.LEAK_L_MIN
                strRet = "l/mn"
                ' end 1500
                ' V2.0.0.4
            Case F28_LEAK_UNITS.LEAK_CM_H2O
                strRet = "cmH2O"
            Case F28_LEAK_UNITS.LEAK_UG_H2O
                strRet = "ugH2O"

            Case F28_LEAK_UNITS.LEAK_JET_CHECK
                strRet = "mm"

        End Select

        GetLeakUnitStr = strRet

    End Function
    '
    ' ------------------------------------------------------------------
    ' Get pressure unit string
    ' ------------------------------------------------------------------
    '

    Private Function GetPressureUnitStr(ucUnit As Byte) As String
        Dim strRet As String

        strRet = "????"
        Select Case ucUnit
            Case F28_PRESS_UNITS.PRESS_PA
                strRet = "Pa"
            Case F28_PRESS_UNITS.PRESS_MPA
                strRet = "MPa"
            Case F28_PRESS_UNITS.PRESS_KPA
                strRet = "KPa"
            Case F28_PRESS_UNITS.PRESS_mBAR
                strRet = "mBar"
            Case F28_PRESS_UNITS.PRESS_BAR
                strRet = "Bar"
            Case F28_PRESS_UNITS.PRESS_PSI
                strRet = "PSI"
            Case F28_PRESS_UNITS.PRESS_POINTS
                strRet = "Pts"
        End Select

        GetPressureUnitStr = strRet

    End Function

    ' *****************************************************************************************
    'STATUS_GOOD_PART	                        PASS
    'STATUS_TEST_FAIL_PART	                    TEST FAIL
    'STATUS_REF_FAIL_PART	                    REF FAIL
    'STATUS_ALARM_EEEE	                        TEST OVER FULL SCALE : GROSS LEAK
    'STATUS_ALARM_MMMM	                        REF OVER FULL SCALE : GROSS LEAK
    'STATUS_ALARM_PPPP	                        PRESS. SIGNAL at VMax : PRESS. SENSOR DEFAULT
    'STATUS_ALARM_MPPP	                        PRESS. SIGNAL at Vmin : PRESS. SENSOR DEFAULT
    'STATUS_ALARM_OFFD_FUITE	                DIFF AZ DEFAULT: DIFF SENSOR DEFAULT
    'STATUS_ALARM_OFFD_PRESSION	                PRESS AZ DEFAULT: PRESS SENSOR DEFAULT
    'STATUS_ALARM_PST	                        PRESSURE TOO HIGH 
    'STATUS_ALARM_MPST	                        PRESSURE TOO LOW
    'STATUS_ALARM_CS_VOLUME_PETIT	            SEALED VOLUME TOO LOW
    'STATUS_ALARM_CS_VOLUME_GRAND	            FAIL SEALED VOLUME (TOO HIGH)
    'STATUS_ALARM_ERREUR_PRESS_CALIBRATION	    DEF PRESS CALIB
    'STATUS_ALARM_ERREUR_LEAK_CALIBRATION	    DEF DIFF CALIB
    'STATUS_ALARM_ERREUR_LINE_PRESS_CALIBRATION	DEF LINE CALIB
    'STATUS_ALARM_OFFD_PRESSION_PIEZO_2	        P2 AZ DEFAULT: P2 SENSOR DEFAULT
    'STATUS_ALARM_PPPP_PIEZO_2	                PRESS. SIGNAL at VMax : P2 SENSOR DEFAULT
    'STATUS_ALARM_MPPP_PIEZO_2	                PRESS. SIGNAL at Vmin : P2 SENSOR DEFAULT
    'STATUS_ALARM_PST_PIEZO_2	                P2 TOO HIGH 
    'STATUS_ALARM_MPST_PIEZO_2	                P2 TOO LOW
    ' *****************************************************************************************

    ' ------------------------------------------------------------------
    ' Get result status string
    ' ------------------------------------------------------------------
    '
    Private Function GetResultStr(ucRslt As Byte) As String
        Dim strRet As String

        strRet = "????"

        Select Case ucRslt
            Case F28_RSLT_STATUS.STATUS_GOOD_PART
                strRet = "PASS"
            Case F28_RSLT_STATUS.STATUS_TEST_FAIL_PART
                strRet = "TEST FAIL"
            Case F28_RSLT_STATUS.STATUS_REF_FAIL_PART
                strRet = "REF FAIL"
            Case F28_RSLT_STATUS.STATUS_ALARM_EEEE
                strRet = "TEST OVER FULL SCALE : GROSS LEAK"
            Case F28_RSLT_STATUS.STATUS_ALARM_MMMM
                strRet = "REF OVER FULL SCALE : GROSS LEAK"
            Case F28_RSLT_STATUS.STATUS_ALARM_PPPP
                strRet = "VMax : PRESS. SENSOR DEFAULT"
            Case F28_RSLT_STATUS.STATUS_ALARM_MPPP
                strRet = "Vmin : PRESS. SENSOR DEFAULT"
            Case F28_RSLT_STATUS.STATUS_ALARM_OFFD_FUITE
                strRet = "DIFF AZ DEFAULT: DIFF SENSOR DEFAULT"
            Case F28_RSLT_STATUS.STATUS_ALARM_OFFD_PRESSION
                strRet = "PRESS AZ DEFAULT: PRESS SENSOR DEFAUL"
            Case F28_RSLT_STATUS.STATUS_ALARM_PST
                strRet = "PRESSURE TOO HIGH"
            Case F28_RSLT_STATUS.STATUS_ALARM_MPST
                strRet = "PRESSURE TOO LOW"
            Case F28_RSLT_STATUS.STATUS_ALARM_CS_VOLUME_PETIT
                strRet = "SEALED VOLUME TOO LOW"
            Case F28_RSLT_STATUS.STATUS_ALARM_CS_VOLUME_GRAND
                strRet = "FAIL SEALED VOLUME (TOO HIGH)"
            Case F28_RSLT_STATUS.STATUS_ALARM_ERREUR_PRESS_CALIBRATION
                strRet = "DEF PRESS CALIB"
            Case F28_RSLT_STATUS.STATUS_ALARM_ERREUR_LEAK_CALIBRATION
                strRet = "DEF DIFF CALIB"
            Case F28_RSLT_STATUS.STATUS_ALARM_ERREUR_LINE_PRESS_CALIBRATION
                strRet = "ERR CAL P LINE"
                ' V2.0.0.4
            Case F28_RSLT_STATUS.STATUS_ALARM_APPR_REG_ELEC_ERROR
                strRet = "ELECTRONIC REG LEARNING FAIL"
            Case F28_RSLT_STATUS.STATUS_ALARM_TEST_PART_LARGE_LEAK
                strRet = "TEST PART LARGE LEAK ALARM"
            Case F28_RSLT_STATUS.STATUS_ALARM_REF_SIDE_LARGE_LEAK
                strRet = "REFERENCE SIDE LARGE LEAK ALARM"
            Case F28_RSLT_STATUS.STATUS_ALARM_P_TOO_LARGE_FILL
                strRet = "PRESSURE TOO HIGH FILL TIME"
            Case F28_RSLT_STATUS.STATUS_ALARM_P_TOO_LOW_FILL
                strRet = "PRESSURE TOO LOW FILL TIME"
            Case F28_RSLT_STATUS.STATUS_ALARM_JET_CHECK_FAIL
                strRet = "JET CHECK FAIL"
            Case F28_RSLT_STATUS.STATUS_ALARM_JET_CHECK_PASS
                strRet = "JET CHECK PASS"
            Case F28_RSLT_STATUS.STATUS_ALARM_INCOMPATIBLE_DEVICE
                strRet = "INCOMPATIBLE DEVICE"


        End Select

        Return strRet

    End Function
    '
    ' ------------------------------------------------------------------
    ' Display string to listbox
    ' ------------------------------------------------------------------
    '

    Private Sub DisplayTxt(ByVal szTxt As String)
        m_ListBoxMsg.Items.Add(szTxt)
        m_ListBoxMsg.Refresh()
        m_ListBoxMsg.SelectedIndex = m_ListBoxMsg.Items.Count() - 1
    End Sub

    '
    ' ------------------------------------------------------------------
    ' Display real time measurement
    ' ------------------------------------------------------------------
    '
    Private Sub DisplayRealTime()

        m_labelMeasure1.Text = m_realTime.fPressureValue.ToString("F")
        m_labelUnit1.Text = GetPressureUnitStr(m_realTime.ucUnitPressure)

        ' 1.400 Auto cal - sccm : 4 digits
        If (m_realTime.ucUnitLeak = F28_LEAK_UNITS.LEAK_PA) Then
            m_labelMeasure2.Text = m_realTime.fLeakValue.ToString("F2")
        Else
            m_labelMeasure2.Text = m_realTime.fLeakValue.ToString("F4")
        End If

        m_labelUnit2.Text = GetLeakUnitStr(m_realTime.ucUnitLeak)

        m_labelPAbs.Text = m_realTime.fPatm.ToString("F2")
        m_labelTemp.Text = m_realTime.fInternalTemperature.ToString("F2")

        m_labelPhase.Text = "<Eoc:" + m_realTime.ucEndCycle.ToString() + "> " + GetPhaseStr(m_realTime.ucStatus)

    End Sub
    '
    ' ------------------------------------------------------------------
    ' Display request counter
    ' ------------------------------------------------------------------
    '
    Private Sub DisplayCounter(ByRef rCptComm As F28_COMMUNICATION_STATISTICS)
        m_labelTransmit.Text = rCptComm.dwTransmited.ToString()
        m_labelReceive.Text = rCptComm.dwReceived.ToString()
        m_labelError.Text = rCptComm.dwErrors.ToString()
    End Sub

    ' ------------------------------------------------------------------
    ' Display result
    ' ------------------------------------------------------------------
    '
    Private Sub DisplayResult(ByVal ucCode As Byte)

        ' Display end of cycle result & unit, measurement
        If (ucCode = 0) Or (ucCode > 1) Then

            If m_Result.ucStatus <> 255 Then
                m_labelMeasure1.Text = m_Result.fPressureValue.ToString("F")
                m_labelUnit1.Text = GetPressureUnitStr(m_Result.ucUnitPressure)

                ' 1.400 Auto cal
                m_labelMeasure2.Text = m_Result.fLeakValue.ToString("F4")
                m_labelUnit2.Text = GetLeakUnitStr(m_Result.ucUnitLeak)
                m_labelPhase.Text = GetResultStr(m_Result.ucStatus)
            Else
                m_labelMeasure1.Text = "--"
                m_labelUnit1.Text = "--"

                m_labelMeasure2.Text = "--"
                m_labelUnit2.Text = "--"
                m_labelPhase.Text = "---"
            End If
        End If

        ' Display result to list
        If (ucCode >= 1) Then

            ' Not use
            ' Display to list

            ' DisplayTxt("----- Cycle Result -----")
            ' DisplayTxt(" . Date : " + _
            '         m_Result.dateReceived.wYear.ToString() + "/" + _
            '         m_Result.dateReceived.wMonth.ToString() + "/" + _
            '         m_Result.dateReceived.wDay.ToString() + " " + _
            '         m_Result.dateReceived.wHour.ToString() + ":" + _
            '         m_Result.dateReceived.wMinute.ToString() + ":" + _
            '         m_Result.dateReceived.wSecond.ToString())

            'DisplayTxt(" . Grp : " + m_Result.GroupID.ToString() + ", Module : " + m_Result.ModuleAddr.ToString())

            'DisplayTxt(" . Status : " + GetResultStr(m_Result.ucStatus))


            'DisplayTxt(" . Pressure : " + m_Result.fPressureValue.ToString("F") + " " + GetPressureUnitStr(m_Result.ucUnitPressure))

            ' 1.400 Auto cal
            'DisplayTxt(" . Leak : " + m_Result.fLeakValue.ToString("F4") + " " + GetLeakUnitStr(m_Result.ucUnitLeak))
            ' End


            ' 1.403
            DisplayTxt(m_Result.dateReceived.wYear.ToString() + "/" + _
                                   m_Result.dateReceived.wMonth.ToString("D2") + "/" + _
                                   m_Result.dateReceived.wDay.ToString("D2") + " " + _
                                   m_Result.dateReceived.wHour.ToString("D2") + ":" + _
                                   m_Result.dateReceived.wMinute.ToString("D2") + ":" + _
                                   m_Result.dateReceived.wSecond.ToString("D2") + _
                                   " " + m_Result.GroupID.ToString() + " " + m_Result.ModuleAddr.ToString() + _
                                   " " + GetResultStr(m_Result.ucStatus) + _
                                   " " + m_Result.fPressureValue.ToString("F") + " " + GetPressureUnitStr(m_Result.ucUnitPressure) + _
                                   " " + m_Result.fLeakValue.ToString("F4") + " " + GetLeakUnitStr(m_Result.ucUnitLeak))


        End If

    End Sub

    '
    ' ------------------------------------------------------------------
    ' Convert from IP string to 32 bits 
    ' ------------------------------------------------------------------
    '
    Private Function IPString2Long(ByVal DottedIP As String) As UInteger            ' 1.504 Long
        Dim arrDec() As String
        Dim lResult As UInteger         '  1.504  Long

        lResult = 0
        If DottedIP <> "" Then
            arrDec = DottedIP.Split(".")
            If (arrDec.Length = 4) Then
                lResult = CLng(arrDec(3)) * 2 ^ 24 + CLng(arrDec(2)) * 2 ^ 16 + CLng(arrDec(1)) * 2 ^ 8 + CLng(arrDec(0))
            End If
        End If
        Return lResult
    End Function

    ' ------------------------------------------------------------------
    ' Read & display Ethernet information
    ' ------------------------------------------------------------------
    '
    Private Function GetEthernetInformation(ByVal sModuleID As Short, ByRef Info As T_ETH_INFO) As Short
        Dim sRet As Short
        Dim strBuff As String
        Dim ulIP As UInteger            ' 1.504
        Dim strMsg As String
        Const ucMaxBuff As Byte = 30


        strMsg = "   ......................"
        DisplayTxt(strMsg)

        ' Read soft version
        If (sRet = F28_RETURN.F28_OK) Then
            strBuff = Space(ucMaxBuff)
            sRet = F28_GetETHSoftVersion(sModuleID, strBuff, ucMaxBuff - 1)
            If (sRet = F28_RETURN.F28_OK) Then
                Info.strVersion = strBuff

                strMsg = "   . Ethernet soft version : " + Info.strVersion
                DisplayTxt(strMsg)

            End If
        End If

        ' Read hard version
        If (sRet = F28_RETURN.F28_OK) Then
            strBuff = Space(ucMaxBuff)
            sRet = F28_GetETHHardVersion(sModuleID, strBuff, ucMaxBuff - 1)
            If (sRet = F28_RETURN.F28_OK) Then
                Info.strHardVersion = strBuff

                strMsg = "   . Ethernet hard version : " + Info.strHardVersion
                DisplayTxt(strMsg)

            End If
        End If

        ' Read IP address
        sRet = F28_GetAddressIP(sModuleID, ulIP)
        If (sRet = F28_RETURN.F28_OK) Then
            Dim curIPAdd As New IPAddress(ulIP)
            Info.strIP = curIPAdd.ToString()

            strMsg = "   . Ethernet IP address : " + Info.strIP
            DisplayTxt(strMsg)

        End If

        ' Read Mask
        If (sRet = F28_RETURN.F28_OK) Then
            sRet = F28_GetSubnetMask(sModuleID, ulIP)
            If (sRet = F28_RETURN.F28_OK) Then
                Dim curIPAdd As New IPAddress(ulIP)
                Info.strSubnetMask = curIPAdd.ToString()

                strMsg = "   . Ethernet Subnet mask : " + Info.strSubnetMask
                DisplayTxt(strMsg)

            End If
        End If

        ' Read gateway
        If (sRet = F28_RETURN.F28_OK) Then
            sRet = F28_GetGatewayAddressIP(sModuleID, ulIP)
            If (sRet = F28_RETURN.F28_OK) Then
                Dim curIPAdd As New IPAddress(ulIP)
                Info.strGateway = curIPAdd.ToString()

                strMsg = "   . Ethernet Gateway : " + Info.strGateway
                DisplayTxt(strMsg)

            End If
        End If

        ' Read MAC address
        If (sRet = F28_RETURN.F28_OK) Then
            strBuff = Space(ucMaxBuff)
            sRet = F28_GetMACAddress(sModuleID, strBuff, ucMaxBuff - 1)
            If (sRet = F28_RETURN.F28_OK) Then
                Info.strMACAddress = strBuff

                strMsg = "   . Ethernet MAC addr : " + Info.strMACAddress
                DisplayTxt(strMsg)

            End If
        End If

        strMsg = "   ......................"
        DisplayTxt(strMsg)


        Return sRet

    End Function
    '
    ' ------------------------------------------------------------------
    ' Add module to Network
    ' ------------------------------------------------------------------
    '
    Private Function AddModule2Channel() As Short

        Dim sRetCode As Short
        Dim sRet As Short
        Dim sModuleId As Short
        Dim ucGroup As Byte
        Dim ucModule As Byte
        Dim ucTimeout As Byte
        Dim strBuff As String
        Dim ulIP As UInteger            ' 1.504


        ' Group = 1, Module = 1, Timeout = 3 sec
        ' --------------------------------------
        ucGroup = F28_GROUP_ID.GROUP_1
        ucModule = F28_MODULE_ADDR.MODULE_ADDR_1
        ucTimeout = 3

        ' Get IP Address string
        strBuff = TextBoxIPAddr.Text

        ' Convert to Long
        ulIP = IPString2Long(strBuff)

        ' Add module 
        sModuleId = F28_AddModule(ulIP, ucModule, ucGroup, ucTimeout)

        strBuff = " . sModuleID #" + Str(sModuleId) + " : IP = " + ulIP.ToString + ", Group #" + Str(ucGroup) + ", Unit #" + Str(ucModule) + " Timeout #" + Str(ucTimeout)
        DisplayTxt(strBuff)

        If sModuleId > 0 Then

            ' Read module info
            sRetCode = GetModuleInfo(sModuleId)

            If (sRetCode = F28_RETURN.F28_OK) Then

                ' Add to list
                cboModules.Items.Add(CStr(sModuleId))
                cboGroup.Items.Add(CStr(ucGroup))

                sRet = sRet + 1             ' 1 module added
            End If

        End If

        Return sRet
    End Function

    ' -------------------------------------------------------------------------------------------------------------
    ' GetModuleInfo
    ' -------------------------------------------------------------------------------------------------------------
    '
    Private Function GetModuleInfo(ByVal sModuleID) As Short
        Dim sRetCode As Short
        Dim strBuff As String
        Dim strMsg As String


        sRetCode = F28_RefreshModuleInformations(sModuleID)

        If (sRetCode = F28_RETURN.F28_OK) Then
            strBuff = Space(100)
            sRetCode = F28_GetSerialNumber(sModuleID, strBuff, 20)
            If (sRetCode = F28_RETURN.F28_OK) Then
                strMsg = strBuff.Insert(0, "   . Serial number : ")
                DisplayTxt(strMsg)
            End If
        End If

        If (sRetCode = F28LightControl.F28_RETURN.F28_OK) Then
            strBuff = Space(100)
            sRetCode = F28_GetModuleHardVersion(sModuleID, strBuff, 20)
            If (sRetCode = F28LightControl.F28_RETURN.F28_OK) Then
                strMsg = strBuff.Insert(0, "   . Module harware version : ")
                DisplayTxt(strMsg)
            End If
        End If

        If (sRetCode = F28LightControl.F28_RETURN.F28_OK) Then
            strBuff = Space(100)
            sRetCode = F28_GetModuleSoftVersion(sModuleID, strBuff, 20)
            If (sRetCode = F28LightControl.F28_RETURN.F28_OK) Then
                strMsg = strBuff.Insert(0, "   . Module software version : ")
                DisplayTxt(strMsg)
            End If
        End If

        ' 1.301 Get Ethernet info 
        If (sRetCode = F28_RETURN.F28_OK) Then
            sRetCode = GetEthernetInformation(sModuleID, m_deviceEthernetInfo)
        End If

        GetModuleInfo = sRetCode

    End Function

    ' -------------------------------------------------------------------------------------------------------------
    ' Open close check
    ' -------------------------------------------------------------------------------------------------------------
    Private Sub CheckOpenClose_CheckedChanged(sender As Object, e As EventArgs) Handles CheckOpenClose.CheckedChanged
        Dim sRetCode As Short

        Me.Cursor = Cursors.WaitCursor

        If CheckOpenClose.CheckState = CheckState.Unchecked Then
            DisplayTxt("API Closed !!")

            ' Stop real time
            m_TimerRealTime.Stop()

            m_bAPIOpened = False

            F28LightControl.F28_Close()

        Else

            DisplayTxt("API Open, F28_Init")

            sRetCode = F28LightControl.F28_Init()

            m_bAPIOpened = (sRetCode = F28_RETURN.F28_OK)

            If (m_bAPIOpened = True) Then

                sRetCode = F28_OpenChannel()

                m_bChannelOk = (sRetCode = F28_RETURN.F28_OK)

                If m_bChannelOk = True Then
                    DisplayTxt("Channel opened Ok !!!")
                Else
                    DisplayTxt("Channel opened error !!!")
                End If

            Else
                DisplayTxt("Driver initialization failed !!!")
            End If
        End If

        Me.Cursor = Cursors.Default

    End Sub

    ' ------------------------------------------------------------------
    ' Close form
    ' ------------------------------------------------------------------
    '
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor

        If m_bAPIOpened = True Then

            ' Stop real time
            m_TimerRealTime.Stop()

            m_bAPIOpened = False

            ' Always close before terminate application
            F28LightControl.F28_Close()

        End If

        Me.Cursor = Cursors.Default

    End Sub

    ' ------------------------------------------------------------------
    ' Load form
    ' ------------------------------------------------------------------
    '
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strBuff As String

        Application.CurrentCulture = New CultureInfo("en-GB")

        ' 1.400 Auto Calibration initialisation
        m_autocal.Initialize()
        m_autoratio.Initialize()
        m_easyauto.Initialize()

        ' 1.500
        parameterForm.Initialize()

        m_sModuleID = 0

        m_bAPIOpened = False
        m_bChannelOk = False

        ' 100 ms real time measure
        m_TimerRealTime.Interval = 100

        m_rCptComm.dwErrors = 0
        m_rCptComm.dwReceived = 0
        m_rCptComm.dwTransmited = 0

        ' Read version at start up
        m_labelDllVer.Text = Str(F28LightControl.F28_GetDllMajorVersion()) + "." + Str(F28LightControl.F28_GetDllMinorVersion())

        strBuff = Me.Text + " -> Ethernet interface"
#If _64BITS Then
        strBuff = strBuff.Replace("Demo", "Demo 64Bits")
#Else
        strBuff = strBuff.Replace("Demo", "Demo 32Bits")
#End If

        m_chkReadFifo.Checked = True

        ' 1.404 Watch dog timer to keep alive connexion
        m_TimerWatchDog.Enabled = True

        Me.Text = strBuff

    End Sub
    '
    ' ------------------------------------------------------------------
    ' Add module button for one unit
    ' ------------------------------------------------------------------
    '
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddModule.Click
        Dim sRet As Short

        cboModules.Items.Clear()
        cboGroup.Items.Clear()

        If m_bChannelOk = True And m_bAPIOpened = True Then
            DisplayTxt("Add modules to channel !!!")

            sRet = AddModule2Channel()

            DisplayTxt(" -> Modules found = " + cboModules.Items.Count.ToString())

            If cboModules.Items.Count() > 0 Then

                cboModules.SelectedIndex = 0

                ' 1.404 Update current module ID
                m_sModuleID = Convert.ToInt16(cboModules.Text)
            End If

            If cboGroup.Items.Count() > 0 Then
                cboGroup.SelectedIndex = 0
            End If

        End If

    End Sub
    '
    ' *********************************************************************************************
    ' 1.504 - Add RemoveModule button
    ' *********************************************************************************************
    '
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles m_btnRemoveModule.Click
        '
        Dim sRetCode As Short

        If F28_IsModuleConnected(m_sModuleID) Then
            sRetCode = F28_RemoveModule(m_sModuleID)
            If (sRetCode = F28_RETURN.F28_OK) Then
                DisplayTxt(" ModuleID # " + CStr(m_sModuleID) + " removed !!!")
                m_sModuleID = 0
            End If
        End If

    End Sub



    ' ------------------------------------------------------------------
    ' Start cycle buttton for current m_sModuleID
    ' ------------------------------------------------------------------
    ' 
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        If m_bAPIOpened = True Then
            m_sModuleID = Convert.ToInt16(cboModules.Text)

            If F28_IsModuleConnected(m_sModuleID) Then

                If (F28_StartCycle(m_sModuleID) = F28_RETURN.F28_OK) Then

                    DisplayTxt(" -> Start Cycle OK -> sModuleID #" + CStr(m_sModuleID))

                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                End If
            Else
                DisplayTxt(" -> Not connected sModuleID #" + CStr(m_sModuleID))
            End If
        End If
    End Sub
    '
    ' ------------------------------------------------------------------
    ' Reset/Abort cycle button for current m_sModuleID
    ' ------------------------------------------------------------------
    '
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click

        If m_bAPIOpened = True Then
            m_sModuleID = Convert.ToInt16(cboModules.Text)

            If F28_IsModuleConnected(m_sModuleID) Then

                F28_StopCycle(m_sModuleID)

                DisplayTxt(" -> Stop Cycle OK -> sModuleID #" + CStr(m_sModuleID))
            Else
                DisplayTxt(" -> Not connected sModuleID #" + CStr(m_sModuleID))
            End If
        End If
    End Sub

    ' ------------------------------------------------------------------
    ' Start cycle by group button
    ' ------------------------------------------------------------------

    Private Sub btnStartGrp_Click(sender As Object, e As EventArgs) Handles btnStartGrp.Click
        Dim sRetCode As Short
        Dim strErr As String

        If m_bAPIOpened = True Then
            Dim sGroup As Short

            sGroup = Convert.ToInt16(cboGroup.Text)

            If sGroup > 0 Then

                sRetCode = F28_StartCycleByGroup(sGroup)

                If (sRetCode = F28_RETURN.F28_OK) Then
                    strErr = "   . -> Ok"
                Else
                    strErr = "   . -> Error"
                End If

                DisplayTxt(" -> Start group -> #" + CStr(sGroup) + strErr)

            Else
                DisplayTxt(" -> Group or channel error !!! ")
            End If
        End If

    End Sub

    ' ------------------------------------------------------------------
    ' Stop cycle by group
    ' ------------------------------------------------------------------

    Private Sub btnStopGrp_Click(sender As Object, e As EventArgs) Handles btnStopGrp.Click
        Dim sGroup As Short
        Dim sRetCode As Short
        Dim strErr As String

        If m_bAPIOpened = True Then
            sGroup = Convert.ToInt16(cboGroup.Text)

            If sGroup > 0 Then

                sRetCode = F28_StopCycleByGroup(sGroup)

                If (sRetCode = F28_RETURN.F28_OK) Then
                    strErr = "   . -> Ok"
                Else
                    strErr = "   . -> Error"
                End If

                DisplayTxt(" -> Start group # " + CStr(sGroup) + strErr)
            Else
                DisplayTxt(" -> Group or channel error !!! ")
            End If
        End If
    End Sub

    '
    ' ------------------------------------------------------------------
    ' Read fifo result button
    ' ------------------------------------------------------------------
    '
    Private Sub btnFIFO_Click(sender As Object, e As EventArgs) Handles btnFIFO.Click
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            Dim wCount As UShort

            wCount = F28_GetResultsCount(m_sModuleID)
            m_labelFifoCount.Text = wCount.ToString()

            ' Read cycle result from FIFO
            If wCount > 0 Then
                ' 1.300 13/10/15
                sRetCode = F28_GetNextResult(m_sModuleID, m_Result)
                If sRetCode = F28_RETURN.F28_OK Then
                    DisplayResult(1)
                End If
            Else
                DisplayTxt(" -> Fifo empty !!! ")
            End If

            wCount = F28_GetResultsCount(m_sModuleID)
            m_labelFifoCount.Text = wCount.ToString()
        End If

    End Sub
    '
    ' ------------------------------------------------------------------
    ' Edit & Write parameters button
    ' ------------------------------------------------------------------
    '
    Private Sub btnParameter_Click(sender As Object, e As EventArgs) Handles btnParameter.Click
        Dim sModuleID As Short

        If m_bAPIOpened = True Then

            sModuleID = Convert.ToInt16(cboModules.Text)

            If sModuleID > 0 Then
                parameterForm.SetCurrentID(sModuleID)
                parameterForm.Visible = True
            End If
        End If
    End Sub

    Private Sub m_btnExit_Click(sender As Object, e As EventArgs) Handles m_btnExit.Click
        Me.Close()
    End Sub
    '
    ' ------------------------------------------------------------------
    ' Clear Fifo button
    ' ------------------------------------------------------------------
    '
    Private Sub m_btnClearFIFO_Click(sender As Object, e As EventArgs) Handles m_btnClearFIFO.Click
        Dim wCount As UShort

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                F28_ClearFIFOResults(m_sModuleID)

                wCount = F28_GetResultsCount(m_sModuleID)
                m_labelFifoCount.Text = wCount.ToString()
            End If
        End If

    End Sub

    '
    ' ------------------------------------------------------------------
    ' Clear listbox
    ' ------------------------------------------------------------------
    '
    Private Sub m_btnClearList_Click(sender As Object, e As EventArgs) Handles m_btnClearList.Click

        m_ListBoxMsg.Items.Clear()

    End Sub
    '
    ' ------------------------------------------------------------------
    ' 02/11/15 1.302 Add Auto Zero button
    ' Auto Zero pressure
    ' ------------------------------------------------------------------
    '
    Private Sub btnAZPressure_Click(sender As Object, e As EventArgs) Handles btnAZPressure.Click

        Dim fDumpTime As Single
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                ' Get dump time in sec
                fDumpTime = Convert.ToSingle(textBoxAZDumpTime.Text)

                sRetCode = F28_StartAutoZeroPressure(m_sModuleID, fDumpTime)

                If (sRetCode = F28_RETURN.F28_OK) Then
                    DisplayTxt("Start auto zero Ok !!!")
                Else
                    DisplayTxt("Start auto zero error !!!")
                End If
            End If
        End If
    End Sub
    '
    ' ------------------------------------------------------------------
    ' Read last result
    ' ------------------------------------------------------------------
    '
    Private Sub btnReadLastResult_Click(sender As Object, e As EventArgs) Handles btnReadLastResult.Click
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                sRetCode = F28_GetLastResult(m_sModuleID, m_Result)

                If sRetCode = F28_RETURN.F28_OK Then
                    DisplayResult(1)
                End If
            End If
        End If
    End Sub
    '
    ' ------------------------------------------------------------------
    ' Read parameter from F28Light
    ' ------------------------------------------------------------------
    '
    Private Sub btnReadPara_Click(sender As Object, e As EventArgs) Handles btnReadPara.Click
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            m_sModuleID = Convert.ToInt16(cboModules.Text)
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                If m_sModuleID > 0 Then

                    parameterForm.SetCurrentID(m_sModuleID)
                    sRetCode = parameterForm.ReadParameter()

                    If (sRetCode = F28_RETURN.F28_OK) Then
                        parameterForm.Visible = True
                    Else
                        DisplayTxt("Read parameters's error !!!")
                    End If
                End If
            End If
        End If

    End Sub

    ' 1.400 Auto Calibration
    '
    ' ------------------------------------------------------------------
    ' Abort auto calibration process
    ' ------------------------------------------------------------------
    '
    Private Sub btnStopAutoCal_Click(sender As Object, e As EventArgs) Handles btnStopAutoCal.Click

        If m_bAPIOpened = True Then
            Dim ucPhase As Byte

            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                ' Start timer & Real time
                m_TimerRealTime.Stop()

                If (m_autocal.IsRunning()) Then
                    m_autocal.StopCal()
                    ucPhase = m_autocal.GetPhase()
                    m_labelCal.Text = ucPhase.ToString() + " : " + m_autocal.GetPhaseStr(ucPhase)
                End If

                If (m_autoratio.IsRunning()) Then
                    m_autoratio.StopAutoRatio()
                    ucPhase = m_autoratio.GetPhase()
                    m_labelCal.Text = ucPhase.ToString() + " : " + m_autoratio.GetPhaseStr(ucPhase)
                End If

                If (m_easyauto.IsRunning()) Then
                    m_easyauto.StopEasyAutoLearning()
                    ucPhase = m_easyauto.GetPhase()
                    m_labelCal.Text = ucPhase.ToString() + " : " + m_easyauto.GetPhaseStr(ucPhase)
                End If

            End If
        End If
    End Sub

    '
    ' ------------------------------------------------------------------
    ' Read parameter from F28Light
    ' ------------------------------------------------------------------
    '
    Private Sub btnOffsetOnly_Click(sender As Object, e As EventArgs) Handles btnOffsetOnly.Click

        If m_bAPIOpened = True Then
            Dim wNbCycles As UShort
            Dim wInterCycle As UShort
            Dim fOffsetMax As Single

            wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
            wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)
            fOffsetMax = Convert.ToSingle(textBoxOffset.Text)

            m_sModuleID = Convert.ToInt16(cboModules.Text)

            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                ' 1.501 Add message before run cal
                If (MsgBox("Put master No leak" & vbCrLf & "OK to Continue, Cancel to abort", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then

                    If (m_autocal.StartCal(m_sModuleID, AutoCal.MODE_AUTO_CAL.OFFSET, wNbCycles, wInterCycle, fOffsetMax) = False) Then

                        DisplayTxt("Start auto cal Offset error !!!")

                    Else

                        ' Start timer & Real time
                        m_TimerRealTime.Start()

                        DisplayTxt("Start auto cal Offset Ok !!!")

                    End If
                End If
            End If
        End If

    End Sub

    '
    ' ------------------------------------------------------------------
    ' Read parameter from F28Light
    ' ------------------------------------------------------------------
    '
    Private Sub btnAutoVolume_Click(sender As Object, e As EventArgs) Handles btnAutoVolume.Click

        If m_bAPIOpened = True Then
            Dim wNbCycles As UShort
            Dim wInterCycle As UShort
            Dim fOffsetMax As Single
            Dim fVolumeLeak As Single
            Dim fVolumePressure As Single
            Dim fVolumeMin As Single
            Dim fVolumeMax As Single

            wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
            wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)
            fOffsetMax = Convert.ToSingle(textBoxOffset.Text)

            fVolumeLeak = Convert.ToSingle(textBoxLeakCal.Text)
            fVolumePressure = Convert.ToSingle(textBoxPressureCal.Text)
            fVolumeMin = Convert.ToSingle(textBoxVolMinCal.Text)
            fVolumeMax = Convert.ToSingle(textBoxVolMaxCal.Text)

            m_sModuleID = Convert.ToInt16(cboModules.Text)

            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                ' 1.501 Add message before run cal
                If (MsgBox("Put master No leak" & vbCrLf & "OK to Continue, Cancel to abort", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then

                    If (m_autocal.StartCal(m_sModuleID, AutoCal.MODE_AUTO_CAL.OFFSET_VOLUME, _
                                           wNbCycles, wInterCycle, fOffsetMax, fVolumeLeak, fVolumePressure, fVolumeMin, fVolumeMax) = False) Then

                        DisplayTxt("Start auto cal Offset + Volume error !!!")
                    Else

                        ' Start timer & Real time
                        m_TimerRealTime.Start()

                        DisplayTxt("Start auto cal Offset + Volume Ok !!!")

                    End If
                End If

            End If
        End If

    End Sub
    '
    ' ------------------------------------------------------------------
    ' Read & display real time status & Measurement
    ' ------------------------------------------------------------------
    '
    Private Sub m_TimerRealTime_Tick(sender As Object, e As EventArgs) Handles m_TimerRealTime.Tick
        Dim sRetCode As Short
        Dim wCount As UShort
        Dim strTmp As String

        If m_bAPIOpened = True And F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

            Dim ucPhaseEasyAuto As Byte

            ' 1- Run Easy Auto Learning
            ucPhaseEasyAuto = m_easyauto.GetPhase()
            If m_easyauto.IsRunning Then

                m_labelCal.Text = m_easyauto.ToString() + " : " + m_easyauto.GetPhaseStr(ucPhaseEasyAuto)

                If (m_easyauto.RunEasyAutoLearning() = True) Then     ' End easy auto learning

                    ' 1- Read easy auto learning errcode
                    If (m_easyauto.GetAlarm() > 0) Then

                        strTmp = "Easy Auto Learning Alarm !!!"
                        DisplayTxt(strTmp)
                        m_labelCal.Text = strTmp

                    Else
                        ' 2- if no erreur -> Read & Save parameters
                        parameterForm.SetCurrentID(m_sModuleID)

                        sRetCode = parameterForm.ReadParameter()

                        strTmp = parameterForm.GetRatioStr()

                        DisplayTxt(strTmp)
                        m_labelCal.Text = strTmp

                    End If

                End If
            End If

            Dim ucPhaseAutoRatio As Byte

            ' 2- Run Auto-Ratio
            ucPhaseAutoRatio = m_autoratio.GetPhase()
            If m_autoratio.IsRunning Then

                m_labelCal.Text = ucPhaseAutoRatio.ToString() + " : " + m_autoratio.GetPhaseStr(ucPhaseAutoRatio)

                If (m_autoratio.RunAutoRatio() = True) Then     ' End auto ratio

                    ' 1- Read auto ratio errcode
                    If (m_autoratio.GetAlarm() > 0) Then

                        strTmp = "Auto-Ratio Alarm !!!"
                        DisplayTxt(strTmp)
                        m_labelCal.Text = strTmp

                    Else
                        ' 2- if no erreur -> Read & Save parameters
                        parameterForm.SetCurrentID(m_sModuleID)

                        sRetCode = parameterForm.ReadParameter()

                        strTmp = parameterForm.GetRatioStr()

                        DisplayTxt(strTmp)
                        m_labelCal.Text = strTmp

                    End If

                End If
            End If

            Dim ucPhase As Byte

            ' 1.402
            ' 3- Run Auto Calibration
            ucPhase = m_autocal.GetPhase()

            If m_autocal.IsRunning() Then      'ucPhase <> AutoCal.CAL_AUTO_PHASES.AUTO_IDDLE Then

                m_labelCal.Text = ucPhase.ToString() + " : " + m_autocal.GetPhaseStr(ucPhase)

                If m_autocal.IsWaitingMasterLeak() Then

                    m_TimerRealTime.Stop()

                    If (MsgBox("Put master leak" & vbCrLf & "OK to Continue, Cancel to abort)", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok) Then
                        m_autocal.RunContinue(True)
                    Else
                        m_autocal.RunContinue(False)

                        ucPhase = m_autocal.GetPhase()
                        m_labelCal.Text = ucPhase.ToString() + " : " + m_autocal.GetPhaseStr(ucPhase)

                    End If
                    m_TimerRealTime.Start()

                End If


                If (m_autocal.RunCal() = True) Then     ' End auto calibration

                    ' 1- Read auto calibration errcode
                    If (m_autocal.GetAlarm() > 0) Then

                        strTmp = "Calibration Alarm !!!"
                        DisplayTxt(strTmp)
                        m_labelCal.Text = strTmp

                    Else
                        ' 2- if no erreur -> Read & Save parameters
                        parameterForm.SetCurrentID(m_sModuleID)

                        sRetCode = parameterForm.ReadParameter()

                        strTmp = parameterForm.GetOffsetVolumeStr()

                        DisplayTxt(strTmp)
                        m_labelCal.Text = strTmp

                    End If

                End If

            End If


            ' 4- Read real time status & measurement
            sRetCode = F28_GetRealTimeData(m_sModuleID, m_realTime)

            If sRetCode = F28_RETURN.F28_OK Then

                ' 1.403 :NEW:(1)
                If m_autocal.IsRunningVolumeCal() = True Then

                    m_realTime.fLeakValue = m_realTime.fLeakValue * 1000
                    m_realTime.ucUnitLeak = F28_LEAK_UNITS.LEAK_PASEC

                End If


                ' Display real time
                DisplayRealTime()

                ' If end of cycle -> Read last result & display
                ' 1.404 
                If (m_realTime.ucEndCycle And F28_FLAG.FLAG_END_OF_CYCLE) = F28_FLAG.FLAG_END_OF_CYCLE Then

                    ' Stop real time reading at EOC
                    If ucPhase = AutoCal.CAL_AUTO_PHASES.AUTO_IDDLE And ucPhaseAutoRatio = AutoRatio.AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE Then
                        m_TimerRealTime.Stop()
                    End If

                    ' Read Last Result & display
                    sRetCode = F28_GetLastResult(m_sModuleID, m_Result)
                    If sRetCode = F28_RETURN.F28_OK Then

                        ' 1.403 :NEW:(2)
                        If m_autocal.IsRunningVolumeCal() = True Then

                            m_Result.fLeakValue = m_Result.fLeakValue * 1000
                            m_Result.ucUnitLeak = F28_LEAK_UNITS.LEAK_PASEC

                        End If


                        DisplayResult(0)
                    End If

                    ' Read Get fifo Result count
                    wCount = F28_GetResultsCount(m_sModuleID)
                    m_labelFifoCount.Text = wCount.ToString()

                    ' Read fifo if demands
                    If wCount > 0 And m_chkReadFifo.Checked Then
                        ' Read fifo
                        sRetCode = F28_GetNextResult(m_sModuleID, m_Result)
                        If sRetCode = F28_RETURN.F28_OK Then

                            ' 1.403 :NEW:(3)
                            If m_autocal.IsRunningVolumeCal() = True Then

                                m_Result.fLeakValue = m_Result.fLeakValue * 1000
                                m_Result.ucUnitLeak = F28_LEAK_UNITS.LEAK_PASEC

                            End If
                            DisplayResult(1)
                        End If

                        wCount = F28_GetResultsCount(m_sModuleID)
                        m_labelFifoCount.Text = wCount.ToString()

                    End If
                End If

            End If
        End If

        ' 5- Read & display counter
        If sRetCode = F28_RETURN.F28_OK Then
            sRetCode = F28_GetCommunicationStatistics(m_sModuleID, m_rCptComm)
            If sRetCode = F28_RETURN.F28_OK Then
                DisplayCounter(m_rCptComm)
            End If
        End If

    End Sub

    ' DLL Ver 1.402 
    ' ------------------------------------------------------------------
    ' Regulator Adjust
    ' ------------------------------------------------------------------
    '
    Private Sub btnRegulatorAjust_Click(sender As Object, e As EventArgs) Handles btnRegulatorAjust.Click

        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                sRetCode = F28_StartRegulatorAdjust(m_sModuleID)

                If (sRetCode = F28_RETURN.F28_OK) Then

                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Start regulator adjust OK !!!")
                Else
                    DisplayTxt("Start regulator adjust Error !!!")
                End If

            End If
        End If
    End Sub


    ' ******************************************************************************* 
    ' 1.404 Show how to start cycle/Start auto Cal for several heads
    ' ******************************************************************************* 
    ' Multiheads example
    ' //:TODO:
    '       - Add 3 heads to network (heads are display inside m_listBox2Heads)
    '       - Try Start/Offset
    ' ******************************************************************************* 
    '
    Private Sub DisplayTxt2(ByVal szTxt As String)
        m_listBox2Heads.Items.Add(szTxt)
        m_listBox2Heads.Refresh()
        m_listBox2Heads.SelectedIndex = m_listBox2Heads.Items.Count() - 1
    End Sub

    ' ------------------------------------------------------------------
    ' AddModule to network
    '   - ucModule  : module index
    '   - strBuff   : IP address string eg: 192.168.1.1 
    ' ------------------------------------------------------------------
    '
    Private Function AddModule2(ucModule As Byte, strBuff As String) As Short

        Dim sRetCode As Short
        Dim sModuleId As Short
        Dim ucGroup As Byte
        Dim ucTimeout As Byte
        Dim ulIP As UInteger                ' 1.504 - ULong

        sModuleId = -1
        If m_bChannelOk = True And m_bAPIOpened = True Then

            ' Group = 1, Module = 1, Timeout = 3 sec
            ' --------------------------------------
            ucGroup = F28_GROUP_ID.GROUP_1
            ucModule = F28_MODULE_ADDR.MODULE_ADDR_1
            ucTimeout = 3

            ' Convert IP address to Long
            ulIP = IPString2Long(strBuff)

            ' Add module to network
            sModuleId = F28_AddModule(ulIP, ucModule, ucGroup, ucTimeout)

            strBuff = " . sModuleID #" + Str(sModuleId) + " : IP = " + ulIP.ToString + ", Group #" + Str(ucGroup) + ", Unit #" + Str(ucModule) + " Timeout #" + Str(ucTimeout)
            DisplayTxt(strBuff)

            If sModuleId > 0 Then

                sRetCode = F28_IsModuleConnected(sModuleId)

                If (sRetCode = F28_CONNECT.F28_CONNECTED) Then

                    ' Add to list
                    m_listBox2Heads.Items.Add(CStr(sModuleId))

                    ' Read module info
                    sRetCode = GetModuleInfo(sModuleId)

                End If

            End If
        End If

        Return sModuleId

    End Function

    ' ------------------------------------------------------------------
    ' AddModule # 1 to network
    ' ------------------------------------------------------------------
    '
    Private Sub btnAddMod1_Click(sender As Object, e As EventArgs) Handles btnAddMod1.Click

        Dim strBuff As String

        strBuff = textBoxIPHead1.Text

        AddModule2(1, strBuff)

    End Sub

    ' ------------------------------------------------------------------
    ' AddModule # 2 to network 
    ' ------------------------------------------------------------------
    '
    Private Sub btnAddMod2_Click(sender As Object, e As EventArgs) Handles btnAddMod2.Click

        Dim strBuff As String

        strBuff = textBoxIPHead2.Text

        AddModule2(2, strBuff)

    End Sub

    ' ------------------------------------------------------------------
    ' AddModule # 3 to network
    ' ------------------------------------------------------------------
    '
    Private Sub btnAddMod3_Click(sender As Object, e As EventArgs) Handles btnAddMod3.Click

        Dim strBuff As String

        strBuff = textBoxIPHead3.Text

        AddModule2(3, strBuff)

    End Sub

    ' ------------------------------------------------------------------
    ' Start cycle on all Modules 
    ' ------------------------------------------------------------------
    '
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnStart2.Click
        Dim n As Integer
        Dim strBuff As String
        Dim sNum As Short
        Dim sRet As Short

        n = m_listBox2Heads.Items.Count

        ' If at least 1 module is in use
        If n > 0 Then
            ' Repeat for all heads
            For i = 0 To n - 1
                strBuff = m_listBox2Heads.Items.Item(i)
                sNum = CShort(strBuff)

                If m_bAPIOpened = True And F28_IsModuleConnected(sNum) = F28_CONNECT.F28_CONNECTED Then

                    sRet = F28_StartCycle(sNum)
                    If (sRet = F28_RETURN.F28_OK) Then
                        DisplayTxt("Start Ok -> " + sNum.ToString())
                    Else
                        DisplayTxt("Start error -> " + sNum.ToString())
                    End If
                End If
            Next
        End If
    End Sub

    ' ------------------------------------------------------------------
    ' Start auto cal offset for all heads inside the listBox 
    ' ------------------------------------------------------------------
    '
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnOffset2.Click
        Dim n As Integer
        Dim strBuff As String
        Dim sNum As Short
        Dim sRet As Short

        Dim wNbCycles As UShort
        Dim wInterCycle As UShort
        Dim fOffsetMax As Single

        wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
        wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)
        fOffsetMax = Convert.ToSingle(textBoxOffset.Text)

        ' Get number of heads inside the listbox
        n = m_listBox2Heads.Items.Count

        ' If at least 1 module is in use
        If n > 0 Then

            ' Repeat for all heads
            For i = 0 To n - 1

                ' Get sModuleID for head i    
                strBuff = m_listBox2Heads.Items.Item(i)
                sNum = CShort(strBuff)

                ' Check if the module is connected
                If m_bAPIOpened = True And F28_IsModuleConnected(sNum) = F28_CONNECT.F28_CONNECTED Then

                    ' Start auto Cal Offset for head i
                    sRet = F28_StartAutoCalOffsetOnly(sNum, wNbCycles, wInterCycle, fOffsetMax)

                    If (sRet = F28_RETURN.F28_OK) Then
                        DisplayTxt("Start Offset Ok -> " + sNum.ToString())
                    Else
                        DisplayTxt("Start Offset error -> " + sNum.ToString())
                    End If

                End If

            Next
        End If

    End Sub
    '
    ' ------------------------------------------------------------------
    '  Every 100 ms, Read & display realtime status + measure for module # 1
    ' ------------------------------------------------------------------
    '
    Private Sub m_TimerHead1_Tick(sender As Object, e As EventArgs) Handles m_TimerHead1.Tick
        Dim sRetCode As Short
        Dim sModuleId As Short
        Dim strBuff As String
        Dim n As Integer

        n = m_listBox2Heads.Items.Count

        ' If module #1 is in use
        If n > 0 Then
            ' Get sModuleID for head #1    
            strBuff = m_listBox2Heads.Items.Item(0)
            sModuleId = CShort(strBuff)

            If m_bAPIOpened = True And F28_IsModuleConnected(sModuleId) = F28_CONNECT.F28_CONNECTED Then

                Dim trealtime As F28_REALTIME_CYCLE

                ' 2- Read real time status & measurement
                sRetCode = F28_GetRealTimeData(sModuleId, trealtime)

                If sRetCode = F28_RETURN.F28_OK Then

                    labelMod1.Text = sModuleId.ToString() + ":<Eoc:" + trealtime.ucEndCycle.ToString() + ">" + trealtime.ucStatus.ToString() + ":"

                    If trealtime.ucStatus <> 255 Then

                        If trealtime.ucStatus <= F28_RSLT_STATUS.NMAX_STATUS_CODE Then
                            labelMod1.Text += GetPhaseStr(trealtime.ucStatus)
                        Else
                            labelMod1.Text += ""
                        End If
                    Else
                        labelMod1.Text += ""
                    End If
                End If
            End If
        End If

    End Sub
    '
    ' ------------------------------------------------------------------
    '  Every 100 ms, Read & display realtime status + measure for module # 2
    ' ------------------------------------------------------------------
    '
    Private Sub m_TimerHead2_Tick(sender As Object, e As EventArgs) Handles m_TimerHead2.Tick
        Dim sRetCode As Short
        Dim sModuleId As Short
        Dim strBuff As String
        Dim n As Integer

        n = m_listBox2Heads.Items.Count

        ' If module #2 is in use
        If n > 1 Then
            ' Get sModuleID for head #2    
            strBuff = m_listBox2Heads.Items.Item(1)
            sModuleId = CShort(strBuff)

            If m_bAPIOpened = True And F28_IsModuleConnected(sModuleId) = F28_CONNECT.F28_CONNECTED Then

                Dim trealtime As F28_REALTIME_CYCLE

                ' 2- Read real time status & measurement
                sRetCode = F28_GetRealTimeData(sModuleId, trealtime)

                If sRetCode = F28_RETURN.F28_OK Then

                    LabelMod2.Text = sModuleId.ToString() + ":<Eoc:" + trealtime.ucEndCycle.ToString() + ">" + trealtime.ucStatus.ToString() + ":"

                    If trealtime.ucStatus <> 255 Then

                        If trealtime.ucStatus <= F28_RSLT_STATUS.NMAX_STATUS_CODE Then
                            LabelMod2.Text += GetPhaseStr(trealtime.ucStatus)
                        Else
                            LabelMod2.Text += ""
                        End If
                    Else
                        LabelMod2.Text += ""
                    End If
                End If
            End If
        End If

    End Sub
    '
    ' -------------------------------------------------------------------------
    '  Every 100 ms, Read & display realtime status + measure for module # 3
    ' -------------------------------------------------------------------------
    '
    Private Sub m_TimerHead3_Tick(sender As Object, e As EventArgs) Handles m_TimerHead3.Tick
        Dim sRetCode As Short
        Dim sModuleId As Short
        Dim strBuff As String
        Dim n As Integer

        n = m_listBox2Heads.Items.Count

        ' If module # 3 is in use
        If n > 2 Then
            ' Get sModuleID for head #3    
            strBuff = m_listBox2Heads.Items.Item(2)
            sModuleId = CShort(strBuff)

            If m_bAPIOpened = True And F28_IsModuleConnected(sModuleId) = F28_CONNECT.F28_CONNECTED Then

                Dim trealtime As F28_REALTIME_CYCLE

                ' 2- Read real time status & measurement
                sRetCode = F28_GetRealTimeData(sModuleId, trealtime)

                If sRetCode = F28_RETURN.F28_OK Then

                    LabelMod3.Text = sModuleId.ToString() + ":<Eoc:" + trealtime.ucEndCycle.ToString() + ">" + trealtime.ucStatus.ToString() + ":"

                    If trealtime.ucStatus <> 255 Then

                        If trealtime.ucStatus <= F28_RSLT_STATUS.NMAX_STATUS_CODE Then
                            LabelMod3.Text += GetPhaseStr(trealtime.ucStatus)
                        Else
                            LabelMod3.Text += ""
                        End If
                    Else
                        LabelMod3.Text += ""
                    End If
                End If
            End If
        End If

    End Sub

    '
    ' -----------------------------------------------------------------------------------------------------------
    ' 1.404 Display communication counter
    ' -----------------------------------------------------------------------------------------------------------
    '
    Private Sub DisplayCounter2(ByRef rCptComm As F28_COMMUNICATION_STATISTICS, _
                                   ByRef labelTransmit As System.Windows.Forms.Label, _
                                   ByRef labelReceive As System.Windows.Forms.Label, _
                                   ByRef labelError As System.Windows.Forms.Label)
        labelTransmit.Text = rCptComm.dwTransmited.ToString()
        labelReceive.Text = rCptComm.dwReceived.ToString()
        labelError.Text = rCptComm.dwErrors.ToString()
    End Sub

    '
    ' -----------------------------------------------------------------------------------------------------------
    ' 1.404 Keep-alive : Shows how to communicate continously every 2 sec & use of F28_ResetEthernetModule if connection lost
    ' -----------------------------------------------------------------------------------------------------------
    '
    Private Sub m_TimerWatchDog_Tick(sender As Object, e As EventArgs) Handles m_TimerWatchDog.Tick
        Dim sRetCode As Short
        Dim sConnect As Short
        Dim rCptComm As New F28_COMMUNICATION_STATISTICS


        If m_bAPIOpened = True And m_sModuleID > 0 Then

            ' Check connection status
            sConnect = F28_IsModuleConnected(m_sModuleID)

            ' If disconnected -> Reset Ethernet module
            If sConnect <> F28_CONNECT.F28_CONNECTED Then
                sRetCode = F28_ResetEthernetModule(m_sModuleID)
                chkConnected.Checked = False
            Else
                ' Read and display counter

                chkConnected.Checked = True

                sRetCode = F28_GetCommunicationStatistics(m_sModuleID, rCptComm)
                If sRetCode = F28_RETURN.F28_OK Then
                    DisplayCounter(rCptComm)
                End If
            End If
        End If


        ' Keep alive module #1, 2, 3
        Dim sModuleId As Short
        Dim strBuff As String
        Dim n As Integer

        n = m_listBox2Heads.Items.Count

        ' If module # 3 is in use
        If m_bAPIOpened = True And n > 0 Then

            ' Repeat for all heads
            For i = 0 To n - 1

                ' Get sModuleID for head #3    
                strBuff = m_listBox2Heads.Items.Item(i)
                sModuleId = CShort(strBuff)

                If sModuleId > 0 Then

                    ' Check connection status
                    sConnect = F28_IsModuleConnected(sModuleId)

                    ' If disconnected -> Reset Ethernet module
                    If sConnect <> F28_CONNECT.F28_CONNECTED Then

                        sRetCode = F28_ResetEthernetModule(sModuleId)
                        Select Case i
                            Case 0
                                chkConnect1.Checked = False
                            Case 1
                                chkConnect2.Checked = False
                            Case 2
                                chkConnect3.Checked = False

                        End Select
                    Else
                        ' Read and display counter

                        Select Case i
                            Case 0
                                chkConnect1.Checked = True
                            Case 1
                                chkConnect2.Checked = True
                            Case 2
                                chkConnect3.Checked = True

                        End Select

                        sRetCode = F28_GetCommunicationStatistics(sModuleId, rCptComm)

                        If sRetCode = F28_RETURN.F28_OK Then
                            Select Case i
                                Case 0
                                    DisplayCounter2(rCptComm, labelTr_1, labelRec_1, labelErr_1)
                                Case 1
                                    DisplayCounter2(rCptComm, labelTr_2, labelRec_2, labelErr_2)
                                Case 2
                                    DisplayCounter2(rCptComm, labelTr_3, labelRec_3, labelErr_3)
                            End Select

                        End If
                    End If
                End If
            Next

        End If

    End Sub
    '
    ' -----------------------------------------------------------------------------------------------------------
    ' 1.500 23/12/15 : Electronic Regulator learnibg
    ' -----------------------------------------------------------------------------------------------------------
    '
    ' 
    Private Sub btnElecRegLearn_Click(sender As Object, e As EventArgs) Handles btnElecRegLearn.Click

        Dim fDumpTime As Single
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                ' Get dump time in sec
                fDumpTime = Convert.ToSingle(textBoxAZDumpTime.Text)

                sRetCode = F28_StartLearningRegulator(m_sModuleID, fDumpTime)

                If (sRetCode = F28_RETURN.F28_OK) Then
                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Start electronic learning Ok !!!")
                Else
                    DisplayTxt("Start Start electronic learning error !!!")
                End If
            End If
        End If
    End Sub

    ' V2.0.0.4
    Private Sub btnJetCheck_Click(sender As Object, e As EventArgs) Handles btnJetCheck.Click
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                sRetCode = F28_StartJetCheck(m_sModuleID)

                If (sRetCode = F28_RETURN.F28_OK) Then
                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Start jet check Ok !!!")
                Else
                    DisplayTxt("Start jet check error !!!")
                End If
            End If
        End If
    End Sub

    Private Sub btnStartAutoRatio_Click(sender As Object, e As EventArgs) Handles btnStartAutoRatio.Click

        If m_bAPIOpened = True Then
            m_sModuleID = Convert.ToInt16(cboModules.Text)
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                Dim paramF28 As New F28_PARAMETERS

                paramF28 = Nothing

                If (F28_GetModuleParameters(m_sModuleID, paramF28) = F28_RETURN.F28_OK) Then

                    Dim wNbCycles As UShort
                    Dim wInterCycle As UShort
                    Dim fRatioMax As Single
                    Dim fRatioMin As Single

                    wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
                    wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)
                    fRatioMax = paramF28.fCoeffMax
                    fRatioMin = paramF28.fCoeffMin

                    If (m_autoratio.StartAutoRatio(m_sModuleID, wNbCycles, wInterCycle, fRatioMax, fRatioMin) = False) Then

                        DisplayTxt("Start Auto-Ratio error !!!")
                    Else

                        ' Start timer & Real time
                        m_TimerRealTime.Start()

                        DisplayTxt("Start Auto-Ratio Ok !!!")

                    End If

                End If
            End If
        End If
    End Sub

    Private Sub btnAutoRatio3_Click(sender As Object, e As EventArgs) Handles btnAutoRatio3.Click
        Dim n As Integer
        Dim strBuff As String
        Dim sNum As Short
        Dim sRet As Short

        Dim wNbCycles As UShort
        Dim wInterCycle As UShort

        wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
        wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)

        ' Get number of heads inside the listbox
        n = m_listBox2Heads.Items.Count

        ' If at least 1 module is in use
        If n > 0 Then

            ' Repeat for all heads
            For i = 0 To n - 1

                ' Get sModuleID for head i    
                strBuff = m_listBox2Heads.Items.Item(i)
                sNum = CShort(strBuff)

                ' Check if the module is connected
                If m_bAPIOpened = True And F28_IsModuleConnected(sNum) = F28_CONNECT.F28_CONNECTED Then

                    Dim paramF28 As New F28_PARAMETERS

                    paramF28 = Nothing

                    If (F28_GetModuleParameters(sNum, paramF28) = F28_RETURN.F28_OK) Then

                        ' Start auto Cal Offset for head i
                        sRet = F28_StartAutoRatio(sNum, wNbCycles, wInterCycle, paramF28.fCoeffMax, paramF28.fCoeffMin)

                        If (sRet = F28_RETURN.F28_OK) Then
                            DisplayTxt("Start Auto-Ratio Ok -> " + sNum.ToString())
                        Else
                            DisplayTxt("Start Auto-Ratio error -> " + sNum.ToString())
                        End If

                    End If
                End If
            Next
        End If

    End Sub

    Private Sub btnInfiniteDump_Click(sender As Object, e As EventArgs) Handles btnInfiniteDump.Click
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                sRetCode = X28_StartVidageInfini(m_sModuleID)

                If (sRetCode = F28_RETURN.F28_OK) Then

                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Start infinite dump OK !!!")
                Else
                    DisplayTxt("Start infinite dump Error !!!")
                End If

            End If
        End If
    End Sub

    Private Sub btnLearningTestVolume_Click(sender As Object, e As EventArgs) Handles btnLearningTestVolume.Click
        Dim sRetCode As Short

        If m_bAPIOpened = True Then
            Dim rPara As New F28_VOLUME_LEARNING_TEST

            rPara.wTempsRempTestVolumeLearn = Convert.ToInt16(TextBoxFillTime.Text)
            rPara.wTempsTransfertTestVolumeLearn = Convert.ToInt16(TextBoxFillTime.Text)
            rPara.fVolumePressCC = Convert.ToSingle(TextBoxVolumePressure.Text)
            rPara.fVolumeMin = Convert.ToSingle(TextBoxVolumeMin.Text)
            rPara.fVolumeMax = Convert.ToSingle(TextBoxVolumeMax.Text)

            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                sRetCode = X28_StartVolumeLearning(m_sModuleID, rPara, True)

                If (sRetCode = F28_RETURN.F28_OK) Then

                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Start learning test volume OK !!!")
                Else
                    DisplayTxt("Start learning test volume Error !!!")
                End If

            End If
        End If
    End Sub

    Private Sub btnLearningRefVolume_Click(sender As Object, e As EventArgs) Handles btnLearningRefVolume.Click
        Dim sRetCode As Short
        If m_bAPIOpened = True Then
            Dim rPara As New F28_VOLUME_LEARNING_TEST

            rPara.wTempsRempTestVolumeLearn = Convert.ToInt16(TextBoxFillTime.Text)
            rPara.wTempsTransfertTestVolumeLearn = Convert.ToInt16(TextBoxFillTime.Text)
            rPara.fVolumePressCC = Convert.ToSingle(TextBoxVolumePressure.Text)
            rPara.fVolumeMin = Convert.ToSingle(TextBoxVolumeMin.Text)
            rPara.fVolumeMax = Convert.ToSingle(TextBoxVolumeMax.Text)

            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then

                sRetCode = X28_StartVolumeLearning(m_sModuleID, rPara, False)

                If (sRetCode = F28_RETURN.F28_OK) Then

                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Start learning reference volume OK !!!")
                Else
                    DisplayTxt("Start learning reference volume Error !!!")
                End If

            End If
        End If
    End Sub

    Private Sub btnStartEasyAutoLearning_Click(sender As Object, e As EventArgs) Handles btnStartEasyAutoLearning.Click

        If m_bAPIOpened = True Then
            m_sModuleID = Convert.ToInt16(cboModules.Text)
            If F28_IsModuleConnected(m_sModuleID) = F28_CONNECT.F28_CONNECTED Then
                Dim wNbCycles As UShort
                Dim wInterCycle As UShort

                wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
                wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)

                If (m_easyauto.StartEasyAutoLearning(m_sModuleID, wNbCycles, wInterCycle) = False) Then

                    DisplayTxt("Easy Auto Learning error !!!")
                Else

                    ' Start timer & Real time
                    m_TimerRealTime.Start()

                    DisplayTxt("Easy Auto Learning Ok !!!")

                End If

            End If
        End If

    End Sub

    Private Sub btnEasyAutoLearning3_Click(sender As Object, e As EventArgs) Handles btnEasyAutoLearning3.Click
        Dim n As Integer
        Dim strBuff As String
        Dim sNum As Short
        Dim sRet As Short

        Dim wNbCycles As UShort
        Dim wInterCycle As UShort

        wNbCycles = Convert.ToInt16(textBoxCycleNumber.Text)
        wInterCycle = Convert.ToInt16(textBoxIntercycle.Text)

        ' Get number of heads inside the listbox
        n = m_listBox2Heads.Items.Count

        ' If at least 1 module is in use
        If n > 0 Then

            ' Repeat for all heads
            For i = 0 To n - 1

                ' Get sModuleID for head i    
                strBuff = m_listBox2Heads.Items.Item(i)
                sNum = CShort(strBuff)

                ' Check if the module is connected
                If m_bAPIOpened = True And F28_IsModuleConnected(sNum) = F28_CONNECT.F28_CONNECTED Then
                    ' Start easy auto learning for head i
                    sRet = F28_StartEasyAutoLearning(sNum, wNbCycles, wInterCycle)

                    If (sRet = F28_RETURN.F28_OK) Then
                        DisplayTxt("Start Easy Auto Learning Ok -> " + sNum.ToString())
                    Else
                        DisplayTxt("Start Easy Auto Learning error -> " + sNum.ToString())
                    End If

                End If
            Next
        End If
    End Sub
End Class

