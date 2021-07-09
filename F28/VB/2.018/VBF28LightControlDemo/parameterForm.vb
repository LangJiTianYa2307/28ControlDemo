' ***********************************************************
' 1.200 10/08/15 Add 3 parameters
' 1.300 16/10/15 Add Ofset leak 
' 1.400 19/11/15 Add options bits 
' ***********************************************************
' 1.500 23/12/15 Add Electronic Regulator
' ***********************************************************

Imports VBF28LightControlDemo.F28LightControl


' ***************************************************************************************
' Class parameters
' ***************************************************************************************
Public Class parameterForm
    ' 1.500  Uses with "wFillMode" parameter
    Enum F28_ENUM_FILL_MODE
        STANDARD
        AUTO_FILL
        INSTRUCTION
        RAMP                   ' 1.500 Ramp fill
        RAMP_CONTROL
        EASY
        ESAY_AUTO
        NMAX_FILL_MODE
    End Enum

    ' 1.400 -  Uses with "wOptions" parameter
    Enum F28_OPTIONS As UShort
        BIT_SIGN = 0                        ' bit 0 -> Sign
        BIT_NO_NEGATIVE_VALUE = 1           ' bit 1 -> No Negative
        BIT_MODE_INDIRECT = 2               ' bit 2
        BIT_AUTOZERO_PIEZO2 = 3             ' bit 3
        BIT_TEST_PRESSURE_CORR = 4          ' bit 4 -> Pressure compensation
        BIT_ELECTRONIC_REGULATOR = 5        ' bit 5 -> 1.500 Electronic Regulator in use
    End Enum


    Private m_paramF28 As F28_PARAMETERS
    Private m_sCurrentID As Short

    Public Function ReadParameter() As Short
        Dim sRetCode As Short
        Dim paramF28 As New F28_PARAMETERS

        paramF28 = Nothing

        sRetCode = F28_GetModuleParameters(m_sCurrentID, paramF28)
        If (sRetCode = F28_RETURN.F28_OK) Then

            m_paramF28 = paramF28

            LoadParamFields()

        End If

        Return sRetCode

    End Function

    ' Exit form
    Private Sub m_btnExit_Click(sender As Object, e As EventArgs) Handles m_btnExit.Click
        Me.Visible = False
    End Sub
    '
    ' *****************************************************
    ' Update option parameter 
    ' *****************************************************
    '
    Private Function GetOptionParameter(wOption As UShort, uiPara As UShort) As Boolean

        Dim bRet As Boolean

        bRet = ((wOption And 2 ^ uiPara) >> uiPara) <> 0

        Return bRet

    End Function
    '
    ' *****************************************************
    ' Update option parameter 
    ' *****************************************************
    '
    Private Sub SetOption(ByRef wOption As UShort, bState As Boolean, uiPara As UShort)

        Dim wVal As UShort

        If bState = True Then
            wVal = (1 << uiPara)
            wOption = wOption Or wVal
        Else
            wVal = 65535 - (1 << uiPara)
            wOption = wOption And wVal
        End If

    End Sub

    '
    ' *****************************************************
    ' Load parameters to edit screen
    ' *****************************************************
    '
    Private Sub LoadParamFields()

        cboTestType.SelectedIndex = m_paramF28.wTypeTest

        edtFillTime.Text = m_paramF28.wTpsFill.ToString()
        edtStabTime.Text = m_paramF28.wTpsStab.ToString()
        edtTestTime.Text = m_paramF28.wTpsTest.ToString()
        edtFillVolTime.Text = m_paramF28.wTpsFillVol.ToString()
        edtTransfertTime.Text = m_paramF28.wTpsTransfert.ToString()
        edtDumpTime.Text = m_paramF28.wTpsDump.ToString()

        cboP1Unit.SelectedIndex = m_paramF28.wPress1Unit
        edtMaxP1.Text = m_paramF28.fPress1Max.ToString()
        edtMinP1.Text = m_paramF28.fPress1Min.ToString()
        edtRatioCoeffMax.Text = m_paramF28.fCoeffMax.ToString()
        edtRatioCoeffMin.Text = m_paramF28.fCoeffMin.ToString()
        edtRatioMax.Text = m_paramF28.fRatioMax.ToString()
        edtRatioMin.Text = m_paramF28.fRatioMin.ToString()
        edtNominalValue.Text = m_paramF28.fNominalValue.ToString()

        edtSetPoint.Text = m_paramF28.fSetFillP1.ToString()
        cboFillType.SelectedIndex = m_paramF28.wFillMode

        If (m_paramF28.wLeakUnit > F28_LEAK_UNITS.LEAK_POINTS) Then    ' Hole in leak unit list
            cboLeakUnit.SelectedIndex = m_paramF28.wLeakUnit - 6
        Else
            cboLeakUnit.SelectedIndex = m_paramF28.wLeakUnit
        End If

        edtLeakMax.Text = m_paramF28.fRejectMax.ToString()
        edtLeakMin.Text = m_paramF28.fRejectMin.ToString()

        cboVolUnit.SelectedIndex = m_paramF28.wVolumeUnit
        edtVolume.Text = m_paramF28.fVolume.ToString("F2")
        cboRejectClac.SelectedIndex = m_paramF28.wRejectCalc

        edtAbsPress.Text = m_paramF28.fPatmSTD.ToString("F2")         ' Patm  standard condition (hPa)
        edtTemp.Text = m_paramF28.fTempSTD.ToString("F2")             ' Temperature standard condition (°C)
        edtFilter.Text = m_paramF28.fFilterTime.ToString()       ' (s)

        edtLeakOffset.Text = m_paramF28.fOffsetLeak.ToString("F4")

        ' 1.400 option
        If (GetOptionParameter(m_paramF28.wOptions, F28_OPTIONS.BIT_SIGN) = True) Then
            chkSign.CheckState = CheckState.Checked
        Else
            chkSign.CheckState = CheckState.Unchecked
        End If

        If (GetOptionParameter(m_paramF28.wOptions, F28_OPTIONS.BIT_NO_NEGATIVE_VALUE) = True) Then
            chkNoNegative.CheckState = CheckState.Checked
        Else
            chkNoNegative.CheckState = CheckState.Unchecked
        End If

        If (GetOptionParameter(m_paramF28.wOptions, F28_OPTIONS.BIT_TEST_PRESSURE_CORR) = True) Then
            chkTestPressureCorr.CheckState = CheckState.Checked
        Else
            chkTestPressureCorr.CheckState = CheckState.Unchecked
        End If
        ' end 1.400

        ' 1.500
        If (GetOptionParameter(m_paramF28.wOptions, F28_OPTIONS.BIT_ELECTRONIC_REGULATOR) = True) Then
            chkElectronicRegulator.CheckState = CheckState.Checked
        Else
            chkElectronicRegulator.CheckState = CheckState.Unchecked
        End If
        ' End 1.500

    End Sub

    '
    ' *****************************************************
    ' Save parameters from edit screen
    ' *****************************************************
    '
    Private Sub SaveParamFields()

        m_paramF28.wTypeTest = cboTestType.SelectedIndex
        m_paramF28.wTpsFill = edtFillTime.Text
        m_paramF28.wTpsStab = edtStabTime.Text
        m_paramF28.wTpsTest = edtTestTime.Text
        m_paramF28.wTpsFillVol = edtFillVolTime.Text
        m_paramF28.wTpsTransfert = edtTransfertTime.Text
        m_paramF28.wTpsDump = edtDumpTime.Text

        m_paramF28.wPress1Unit = cboP1Unit.SelectedIndex
        m_paramF28.fPress1Max = edtMaxP1.Text
        m_paramF28.fPress1Min = edtMinP1.Text
        m_paramF28.fCoeffMax = edtRatioCoeffMax.Text
        m_paramF28.fCoeffMin = edtRatioCoeffMin.Text
        m_paramF28.fRatioMax = edtRatioMax.Text
        m_paramF28.fRatioMin = edtRatioMin.Text

        m_paramF28.fSetFillP1 = edtSetPoint.Text
        m_paramF28.wFillMode = cboFillType.SelectedIndex

        m_paramF28.wLeakUnit = cboLeakUnit.SelectedIndex
        If (m_paramF28.wLeakUnit > F28_LEAK_UNITS.LEAK_POINTS) Then    ' Hole in leak unit list
            m_paramF28.wLeakUnit += 6
        End If
        m_paramF28.fRejectMax = edtLeakMax.Text
        m_paramF28.fRejectMin = edtLeakMin.Text

        m_paramF28.wVolumeUnit = cboVolUnit.SelectedIndex
        m_paramF28.fVolume = edtVolume.Text
        m_paramF28.wRejectCalc = cboRejectClac.SelectedIndex

        m_paramF28.fPatmSTD = edtAbsPress.Text        ' Patm  standard condition (hPa)
        m_paramF28.fTempSTD = edtTemp.Text            ' Temperature standard condition (°C)
        m_paramF28.fFilterTime = edtFilter.Text       ' (s)

        m_paramF28.fOffsetLeak = edtLeakOffset.Text

        ' 1.400 Options
        SetOption(m_paramF28.wOptions, chkSign.CheckState = CheckState.Checked, F28_OPTIONS.BIT_SIGN)
        SetOption(m_paramF28.wOptions, chkNoNegative.CheckState = CheckState.Checked, F28_OPTIONS.BIT_NO_NEGATIVE_VALUE)
        SetOption(m_paramF28.wOptions, chkTestPressureCorr.CheckState = CheckState.Checked, F28_OPTIONS.BIT_TEST_PRESSURE_CORR)
        ' end 1.400

        SetOption(m_paramF28.wOptions, chkElectronicRegulator.CheckState = CheckState.Checked, F28_OPTIONS.BIT_ELECTRONIC_REGULATOR)

    End Sub

    '
    ' *****************************************************
    ' Set current module ID
    ' *****************************************************
    '
    Public Sub SetCurrentID(sModuleID As Short)

        m_sCurrentID = sModuleID

    End Sub
    '
    ' *****************************************************
    ' Set parameter to default
    ' *****************************************************
    '
    Public Sub Initialize()

        m_paramF28.wTypeTest = F28_TYPE_TEST.LEAK_TEST
        m_paramF28.wTpsTest = 300               ' 3 s
        m_paramF28.wTpsFillVol = 100            ' 1 s
        m_paramF28.wTpsTransfert = 100          ' 1 s
        m_paramF28.wTpsFill = 100               ' 1 s
        m_paramF28.wTpsStab = 100               ' 1 s
        m_paramF28.wTpsDump = 100
        m_paramF28.wPress1Unit = F28_PRESS_UNITS.PRESS_mBAR ' mBar
        m_paramF28.fPress1Min = -1000
        m_paramF28.fPress1Max = 5000
        m_paramF28.fSetFillP1 = 0               ' mode auto-fill
        m_paramF28.fRatioMax = 0
        m_paramF28.fRatioMin = 0
        m_paramF28.wFillMode = 0                ' STD_FILL_MODE / AUTOFILL_MODE
        m_paramF28.wLeakUnit = F28_LEAK_UNITS.LEAK_SCCM

        m_paramF28.wRejectCalc = 1              ' Pa or Pa/s
        m_paramF28.wVolumeUnit = F28_ENUM_VOLUME_UNIT.VOLUME_CM3
        m_paramF28.fVolume = 30

        m_paramF28.fRejectMin = 0
        m_paramF28.fRejectMax = 10

        m_paramF28.fCoeffAutoFill = 0           ' 
        m_paramF28.wOptions = 0                 ' option

        m_paramF28.fPatmSTD = 1013.0            ' Patm  standard condition (hPa)
        m_paramF28.fTempSTD = 0                 ' Temperature standard condition (°C)
        m_paramF28.fFilterTime = 0              ' (s)

        ' Offset leak
        m_paramF28.fOffsetLeak = 0

        m_paramF28.fVolumeRef = 0.0

        m_paramF28.wTpsTestCompTemp = 0
        m_paramF28.wPourcCompTemp = 0
        m_paramF28.wTpsWaitingTime = 0
        m_paramF28.wLastConsigneDacEasy = 0

        m_paramF28.fCoeffMin = 0.2
        m_paramF28.fCoeffMax = 1.0
        m_paramF28.fNominalValue = 0.0

    End Sub

    '
    ' *****************************************************
    ' Get Offset + Volume in string
    ' *****************************************************
    '
    Public Function GetOffsetVolumeStr() As String
        Dim str As String

        str = "Offset = " & m_paramF28.fOffsetLeak.ToString("F4") & " - Volume = " & m_paramF28.fVolume.ToString("F2")

        Return str

    End Function
    '
    ' *****************************************************
    ' Get Ratio
    ' *****************************************************
    '
    Public Function GetRatioStr() As String
        Dim str As String

        str = "Ratio max. = " & m_paramF28.fRatioMax.ToString("F4") & " - Ratio min. = " & m_paramF28.fRatioMin.ToString("F4")

        Return str

    End Function

    '
    ' *****************************************************
    ' form Load 
    ' *****************************************************
    '
    Private Sub parameterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Load all parameters
        LoadParamFields()

    End Sub

    '
    ' *****************************************************
    ' End of edit & write to F28L unit 
    ' *****************************************************
    '
    Private Sub m_btnWrite_Click(sender As Object, e As EventArgs) Handles m_btnWrite.Click
        Dim sRetCode As Short

        If (m_sCurrentID > 0) Then

            Me.Cursor = Cursors.WaitCursor

            SaveParamFields()

            sRetCode = F28_SetModuleParameters(m_sCurrentID, m_paramF28)
            F28_GetModuleParameters(m_sCurrentID, m_paramF28)       ' Read after write to update some fields
            LoadParamFields()

            Me.Cursor = Cursors.Default

            If sRetCode <> F28_RETURN.F28_OK Then
                MsgBox("Error writing paramerters !!!")
            End If

        End If

        If sRetCode = F28_RETURN.F28_OK Then
            Me.Visible = False
        End If
    End Sub

End Class

