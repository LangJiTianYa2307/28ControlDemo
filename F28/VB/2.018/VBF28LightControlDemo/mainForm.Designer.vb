<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.CheckOpenClose = New System.Windows.Forms.CheckBox()
        Me.m_ListBoxMsg = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AddModule = New System.Windows.Forms.Button()
        Me.cboModules = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnParameter = New System.Windows.Forms.Button()
        Me.cboGroup = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStopGrp = New System.Windows.Forms.Button()
        Me.btnStartGrp = New System.Windows.Forms.Button()
        Me.btnFIFO = New System.Windows.Forms.Button()
        Me.m_TimerRealTime = New System.Windows.Forms.Timer(Me.components)
        Me.m_labelMeasure1 = New System.Windows.Forms.Label()
        Me.m_labelMeasure2 = New System.Windows.Forms.Label()
        Me.m_labelDllVer = New System.Windows.Forms.Label()
        Me.m_labelFifoCount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.m_labelPhase = New System.Windows.Forms.Label()
        Me.m_labelTransmit = New System.Windows.Forms.Label()
        Me.m_labelReceive = New System.Windows.Forms.Label()
        Me.m_labelError = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.m_labelUnit1 = New System.Windows.Forms.Label()
        Me.m_labelUnit2 = New System.Windows.Forms.Label()
        Me.m_btnExit = New System.Windows.Forms.Button()
        Me.m_chkReadFifo = New System.Windows.Forms.CheckBox()
        Me.m_btnClearFIFO = New System.Windows.Forms.Button()
        Me.m_btnClearList = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.m_labelUnitOC = New System.Windows.Forms.Label()
        Me.m_labelUnit_hPa = New System.Windows.Forms.Label()
        Me.m_labelTemp = New System.Windows.Forms.Label()
        Me.m_labelPAbs = New System.Windows.Forms.Label()
        Me.TextBoxIPAddr = New System.Windows.Forms.TextBox()
        Me.labelIPAddr = New System.Windows.Forms.Label()
        Me.btnAZPressure = New System.Windows.Forms.Button()
        Me.textBoxAZDumpTime = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReadLastResult = New System.Windows.Forms.Button()
        Me.btnOffsetOnly = New System.Windows.Forms.Button()
        Me.btnAutoVolume = New System.Windows.Forms.Button()
        Me.textBoxIntercycle = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.textBoxCycleNumber = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grpBoxCalibration = New System.Windows.Forms.GroupBox()
        Me.btnStartEasyAutoLearning = New System.Windows.Forms.Button()
        Me.btnStartAutoRatio = New System.Windows.Forms.Button()
        Me.m_labelCal = New System.Windows.Forms.Label()
        Me.btnStopAutoCal = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.textBoxVolMaxCal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.textBoxOffset = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.textBoxVolMinCal = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.textBoxPressureCal = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.textBoxLeakCal = New System.Windows.Forms.TextBox()
        Me.btnReadPara = New System.Windows.Forms.Button()
        Me.grpBoxRegAdjust = New System.Windows.Forms.GroupBox()
        Me.btnJetCheck = New System.Windows.Forms.Button()
        Me.btnElecRegLearn = New System.Windows.Forms.Button()
        Me.btnRegulatorAjust = New System.Windows.Forms.Button()
        Me.textBoxIPHead1 = New System.Windows.Forms.TextBox()
        Me.btnAddMod1 = New System.Windows.Forms.Button()
        Me.textBoxIPHead2 = New System.Windows.Forms.TextBox()
        Me.btnAddMod2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEasyAutoLearning3 = New System.Windows.Forms.Button()
        Me.btnAutoRatio3 = New System.Windows.Forms.Button()
        Me.chkConnect3 = New System.Windows.Forms.CheckBox()
        Me.labelErr_3 = New System.Windows.Forms.Label()
        Me.labelRec_3 = New System.Windows.Forms.Label()
        Me.labelTr_3 = New System.Windows.Forms.Label()
        Me.chkConnect2 = New System.Windows.Forms.CheckBox()
        Me.labelErr_2 = New System.Windows.Forms.Label()
        Me.labelRec_2 = New System.Windows.Forms.Label()
        Me.labelTr_2 = New System.Windows.Forms.Label()
        Me.chkConnect1 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.labelErr_1 = New System.Windows.Forms.Label()
        Me.labelRec_1 = New System.Windows.Forms.Label()
        Me.labelTr_1 = New System.Windows.Forms.Label()
        Me.LabelMod3 = New System.Windows.Forms.Label()
        Me.LabelMod2 = New System.Windows.Forms.Label()
        Me.btnAddMod3 = New System.Windows.Forms.Button()
        Me.textBoxIPHead3 = New System.Windows.Forms.TextBox()
        Me.labelMod1 = New System.Windows.Forms.Label()
        Me.btnOffset2 = New System.Windows.Forms.Button()
        Me.btnStart2 = New System.Windows.Forms.Button()
        Me.m_listBox2Heads = New System.Windows.Forms.ListBox()
        Me.m_TimerHead1 = New System.Windows.Forms.Timer(Me.components)
        Me.m_TimerHead2 = New System.Windows.Forms.Timer(Me.components)
        Me.m_TimerHead3 = New System.Windows.Forms.Timer(Me.components)
        Me.m_TimerWatchDog = New System.Windows.Forms.Timer(Me.components)
        Me.chkConnected = New System.Windows.Forms.CheckBox()
        Me.m_btnRemoveModule = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxVolumeMax = New System.Windows.Forms.TextBox()
        Me.TextBoxVolumeMin = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextBoxVolumePressure = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBoxTransfertTime = New System.Windows.Forms.TextBox()
        Me.TextBoxFillTime = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnLearningRefVolume = New System.Windows.Forms.Button()
        Me.btnLearningTestVolume = New System.Windows.Forms.Button()
        Me.btnInfiniteDump = New System.Windows.Forms.Button()
        Me.grpBoxCalibration.SuspendLayout()
        Me.grpBoxRegAdjust.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckOpenClose
        '
        Me.CheckOpenClose.Location = New System.Drawing.Point(27, 41)
        Me.CheckOpenClose.Name = "CheckOpenClose"
        Me.CheckOpenClose.Size = New System.Drawing.Size(144, 34)
        Me.CheckOpenClose.TabIndex = 4
        Me.CheckOpenClose.Text = "(1) Open/Close"
        Me.CheckOpenClose.UseVisualStyleBackColor = True
        '
        'm_ListBoxMsg
        '
        Me.m_ListBoxMsg.FormattingEnabled = True
        Me.m_ListBoxMsg.Location = New System.Drawing.Point(11, 464)
        Me.m_ListBoxMsg.Name = "m_ListBoxMsg"
        Me.m_ListBoxMsg.Size = New System.Drawing.Size(909, 121)
        Me.m_ListBoxMsg.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "DLL Version"
        '
        'AddModule
        '
        Me.AddModule.Location = New System.Drawing.Point(27, 155)
        Me.AddModule.Name = "AddModule"
        Me.AddModule.Size = New System.Drawing.Size(144, 32)
        Me.AddModule.TabIndex = 7
        Me.AddModule.Text = "(2) AddModule"
        Me.AddModule.UseVisualStyleBackColor = True
        '
        'cboModules
        '
        Me.cboModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModules.FormattingEnabled = True
        Me.cboModules.Location = New System.Drawing.Point(222, 15)
        Me.cboModules.Name = "cboModules"
        Me.cboModules.Size = New System.Drawing.Size(106, 21)
        Me.cboModules.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(166, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ModuleID"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(357, 130)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(124, 32)
        Me.btnStart.TabIndex = 10
        Me.btnStart.Text = "Start Cycle"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(357, 173)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(124, 32)
        Me.btnStop.TabIndex = 11
        Me.btnStop.Text = "Reset Cycle"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnParameter
        '
        Me.btnParameter.Location = New System.Drawing.Point(203, 44)
        Me.btnParameter.Name = "btnParameter"
        Me.btnParameter.Size = New System.Drawing.Size(124, 32)
        Me.btnParameter.TabIndex = 12
        Me.btnParameter.Text = "(3) Write Parameter"
        Me.btnParameter.UseVisualStyleBackColor = True
        '
        'cboGroup
        '
        Me.cboGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroup.FormattingEnabled = True
        Me.cboGroup.Location = New System.Drawing.Point(806, 8)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(106, 21)
        Me.cboGroup.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(727, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Groups"
        '
        'btnStopGrp
        '
        Me.btnStopGrp.Location = New System.Drawing.Point(787, 81)
        Me.btnStopGrp.Name = "btnStopGrp"
        Me.btnStopGrp.Size = New System.Drawing.Size(125, 32)
        Me.btnStopGrp.TabIndex = 16
        Me.btnStopGrp.Text = "Reset group"
        Me.btnStopGrp.UseVisualStyleBackColor = True
        '
        'btnStartGrp
        '
        Me.btnStartGrp.Location = New System.Drawing.Point(787, 41)
        Me.btnStartGrp.Name = "btnStartGrp"
        Me.btnStartGrp.Size = New System.Drawing.Size(125, 32)
        Me.btnStartGrp.TabIndex = 15
        Me.btnStartGrp.Text = "Start group"
        Me.btnStartGrp.UseVisualStyleBackColor = True
        '
        'btnFIFO
        '
        Me.btnFIFO.Location = New System.Drawing.Point(203, 173)
        Me.btnFIFO.Name = "btnFIFO"
        Me.btnFIFO.Size = New System.Drawing.Size(124, 32)
        Me.btnFIFO.TabIndex = 17
        Me.btnFIFO.Text = "Read FIFO"
        Me.btnFIFO.UseVisualStyleBackColor = True
        '
        'm_TimerRealTime
        '
        '
        'm_labelMeasure1
        '
        Me.m_labelMeasure1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelMeasure1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelMeasure1.Location = New System.Drawing.Point(357, 9)
        Me.m_labelMeasure1.Name = "m_labelMeasure1"
        Me.m_labelMeasure1.Size = New System.Drawing.Size(106, 28)
        Me.m_labelMeasure1.TabIndex = 20
        Me.m_labelMeasure1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'm_labelMeasure2
        '
        Me.m_labelMeasure2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelMeasure2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelMeasure2.Location = New System.Drawing.Point(539, 9)
        Me.m_labelMeasure2.Name = "m_labelMeasure2"
        Me.m_labelMeasure2.Size = New System.Drawing.Size(106, 28)
        Me.m_labelMeasure2.TabIndex = 21
        Me.m_labelMeasure2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'm_labelDllVer
        '
        Me.m_labelDllVer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelDllVer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelDllVer.Location = New System.Drawing.Point(87, 15)
        Me.m_labelDllVer.Name = "m_labelDllVer"
        Me.m_labelDllVer.Size = New System.Drawing.Size(59, 20)
        Me.m_labelDllVer.TabIndex = 22
        Me.m_labelDllVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelFifoCount
        '
        Me.m_labelFifoCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelFifoCount.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelFifoCount.Location = New System.Drawing.Point(278, 247)
        Me.m_labelFifoCount.Name = "m_labelFifoCount"
        Me.m_labelFifoCount.Size = New System.Drawing.Size(45, 20)
        Me.m_labelFifoCount.TabIndex = 25
        Me.m_labelFifoCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 250)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Result count"
        '
        'm_labelPhase
        '
        Me.m_labelPhase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelPhase.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelPhase.Location = New System.Drawing.Point(357, 42)
        Me.m_labelPhase.Name = "m_labelPhase"
        Me.m_labelPhase.Size = New System.Drawing.Size(358, 28)
        Me.m_labelPhase.TabIndex = 27
        Me.m_labelPhase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelTransmit
        '
        Me.m_labelTransmit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelTransmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelTransmit.Location = New System.Drawing.Point(546, 128)
        Me.m_labelTransmit.Name = "m_labelTransmit"
        Me.m_labelTransmit.Size = New System.Drawing.Size(87, 23)
        Me.m_labelTransmit.TabIndex = 28
        Me.m_labelTransmit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelReceive
        '
        Me.m_labelReceive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelReceive.Location = New System.Drawing.Point(546, 156)
        Me.m_labelReceive.Name = "m_labelReceive"
        Me.m_labelReceive.Size = New System.Drawing.Size(87, 23)
        Me.m_labelReceive.TabIndex = 29
        Me.m_labelReceive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelError
        '
        Me.m_labelError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelError.Location = New System.Drawing.Point(546, 186)
        Me.m_labelError.Name = "m_labelError"
        Me.m_labelError.Size = New System.Drawing.Size(87, 23)
        Me.m_labelError.TabIndex = 30
        Me.m_labelError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(493, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Transmit"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(496, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Receive"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(510, 193)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "Error"
        '
        'm_labelUnit1
        '
        Me.m_labelUnit1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelUnit1.Location = New System.Drawing.Point(469, 9)
        Me.m_labelUnit1.Name = "m_labelUnit1"
        Me.m_labelUnit1.Size = New System.Drawing.Size(64, 28)
        Me.m_labelUnit1.TabIndex = 34
        Me.m_labelUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelUnit2
        '
        Me.m_labelUnit2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelUnit2.Location = New System.Drawing.Point(651, 9)
        Me.m_labelUnit2.Name = "m_labelUnit2"
        Me.m_labelUnit2.Size = New System.Drawing.Size(64, 28)
        Me.m_labelUnit2.TabIndex = 35
        Me.m_labelUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_btnExit
        '
        Me.m_btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.m_btnExit.Location = New System.Drawing.Point(1002, 763)
        Me.m_btnExit.Name = "m_btnExit"
        Me.m_btnExit.Size = New System.Drawing.Size(108, 32)
        Me.m_btnExit.TabIndex = 36
        Me.m_btnExit.Text = "Exit"
        Me.m_btnExit.UseVisualStyleBackColor = True
        '
        'm_chkReadFifo
        '
        Me.m_chkReadFifo.AutoSize = True
        Me.m_chkReadFifo.Location = New System.Drawing.Point(203, 219)
        Me.m_chkReadFifo.Name = "m_chkReadFifo"
        Me.m_chkReadFifo.Size = New System.Drawing.Size(142, 17)
        Me.m_chkReadFifo.TabIndex = 37
        Me.m_chkReadFifo.Text = "Read Fifo Result at EOC"
        Me.m_chkReadFifo.UseVisualStyleBackColor = True
        '
        'm_btnClearFIFO
        '
        Me.m_btnClearFIFO.Location = New System.Drawing.Point(203, 130)
        Me.m_btnClearFIFO.Name = "m_btnClearFIFO"
        Me.m_btnClearFIFO.Size = New System.Drawing.Size(124, 32)
        Me.m_btnClearFIFO.TabIndex = 38
        Me.m_btnClearFIFO.Text = "Clear FIFO"
        Me.m_btnClearFIFO.UseVisualStyleBackColor = True
        '
        'm_btnClearList
        '
        Me.m_btnClearList.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.m_btnClearList.Location = New System.Drawing.Point(1002, 553)
        Me.m_btnClearList.Name = "m_btnClearList"
        Me.m_btnClearList.Size = New System.Drawing.Size(108, 32)
        Me.m_btnClearList.TabIndex = 39
        Me.m_btnClearList.Text = "Clear List"
        Me.m_btnClearList.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(56, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "(Grp #1, Unit #1)"
        '
        'm_labelUnitOC
        '
        Me.m_labelUnitOC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelUnitOC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelUnitOC.ForeColor = System.Drawing.Color.Blue
        Me.m_labelUnitOC.Location = New System.Drawing.Point(651, 77)
        Me.m_labelUnitOC.Name = "m_labelUnitOC"
        Me.m_labelUnitOC.Size = New System.Drawing.Size(64, 28)
        Me.m_labelUnitOC.TabIndex = 44
        Me.m_labelUnitOC.Text = "(°C)"
        Me.m_labelUnitOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelUnit_hPa
        '
        Me.m_labelUnit_hPa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelUnit_hPa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelUnit_hPa.ForeColor = System.Drawing.Color.Blue
        Me.m_labelUnit_hPa.Location = New System.Drawing.Point(469, 77)
        Me.m_labelUnit_hPa.Name = "m_labelUnit_hPa"
        Me.m_labelUnit_hPa.Size = New System.Drawing.Size(64, 28)
        Me.m_labelUnit_hPa.TabIndex = 43
        Me.m_labelUnit_hPa.Text = "(hPa)"
        Me.m_labelUnit_hPa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'm_labelTemp
        '
        Me.m_labelTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelTemp.ForeColor = System.Drawing.Color.Blue
        Me.m_labelTemp.Location = New System.Drawing.Point(539, 77)
        Me.m_labelTemp.Name = "m_labelTemp"
        Me.m_labelTemp.Size = New System.Drawing.Size(106, 28)
        Me.m_labelTemp.TabIndex = 42
        Me.m_labelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'm_labelPAbs
        '
        Me.m_labelPAbs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelPAbs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelPAbs.ForeColor = System.Drawing.Color.Blue
        Me.m_labelPAbs.Location = New System.Drawing.Point(357, 77)
        Me.m_labelPAbs.Name = "m_labelPAbs"
        Me.m_labelPAbs.Size = New System.Drawing.Size(106, 28)
        Me.m_labelPAbs.TabIndex = 41
        Me.m_labelPAbs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxIPAddr
        '
        Me.TextBoxIPAddr.Location = New System.Drawing.Point(27, 126)
        Me.TextBoxIPAddr.Name = "TextBoxIPAddr"
        Me.TextBoxIPAddr.Size = New System.Drawing.Size(144, 21)
        Me.TextBoxIPAddr.TabIndex = 45
        Me.TextBoxIPAddr.Text = "192.168.1.3"
        '
        'labelIPAddr
        '
        Me.labelIPAddr.AutoSize = True
        Me.labelIPAddr.Location = New System.Drawing.Point(28, 104)
        Me.labelIPAddr.Name = "labelIPAddr"
        Me.labelIPAddr.Size = New System.Drawing.Size(59, 13)
        Me.labelIPAddr.TabIndex = 46
        Me.labelIPAddr.Text = "IP Address"
        '
        'btnAZPressure
        '
        Me.btnAZPressure.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAZPressure.Location = New System.Drawing.Point(148, 45)
        Me.btnAZPressure.Name = "btnAZPressure"
        Me.btnAZPressure.Size = New System.Drawing.Size(125, 32)
        Me.btnAZPressure.TabIndex = 47
        Me.btnAZPressure.Text = "Auto Zero"
        Me.btnAZPressure.UseVisualStyleBackColor = True
        '
        'textBoxAZDumpTime
        '
        Me.textBoxAZDumpTime.Location = New System.Drawing.Point(221, 14)
        Me.textBoxAZDumpTime.Name = "textBoxAZDumpTime"
        Me.textBoxAZDumpTime.Size = New System.Drawing.Size(36, 21)
        Me.textBoxAZDumpTime.TabIndex = 48
        Me.textBoxAZDumpTime.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Auto Zero / Elec.Reg.Learn dump time (s)"
        '
        'btnReadLastResult
        '
        Me.btnReadLastResult.Location = New System.Drawing.Point(357, 216)
        Me.btnReadLastResult.Name = "btnReadLastResult"
        Me.btnReadLastResult.Size = New System.Drawing.Size(124, 32)
        Me.btnReadLastResult.TabIndex = 50
        Me.btnReadLastResult.Text = "Read Last Result"
        Me.btnReadLastResult.UseVisualStyleBackColor = True
        '
        'btnOffsetOnly
        '
        Me.btnOffsetOnly.Location = New System.Drawing.Point(640, 18)
        Me.btnOffsetOnly.Name = "btnOffsetOnly"
        Me.btnOffsetOnly.Size = New System.Drawing.Size(125, 32)
        Me.btnOffsetOnly.TabIndex = 48
        Me.btnOffsetOnly.Text = "Auto Offset Only"
        Me.btnOffsetOnly.UseVisualStyleBackColor = True
        '
        'btnAutoVolume
        '
        Me.btnAutoVolume.Location = New System.Drawing.Point(776, 17)
        Me.btnAutoVolume.Name = "btnAutoVolume"
        Me.btnAutoVolume.Size = New System.Drawing.Size(125, 32)
        Me.btnAutoVolume.TabIndex = 53
        Me.btnAutoVolume.Text = "Auto Offset + Volume"
        Me.btnAutoVolume.UseVisualStyleBackColor = True
        '
        'textBoxIntercycle
        '
        Me.textBoxIntercycle.Location = New System.Drawing.Point(225, 36)
        Me.textBoxIntercycle.Name = "textBoxIntercycle"
        Me.textBoxIntercycle.Size = New System.Drawing.Size(57, 21)
        Me.textBoxIntercycle.TabIndex = 54
        Me.textBoxIntercycle.Text = "1000"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(225, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Intercycle (0.01s)"
        '
        'textBoxCycleNumber
        '
        Me.textBoxCycleNumber.Location = New System.Drawing.Point(150, 36)
        Me.textBoxCycleNumber.Name = "textBoxCycleNumber"
        Me.textBoxCycleNumber.Size = New System.Drawing.Size(57, 21)
        Me.textBoxCycleNumber.TabIndex = 56
        Me.textBoxCycleNumber.Text = "2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(146, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 57
        Me.Label12.Text = "Cycle number"
        '
        'grpBoxCalibration
        '
        Me.grpBoxCalibration.Controls.Add(Me.btnStartEasyAutoLearning)
        Me.grpBoxCalibration.Controls.Add(Me.btnStartAutoRatio)
        Me.grpBoxCalibration.Controls.Add(Me.m_labelCal)
        Me.grpBoxCalibration.Controls.Add(Me.btnStopAutoCal)
        Me.grpBoxCalibration.Controls.Add(Me.Label19)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxVolMaxCal)
        Me.grpBoxCalibration.Controls.Add(Me.Label18)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxOffset)
        Me.grpBoxCalibration.Controls.Add(Me.Label16)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxVolMinCal)
        Me.grpBoxCalibration.Controls.Add(Me.btnOffsetOnly)
        Me.grpBoxCalibration.Controls.Add(Me.Label15)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxPressureCal)
        Me.grpBoxCalibration.Controls.Add(Me.Label14)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxLeakCal)
        Me.grpBoxCalibration.Controls.Add(Me.Label12)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxCycleNumber)
        Me.grpBoxCalibration.Controls.Add(Me.Label13)
        Me.grpBoxCalibration.Controls.Add(Me.textBoxIntercycle)
        Me.grpBoxCalibration.Controls.Add(Me.btnAutoVolume)
        Me.grpBoxCalibration.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpBoxCalibration.Location = New System.Drawing.Point(11, 273)
        Me.grpBoxCalibration.Name = "grpBoxCalibration"
        Me.grpBoxCalibration.Size = New System.Drawing.Size(909, 185)
        Me.grpBoxCalibration.TabIndex = 51
        Me.grpBoxCalibration.TabStop = False
        Me.grpBoxCalibration.Text = "[ Offset + Volume Calibration + Auto-Ratio] "
        '
        'btnStartEasyAutoLearning
        '
        Me.btnStartEasyAutoLearning.Location = New System.Drawing.Point(640, 102)
        Me.btnStartEasyAutoLearning.Name = "btnStartEasyAutoLearning"
        Me.btnStartEasyAutoLearning.Size = New System.Drawing.Size(125, 32)
        Me.btnStartEasyAutoLearning.TabIndex = 76
        Me.btnStartEasyAutoLearning.Text = "Easy Auto Learning"
        Me.btnStartEasyAutoLearning.UseVisualStyleBackColor = True
        '
        'btnStartAutoRatio
        '
        Me.btnStartAutoRatio.Location = New System.Drawing.Point(776, 102)
        Me.btnStartAutoRatio.Name = "btnStartAutoRatio"
        Me.btnStartAutoRatio.Size = New System.Drawing.Size(125, 32)
        Me.btnStartAutoRatio.TabIndex = 75
        Me.btnStartAutoRatio.Text = "Auto-Ratio"
        Me.btnStartAutoRatio.UseVisualStyleBackColor = True
        '
        'm_labelCal
        '
        Me.m_labelCal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.m_labelCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m_labelCal.Location = New System.Drawing.Point(225, 66)
        Me.m_labelCal.Name = "m_labelCal"
        Me.m_labelCal.Size = New System.Drawing.Size(440, 28)
        Me.m_labelCal.TabIndex = 70
        Me.m_labelCal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStopAutoCal
        '
        Me.btnStopAutoCal.Location = New System.Drawing.Point(776, 146)
        Me.btnStopAutoCal.Name = "btnStopAutoCal"
        Me.btnStopAutoCal.Size = New System.Drawing.Size(125, 32)
        Me.btnStopAutoCal.TabIndex = 67
        Me.btnStopAutoCal.Text = "Abort"
        Me.btnStopAutoCal.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(248, 121)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(94, 13)
        Me.Label19.TabIndex = 69
        Me.Label19.Text = "Volume max (cm3)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'textBoxVolMaxCal
        '
        Me.textBoxVolMaxCal.Location = New System.Drawing.Point(346, 118)
        Me.textBoxVolMaxCal.Name = "textBoxVolMaxCal"
        Me.textBoxVolMaxCal.Size = New System.Drawing.Size(57, 21)
        Me.textBoxVolMaxCal.TabIndex = 68
        Me.textBoxVolMaxCal.Text = "45"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(345, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 13)
        Me.Label18.TabIndex = 67
        Me.Label18.Text = "Offset Max (sccm)"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'textBoxOffset
        '
        Me.textBoxOffset.Location = New System.Drawing.Point(343, 36)
        Me.textBoxOffset.Name = "textBoxOffset"
        Me.textBoxOffset.Size = New System.Drawing.Size(57, 21)
        Me.textBoxOffset.TabIndex = 66
        Me.textBoxOffset.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(45, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 13)
        Me.Label16.TabIndex = 63
        Me.Label16.Text = "Volume min (cm3)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'textBoxVolMinCal
        '
        Me.textBoxVolMinCal.Location = New System.Drawing.Point(150, 117)
        Me.textBoxVolMinCal.Name = "textBoxVolMinCal"
        Me.textBoxVolMinCal.Size = New System.Drawing.Size(57, 21)
        Me.textBoxVolMinCal.TabIndex = 62
        Me.textBoxVolMinCal.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(130, 13)
        Me.Label15.TabIndex = 61
        Me.Label15.Text = "Calibration pressure (bar)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'textBoxPressureCal
        '
        Me.textBoxPressureCal.Location = New System.Drawing.Point(150, 90)
        Me.textBoxPressureCal.Name = "textBoxPressureCal"
        Me.textBoxPressureCal.Size = New System.Drawing.Size(57, 21)
        Me.textBoxPressureCal.TabIndex = 60
        Me.textBoxPressureCal.Text = "5"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(25, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(114, 13)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "Calibration leak (sccm)"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'textBoxLeakCal
        '
        Me.textBoxLeakCal.Location = New System.Drawing.Point(150, 63)
        Me.textBoxLeakCal.Name = "textBoxLeakCal"
        Me.textBoxLeakCal.Size = New System.Drawing.Size(57, 21)
        Me.textBoxLeakCal.TabIndex = 58
        Me.textBoxLeakCal.Text = "0"
        '
        'btnReadPara
        '
        Me.btnReadPara.Location = New System.Drawing.Point(203, 87)
        Me.btnReadPara.Name = "btnReadPara"
        Me.btnReadPara.Size = New System.Drawing.Size(124, 32)
        Me.btnReadPara.TabIndex = 68
        Me.btnReadPara.Text = "Read Parameter"
        Me.btnReadPara.UseVisualStyleBackColor = True
        '
        'grpBoxRegAdjust
        '
        Me.grpBoxRegAdjust.Controls.Add(Me.btnJetCheck)
        Me.grpBoxRegAdjust.Controls.Add(Me.btnElecRegLearn)
        Me.grpBoxRegAdjust.Controls.Add(Me.textBoxAZDumpTime)
        Me.grpBoxRegAdjust.Controls.Add(Me.Label4)
        Me.grpBoxRegAdjust.Controls.Add(Me.btnAZPressure)
        Me.grpBoxRegAdjust.Controls.Add(Me.btnRegulatorAjust)
        Me.grpBoxRegAdjust.ForeColor = System.Drawing.Color.Blue
        Me.grpBoxRegAdjust.Location = New System.Drawing.Point(639, 126)
        Me.grpBoxRegAdjust.Name = "grpBoxRegAdjust"
        Me.grpBoxRegAdjust.Size = New System.Drawing.Size(281, 141)
        Me.grpBoxRegAdjust.TabIndex = 70
        Me.grpBoxRegAdjust.TabStop = False
        Me.grpBoxRegAdjust.Text = "[ Special cycles ] "
        '
        'btnJetCheck
        '
        Me.btnJetCheck.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnJetCheck.Location = New System.Drawing.Point(12, 90)
        Me.btnJetCheck.Name = "btnJetCheck"
        Me.btnJetCheck.Size = New System.Drawing.Size(125, 32)
        Me.btnJetCheck.TabIndex = 51
        Me.btnJetCheck.Text = "Jet check"
        Me.btnJetCheck.UseVisualStyleBackColor = True
        '
        'btnElecRegLearn
        '
        Me.btnElecRegLearn.ForeColor = System.Drawing.Color.Blue
        Me.btnElecRegLearn.Location = New System.Drawing.Point(12, 45)
        Me.btnElecRegLearn.Name = "btnElecRegLearn"
        Me.btnElecRegLearn.Size = New System.Drawing.Size(125, 32)
        Me.btnElecRegLearn.TabIndex = 50
        Me.btnElecRegLearn.Text = "Elec.Reg.Lean"
        Me.btnElecRegLearn.UseVisualStyleBackColor = True
        '
        'btnRegulatorAjust
        '
        Me.btnRegulatorAjust.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRegulatorAjust.Location = New System.Drawing.Point(148, 90)
        Me.btnRegulatorAjust.Name = "btnRegulatorAjust"
        Me.btnRegulatorAjust.Size = New System.Drawing.Size(125, 32)
        Me.btnRegulatorAjust.TabIndex = 48
        Me.btnRegulatorAjust.Text = "Regulator Adjust"
        Me.btnRegulatorAjust.UseVisualStyleBackColor = True
        '
        'textBoxIPHead1
        '
        Me.textBoxIPHead1.Location = New System.Drawing.Point(12, 21)
        Me.textBoxIPHead1.Name = "textBoxIPHead1"
        Me.textBoxIPHead1.Size = New System.Drawing.Size(105, 21)
        Me.textBoxIPHead1.TabIndex = 72
        Me.textBoxIPHead1.Text = "192.168.1.1"
        '
        'btnAddMod1
        '
        Me.btnAddMod1.Location = New System.Drawing.Point(12, 49)
        Me.btnAddMod1.Name = "btnAddMod1"
        Me.btnAddMod1.Size = New System.Drawing.Size(105, 32)
        Me.btnAddMod1.TabIndex = 71
        Me.btnAddMod1.Text = "AddModule"
        Me.btnAddMod1.UseVisualStyleBackColor = True
        '
        'textBoxIPHead2
        '
        Me.textBoxIPHead2.Location = New System.Drawing.Point(140, 21)
        Me.textBoxIPHead2.Name = "textBoxIPHead2"
        Me.textBoxIPHead2.Size = New System.Drawing.Size(103, 21)
        Me.textBoxIPHead2.TabIndex = 74
        Me.textBoxIPHead2.Text = "192.168.1.2"
        '
        'btnAddMod2
        '
        Me.btnAddMod2.Location = New System.Drawing.Point(140, 49)
        Me.btnAddMod2.Name = "btnAddMod2"
        Me.btnAddMod2.Size = New System.Drawing.Size(103, 32)
        Me.btnAddMod2.TabIndex = 73
        Me.btnAddMod2.Text = "AddModule"
        Me.btnAddMod2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnEasyAutoLearning3)
        Me.GroupBox1.Controls.Add(Me.btnAutoRatio3)
        Me.GroupBox1.Controls.Add(Me.chkConnect3)
        Me.GroupBox1.Controls.Add(Me.labelErr_3)
        Me.GroupBox1.Controls.Add(Me.labelRec_3)
        Me.GroupBox1.Controls.Add(Me.labelTr_3)
        Me.GroupBox1.Controls.Add(Me.chkConnect2)
        Me.GroupBox1.Controls.Add(Me.labelErr_2)
        Me.GroupBox1.Controls.Add(Me.labelRec_2)
        Me.GroupBox1.Controls.Add(Me.labelTr_2)
        Me.GroupBox1.Controls.Add(Me.chkConnect1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.labelErr_1)
        Me.GroupBox1.Controls.Add(Me.labelRec_1)
        Me.GroupBox1.Controls.Add(Me.labelTr_1)
        Me.GroupBox1.Controls.Add(Me.LabelMod3)
        Me.GroupBox1.Controls.Add(Me.LabelMod2)
        Me.GroupBox1.Controls.Add(Me.btnAddMod3)
        Me.GroupBox1.Controls.Add(Me.textBoxIPHead3)
        Me.GroupBox1.Controls.Add(Me.labelMod1)
        Me.GroupBox1.Controls.Add(Me.btnOffset2)
        Me.GroupBox1.Controls.Add(Me.btnStart2)
        Me.GroupBox1.Controls.Add(Me.m_listBox2Heads)
        Me.GroupBox1.Controls.Add(Me.btnAddMod2)
        Me.GroupBox1.Controls.Add(Me.textBoxIPHead2)
        Me.GroupBox1.Controls.Add(Me.btnAddMod1)
        Me.GroupBox1.Controls.Add(Me.textBoxIPHead1)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(11, 591)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 214)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Example : Start/Offset Cal 3 Heads Network ] "
        '
        'btnEasyAutoLearning3
        '
        Me.btnEasyAutoLearning3.Location = New System.Drawing.Point(749, 134)
        Me.btnEasyAutoLearning3.Name = "btnEasyAutoLearning3"
        Me.btnEasyAutoLearning3.Size = New System.Drawing.Size(201, 32)
        Me.btnEasyAutoLearning3.TabIndex = 100
        Me.btnEasyAutoLearning3.Text = "Easy Auto Learning Only #1, #2, #3"
        Me.btnEasyAutoLearning3.UseVisualStyleBackColor = True
        '
        'btnAutoRatio3
        '
        Me.btnAutoRatio3.Location = New System.Drawing.Point(586, 172)
        Me.btnAutoRatio3.Name = "btnAutoRatio3"
        Me.btnAutoRatio3.Size = New System.Drawing.Size(157, 32)
        Me.btnAutoRatio3.TabIndex = 99
        Me.btnAutoRatio3.Text = "Auto-Ratio #1, #2, #3"
        Me.btnAutoRatio3.UseVisualStyleBackColor = True
        '
        'chkConnect3
        '
        Me.chkConnect3.AutoSize = True
        Me.chkConnect3.Enabled = False
        Me.chkConnect3.Location = New System.Drawing.Point(276, 158)
        Me.chkConnect3.Name = "chkConnect3"
        Me.chkConnect3.Size = New System.Drawing.Size(95, 17)
        Me.chkConnect3.TabIndex = 98
        Me.chkConnect3.Text = "Connected #3"
        Me.chkConnect3.UseVisualStyleBackColor = True
        '
        'labelErr_3
        '
        Me.labelErr_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelErr_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelErr_3.Location = New System.Drawing.Point(278, 133)
        Me.labelErr_3.Name = "labelErr_3"
        Me.labelErr_3.Size = New System.Drawing.Size(80, 20)
        Me.labelErr_3.TabIndex = 97
        Me.labelErr_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelRec_3
        '
        Me.labelRec_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelRec_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelRec_3.Location = New System.Drawing.Point(278, 109)
        Me.labelRec_3.Name = "labelRec_3"
        Me.labelRec_3.Size = New System.Drawing.Size(80, 20)
        Me.labelRec_3.TabIndex = 96
        Me.labelRec_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelTr_3
        '
        Me.labelTr_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelTr_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTr_3.Location = New System.Drawing.Point(278, 86)
        Me.labelTr_3.Name = "labelTr_3"
        Me.labelTr_3.Size = New System.Drawing.Size(80, 20)
        Me.labelTr_3.TabIndex = 95
        Me.labelTr_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkConnect2
        '
        Me.chkConnect2.AutoSize = True
        Me.chkConnect2.Enabled = False
        Me.chkConnect2.Location = New System.Drawing.Point(156, 158)
        Me.chkConnect2.Name = "chkConnect2"
        Me.chkConnect2.Size = New System.Drawing.Size(95, 17)
        Me.chkConnect2.TabIndex = 94
        Me.chkConnect2.Text = "Connected #2"
        Me.chkConnect2.UseVisualStyleBackColor = True
        '
        'labelErr_2
        '
        Me.labelErr_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelErr_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelErr_2.Location = New System.Drawing.Point(158, 133)
        Me.labelErr_2.Name = "labelErr_2"
        Me.labelErr_2.Size = New System.Drawing.Size(80, 20)
        Me.labelErr_2.TabIndex = 93
        Me.labelErr_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelRec_2
        '
        Me.labelRec_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelRec_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelRec_2.Location = New System.Drawing.Point(158, 109)
        Me.labelRec_2.Name = "labelRec_2"
        Me.labelRec_2.Size = New System.Drawing.Size(80, 20)
        Me.labelRec_2.TabIndex = 92
        Me.labelRec_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelTr_2
        '
        Me.labelTr_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelTr_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTr_2.Location = New System.Drawing.Point(158, 86)
        Me.labelTr_2.Name = "labelTr_2"
        Me.labelTr_2.Size = New System.Drawing.Size(80, 20)
        Me.labelTr_2.TabIndex = 91
        Me.labelTr_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkConnect1
        '
        Me.chkConnect1.AutoSize = True
        Me.chkConnect1.Enabled = False
        Me.chkConnect1.Location = New System.Drawing.Point(33, 158)
        Me.chkConnect1.Name = "chkConnect1"
        Me.chkConnect1.Size = New System.Drawing.Size(95, 17)
        Me.chkConnect1.TabIndex = 90
        Me.chkConnect1.Text = "Connected #1"
        Me.chkConnect1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Err"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Rec"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 87)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(17, 13)
        Me.Label17.TabIndex = 87
        Me.Label17.Text = "Tr"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelErr_1
        '
        Me.labelErr_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelErr_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelErr_1.Location = New System.Drawing.Point(35, 133)
        Me.labelErr_1.Name = "labelErr_1"
        Me.labelErr_1.Size = New System.Drawing.Size(80, 20)
        Me.labelErr_1.TabIndex = 86
        Me.labelErr_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelRec_1
        '
        Me.labelRec_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelRec_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelRec_1.Location = New System.Drawing.Point(35, 109)
        Me.labelRec_1.Name = "labelRec_1"
        Me.labelRec_1.Size = New System.Drawing.Size(80, 20)
        Me.labelRec_1.TabIndex = 85
        Me.labelRec_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelTr_1
        '
        Me.labelTr_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelTr_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTr_1.Location = New System.Drawing.Point(35, 86)
        Me.labelTr_1.Name = "labelTr_1"
        Me.labelTr_1.Size = New System.Drawing.Size(80, 20)
        Me.labelTr_1.TabIndex = 84
        Me.labelTr_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelMod3
        '
        Me.LabelMod3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelMod3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMod3.Location = New System.Drawing.Point(469, 88)
        Me.LabelMod3.Name = "LabelMod3"
        Me.LabelMod3.Size = New System.Drawing.Size(288, 23)
        Me.LabelMod3.TabIndex = 83
        Me.LabelMod3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelMod2
        '
        Me.LabelMod2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelMod2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMod2.Location = New System.Drawing.Point(469, 53)
        Me.LabelMod2.Name = "LabelMod2"
        Me.LabelMod2.Size = New System.Drawing.Size(288, 23)
        Me.LabelMod2.TabIndex = 82
        Me.LabelMod2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAddMod3
        '
        Me.btnAddMod3.Location = New System.Drawing.Point(255, 48)
        Me.btnAddMod3.Name = "btnAddMod3"
        Me.btnAddMod3.Size = New System.Drawing.Size(103, 32)
        Me.btnAddMod3.TabIndex = 80
        Me.btnAddMod3.Text = "AddModule"
        Me.btnAddMod3.UseVisualStyleBackColor = True
        '
        'textBoxIPHead3
        '
        Me.textBoxIPHead3.Location = New System.Drawing.Point(255, 20)
        Me.textBoxIPHead3.Name = "textBoxIPHead3"
        Me.textBoxIPHead3.Size = New System.Drawing.Size(103, 21)
        Me.textBoxIPHead3.TabIndex = 81
        Me.textBoxIPHead3.Text = "192.168.1.3"
        '
        'labelMod1
        '
        Me.labelMod1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelMod1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelMod1.Location = New System.Drawing.Point(469, 17)
        Me.labelMod1.Name = "labelMod1"
        Me.labelMod1.Size = New System.Drawing.Size(288, 23)
        Me.labelMod1.TabIndex = 79
        Me.labelMod1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOffset2
        '
        Me.btnOffset2.Location = New System.Drawing.Point(586, 134)
        Me.btnOffset2.Name = "btnOffset2"
        Me.btnOffset2.Size = New System.Drawing.Size(157, 32)
        Me.btnOffset2.TabIndex = 78
        Me.btnOffset2.Text = "Auto Offset Only #1, #2, #3"
        Me.btnOffset2.UseVisualStyleBackColor = True
        '
        'btnStart2
        '
        Me.btnStart2.Location = New System.Drawing.Point(470, 134)
        Me.btnStart2.Name = "btnStart2"
        Me.btnStart2.Size = New System.Drawing.Size(110, 32)
        Me.btnStart2.TabIndex = 77
        Me.btnStart2.Text = "Start #1, #2, #3"
        Me.btnStart2.UseVisualStyleBackColor = True
        '
        'm_listBox2Heads
        '
        Me.m_listBox2Heads.FormattingEnabled = True
        Me.m_listBox2Heads.Location = New System.Drawing.Point(375, 19)
        Me.m_listBox2Heads.Name = "m_listBox2Heads"
        Me.m_listBox2Heads.Size = New System.Drawing.Size(81, 147)
        Me.m_listBox2Heads.TabIndex = 75
        '
        'm_TimerHead1
        '
        Me.m_TimerHead1.Enabled = True
        '
        'm_TimerHead2
        '
        Me.m_TimerHead2.Enabled = True
        '
        'm_TimerHead3
        '
        Me.m_TimerHead3.Enabled = True
        '
        'm_TimerWatchDog
        '
        Me.m_TimerWatchDog.Interval = 2000
        '
        'chkConnected
        '
        Me.chkConnected.AutoSize = True
        Me.chkConnected.Enabled = False
        Me.chkConnected.Location = New System.Drawing.Point(513, 219)
        Me.chkConnected.Name = "chkConnected"
        Me.chkConnected.Size = New System.Drawing.Size(78, 17)
        Me.chkConnected.TabIndex = 76
        Me.chkConnected.Text = "Connected"
        Me.chkConnected.UseVisualStyleBackColor = True
        '
        'm_btnRemoveModule
        '
        Me.m_btnRemoveModule.Location = New System.Drawing.Point(27, 216)
        Me.m_btnRemoveModule.Name = "m_btnRemoveModule"
        Me.m_btnRemoveModule.Size = New System.Drawing.Size(144, 32)
        Me.m_btnRemoveModule.TabIndex = 77
        Me.m_btnRemoveModule.Text = "RemoveModule"
        Me.m_btnRemoveModule.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxVolumeMax)
        Me.GroupBox2.Controls.Add(Me.TextBoxVolumeMin)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.TextBoxVolumePressure)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.TextBoxTransfertTime)
        Me.GroupBox2.Controls.Add(Me.TextBoxFillTime)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.btnLearningRefVolume)
        Me.GroupBox2.Controls.Add(Me.btnLearningTestVolume)
        Me.GroupBox2.Controls.Add(Me.btnInfiniteDump)
        Me.GroupBox2.Location = New System.Drawing.Point(930, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 287)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ FC28L Special cycle ]"
        '
        'TextBoxVolumeMax
        '
        Me.TextBoxVolumeMax.Location = New System.Drawing.Point(123, 255)
        Me.TextBoxVolumeMax.Name = "TextBoxVolumeMax"
        Me.TextBoxVolumeMax.Size = New System.Drawing.Size(57, 21)
        Me.TextBoxVolumeMax.TabIndex = 83
        Me.TextBoxVolumeMax.Text = "10"
        '
        'TextBoxVolumeMin
        '
        Me.TextBoxVolumeMin.Location = New System.Drawing.Point(123, 228)
        Me.TextBoxVolumeMin.Name = "TextBoxVolumeMin"
        Me.TextBoxVolumeMin.Size = New System.Drawing.Size(57, 21)
        Me.TextBoxVolumeMin.TabIndex = 82
        Me.TextBoxVolumeMin.Text = "2"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 258)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(98, 13)
        Me.Label26.TabIndex = 81
        Me.Label26.Text = "Volume Max. (cm3)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 231)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(94, 13)
        Me.Label25.TabIndex = 80
        Me.Label25.Text = "Volume Min. (cm3)"
        '
        'TextBoxVolumePressure
        '
        Me.TextBoxVolumePressure.Location = New System.Drawing.Point(123, 201)
        Me.TextBoxVolumePressure.Name = "TextBoxVolumePressure"
        Me.TextBoxVolumePressure.Size = New System.Drawing.Size(57, 21)
        Me.TextBoxVolumePressure.TabIndex = 79
        Me.TextBoxVolumePressure.Text = "8.58"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 205)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 13)
        Me.Label24.TabIndex = 78
        Me.Label24.Text = "Volume pressure (cm3)"
        '
        'TextBoxTransfertTime
        '
        Me.TextBoxTransfertTime.Location = New System.Drawing.Point(123, 174)
        Me.TextBoxTransfertTime.Name = "TextBoxTransfertTime"
        Me.TextBoxTransfertTime.Size = New System.Drawing.Size(57, 21)
        Me.TextBoxTransfertTime.TabIndex = 77
        Me.TextBoxTransfertTime.Text = "2"
        '
        'TextBoxFillTime
        '
        Me.TextBoxFillTime.Location = New System.Drawing.Point(123, 147)
        Me.TextBoxFillTime.Name = "TextBoxFillTime"
        Me.TextBoxFillTime.Size = New System.Drawing.Size(57, 21)
        Me.TextBoxFillTime.TabIndex = 76
        Me.TextBoxFillTime.Text = "2"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 177)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 13)
        Me.Label23.TabIndex = 56
        Me.Label23.Text = "Transfert time (0.01s)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 150)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 55
        Me.Label22.Text = "Fill time (0.01s)"
        '
        'btnLearningRefVolume
        '
        Me.btnLearningRefVolume.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLearningRefVolume.Location = New System.Drawing.Point(6, 112)
        Me.btnLearningRefVolume.Name = "btnLearningRefVolume"
        Me.btnLearningRefVolume.Size = New System.Drawing.Size(125, 32)
        Me.btnLearningRefVolume.TabIndex = 54
        Me.btnLearningRefVolume.Text = "Learning Ref. Volume"
        Me.btnLearningRefVolume.UseVisualStyleBackColor = True
        '
        'btnLearningTestVolume
        '
        Me.btnLearningTestVolume.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLearningTestVolume.Location = New System.Drawing.Point(6, 67)
        Me.btnLearningTestVolume.Name = "btnLearningTestVolume"
        Me.btnLearningTestVolume.Size = New System.Drawing.Size(125, 32)
        Me.btnLearningTestVolume.TabIndex = 53
        Me.btnLearningTestVolume.Text = "Learning Test Volume"
        Me.btnLearningTestVolume.UseVisualStyleBackColor = True
        '
        'btnInfiniteDump
        '
        Me.btnInfiniteDump.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnInfiniteDump.Location = New System.Drawing.Point(6, 26)
        Me.btnInfiniteDump.Name = "btnInfiniteDump"
        Me.btnInfiniteDump.Size = New System.Drawing.Size(125, 32)
        Me.btnInfiniteDump.TabIndex = 52
        Me.btnInfiniteDump.Text = "Infinite Dump"
        Me.btnInfiniteDump.UseVisualStyleBackColor = True
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 806)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.m_btnRemoveModule)
        Me.Controls.Add(Me.chkConnected)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpBoxRegAdjust)
        Me.Controls.Add(Me.btnReadPara)
        Me.Controls.Add(Me.grpBoxCalibration)
        Me.Controls.Add(Me.btnReadLastResult)
        Me.Controls.Add(Me.labelIPAddr)
        Me.Controls.Add(Me.TextBoxIPAddr)
        Me.Controls.Add(Me.m_labelUnitOC)
        Me.Controls.Add(Me.m_labelUnit_hPa)
        Me.Controls.Add(Me.m_labelTemp)
        Me.Controls.Add(Me.m_labelPAbs)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.m_btnClearList)
        Me.Controls.Add(Me.m_btnClearFIFO)
        Me.Controls.Add(Me.m_chkReadFifo)
        Me.Controls.Add(Me.m_btnExit)
        Me.Controls.Add(Me.m_labelUnit2)
        Me.Controls.Add(Me.m_labelUnit1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.m_labelError)
        Me.Controls.Add(Me.m_labelReceive)
        Me.Controls.Add(Me.m_labelTransmit)
        Me.Controls.Add(Me.m_labelPhase)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.m_labelFifoCount)
        Me.Controls.Add(Me.m_labelDllVer)
        Me.Controls.Add(Me.m_labelMeasure2)
        Me.Controls.Add(Me.m_labelMeasure1)
        Me.Controls.Add(Me.btnFIFO)
        Me.Controls.Add(Me.btnStopGrp)
        Me.Controls.Add(Me.btnStartGrp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboGroup)
        Me.Controls.Add(Me.btnParameter)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboModules)
        Me.Controls.Add(Me.AddModule)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.m_ListBoxMsg)
        Me.Controls.Add(Me.CheckOpenClose)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeBox = False
        Me.Name = "mainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VBF28LightControlDemo (Ver : 2.018 04/11/19 for DLL >= 2.017)"
        Me.grpBoxCalibration.ResumeLayout(False)
        Me.grpBoxCalibration.PerformLayout()
        Me.grpBoxRegAdjust.ResumeLayout(False)
        Me.grpBoxRegAdjust.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckOpenClose As System.Windows.Forms.CheckBox
    Friend WithEvents m_ListBoxMsg As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AddModule As System.Windows.Forms.Button
    Friend WithEvents cboModules As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnParameter As System.Windows.Forms.Button
    Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnStopGrp As System.Windows.Forms.Button
    Friend WithEvents btnStartGrp As System.Windows.Forms.Button
    Friend WithEvents btnFIFO As System.Windows.Forms.Button
    Friend WithEvents m_TimerRealTime As System.Windows.Forms.Timer
    Friend WithEvents m_labelMeasure1 As System.Windows.Forms.Label
    Friend WithEvents m_labelMeasure2 As System.Windows.Forms.Label
    Friend WithEvents m_labelDllVer As System.Windows.Forms.Label
    Friend WithEvents m_labelFifoCount As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents m_labelPhase As System.Windows.Forms.Label
    Friend WithEvents m_labelTransmit As System.Windows.Forms.Label
    Friend WithEvents m_labelReceive As System.Windows.Forms.Label
    Friend WithEvents m_labelError As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents m_labelUnit1 As System.Windows.Forms.Label
    Friend WithEvents m_labelUnit2 As System.Windows.Forms.Label
    Friend WithEvents m_btnExit As System.Windows.Forms.Button
    Friend WithEvents m_chkReadFifo As System.Windows.Forms.CheckBox
    Friend WithEvents m_btnClearFIFO As System.Windows.Forms.Button
    Friend WithEvents m_btnClearList As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents m_labelUnitOC As System.Windows.Forms.Label
    Friend WithEvents m_labelUnit_hPa As System.Windows.Forms.Label
    Friend WithEvents m_labelTemp As System.Windows.Forms.Label
    Friend WithEvents m_labelPAbs As System.Windows.Forms.Label
    Friend WithEvents TextBoxIPAddr As System.Windows.Forms.TextBox
    Friend WithEvents labelIPAddr As System.Windows.Forms.Label
    Friend WithEvents btnAZPressure As System.Windows.Forms.Button
    Friend WithEvents textBoxAZDumpTime As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnReadLastResult As System.Windows.Forms.Button
    Friend WithEvents btnOffsetOnly As System.Windows.Forms.Button
    Friend WithEvents btnAutoVolume As System.Windows.Forms.Button
    Friend WithEvents textBoxIntercycle As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents textBoxCycleNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents grpBoxCalibration As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents textBoxPressureCal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents textBoxLeakCal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents textBoxOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents textBoxVolMinCal As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents textBoxVolMaxCal As System.Windows.Forms.TextBox
    Friend WithEvents btnStopAutoCal As System.Windows.Forms.Button
    Friend WithEvents btnReadPara As System.Windows.Forms.Button
    Friend WithEvents m_labelCal As System.Windows.Forms.Label
    Friend WithEvents grpBoxRegAdjust As System.Windows.Forms.GroupBox
    Friend WithEvents btnRegulatorAjust As System.Windows.Forms.Button
    Friend WithEvents textBoxIPHead1 As System.Windows.Forms.TextBox
    Friend WithEvents btnAddMod1 As System.Windows.Forms.Button
    Friend WithEvents textBoxIPHead2 As System.Windows.Forms.TextBox
    Friend WithEvents btnAddMod2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOffset2 As System.Windows.Forms.Button
    Friend WithEvents btnStart2 As System.Windows.Forms.Button
    Friend WithEvents m_listBox2Heads As System.Windows.Forms.ListBox
    Friend WithEvents LabelMod3 As System.Windows.Forms.Label
    Friend WithEvents LabelMod2 As System.Windows.Forms.Label
    Friend WithEvents btnAddMod3 As System.Windows.Forms.Button
    Friend WithEvents textBoxIPHead3 As System.Windows.Forms.TextBox
    Friend WithEvents labelMod1 As System.Windows.Forms.Label
    Friend WithEvents m_TimerHead1 As System.Windows.Forms.Timer
    Friend WithEvents m_TimerHead2 As System.Windows.Forms.Timer
    Friend WithEvents m_TimerHead3 As System.Windows.Forms.Timer
    Friend WithEvents m_TimerWatchDog As System.Windows.Forms.Timer
    Friend WithEvents chkConnected As System.Windows.Forms.CheckBox
    Friend WithEvents chkConnect3 As System.Windows.Forms.CheckBox
    Friend WithEvents labelErr_3 As System.Windows.Forms.Label
    Friend WithEvents labelRec_3 As System.Windows.Forms.Label
    Friend WithEvents labelTr_3 As System.Windows.Forms.Label
    Friend WithEvents chkConnect2 As System.Windows.Forms.CheckBox
    Friend WithEvents labelErr_2 As System.Windows.Forms.Label
    Friend WithEvents labelRec_2 As System.Windows.Forms.Label
    Friend WithEvents labelTr_2 As System.Windows.Forms.Label
    Friend WithEvents chkConnect1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents labelErr_1 As System.Windows.Forms.Label
    Friend WithEvents labelRec_1 As System.Windows.Forms.Label
    Friend WithEvents labelTr_1 As System.Windows.Forms.Label
    Friend WithEvents btnElecRegLearn As System.Windows.Forms.Button
    Friend WithEvents m_btnRemoveModule As System.Windows.Forms.Button
    Friend WithEvents btnJetCheck As System.Windows.Forms.Button
    Friend WithEvents btnStartAutoRatio As System.Windows.Forms.Button
    Friend WithEvents btnAutoRatio3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnInfiniteDump As System.Windows.Forms.Button
    Friend WithEvents btnLearningRefVolume As System.Windows.Forms.Button
    Friend WithEvents btnLearningTestVolume As System.Windows.Forms.Button
    Friend WithEvents TextBoxVolumeMax As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxVolumeMin As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextBoxVolumePressure As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTransfertTime As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFillTime As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnStartEasyAutoLearning As System.Windows.Forms.Button
    Friend WithEvents btnEasyAutoLearning3 As System.Windows.Forms.Button

End Class
