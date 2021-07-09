<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class parameterForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.m_btnWrite = New System.Windows.Forms.Button()
        Me.m_btnRead = New System.Windows.Forms.Button()
        Me.m_btnExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTestType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.edtTestTime = New System.Windows.Forms.TextBox()
        Me.edtFillTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.edtFillVolTime = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.edtTransfertTime = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboP1Unit = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.edtMaxP1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.edtMinP1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.edtRatioCoeffMin = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.edtRatioCoeffMax = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboLeakUnit = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.edtLeakMin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.edtLeakMax = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.edtVolume = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboVolUnit = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkSign = New System.Windows.Forms.CheckBox()
        Me.edtStabTime = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.edtDumpTime = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.edtSetPoint = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboFillType = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboRejectClac = New System.Windows.Forms.ComboBox()
        Me.edtAbsPress = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.edtTemp = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.edtFilter = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.edtLeakOffset = New System.Windows.Forms.TextBox()
        Me.chkNoNegative = New System.Windows.Forms.CheckBox()
        Me.chkTestPressureCorr = New System.Windows.Forms.CheckBox()
        Me.chkElectronicRegulator = New System.Windows.Forms.CheckBox()
        Me.grpBoxOption = New System.Windows.Forms.GroupBox()
        Me.edtRatioMax = New System.Windows.Forms.TextBox()
        Me.edtRatioMin = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.edtNominalValue = New System.Windows.Forms.TextBox()
        Me.grpBoxOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_btnWrite
        '
        Me.m_btnWrite.Location = New System.Drawing.Point(324, 597)
        Me.m_btnWrite.Name = "m_btnWrite"
        Me.m_btnWrite.Size = New System.Drawing.Size(100, 36)
        Me.m_btnWrite.TabIndex = 0
        Me.m_btnWrite.Text = "OK(Write)"
        Me.m_btnWrite.UseVisualStyleBackColor = True
        '
        'm_btnRead
        '
        Me.m_btnRead.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.m_btnRead.Location = New System.Drawing.Point(577, 92)
        Me.m_btnRead.Name = "m_btnRead"
        Me.m_btnRead.Size = New System.Drawing.Size(30, 108)
        Me.m_btnRead.TabIndex = 1
        Me.m_btnRead.Text = "Read"
        Me.m_btnRead.UseVisualStyleBackColor = True
        '
        'm_btnExit
        '
        Me.m_btnExit.Location = New System.Drawing.Point(460, 597)
        Me.m_btnExit.Name = "m_btnExit"
        Me.m_btnExit.Size = New System.Drawing.Size(100, 36)
        Me.m_btnExit.TabIndex = 2
        Me.m_btnExit.Text = "Exit"
        Me.m_btnExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(59, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Type of test "
        '
        'cboTestType
        '
        Me.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTestType.ForeColor = System.Drawing.Color.Blue
        Me.cboTestType.FormattingEnabled = True
        Me.cboTestType.Items.AddRange(New Object() {"Undefined", "Leak test", "Sealed component", "Desensibilized", "Flow test"})
        Me.cboTestType.Location = New System.Drawing.Point(144, 4)
        Me.cboTestType.Name = "cboTestType"
        Me.cboTestType.Size = New System.Drawing.Size(116, 21)
        Me.cboTestType.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Test time (0.01 s)"
        '
        'edtTestTime
        '
        Me.edtTestTime.Location = New System.Drawing.Point(144, 58)
        Me.edtTestTime.Name = "edtTestTime"
        Me.edtTestTime.Size = New System.Drawing.Size(115, 21)
        Me.edtTestTime.TabIndex = 3
        '
        'edtFillTime
        '
        Me.edtFillTime.Location = New System.Drawing.Point(144, 31)
        Me.edtFillTime.Name = "edtFillTime"
        Me.edtFillTime.Size = New System.Drawing.Size(115, 21)
        Me.edtFillTime.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fill time (0.01 s)"
        '
        'edtFillVolTime
        '
        Me.edtFillVolTime.Location = New System.Drawing.Point(144, 86)
        Me.edtFillVolTime.Name = "edtFillVolTime"
        Me.edtFillVolTime.Size = New System.Drawing.Size(115, 21)
        Me.edtFillVolTime.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fill volume (0.01 s)"
        '
        'edtTransfertTime
        '
        Me.edtTransfertTime.Location = New System.Drawing.Point(144, 112)
        Me.edtTransfertTime.Name = "edtTransfertTime"
        Me.edtTransfertTime.Size = New System.Drawing.Size(115, 21)
        Me.edtTransfertTime.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Transfert (0.01 s)"
        '
        'cboP1Unit
        '
        Me.cboP1Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboP1Unit.FormattingEnabled = True
        Me.cboP1Unit.Items.AddRange(New Object() {"Pa", "KPa", "MPa", "Bar", "mBar", "PSI", "Points"})
        Me.cboP1Unit.Location = New System.Drawing.Point(144, 155)
        Me.cboP1Unit.Name = "cboP1Unit"
        Me.cboP1Unit.Size = New System.Drawing.Size(116, 21)
        Me.cboP1Unit.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(39, 162)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Unit pressure P1"
        '
        'edtMaxP1
        '
        Me.edtMaxP1.Location = New System.Drawing.Point(144, 185)
        Me.edtMaxP1.Name = "edtMaxP1"
        Me.edtMaxP1.Size = New System.Drawing.Size(115, 21)
        Me.edtMaxP1.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 189)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Max pressure P1"
        '
        'edtMinP1
        '
        Me.edtMinP1.Location = New System.Drawing.Point(144, 211)
        Me.edtMinP1.Name = "edtMinP1"
        Me.edtMinP1.Size = New System.Drawing.Size(115, 21)
        Me.edtMinP1.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(42, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Min pressure P1"
        '
        'edtRatioCoeffMin
        '
        Me.edtRatioCoeffMin.Location = New System.Drawing.Point(145, 263)
        Me.edtRatioCoeffMin.Name = "edtRatioCoeffMin"
        Me.edtRatioCoeffMin.Size = New System.Drawing.Size(115, 21)
        Me.edtRatioCoeffMin.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(53, 267)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Ratio Min (%)"
        '
        'edtRatioCoeffMax
        '
        Me.edtRatioCoeffMax.Location = New System.Drawing.Point(145, 237)
        Me.edtRatioCoeffMax.Name = "edtRatioCoeffMax"
        Me.edtRatioCoeffMax.Size = New System.Drawing.Size(115, 21)
        Me.edtRatioCoeffMax.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(49, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Ratio Max (%)"
        '
        'cboLeakUnit
        '
        Me.cboLeakUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeakUnit.FormattingEnabled = True
        Me.cboLeakUnit.Items.AddRange(New Object() {"Pa", "Pa/sc", "PaHr", "Pa/sHr", "Pa", "CalPa/s", "cc/mn", "cc/s", "cc/h", "mm3/s", "cm3/s", "cm3/mn", "cm3/h", "ml/sec", "ml/mn", "ml/h", "inch3/s", "inch3/mn", "inch3/h", "ft3/s", "ft3/mn", "ft3/h", "mmCE", "mmCE/s", "sccm", "Pts", "cmH2O", "ugH20"})
        Me.cboLeakUnit.Location = New System.Drawing.Point(143, 338)
        Me.cboLeakUnit.Name = "cboLeakUnit"
        Me.cboLeakUnit.Size = New System.Drawing.Size(116, 21)
        Me.cboLeakUnit.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(74, 348)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Leak unit"
        '
        'edtLeakMin
        '
        Me.edtLeakMin.Location = New System.Drawing.Point(144, 391)
        Me.edtLeakMin.Name = "edtLeakMin"
        Me.edtLeakMin.Size = New System.Drawing.Size(115, 21)
        Me.edtLeakMin.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(74, 398)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Leak Min"
        '
        'edtLeakMax
        '
        Me.edtLeakMax.Location = New System.Drawing.Point(144, 365)
        Me.edtLeakMax.Name = "edtLeakMax"
        Me.edtLeakMax.Size = New System.Drawing.Size(115, 21)
        Me.edtLeakMax.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(68, 372)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Leak Max "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(56, 499)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Volume calc Unit"
        '
        'edtVolume
        '
        Me.edtVolume.Location = New System.Drawing.Point(144, 466)
        Me.edtVolume.Name = "edtVolume"
        Me.edtVolume.Size = New System.Drawing.Size(115, 21)
        Me.edtVolume.TabIndex = 20
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(83, 473)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Volume"
        '
        'cboVolUnit
        '
        Me.cboVolUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVolUnit.FormattingEnabled = True
        Me.cboVolUnit.Items.AddRange(New Object() {"cm3", "mm3", "ml", "litre", "Inch3", "Ft3"})
        Me.cboVolUnit.Location = New System.Drawing.Point(143, 439)
        Me.cboVolUnit.Name = "cboVolUnit"
        Me.cboVolUnit.Size = New System.Drawing.Size(116, 21)
        Me.cboVolUnit.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(63, 449)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(62, 13)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Volume unit"
        '
        'chkSign
        '
        Me.chkSign.AutoSize = True
        Me.chkSign.Location = New System.Drawing.Point(29, 26)
        Me.chkSign.Name = "chkSign"
        Me.chkSign.Size = New System.Drawing.Size(79, 17)
        Me.chkSign.TabIndex = 22
        Me.chkSign.Text = "Sign option"
        Me.chkSign.UseVisualStyleBackColor = True
        '
        'edtStabTime
        '
        Me.edtStabTime.Location = New System.Drawing.Point(439, 30)
        Me.edtStabTime.Name = "edtStabTime"
        Me.edtStabTime.Size = New System.Drawing.Size(115, 21)
        Me.edtStabTime.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(308, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Stabilisation time (0.01 s)"
        '
        'edtDumpTime
        '
        Me.edtDumpTime.Location = New System.Drawing.Point(439, 57)
        Me.edtDumpTime.Name = "edtDumpTime"
        Me.edtDumpTime.Size = New System.Drawing.Size(115, 21)
        Me.edtDumpTime.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(334, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 13)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Dump time (0.01 s)"
        '
        'edtSetPoint
        '
        Me.edtSetPoint.Location = New System.Drawing.Point(437, 181)
        Me.edtSetPoint.Name = "edtSetPoint"
        Me.edtSetPoint.Size = New System.Drawing.Size(115, 21)
        Me.edtSetPoint.TabIndex = 12
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(366, 189)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Setpoint Fill "
        '
        'cboFillType
        '
        Me.cboFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFillType.ForeColor = System.Drawing.Color.Blue
        Me.cboFillType.FormattingEnabled = True
        Me.cboFillType.Items.AddRange(New Object() {"Standard", "AutoFill", "Instruction", "Ramp", "Ramp control", "Easy", "Easy auto"})
        Me.cboFillType.Location = New System.Drawing.Point(436, 212)
        Me.cboFillType.Name = "cboFillType"
        Me.cboFillType.Size = New System.Drawing.Size(116, 21)
        Me.cboFillType.TabIndex = 13
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(381, 219)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Fill type"
        '
        'cboRejectClac
        '
        Me.cboRejectClac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRejectClac.FormattingEnabled = True
        Me.cboRejectClac.Items.AddRange(New Object() {"Pa", "Pa/s"})
        Me.cboRejectClac.Location = New System.Drawing.Point(145, 495)
        Me.cboRejectClac.Name = "cboRejectClac"
        Me.cboRejectClac.Size = New System.Drawing.Size(116, 21)
        Me.cboRejectClac.TabIndex = 21
        '
        'edtAbsPress
        '
        Me.edtAbsPress.Location = New System.Drawing.Point(440, 432)
        Me.edtAbsPress.Name = "edtAbsPress"
        Me.edtAbsPress.Size = New System.Drawing.Size(115, 21)
        Me.edtAbsPress.TabIndex = 23
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(269, 442)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(148, 11)
        Me.Label21.TabIndex = 45
        Me.Label21.Text = "Std Cond. Abs pressure(hPa)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'edtTemp
        '
        Me.edtTemp.Location = New System.Drawing.Point(440, 458)
        Me.edtTemp.Name = "edtTemp"
        Me.edtTemp.Size = New System.Drawing.Size(115, 21)
        Me.edtTemp.TabIndex = 24
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(274, 466)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(143, 13)
        Me.Label22.TabIndex = 47
        Me.Label22.Text = "Std Cond. temperature (°C)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'edtFilter
        '
        Me.edtFilter.Location = New System.Drawing.Point(440, 390)
        Me.edtFilter.Name = "edtFilter"
        Me.edtFilter.Size = New System.Drawing.Size(115, 21)
        Me.edtFilter.TabIndex = 18
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(286, 398)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(133, 13)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Filter (s)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(362, 365)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 13)
        Me.Label24.TabIndex = 51
        Me.Label24.Text = "Leak Offset"
        '
        'edtLeakOffset
        '
        Me.edtLeakOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.edtLeakOffset.Location = New System.Drawing.Point(440, 362)
        Me.edtLeakOffset.Name = "edtLeakOffset"
        Me.edtLeakOffset.Size = New System.Drawing.Size(115, 21)
        Me.edtLeakOffset.TabIndex = 17
        '
        'chkNoNegative
        '
        Me.chkNoNegative.AutoSize = True
        Me.chkNoNegative.Location = New System.Drawing.Point(133, 26)
        Me.chkNoNegative.Name = "chkNoNegative"
        Me.chkNoNegative.Size = New System.Drawing.Size(84, 17)
        Me.chkNoNegative.TabIndex = 52
        Me.chkNoNegative.Text = "No negative"
        Me.chkNoNegative.UseVisualStyleBackColor = True
        '
        'chkTestPressureCorr
        '
        Me.chkTestPressureCorr.AutoSize = True
        Me.chkTestPressureCorr.Location = New System.Drawing.Point(239, 26)
        Me.chkTestPressureCorr.Name = "chkTestPressureCorr"
        Me.chkTestPressureCorr.Size = New System.Drawing.Size(161, 17)
        Me.chkTestPressureCorr.TabIndex = 53
        Me.chkTestPressureCorr.Text = "Test pressure compensation"
        Me.chkTestPressureCorr.UseVisualStyleBackColor = True
        '
        'chkElectronicRegulator
        '
        Me.chkElectronicRegulator.AutoSize = True
        Me.chkElectronicRegulator.ForeColor = System.Drawing.Color.Blue
        Me.chkElectronicRegulator.Location = New System.Drawing.Point(427, 26)
        Me.chkElectronicRegulator.Name = "chkElectronicRegulator"
        Me.chkElectronicRegulator.Size = New System.Drawing.Size(122, 17)
        Me.chkElectronicRegulator.TabIndex = 54
        Me.chkElectronicRegulator.Text = "Electronic Regulator"
        Me.chkElectronicRegulator.UseVisualStyleBackColor = True
        '
        'grpBoxOption
        '
        Me.grpBoxOption.Controls.Add(Me.chkElectronicRegulator)
        Me.grpBoxOption.Controls.Add(Me.chkSign)
        Me.grpBoxOption.Controls.Add(Me.chkTestPressureCorr)
        Me.grpBoxOption.Controls.Add(Me.chkNoNegative)
        Me.grpBoxOption.Location = New System.Drawing.Point(12, 522)
        Me.grpBoxOption.Name = "grpBoxOption"
        Me.grpBoxOption.Size = New System.Drawing.Size(554, 66)
        Me.grpBoxOption.TabIndex = 55
        Me.grpBoxOption.TabStop = False
        Me.grpBoxOption.Text = "[ Options ] "
        '
        'edtRatioMax
        '
        Me.edtRatioMax.Location = New System.Drawing.Point(277, 237)
        Me.edtRatioMax.Name = "edtRatioMax"
        Me.edtRatioMax.ReadOnly = True
        Me.edtRatioMax.Size = New System.Drawing.Size(115, 21)
        Me.edtRatioMax.TabIndex = 56
        '
        'edtRatioMin
        '
        Me.edtRatioMin.Location = New System.Drawing.Point(277, 264)
        Me.edtRatioMin.Name = "edtRatioMin"
        Me.edtRatioMin.ReadOnly = True
        Me.edtRatioMin.Size = New System.Drawing.Size(115, 21)
        Me.edtRatioMin.TabIndex = 57
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(56, 295)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(73, 13)
        Me.Label25.TabIndex = 58
        Me.Label25.Text = "Nominal value"
        '
        'edtNominalValue
        '
        Me.edtNominalValue.Location = New System.Drawing.Point(145, 292)
        Me.edtNominalValue.Name = "edtNominalValue"
        Me.edtNominalValue.Size = New System.Drawing.Size(115, 21)
        Me.edtNominalValue.TabIndex = 59
        '
        'parameterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 639)
        Me.Controls.Add(Me.edtNominalValue)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.edtRatioMin)
        Me.Controls.Add(Me.edtRatioMax)
        Me.Controls.Add(Me.grpBoxOption)
        Me.Controls.Add(Me.edtLeakOffset)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.edtFilter)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.edtTemp)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.edtAbsPress)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cboRejectClac)
        Me.Controls.Add(Me.cboFillType)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.edtSetPoint)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.edtStabTime)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.edtDumpTime)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.edtVolume)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboVolUnit)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.edtLeakMin)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.edtLeakMax)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboLeakUnit)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.edtRatioCoeffMin)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.edtRatioCoeffMax)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.edtMinP1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.edtMaxP1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboP1Unit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.edtTransfertTime)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.edtFillVolTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.edtFillTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.edtTestTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTestType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.m_btnExit)
        Me.Controls.Add(Me.m_btnRead)
        Me.Controls.Add(Me.m_btnWrite)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "parameterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F28 Parameters (for Structure ver 1.4xx)"
        Me.grpBoxOption.ResumeLayout(False)
        Me.grpBoxOption.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents m_btnWrite As System.Windows.Forms.Button
    Friend WithEvents m_btnRead As System.Windows.Forms.Button
    Friend WithEvents m_btnExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTestType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents edtTestTime As System.Windows.Forms.TextBox
    Friend WithEvents edtFillTime As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents edtFillVolTime As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents edtTransfertTime As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboP1Unit As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents edtMaxP1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents edtMinP1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents edtRatioCoeffMin As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents edtRatioCoeffMax As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboLeakUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents edtLeakMin As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents edtLeakMax As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents edtVolume As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboVolUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkSign As System.Windows.Forms.CheckBox
    Friend WithEvents edtStabTime As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents edtDumpTime As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents edtSetPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboFillType As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboRejectClac As System.Windows.Forms.ComboBox
    Friend WithEvents edtAbsPress As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents edtTemp As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents edtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents edtLeakOffset As System.Windows.Forms.TextBox
    Friend WithEvents chkNoNegative As System.Windows.Forms.CheckBox
    Friend WithEvents chkTestPressureCorr As System.Windows.Forms.CheckBox
    Friend WithEvents chkElectronicRegulator As System.Windows.Forms.CheckBox
    Friend WithEvents grpBoxOption As System.Windows.Forms.GroupBox
    Friend WithEvents edtRatioMax As System.Windows.Forms.TextBox
    Friend WithEvents edtRatioMin As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents edtNominalValue As System.Windows.Forms.TextBox
End Class
