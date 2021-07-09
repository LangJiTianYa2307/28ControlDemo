namespace VCSharpF28LightControlDemo
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDLLVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxModuleID = new System.Windows.Forms.TextBox();
            this.checkBoxOpenClose = new System.Windows.Forms.CheckBox();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAddressIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.Pressure = new System.Windows.Forms.Label();
            this.timerRealTime = new System.Windows.Forms.Timer(this.components);
            this.PressureUnit = new System.Windows.Forms.Label();
            this.Leak = new System.Windows.Forms.Label();
            this.LeakUnit = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.PAtm = new System.Windows.Forms.Label();
            this.PAtmUnit = new System.Windows.Forms.Label();
            this.Temperature = new System.Windows.Forms.Label();
            this.TemperatureUnit = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxResultCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAZDumpTime = new System.Windows.Forms.TextBox();
            this.buttonAutoZero = new System.Windows.Forms.Button();
            this.buttonReadFifo = new System.Windows.Forms.Button();
            this.buttonClearFifo = new System.Windows.Forms.Button();
            this.buttonParameters = new System.Windows.Forms.Button();
            this.buttonLastResult = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonResetGroup = new System.Windows.Forms.Button();
            this.buttonStartGroup = new System.Windows.Forms.Button();
            this.buttonAddModule = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelTransmit = new System.Windows.Forms.Label();
            this.labelReceive = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.timerCounters = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonJetCheck = new System.Windows.Forms.Button();
            this.buttonElecRegLearn = new System.Windows.Forms.Button();
            this.buttonRegAdjust = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpBoxCalibration = new System.Windows.Forms.GroupBox();
            this.btnEasyAutoLearning = new System.Windows.Forms.Button();
            this.btnAutoRatio = new System.Windows.Forms.Button();
            this.m_labelCal = new System.Windows.Forms.Label();
            this.btnStopAutoCal = new System.Windows.Forms.Button();
            this.Label19 = new System.Windows.Forms.Label();
            this.textBoxVolMaxCal = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.textBoxOffset = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.textBoxVolMinCal = new System.Windows.Forms.TextBox();
            this.btnOffsetOnly = new System.Windows.Forms.Button();
            this.Label15 = new System.Windows.Forms.Label();
            this.textBoxPressureCal = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.textBoxLeakCal = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.textBoxCycleNumber = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.textBoxIntercycle = new System.Windows.Forms.TextBox();
            this.btnAutoVolume = new System.Windows.Forms.Button();
            this.buttonReadParameters = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.btnClearListbox = new System.Windows.Forms.Button();
            this.groupBox2Heads = new System.Windows.Forms.GroupBox();
            this.btnStartEasyAuto2Heads = new System.Windows.Forms.Button();
            this.btnStartAutoRatio2Heads = new System.Windows.Forms.Button();
            this.chkConnected2 = new System.Windows.Forms.CheckBox();
            this.chkConnected1 = new System.Windows.Forms.CheckBox();
            this.label1E = new System.Windows.Forms.Label();
            this.label1R = new System.Windows.Forms.Label();
            this.label1T = new System.Windows.Forms.Label();
            this.label2E = new System.Windows.Forms.Label();
            this.labelStateHead2 = new System.Windows.Forms.Label();
            this.labelStateHead1 = new System.Windows.Forms.Label();
            this.btnStartOffset2Heads = new System.Windows.Forms.Button();
            this.label2R = new System.Windows.Forms.Label();
            this.btnStart2Heads = new System.Windows.Forms.Button();
            this.label2T = new System.Windows.Forms.Label();
            this.listBox2Heads = new System.Windows.Forms.ListBox();
            this.btnHead2 = new System.Windows.Forms.Button();
            this.textBoxIPHead2 = new System.Windows.Forms.TextBox();
            this.btnHead1 = new System.Windows.Forms.Button();
            this.textBoxIPHead1 = new System.Windows.Forms.TextBox();
            this.timerHead1 = new System.Windows.Forms.Timer(this.components);
            this.timerHead2 = new System.Windows.Forms.Timer(this.components);
            this.chkConnected = new System.Windows.Forms.CheckBox();
            this.btnRemoveModule = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBoxCalibration.SuspendLayout();
            this.groupBox2Heads.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "DLL Version";
            // 
            // textBoxDLLVersion
            // 
            this.textBoxDLLVersion.Location = new System.Drawing.Point(104, 5);
            this.textBoxDLLVersion.Name = "textBoxDLLVersion";
            this.textBoxDLLVersion.ReadOnly = true;
            this.textBoxDLLVersion.Size = new System.Drawing.Size(55, 21);
            this.textBoxDLLVersion.TabIndex = 1;
            this.textBoxDLLVersion.TabStop = false;
            this.textBoxDLLVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Module ID";
            // 
            // textBoxModuleID
            // 
            this.textBoxModuleID.Location = new System.Drawing.Point(246, 5);
            this.textBoxModuleID.Name = "textBoxModuleID";
            this.textBoxModuleID.ReadOnly = true;
            this.textBoxModuleID.Size = new System.Drawing.Size(55, 21);
            this.textBoxModuleID.TabIndex = 3;
            this.textBoxModuleID.TabStop = false;
            this.textBoxModuleID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxOpenClose
            // 
            this.checkBoxOpenClose.AutoSize = true;
            this.checkBoxOpenClose.Location = new System.Drawing.Point(25, 54);
            this.checkBoxOpenClose.Name = "checkBoxOpenClose";
            this.checkBoxOpenClose.Size = new System.Drawing.Size(108, 16);
            this.checkBoxOpenClose.TabIndex = 4;
            this.checkBoxOpenClose.Text = "(1) Open/Close";
            this.checkBoxOpenClose.UseVisualStyleBackColor = true;
            this.checkBoxOpenClose.CheckedChanged += new System.EventHandler(this.checkBoxOpenClose_CheckedChanged);
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMessage.ForeColor = System.Drawing.Color.MediumBlue;
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 16;
            this.listBoxMessage.Location = new System.Drawing.Point(12, 450);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(1041, 148);
            this.listBoxMessage.TabIndex = 5;
            this.listBoxMessage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(25, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP Address";
            // 
            // textBoxAddressIP
            // 
            this.textBoxAddressIP.Location = new System.Drawing.Point(25, 95);
            this.textBoxAddressIP.MaxLength = 15;
            this.textBoxAddressIP.Name = "textBoxAddressIP";
            this.textBoxAddressIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxAddressIP.TabIndex = 7;
            this.textBoxAddressIP.Text = "192.168.1.67";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "(Group 1, Module 1)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Group #";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBoxGroup.Location = new System.Drawing.Point(98, 16);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(50, 20);
            this.comboBoxGroup.TabIndex = 11;
            // 
            // Pressure
            // 
            this.Pressure.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pressure.Location = new System.Drawing.Point(347, 5);
            this.Pressure.Name = "Pressure";
            this.Pressure.Size = new System.Drawing.Size(110, 30);
            this.Pressure.TabIndex = 16;
            this.Pressure.Text = "--------";
            this.Pressure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerRealTime
            // 
            this.timerRealTime.Interval = 200;
            this.timerRealTime.Tick += new System.EventHandler(this.timerRealTime_Tick);
            // 
            // PressureUnit
            // 
            this.PressureUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PressureUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PressureUnit.Location = new System.Drawing.Point(463, 5);
            this.PressureUnit.Name = "PressureUnit";
            this.PressureUnit.Size = new System.Drawing.Size(96, 30);
            this.PressureUnit.TabIndex = 17;
            this.PressureUnit.Text = "--------";
            this.PressureUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Leak
            // 
            this.Leak.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Leak.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Leak.Location = new System.Drawing.Point(581, 5);
            this.Leak.Name = "Leak";
            this.Leak.Size = new System.Drawing.Size(123, 30);
            this.Leak.TabIndex = 18;
            this.Leak.Text = "--------";
            this.Leak.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LeakUnit
            // 
            this.LeakUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LeakUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeakUnit.Location = new System.Drawing.Point(710, 5);
            this.LeakUnit.Name = "LeakUnit";
            this.LeakUnit.Size = new System.Drawing.Size(96, 30);
            this.LeakUnit.TabIndex = 19;
            this.LeakUnit.Text = "--------";
            this.LeakUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Status
            // 
            this.Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(347, 42);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(459, 30);
            this.Status.TabIndex = 20;
            this.Status.Text = "--------";
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PAtm
            // 
            this.PAtm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PAtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAtm.Location = new System.Drawing.Point(347, 77);
            this.PAtm.Name = "PAtm";
            this.PAtm.Size = new System.Drawing.Size(110, 30);
            this.PAtm.TabIndex = 21;
            this.PAtm.Text = "--------";
            this.PAtm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PAtmUnit
            // 
            this.PAtmUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PAtmUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAtmUnit.Location = new System.Drawing.Point(463, 77);
            this.PAtmUnit.Name = "PAtmUnit";
            this.PAtmUnit.Size = new System.Drawing.Size(96, 30);
            this.PAtmUnit.TabIndex = 22;
            this.PAtmUnit.Text = "hPa";
            this.PAtmUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Temperature
            // 
            this.Temperature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temperature.Location = new System.Drawing.Point(581, 77);
            this.Temperature.Name = "Temperature";
            this.Temperature.Size = new System.Drawing.Size(123, 30);
            this.Temperature.TabIndex = 23;
            this.Temperature.Text = "--------";
            this.Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TemperatureUnit
            // 
            this.TemperatureUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TemperatureUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureUnit.Location = new System.Drawing.Point(710, 77);
            this.TemperatureUnit.Name = "TemperatureUnit";
            this.TemperatureUnit.Size = new System.Drawing.Size(96, 30);
            this.TemperatureUnit.TabIndex = 24;
            this.TemperatureUnit.Text = "°C";
            this.TemperatureUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "Result count";
            // 
            // textBoxResultCount
            // 
            this.textBoxResultCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResultCount.Location = new System.Drawing.Point(254, 217);
            this.textBoxResultCount.Name = "textBoxResultCount";
            this.textBoxResultCount.ReadOnly = true;
            this.textBoxResultCount.Size = new System.Drawing.Size(47, 22);
            this.textBoxResultCount.TabIndex = 30;
            this.textBoxResultCount.TabStop = false;
            this.textBoxResultCount.Text = "0";
            this.textBoxResultCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "Auto-zero Dump time (s)";
            // 
            // textBoxAZDumpTime
            // 
            this.textBoxAZDumpTime.Location = new System.Drawing.Point(63, 33);
            this.textBoxAZDumpTime.Name = "textBoxAZDumpTime";
            this.textBoxAZDumpTime.Size = new System.Drawing.Size(65, 21);
            this.textBoxAZDumpTime.TabIndex = 32;
            // 
            // buttonAutoZero
            // 
            this.buttonAutoZero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAutoZero.Image = global::VCSharpF28LightControlDemo.Properties.Resources.AutoZero;
            this.buttonAutoZero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAutoZero.Location = new System.Drawing.Point(213, 16);
            this.buttonAutoZero.Name = "buttonAutoZero";
            this.buttonAutoZero.Size = new System.Drawing.Size(145, 36);
            this.buttonAutoZero.TabIndex = 33;
            this.buttonAutoZero.Text = "Auto-Zero";
            this.buttonAutoZero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAutoZero.UseVisualStyleBackColor = true;
            this.buttonAutoZero.Click += new System.EventHandler(this.buttonAutoZero_Click);
            // 
            // buttonReadFifo
            // 
            this.buttonReadFifo.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Extraire;
            this.buttonReadFifo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReadFifo.Location = new System.Drawing.Point(184, 162);
            this.buttonReadFifo.Name = "buttonReadFifo";
            this.buttonReadFifo.Size = new System.Drawing.Size(117, 36);
            this.buttonReadFifo.TabIndex = 28;
            this.buttonReadFifo.Text = "Read FIFO    ";
            this.buttonReadFifo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReadFifo.UseVisualStyleBackColor = true;
            this.buttonReadFifo.Click += new System.EventHandler(this.buttonReadFifo_Click);
            // 
            // buttonClearFifo
            // 
            this.buttonClearFifo.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Effacer;
            this.buttonClearFifo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearFifo.Location = new System.Drawing.Point(184, 120);
            this.buttonClearFifo.Name = "buttonClearFifo";
            this.buttonClearFifo.Size = new System.Drawing.Size(117, 36);
            this.buttonClearFifo.TabIndex = 27;
            this.buttonClearFifo.Text = "Clear FIFO    ";
            this.buttonClearFifo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonClearFifo.UseVisualStyleBackColor = true;
            this.buttonClearFifo.Click += new System.EventHandler(this.buttonClearFifo_Click);
            // 
            // buttonParameters
            // 
            this.buttonParameters.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Parameters;
            this.buttonParameters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonParameters.Location = new System.Drawing.Point(184, 35);
            this.buttonParameters.Name = "buttonParameters";
            this.buttonParameters.Size = new System.Drawing.Size(117, 36);
            this.buttonParameters.TabIndex = 26;
            this.buttonParameters.Text = "(3) Parameters";
            this.buttonParameters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonParameters.UseVisualStyleBackColor = true;
            this.buttonParameters.Click += new System.EventHandler(this.buttonParameters_Click);
            // 
            // buttonLastResult
            // 
            this.buttonLastResult.Image = global::VCSharpF28LightControlDemo.Properties.Resources.LastResult;
            this.buttonLastResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLastResult.Location = new System.Drawing.Point(346, 205);
            this.buttonLastResult.Name = "buttonLastResult";
            this.buttonLastResult.Size = new System.Drawing.Size(127, 36);
            this.buttonLastResult.TabIndex = 25;
            this.buttonLastResult.Text = "Read Last Result";
            this.buttonLastResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLastResult.UseVisualStyleBackColor = true;
            this.buttonLastResult.Click += new System.EventHandler(this.buttonLastResult_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Reset;
            this.buttonReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReset.Location = new System.Drawing.Point(347, 162);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(127, 36);
            this.buttonReset.TabIndex = 15;
            this.buttonReset.Text = "Abort Cycle";
            this.buttonReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Start;
            this.buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStart.Location = new System.Drawing.Point(346, 120);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(127, 36);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Start  Cycle    ";
            this.buttonStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonResetGroup
            // 
            this.buttonResetGroup.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Reset;
            this.buttonResetGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonResetGroup.Location = new System.Drawing.Point(49, 81);
            this.buttonResetGroup.Name = "buttonResetGroup";
            this.buttonResetGroup.Size = new System.Drawing.Size(145, 36);
            this.buttonResetGroup.TabIndex = 13;
            this.buttonResetGroup.Text = "Abort Group";
            this.buttonResetGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonResetGroup.UseVisualStyleBackColor = true;
            this.buttonResetGroup.Click += new System.EventHandler(this.buttonResetGroup_Click);
            // 
            // buttonStartGroup
            // 
            this.buttonStartGroup.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Start;
            this.buttonStartGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStartGroup.Location = new System.Drawing.Point(49, 40);
            this.buttonStartGroup.Name = "buttonStartGroup";
            this.buttonStartGroup.Size = new System.Drawing.Size(145, 36);
            this.buttonStartGroup.TabIndex = 12;
            this.buttonStartGroup.Text = "Start Group";
            this.buttonStartGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStartGroup.UseVisualStyleBackColor = true;
            this.buttonStartGroup.Click += new System.EventHandler(this.buttonStartGroup_Click);
            // 
            // buttonAddModule
            // 
            this.buttonAddModule.Image = global::VCSharpF28LightControlDemo.Properties.Resources.AddModule;
            this.buttonAddModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddModule.Location = new System.Drawing.Point(25, 119);
            this.buttonAddModule.Name = "buttonAddModule";
            this.buttonAddModule.Size = new System.Drawing.Size(124, 36);
            this.buttonAddModule.TabIndex = 8;
            this.buttonAddModule.Text = "(2) Add Module";
            this.buttonAddModule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAddModule.UseVisualStyleBackColor = true;
            this.buttonAddModule.Click += new System.EventHandler(this.buttonAddModule_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(488, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "Transmit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(488, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "Receive";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(506, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "Error";
            // 
            // labelTransmit
            // 
            this.labelTransmit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTransmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransmit.Location = new System.Drawing.Point(541, 121);
            this.labelTransmit.Name = "labelTransmit";
            this.labelTransmit.Size = new System.Drawing.Size(100, 21);
            this.labelTransmit.TabIndex = 37;
            this.labelTransmit.Text = "0";
            this.labelTransmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelReceive
            // 
            this.labelReceive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceive.Location = new System.Drawing.Point(541, 150);
            this.labelReceive.Name = "labelReceive";
            this.labelReceive.Size = new System.Drawing.Size(100, 21);
            this.labelReceive.TabIndex = 38;
            this.labelReceive.Text = "0";
            this.labelReceive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelError
            // 
            this.labelError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.Location = new System.Drawing.Point(541, 179);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(100, 21);
            this.labelError.TabIndex = 39;
            this.labelError.Text = "0";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerCounters
            // 
            this.timerCounters.Interval = 500;
            this.timerCounters.Tick += new System.EventHandler(this.timerCounters_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonJetCheck);
            this.groupBox1.Controls.Add(this.buttonElecRegLearn);
            this.groupBox1.Controls.Add(this.buttonRegAdjust);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxAZDumpTime);
            this.groupBox1.Controls.Add(this.buttonAutoZero);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(662, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 154);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Special Cycles ]";
            // 
            // buttonJetCheck
            // 
            this.buttonJetCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonJetCheck.Image = global::VCSharpF28LightControlDemo.Properties.Resources.AutoZero;
            this.buttonJetCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonJetCheck.Location = new System.Drawing.Point(215, 113);
            this.buttonJetCheck.Name = "buttonJetCheck";
            this.buttonJetCheck.Size = new System.Drawing.Size(145, 36);
            this.buttonJetCheck.TabIndex = 36;
            this.buttonJetCheck.Text = "Jet check";
            this.buttonJetCheck.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonJetCheck.UseVisualStyleBackColor = true;
            this.buttonJetCheck.Click += new System.EventHandler(this.buttonJetCheck_Click);
            // 
            // buttonElecRegLearn
            // 
            this.buttonElecRegLearn.ForeColor = System.Drawing.Color.Blue;
            this.buttonElecRegLearn.Image = global::VCSharpF28LightControlDemo.Properties.Resources.AutoZero;
            this.buttonElecRegLearn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonElecRegLearn.Location = new System.Drawing.Point(29, 63);
            this.buttonElecRegLearn.Name = "buttonElecRegLearn";
            this.buttonElecRegLearn.Size = new System.Drawing.Size(145, 36);
            this.buttonElecRegLearn.TabIndex = 35;
            this.buttonElecRegLearn.Text = "Elec. Reg. Learn";
            this.buttonElecRegLearn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonElecRegLearn.UseVisualStyleBackColor = true;
            this.buttonElecRegLearn.Click += new System.EventHandler(this.buttonElecRegLearn_Click);
            // 
            // buttonRegAdjust
            // 
            this.buttonRegAdjust.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRegAdjust.Image = global::VCSharpF28LightControlDemo.Properties.Resources.AutoZero;
            this.buttonRegAdjust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRegAdjust.Location = new System.Drawing.Point(213, 63);
            this.buttonRegAdjust.Name = "buttonRegAdjust";
            this.buttonRegAdjust.Size = new System.Drawing.Size(145, 36);
            this.buttonRegAdjust.TabIndex = 34;
            this.buttonRegAdjust.Text = "Regulator Adjust";
            this.buttonRegAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRegAdjust.UseVisualStyleBackColor = true;
            this.buttonRegAdjust.Click += new System.EventHandler(this.buttonRegAdjust_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxGroup);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonStartGroup);
            this.groupBox2.Controls.Add(this.buttonResetGroup);
            this.groupBox2.Location = new System.Drawing.Point(828, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 126);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ Group Functions ]";
            // 
            // grpBoxCalibration
            // 
            this.grpBoxCalibration.Controls.Add(this.btnEasyAutoLearning);
            this.grpBoxCalibration.Controls.Add(this.btnAutoRatio);
            this.grpBoxCalibration.Controls.Add(this.m_labelCal);
            this.grpBoxCalibration.Controls.Add(this.btnStopAutoCal);
            this.grpBoxCalibration.Controls.Add(this.Label19);
            this.grpBoxCalibration.Controls.Add(this.textBoxVolMaxCal);
            this.grpBoxCalibration.Controls.Add(this.Label18);
            this.grpBoxCalibration.Controls.Add(this.textBoxOffset);
            this.grpBoxCalibration.Controls.Add(this.Label16);
            this.grpBoxCalibration.Controls.Add(this.textBoxVolMinCal);
            this.grpBoxCalibration.Controls.Add(this.btnOffsetOnly);
            this.grpBoxCalibration.Controls.Add(this.Label15);
            this.grpBoxCalibration.Controls.Add(this.textBoxPressureCal);
            this.grpBoxCalibration.Controls.Add(this.Label14);
            this.grpBoxCalibration.Controls.Add(this.textBoxLeakCal);
            this.grpBoxCalibration.Controls.Add(this.Label12);
            this.grpBoxCalibration.Controls.Add(this.textBoxCycleNumber);
            this.grpBoxCalibration.Controls.Add(this.Label13);
            this.grpBoxCalibration.Controls.Add(this.textBoxIntercycle);
            this.grpBoxCalibration.Controls.Add(this.btnAutoVolume);
            this.grpBoxCalibration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpBoxCalibration.Location = new System.Drawing.Point(12, 282);
            this.grpBoxCalibration.Name = "grpBoxCalibration";
            this.grpBoxCalibration.Size = new System.Drawing.Size(1041, 162);
            this.grpBoxCalibration.TabIndex = 52;
            this.grpBoxCalibration.TabStop = false;
            this.grpBoxCalibration.Text = "[ Offset + Volume Calibration  + Auto-Ratio + Easy auto learning] ";
            // 
            // btnEasyAutoLearning
            // 
            this.btnEasyAutoLearning.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Start;
            this.btnEasyAutoLearning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEasyAutoLearning.Location = new System.Drawing.Point(865, 65);
            this.btnEasyAutoLearning.Name = "btnEasyAutoLearning";
            this.btnEasyAutoLearning.Size = new System.Drawing.Size(145, 35);
            this.btnEasyAutoLearning.TabIndex = 76;
            this.btnEasyAutoLearning.Text = "Easy Auto Learning";
            this.btnEasyAutoLearning.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEasyAutoLearning.UseVisualStyleBackColor = true;
            this.btnEasyAutoLearning.Click += new System.EventHandler(this.btnEasyAutoLearning_Click);
            // 
            // btnAutoRatio
            // 
            this.btnAutoRatio.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Start;
            this.btnAutoRatio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoRatio.Location = new System.Drawing.Point(865, 17);
            this.btnAutoRatio.Name = "btnAutoRatio";
            this.btnAutoRatio.Size = new System.Drawing.Size(145, 35);
            this.btnAutoRatio.TabIndex = 75;
            this.btnAutoRatio.Text = "Auto-Ratio";
            this.btnAutoRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAutoRatio.UseVisualStyleBackColor = true;
            this.btnAutoRatio.Click += new System.EventHandler(this.btnAutoRatio_Click);
            // 
            // m_labelCal
            // 
            this.m_labelCal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelCal.Location = new System.Drawing.Point(244, 66);
            this.m_labelCal.Name = "m_labelCal";
            this.m_labelCal.Size = new System.Drawing.Size(606, 31);
            this.m_labelCal.TabIndex = 70;
            this.m_labelCal.Text = "------";
            this.m_labelCal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStopAutoCal
            // 
            this.btnStopAutoCal.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Reset;
            this.btnStopAutoCal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopAutoCal.Location = new System.Drawing.Point(863, 117);
            this.btnStopAutoCal.Name = "btnStopAutoCal";
            this.btnStopAutoCal.Size = new System.Drawing.Size(145, 35);
            this.btnStopAutoCal.TabIndex = 67;
            this.btnStopAutoCal.Text = "Abort";
            this.btnStopAutoCal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopAutoCal.UseVisualStyleBackColor = true;
            this.btnStopAutoCal.Click += new System.EventHandler(this.btnStopAutoCal_Click);
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(264, 113);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(101, 12);
            this.Label19.TabIndex = 69;
            this.Label19.Text = "Volume max (cm3)";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxVolMaxCal
            // 
            this.textBoxVolMaxCal.Location = new System.Drawing.Point(362, 106);
            this.textBoxVolMaxCal.Name = "textBoxVolMaxCal";
            this.textBoxVolMaxCal.Size = new System.Drawing.Size(57, 21);
            this.textBoxVolMaxCal.TabIndex = 68;
            this.textBoxVolMaxCal.Text = "45";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(361, 18);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(107, 12);
            this.Label18.TabIndex = 67;
            this.Label18.Text = "Offset Max (sccm)";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxOffset
            // 
            this.textBoxOffset.Location = new System.Drawing.Point(359, 33);
            this.textBoxOffset.Name = "textBoxOffset";
            this.textBoxOffset.Size = new System.Drawing.Size(57, 21);
            this.textBoxOffset.TabIndex = 66;
            this.textBoxOffset.Text = "1";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(57, 114);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(101, 12);
            this.Label16.TabIndex = 63;
            this.Label16.Text = "Volume min (cm3)";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxVolMinCal
            // 
            this.textBoxVolMinCal.Location = new System.Drawing.Point(162, 108);
            this.textBoxVolMinCal.Name = "textBoxVolMinCal";
            this.textBoxVolMinCal.Size = new System.Drawing.Size(57, 21);
            this.textBoxVolMinCal.TabIndex = 62;
            this.textBoxVolMinCal.Text = "0";
            // 
            // btnOffsetOnly
            // 
            this.btnOffsetOnly.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Start;
            this.btnOffsetOnly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOffsetOnly.Location = new System.Drawing.Point(494, 17);
            this.btnOffsetOnly.Name = "btnOffsetOnly";
            this.btnOffsetOnly.Size = new System.Drawing.Size(145, 35);
            this.btnOffsetOnly.TabIndex = 48;
            this.btnOffsetOnly.Text = "Auto Offset Only";
            this.btnOffsetOnly.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOffsetOnly.UseVisualStyleBackColor = true;
            this.btnOffsetOnly.Click += new System.EventHandler(this.btnOffsetOnly_Click);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(24, 90);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(161, 12);
            this.Label15.TabIndex = 61;
            this.Label15.Text = "Calibration pressure (bar)";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPressureCal
            // 
            this.textBoxPressureCal.Location = new System.Drawing.Point(162, 83);
            this.textBoxPressureCal.Name = "textBoxPressureCal";
            this.textBoxPressureCal.Size = new System.Drawing.Size(57, 21);
            this.textBoxPressureCal.TabIndex = 60;
            this.textBoxPressureCal.Text = "1";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(34, 65);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(143, 12);
            this.Label14.TabIndex = 59;
            this.Label14.Text = "Calibration leak (sccm)";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxLeakCal
            // 
            this.textBoxLeakCal.Location = new System.Drawing.Point(162, 58);
            this.textBoxLeakCal.Name = "textBoxLeakCal";
            this.textBoxLeakCal.Size = new System.Drawing.Size(57, 21);
            this.textBoxLeakCal.TabIndex = 58;
            this.textBoxLeakCal.Text = "0";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(162, 18);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(77, 12);
            this.Label12.TabIndex = 57;
            this.Label12.Text = "Cycle number";
            // 
            // textBoxCycleNumber
            // 
            this.textBoxCycleNumber.Location = new System.Drawing.Point(162, 33);
            this.textBoxCycleNumber.Name = "textBoxCycleNumber";
            this.textBoxCycleNumber.Size = new System.Drawing.Size(57, 21);
            this.textBoxCycleNumber.TabIndex = 56;
            this.textBoxCycleNumber.Text = "2";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(241, 18);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(113, 12);
            this.Label13.TabIndex = 55;
            this.Label13.Text = "Intercycle (0.01s)";
            // 
            // textBoxIntercycle
            // 
            this.textBoxIntercycle.Location = new System.Drawing.Point(241, 33);
            this.textBoxIntercycle.Name = "textBoxIntercycle";
            this.textBoxIntercycle.Size = new System.Drawing.Size(57, 21);
            this.textBoxIntercycle.TabIndex = 54;
            this.textBoxIntercycle.Text = "300";
            // 
            // btnAutoVolume
            // 
            this.btnAutoVolume.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Start;
            this.btnAutoVolume.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoVolume.Location = new System.Drawing.Point(679, 17);
            this.btnAutoVolume.Name = "btnAutoVolume";
            this.btnAutoVolume.Size = new System.Drawing.Size(145, 35);
            this.btnAutoVolume.TabIndex = 53;
            this.btnAutoVolume.Text = "Auto Offset + Volume";
            this.btnAutoVolume.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAutoVolume.UseVisualStyleBackColor = true;
            this.btnAutoVolume.Click += new System.EventHandler(this.btnAutoVolume_Click);
            // 
            // buttonReadParameters
            // 
            this.buttonReadParameters.Location = new System.Drawing.Point(184, 78);
            this.buttonReadParameters.Name = "buttonReadParameters";
            this.buttonReadParameters.Size = new System.Drawing.Size(117, 36);
            this.buttonReadParameters.TabIndex = 53;
            this.buttonReadParameters.Text = "Read Parameters";
            this.buttonReadParameters.UseVisualStyleBackColor = true;
            this.buttonReadParameters.Click += new System.EventHandler(this.buttonReadParameters_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Annuler;
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(906, 687);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(145, 35);
            this.buttonExit.TabIndex = 54;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // btnClearListbox
            // 
            this.btnClearListbox.Location = new System.Drawing.Point(906, 629);
            this.btnClearListbox.Name = "btnClearListbox";
            this.btnClearListbox.Size = new System.Drawing.Size(145, 35);
            this.btnClearListbox.TabIndex = 55;
            this.btnClearListbox.Text = "Clear list";
            this.btnClearListbox.UseVisualStyleBackColor = true;
            this.btnClearListbox.Click += new System.EventHandler(this.btnClearListbox_Click);
            // 
            // groupBox2Heads
            // 
            this.groupBox2Heads.Controls.Add(this.btnStartEasyAuto2Heads);
            this.groupBox2Heads.Controls.Add(this.btnStartAutoRatio2Heads);
            this.groupBox2Heads.Controls.Add(this.chkConnected2);
            this.groupBox2Heads.Controls.Add(this.chkConnected1);
            this.groupBox2Heads.Controls.Add(this.label1E);
            this.groupBox2Heads.Controls.Add(this.label1R);
            this.groupBox2Heads.Controls.Add(this.label1T);
            this.groupBox2Heads.Controls.Add(this.label2E);
            this.groupBox2Heads.Controls.Add(this.labelStateHead2);
            this.groupBox2Heads.Controls.Add(this.labelStateHead1);
            this.groupBox2Heads.Controls.Add(this.btnStartOffset2Heads);
            this.groupBox2Heads.Controls.Add(this.label2R);
            this.groupBox2Heads.Controls.Add(this.btnStart2Heads);
            this.groupBox2Heads.Controls.Add(this.label2T);
            this.groupBox2Heads.Controls.Add(this.listBox2Heads);
            this.groupBox2Heads.Controls.Add(this.btnHead2);
            this.groupBox2Heads.Controls.Add(this.textBoxIPHead2);
            this.groupBox2Heads.Controls.Add(this.btnHead1);
            this.groupBox2Heads.Controls.Add(this.textBoxIPHead1);
            this.groupBox2Heads.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2Heads.Location = new System.Drawing.Point(12, 611);
            this.groupBox2Heads.Name = "groupBox2Heads";
            this.groupBox2Heads.Size = new System.Drawing.Size(888, 126);
            this.groupBox2Heads.TabIndex = 56;
            this.groupBox2Heads.TabStop = false;
            this.groupBox2Heads.Text = "[ Example : Start / Start Offset for 2 Heads Network ]";
            // 
            // btnStartEasyAuto2Heads
            // 
            this.btnStartEasyAuto2Heads.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartEasyAuto2Heads.Location = new System.Drawing.Point(713, 84);
            this.btnStartEasyAuto2Heads.Name = "btnStartEasyAuto2Heads";
            this.btnStartEasyAuto2Heads.Size = new System.Drawing.Size(93, 36);
            this.btnStartEasyAuto2Heads.TabIndex = 80;
            this.btnStartEasyAuto2Heads.Text = "Start Easy Auto Learning #1, #2";
            this.btnStartEasyAuto2Heads.UseVisualStyleBackColor = true;
            this.btnStartEasyAuto2Heads.Click += new System.EventHandler(this.btnStartEasyAuto2Heads_Click);
            // 
            // btnStartAutoRatio2Heads
            // 
            this.btnStartAutoRatio2Heads.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartAutoRatio2Heads.Location = new System.Drawing.Point(713, 43);
            this.btnStartAutoRatio2Heads.Name = "btnStartAutoRatio2Heads";
            this.btnStartAutoRatio2Heads.Size = new System.Drawing.Size(93, 36);
            this.btnStartAutoRatio2Heads.TabIndex = 79;
            this.btnStartAutoRatio2Heads.Text = "Start Auto-Ratio #1, #2";
            this.btnStartAutoRatio2Heads.UseVisualStyleBackColor = true;
            this.btnStartAutoRatio2Heads.Click += new System.EventHandler(this.btnStartAutoRatio2Heads_Click);
            // 
            // chkConnected2
            // 
            this.chkConnected2.AutoSize = true;
            this.chkConnected2.Enabled = false;
            this.chkConnected2.Location = new System.Drawing.Point(150, 98);
            this.chkConnected2.Name = "chkConnected2";
            this.chkConnected2.Size = new System.Drawing.Size(96, 16);
            this.chkConnected2.TabIndex = 78;
            this.chkConnected2.Text = "Connected #2";
            this.chkConnected2.UseVisualStyleBackColor = true;
            // 
            // chkConnected1
            // 
            this.chkConnected1.AutoSize = true;
            this.chkConnected1.Enabled = false;
            this.chkConnected1.Location = new System.Drawing.Point(13, 100);
            this.chkConnected1.Name = "chkConnected1";
            this.chkConnected1.Size = new System.Drawing.Size(96, 16);
            this.chkConnected1.TabIndex = 77;
            this.chkConnected1.Text = "Connected #1";
            this.chkConnected1.UseVisualStyleBackColor = true;
            // 
            // label1E
            // 
            this.label1E.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1E.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1E.Location = new System.Drawing.Point(414, 94);
            this.label1E.Name = "label1E";
            this.label1E.Size = new System.Drawing.Size(60, 21);
            this.label1E.TabIndex = 76;
            this.label1E.Text = "0";
            this.label1E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1R
            // 
            this.label1R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1R.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1R.Location = new System.Drawing.Point(414, 68);
            this.label1R.Name = "label1R";
            this.label1R.Size = new System.Drawing.Size(60, 21);
            this.label1R.TabIndex = 75;
            this.label1R.Text = "0";
            this.label1R.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1T
            // 
            this.label1T.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1T.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1T.Location = new System.Drawing.Point(414, 43);
            this.label1T.Name = "label1T";
            this.label1T.Size = new System.Drawing.Size(60, 21);
            this.label1T.TabIndex = 74;
            this.label1T.Text = "0";
            this.label1T.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2E
            // 
            this.label2E.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2E.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2E.Location = new System.Drawing.Point(820, 92);
            this.label2E.Name = "label2E";
            this.label2E.Size = new System.Drawing.Size(60, 21);
            this.label2E.TabIndex = 73;
            this.label2E.Text = "0";
            this.label2E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelStateHead2
            // 
            this.labelStateHead2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStateHead2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStateHead2.Location = new System.Drawing.Point(650, 15);
            this.labelStateHead2.Name = "labelStateHead2";
            this.labelStateHead2.Size = new System.Drawing.Size(230, 21);
            this.labelStateHead2.TabIndex = 39;
            this.labelStateHead2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStateHead1
            // 
            this.labelStateHead1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStateHead1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStateHead1.Location = new System.Drawing.Point(414, 15);
            this.labelStateHead1.Name = "labelStateHead1";
            this.labelStateHead1.Size = new System.Drawing.Size(230, 21);
            this.labelStateHead1.TabIndex = 38;
            this.labelStateHead1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartOffset2Heads
            // 
            this.btnStartOffset2Heads.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartOffset2Heads.Location = new System.Drawing.Point(599, 43);
            this.btnStartOffset2Heads.Name = "btnStartOffset2Heads";
            this.btnStartOffset2Heads.Size = new System.Drawing.Size(93, 36);
            this.btnStartOffset2Heads.TabIndex = 16;
            this.btnStartOffset2Heads.Text = "Start Auto Offset #1, #2";
            this.btnStartOffset2Heads.UseVisualStyleBackColor = true;
            this.btnStartOffset2Heads.Click += new System.EventHandler(this.btnStartOffset2Heads_Click);
            // 
            // label2R
            // 
            this.label2R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2R.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2R.Location = new System.Drawing.Point(820, 66);
            this.label2R.Name = "label2R";
            this.label2R.Size = new System.Drawing.Size(60, 21);
            this.label2R.TabIndex = 72;
            this.label2R.Text = "0";
            this.label2R.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStart2Heads
            // 
            this.btnStart2Heads.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart2Heads.Location = new System.Drawing.Point(494, 43);
            this.btnStart2Heads.Name = "btnStart2Heads";
            this.btnStart2Heads.Size = new System.Drawing.Size(84, 36);
            this.btnStart2Heads.TabIndex = 15;
            this.btnStart2Heads.Text = "Start Mod #1, #2";
            this.btnStart2Heads.UseVisualStyleBackColor = true;
            this.btnStart2Heads.Click += new System.EventHandler(this.btnStart2Heads_Click);
            // 
            // label2T
            // 
            this.label2T.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2T.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2T.Location = new System.Drawing.Point(820, 43);
            this.label2T.Name = "label2T";
            this.label2T.Size = new System.Drawing.Size(60, 21);
            this.label2T.TabIndex = 71;
            this.label2T.Text = "0";
            this.label2T.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox2Heads
            // 
            this.listBox2Heads.FormattingEnabled = true;
            this.listBox2Heads.ItemHeight = 12;
            this.listBox2Heads.Location = new System.Drawing.Point(288, 18);
            this.listBox2Heads.Name = "listBox2Heads";
            this.listBox2Heads.Size = new System.Drawing.Size(105, 64);
            this.listBox2Heads.TabIndex = 13;
            // 
            // btnHead2
            // 
            this.btnHead2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHead2.Location = new System.Drawing.Point(150, 53);
            this.btnHead2.Name = "btnHead2";
            this.btnHead2.Size = new System.Drawing.Size(124, 36);
            this.btnHead2.TabIndex = 12;
            this.btnHead2.Text = "Add Module #2";
            this.btnHead2.UseVisualStyleBackColor = true;
            this.btnHead2.Click += new System.EventHandler(this.btnHead2_Click);
            // 
            // textBoxIPHead2
            // 
            this.textBoxIPHead2.Location = new System.Drawing.Point(154, 27);
            this.textBoxIPHead2.MaxLength = 15;
            this.textBoxIPHead2.Name = "textBoxIPHead2";
            this.textBoxIPHead2.Size = new System.Drawing.Size(120, 21);
            this.textBoxIPHead2.TabIndex = 11;
            this.textBoxIPHead2.Text = "192.168.1.2";
            // 
            // btnHead1
            // 
            this.btnHead1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHead1.Location = new System.Drawing.Point(15, 52);
            this.btnHead1.Name = "btnHead1";
            this.btnHead1.Size = new System.Drawing.Size(124, 36);
            this.btnHead1.TabIndex = 10;
            this.btnHead1.Text = "Add Module #1";
            this.btnHead1.UseVisualStyleBackColor = true;
            this.btnHead1.Click += new System.EventHandler(this.btnHead1_Click);
            // 
            // textBoxIPHead1
            // 
            this.textBoxIPHead1.Location = new System.Drawing.Point(15, 26);
            this.textBoxIPHead1.MaxLength = 15;
            this.textBoxIPHead1.Name = "textBoxIPHead1";
            this.textBoxIPHead1.Size = new System.Drawing.Size(122, 21);
            this.textBoxIPHead1.TabIndex = 9;
            this.textBoxIPHead1.Text = "192.168.1.1";
            // 
            // timerHead1
            // 
            this.timerHead1.Tick += new System.EventHandler(this.timerHead1_Tick);
            // 
            // timerHead2
            // 
            this.timerHead2.Tick += new System.EventHandler(this.timerHead2_Tick);
            // 
            // chkConnected
            // 
            this.chkConnected.AutoSize = true;
            this.chkConnected.Enabled = false;
            this.chkConnected.Location = new System.Drawing.Point(542, 216);
            this.chkConnected.Name = "chkConnected";
            this.chkConnected.Size = new System.Drawing.Size(78, 16);
            this.chkConnected.TabIndex = 57;
            this.chkConnected.Text = "Connected";
            this.chkConnected.UseVisualStyleBackColor = true;
            // 
            // btnRemoveModule
            // 
            this.btnRemoveModule.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Effacer;
            this.btnRemoveModule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveModule.Location = new System.Drawing.Point(25, 184);
            this.btnRemoveModule.Name = "btnRemoveModule";
            this.btnRemoveModule.Size = new System.Drawing.Size(124, 36);
            this.btnRemoveModule.TabIndex = 58;
            this.btnRemoveModule.Text = "Remove Module";
            this.btnRemoveModule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveModule.UseVisualStyleBackColor = true;
            this.btnRemoveModule.Click += new System.EventHandler(this.btnRemoveModule_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(1065, 747);
            this.Controls.Add(this.btnRemoveModule);
            this.Controls.Add(this.chkConnected);
            this.Controls.Add(this.groupBox2Heads);
            this.Controls.Add(this.btnClearListbox);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReadParameters);
            this.Controls.Add(this.grpBoxCalibration);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelReceive);
            this.Controls.Add(this.labelTransmit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxResultCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonReadFifo);
            this.Controls.Add(this.buttonClearFifo);
            this.Controls.Add(this.buttonParameters);
            this.Controls.Add(this.buttonLastResult);
            this.Controls.Add(this.TemperatureUnit);
            this.Controls.Add(this.Temperature);
            this.Controls.Add(this.PAtmUnit);
            this.Controls.Add(this.PAtm);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.LeakUnit);
            this.Controls.Add(this.Leak);
            this.Controls.Add(this.PressureUnit);
            this.Controls.Add(this.Pressure);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddModule);
            this.Controls.Add(this.textBoxAddressIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxMessage);
            this.Controls.Add(this.checkBoxOpenClose);
            this.Controls.Add(this.textBoxModuleID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDLLVersion);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCSharpLightControlDemo  -> Ethernet Interface";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBoxCalibration.ResumeLayout(false);
            this.grpBoxCalibration.PerformLayout();
            this.groupBox2Heads.ResumeLayout(false);
            this.groupBox2Heads.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDLLVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxModuleID;
        private System.Windows.Forms.CheckBox checkBoxOpenClose;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAddressIP;
        private System.Windows.Forms.Button buttonAddModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonStartGroup;
        private System.Windows.Forms.Button buttonResetGroup;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label Pressure;
        private System.Windows.Forms.Timer timerRealTime;
        private System.Windows.Forms.Label PressureUnit;
        private System.Windows.Forms.Label Leak;
        private System.Windows.Forms.Label LeakUnit;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label PAtm;
        private System.Windows.Forms.Label PAtmUnit;
        private System.Windows.Forms.Label Temperature;
        private System.Windows.Forms.Label TemperatureUnit;
        private System.Windows.Forms.Button buttonLastResult;
        private System.Windows.Forms.Button buttonParameters;
        private System.Windows.Forms.Button buttonClearFifo;
        private System.Windows.Forms.Button buttonReadFifo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxResultCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAZDumpTime;
        private System.Windows.Forms.Button buttonAutoZero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTransmit;
        private System.Windows.Forms.Label labelReceive;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Timer timerCounters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonRegAdjust;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.GroupBox grpBoxCalibration;
        internal System.Windows.Forms.Label m_labelCal;
        internal System.Windows.Forms.Button btnStopAutoCal;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox textBoxVolMaxCal;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox textBoxOffset;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox textBoxVolMinCal;
        internal System.Windows.Forms.Button btnOffsetOnly;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox textBoxPressureCal;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox textBoxLeakCal;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox textBoxCycleNumber;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox textBoxIntercycle;
        internal System.Windows.Forms.Button btnAutoVolume;
        private System.Windows.Forms.Button buttonReadParameters;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button btnClearListbox;
        private System.Windows.Forms.GroupBox groupBox2Heads;
        private System.Windows.Forms.Button btnStartOffset2Heads;
        private System.Windows.Forms.Button btnStart2Heads;
        private System.Windows.Forms.ListBox listBox2Heads;
        private System.Windows.Forms.Button btnHead2;
        private System.Windows.Forms.TextBox textBoxIPHead2;
        private System.Windows.Forms.Button btnHead1;
        private System.Windows.Forms.TextBox textBoxIPHead1;
        private System.Windows.Forms.Label labelStateHead2;
        private System.Windows.Forms.Label labelStateHead1;
        private System.Windows.Forms.Timer timerHead1;
        private System.Windows.Forms.Timer timerHead2;
        private System.Windows.Forms.Label label1E;
        private System.Windows.Forms.Label label1R;
        private System.Windows.Forms.Label label1T;
        private System.Windows.Forms.Label label2E;
        private System.Windows.Forms.Label label2R;
        private System.Windows.Forms.Label label2T;
        private System.Windows.Forms.CheckBox chkConnected;
        private System.Windows.Forms.CheckBox chkConnected2;
        private System.Windows.Forms.CheckBox chkConnected1;
        private System.Windows.Forms.Button buttonElecRegLearn;
        private System.Windows.Forms.Button btnRemoveModule;
        private System.Windows.Forms.Button buttonJetCheck;
        internal System.Windows.Forms.Button btnAutoRatio;
        private System.Windows.Forms.Button btnStartAutoRatio2Heads;
        internal System.Windows.Forms.Button btnEasyAutoLearning;
        private System.Windows.Forms.Button btnStartEasyAuto2Heads;
    }
}

