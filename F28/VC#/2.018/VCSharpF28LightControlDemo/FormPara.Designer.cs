namespace VCSharpF28LightControlDemo
{
    partial class FormPara
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPara));
            this.btnOk = new System.Windows.Forms.Button();
            this.edtLeakOffset = new System.Windows.Forms.TextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.edtFilter = new System.Windows.Forms.TextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.edtTemp = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.edtAbsPress = new System.Windows.Forms.TextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.cboRejectClac = new System.Windows.Forms.ComboBox();
            this.cboFillType = new System.Windows.Forms.ComboBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.edtSetPoint = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.edtStabTime = new System.Windows.Forms.TextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.edtDumpTime = new System.Windows.Forms.TextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.chkSign = new System.Windows.Forms.CheckBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.edtVolume = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.cboVolUnit = new System.Windows.Forms.ComboBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.edtLeakMin = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.edtLeakMax = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.cboLeakUnit = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.edtRatioMin = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.edtRatioMax = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.edtMinP1 = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.edtMaxP1 = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboP1Unit = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.edtTransfertTime = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.edtFillVolTime = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.edtFillTime = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.edtTestTime = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboTestType = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkElecReg = new System.Windows.Forms.CheckBox();
            this.chkPressureCorr = new System.Windows.Forms.CheckBox();
            this.chkNoNegative = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.edtNominalValue = new System.Windows.Forms.TextBox();
            this.edtCoeffRatioMax = new System.Windows.Forms.TextBox();
            this.edtCoeffRatioMin = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Ok;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(468, 584);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // edtLeakOffset
            // 
            this.edtLeakOffset.Location = new System.Drawing.Point(440, 349);
            this.edtLeakOffset.Name = "edtLeakOffset";
            this.edtLeakOffset.Size = new System.Drawing.Size(115, 20);
            this.edtLeakOffset.TabIndex = 101;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(362, 352);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(62, 13);
            this.Label24.TabIndex = 100;
            this.Label24.Text = "Leak Offset";
            // 
            // edtFilter
            // 
            this.edtFilter.Location = new System.Drawing.Point(440, 377);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Size = new System.Drawing.Size(115, 20);
            this.edtFilter.TabIndex = 99;
            // 
            // Label23
            // 
            this.Label23.Location = new System.Drawing.Point(286, 385);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(133, 13);
            this.Label23.TabIndex = 98;
            this.Label23.Text = "Filter (s)";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // edtTemp
            // 
            this.edtTemp.Location = new System.Drawing.Point(440, 438);
            this.edtTemp.Name = "edtTemp";
            this.edtTemp.Size = new System.Drawing.Size(115, 20);
            this.edtTemp.TabIndex = 97;
            // 
            // Label22
            // 
            this.Label22.Location = new System.Drawing.Point(274, 446);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(143, 13);
            this.Label22.TabIndex = 96;
            this.Label22.Text = "Std Cond. temperature (°C)";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // edtAbsPress
            // 
            this.edtAbsPress.Location = new System.Drawing.Point(440, 412);
            this.edtAbsPress.Name = "edtAbsPress";
            this.edtAbsPress.Size = new System.Drawing.Size(115, 20);
            this.edtAbsPress.TabIndex = 95;
            // 
            // Label21
            // 
            this.Label21.Location = new System.Drawing.Point(269, 422);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(148, 11);
            this.Label21.TabIndex = 94;
            this.Label21.Text = "Std Cond. Abs pressure(hPa)";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboRejectClac
            // 
            this.cboRejectClac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRejectClac.FormattingEnabled = true;
            this.cboRejectClac.Items.AddRange(new object[] {
            "Pa",
            "Pa/s"});
            this.cboRejectClac.Location = new System.Drawing.Point(145, 475);
            this.cboRejectClac.Name = "cboRejectClac";
            this.cboRejectClac.Size = new System.Drawing.Size(116, 21);
            this.cboRejectClac.TabIndex = 93;
            // 
            // cboFillType
            // 
            this.cboFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFillType.ForeColor = System.Drawing.Color.Blue;
            this.cboFillType.FormattingEnabled = true;
            this.cboFillType.Items.AddRange(new object[] {
            "Standard",
            "AutoFill",
            "Instruction",
            "Ramp",
            "Ramp control",
            "Easy",
            "Easy auto"});
            this.cboFillType.Location = new System.Drawing.Point(436, 212);
            this.cboFillType.Name = "cboFillType";
            this.cboFillType.Size = new System.Drawing.Size(116, 21);
            this.cboFillType.TabIndex = 92;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.ForeColor = System.Drawing.Color.Blue;
            this.Label20.Location = new System.Drawing.Point(386, 218);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(42, 13);
            this.Label20.TabIndex = 91;
            this.Label20.Text = "Fill type";
            // 
            // edtSetPoint
            // 
            this.edtSetPoint.Location = new System.Drawing.Point(437, 186);
            this.edtSetPoint.Name = "edtSetPoint";
            this.edtSetPoint.Size = new System.Drawing.Size(115, 20);
            this.edtSetPoint.TabIndex = 90;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(366, 190);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(64, 13);
            this.Label19.TabIndex = 89;
            this.Label19.Text = "Setpoint Fill ";
            // 
            // edtStabTime
            // 
            this.edtStabTime.Location = new System.Drawing.Point(439, 40);
            this.edtStabTime.Name = "edtStabTime";
            this.edtStabTime.Size = new System.Drawing.Size(115, 20);
            this.edtStabTime.TabIndex = 88;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(308, 46);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(123, 13);
            this.Label17.TabIndex = 87;
            this.Label17.Text = "Stabilisation time (0.01 s)";
            // 
            // edtDumpTime
            // 
            this.edtDumpTime.Location = new System.Drawing.Point(439, 67);
            this.edtDumpTime.Name = "edtDumpTime";
            this.edtDumpTime.Size = new System.Drawing.Size(115, 20);
            this.edtDumpTime.TabIndex = 86;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(334, 71);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(95, 13);
            this.Label18.TabIndex = 85;
            this.Label18.Text = "Dump time (0.01 s)";
            // 
            // chkSign
            // 
            this.chkSign.AutoSize = true;
            this.chkSign.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSign.Location = new System.Drawing.Point(46, 28);
            this.chkSign.Name = "chkSign";
            this.chkSign.Size = new System.Drawing.Size(50, 17);
            this.chkSign.TabIndex = 84;
            this.chkSign.Text = "Sign ";
            this.chkSign.UseVisualStyleBackColor = true;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(38, 479);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(87, 13);
            this.Label14.TabIndex = 83;
            this.Label14.Text = "Volume calc Unit";
            // 
            // edtVolume
            // 
            this.edtVolume.Location = new System.Drawing.Point(144, 446);
            this.edtVolume.Name = "edtVolume";
            this.edtVolume.Size = new System.Drawing.Size(115, 20);
            this.edtVolume.TabIndex = 82;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(83, 453);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(42, 13);
            this.Label15.TabIndex = 81;
            this.Label15.Text = "Volume";
            // 
            // cboVolUnit
            // 
            this.cboVolUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVolUnit.FormattingEnabled = true;
            this.cboVolUnit.Items.AddRange(new object[] {
            "cm3",
            "mm3",
            "ml",
            "litre",
            "Inch3",
            "Ft3"});
            this.cboVolUnit.Location = new System.Drawing.Point(143, 419);
            this.cboVolUnit.Name = "cboVolUnit";
            this.cboVolUnit.Size = new System.Drawing.Size(116, 21);
            this.cboVolUnit.TabIndex = 80;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(63, 429);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(62, 13);
            this.Label16.TabIndex = 79;
            this.Label16.Text = "Volume unit";
            // 
            // edtLeakMin
            // 
            this.edtLeakMin.Location = new System.Drawing.Point(144, 378);
            this.edtLeakMin.Name = "edtLeakMin";
            this.edtLeakMin.Size = new System.Drawing.Size(115, 20);
            this.edtLeakMin.TabIndex = 78;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(74, 385);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(51, 13);
            this.Label12.TabIndex = 77;
            this.Label12.Text = "Leak Min";
            // 
            // edtLeakMax
            // 
            this.edtLeakMax.Location = new System.Drawing.Point(144, 352);
            this.edtLeakMax.Name = "edtLeakMax";
            this.edtLeakMax.Size = new System.Drawing.Size(115, 20);
            this.edtLeakMax.TabIndex = 76;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(68, 359);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(57, 13);
            this.Label13.TabIndex = 75;
            this.Label13.Text = "Leak Max ";
            // 
            // cboLeakUnit
            // 
            this.cboLeakUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeakUnit.FormattingEnabled = true;
            this.cboLeakUnit.Items.AddRange(new object[] {
            "Pa",
            "Pa/sc",
            "PaHr",
            "Pa/sHr",
            "Pa",
            "CalPa/s",
            "cc/mn",
            "cc/s",
            "cc/h",
            "mm3/s",
            "cm3/s",
            "cm3/mn",
            "cm3/h",
            "ml/sec",
            "ml/mn",
            "ml/h",
            "inch3/s",
            "inch3/mn",
            "inch3/h",
            "ft3/s",
            "ft3/mn",
            "ft3/h",
            "mmCE",
            "mmCE/s",
            "sccm",
            "Pts",
            "cmH2O",
            "ugH2O"});
            this.cboLeakUnit.Location = new System.Drawing.Point(143, 325);
            this.cboLeakUnit.Name = "cboLeakUnit";
            this.cboLeakUnit.Size = new System.Drawing.Size(116, 21);
            this.cboLeakUnit.TabIndex = 74;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(74, 335);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(51, 13);
            this.Label11.TabIndex = 73;
            this.Label11.Text = "Leak unit";
            // 
            // edtRatioMin
            // 
            this.edtRatioMin.Location = new System.Drawing.Point(277, 264);
            this.edtRatioMin.Name = "edtRatioMin";
            this.edtRatioMin.ReadOnly = true;
            this.edtRatioMin.Size = new System.Drawing.Size(115, 20);
            this.edtRatioMin.TabIndex = 72;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(56, 268);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(69, 13);
            this.Label9.TabIndex = 71;
            this.Label9.Text = "Ratio Min (%)";
            // 
            // edtRatioMax
            // 
            this.edtRatioMax.Location = new System.Drawing.Point(277, 238);
            this.edtRatioMax.Name = "edtRatioMax";
            this.edtRatioMax.ReadOnly = true;
            this.edtRatioMax.Size = new System.Drawing.Size(115, 20);
            this.edtRatioMax.TabIndex = 70;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(53, 242);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(72, 13);
            this.Label10.TabIndex = 69;
            this.Label10.Text = "Ratio Max (%)";
            // 
            // edtMinP1
            // 
            this.edtMinP1.Location = new System.Drawing.Point(144, 212);
            this.edtMinP1.Name = "edtMinP1";
            this.edtMinP1.Size = new System.Drawing.Size(115, 20);
            this.edtMinP1.TabIndex = 68;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(42, 216);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(83, 13);
            this.Label8.TabIndex = 67;
            this.Label8.Text = "Min pressure P1";
            // 
            // edtMaxP1
            // 
            this.edtMaxP1.Location = new System.Drawing.Point(144, 186);
            this.edtMaxP1.Name = "edtMaxP1";
            this.edtMaxP1.Size = new System.Drawing.Size(115, 20);
            this.edtMaxP1.TabIndex = 66;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(38, 190);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(86, 13);
            this.Label7.TabIndex = 65;
            this.Label7.Text = "Max pressure P1";
            // 
            // cboP1Unit
            // 
            this.cboP1Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboP1Unit.FormattingEnabled = true;
            this.cboP1Unit.Items.AddRange(new object[] {
            "Pa",
            "KPa",
            "MPa",
            "bar",
            "mbar",
            "PSI",
            "Points"});
            this.cboP1Unit.Location = new System.Drawing.Point(144, 156);
            this.cboP1Unit.Name = "cboP1Unit";
            this.cboP1Unit.Size = new System.Drawing.Size(116, 21);
            this.cboP1Unit.TabIndex = 64;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(39, 163);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(85, 13);
            this.Label6.TabIndex = 63;
            this.Label6.Text = "Unit pressure P1";
            // 
            // edtTransfertTime
            // 
            this.edtTransfertTime.Location = new System.Drawing.Point(144, 122);
            this.edtTransfertTime.Name = "edtTransfertTime";
            this.edtTransfertTime.Size = new System.Drawing.Size(115, 20);
            this.edtTransfertTime.TabIndex = 62;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(38, 129);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(87, 13);
            this.Label5.TabIndex = 61;
            this.Label5.Text = "Transfert (0.01 s)";
            // 
            // edtFillVolTime
            // 
            this.edtFillVolTime.Location = new System.Drawing.Point(144, 96);
            this.edtFillVolTime.Name = "edtFillVolTime";
            this.edtFillVolTime.Size = new System.Drawing.Size(115, 20);
            this.edtFillVolTime.TabIndex = 60;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(31, 103);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 13);
            this.Label4.TabIndex = 59;
            this.Label4.Text = "Fill volume (0.01 s)";
            // 
            // edtFillTime
            // 
            this.edtFillTime.Location = new System.Drawing.Point(144, 41);
            this.edtFillTime.Name = "edtFillTime";
            this.edtFillTime.Size = new System.Drawing.Size(115, 20);
            this.edtFillTime.TabIndex = 58;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(46, 48);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(79, 13);
            this.Label3.TabIndex = 57;
            this.Label3.Text = "Fill time (0.01 s)";
            // 
            // edtTestTime
            // 
            this.edtTestTime.Location = new System.Drawing.Point(144, 68);
            this.edtTestTime.Name = "edtTestTime";
            this.edtTestTime.Size = new System.Drawing.Size(115, 20);
            this.edtTestTime.TabIndex = 56;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(37, 75);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(88, 13);
            this.Label2.TabIndex = 55;
            this.Label2.Text = "Test time (0.01 s)";
            // 
            // cboTestType
            // 
            this.cboTestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTestType.ForeColor = System.Drawing.Color.Blue;
            this.cboTestType.FormattingEnabled = true;
            this.cboTestType.Items.AddRange(new object[] {
            "Undefined",
            "Leak test",
            "Sealed component",
            "Desensibilized"});
            this.cboTestType.Location = new System.Drawing.Point(144, 14);
            this.cboTestType.Name = "cboTestType";
            this.cboTestType.Size = new System.Drawing.Size(116, 21);
            this.cboTestType.TabIndex = 54;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.Blue;
            this.Label1.Location = new System.Drawing.Point(59, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 13);
            this.Label1.TabIndex = 53;
            this.Label1.Text = "Type of test ";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::VCSharpF28LightControlDemo.Properties.Resources.Annuler;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(34, 584);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkElecReg);
            this.groupBox1.Controls.Add(this.chkPressureCorr);
            this.groupBox1.Controls.Add(this.chkNoNegative);
            this.groupBox1.Controls.Add(this.chkSign);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(13, 514);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(564, 64);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Options ]";
            // 
            // chkElecReg
            // 
            this.chkElecReg.AutoSize = true;
            this.chkElecReg.Location = new System.Drawing.Point(410, 28);
            this.chkElecReg.Name = "chkElecReg";
            this.chkElecReg.Size = new System.Drawing.Size(122, 17);
            this.chkElecReg.TabIndex = 87;
            this.chkElecReg.Text = "Electronic Regulator";
            this.chkElecReg.UseVisualStyleBackColor = true;
            // 
            // chkPressureCorr
            // 
            this.chkPressureCorr.AutoSize = true;
            this.chkPressureCorr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPressureCorr.Location = new System.Drawing.Point(248, 28);
            this.chkPressureCorr.Name = "chkPressureCorr";
            this.chkPressureCorr.Size = new System.Drawing.Size(136, 17);
            this.chkPressureCorr.TabIndex = 86;
            this.chkPressureCorr.Text = "Pressure compensation";
            this.chkPressureCorr.UseVisualStyleBackColor = true;
            // 
            // chkNoNegative
            // 
            this.chkNoNegative.AutoSize = true;
            this.chkNoNegative.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkNoNegative.Location = new System.Drawing.Point(122, 28);
            this.chkNoNegative.Name = "chkNoNegative";
            this.chkNoNegative.Size = new System.Drawing.Size(86, 17);
            this.chkNoNegative.TabIndex = 85;
            this.chkNoNegative.Text = "No Negative";
            this.chkNoNegative.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(51, 297);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(74, 13);
            this.label25.TabIndex = 103;
            this.label25.Text = "Nominal value";
            // 
            // edtNominalValue
            // 
            this.edtNominalValue.Location = new System.Drawing.Point(146, 290);
            this.edtNominalValue.Name = "edtNominalValue";
            this.edtNominalValue.Size = new System.Drawing.Size(115, 20);
            this.edtNominalValue.TabIndex = 104;
            // 
            // edtCoeffRatioMax
            // 
            this.edtCoeffRatioMax.Location = new System.Drawing.Point(145, 238);
            this.edtCoeffRatioMax.Name = "edtCoeffRatioMax";
            this.edtCoeffRatioMax.Size = new System.Drawing.Size(115, 20);
            this.edtCoeffRatioMax.TabIndex = 105;
            // 
            // edtCoeffRatioMin
            // 
            this.edtCoeffRatioMin.Location = new System.Drawing.Point(146, 265);
            this.edtCoeffRatioMin.Name = "edtCoeffRatioMin";
            this.edtCoeffRatioMin.Size = new System.Drawing.Size(115, 20);
            this.edtCoeffRatioMin.TabIndex = 106;
            // 
            // FormPara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 643);
            this.Controls.Add(this.edtCoeffRatioMin);
            this.Controls.Add(this.edtCoeffRatioMax);
            this.Controls.Add(this.edtNominalValue);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.edtLeakOffset);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.edtFilter);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.edtTemp);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.edtAbsPress);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.cboRejectClac);
            this.Controls.Add(this.cboFillType);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.edtSetPoint);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.edtStabTime);
            this.Controls.Add(this.Label17);
            this.Controls.Add(this.edtDumpTime);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.edtVolume);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.cboVolUnit);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.edtLeakMin);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.edtLeakMax);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.cboLeakUnit);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.edtRatioMin);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.edtRatioMax);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.edtMinP1);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.edtMaxP1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.cboP1Unit);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.edtTransfertTime);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.edtFillVolTime);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.edtFillTime);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.edtTestTime);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cboTestType);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "F28 Parameterts Ver 1.5xx (for DLL ver 1.5xx)";
            this.Load += new System.EventHandler(this.FormPara_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox edtLeakOffset;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.TextBox edtFilter;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.TextBox edtTemp;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.TextBox edtAbsPress;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.ComboBox cboRejectClac;
        internal System.Windows.Forms.ComboBox cboFillType;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.TextBox edtSetPoint;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox edtStabTime;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.TextBox edtDumpTime;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.CheckBox chkSign;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox edtVolume;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.ComboBox cboVolUnit;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox edtLeakMin;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox edtLeakMax;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.ComboBox cboLeakUnit;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox edtRatioMin;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox edtRatioMax;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox edtMinP1;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox edtMaxP1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cboP1Unit;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox edtTransfertTime;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox edtFillVolTime;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox edtFillTime;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox edtTestTime;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboTestType;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPressureCorr;
        private System.Windows.Forms.CheckBox chkNoNegative;
        private System.Windows.Forms.CheckBox chkElecReg;
        private System.Windows.Forms.Label label25;
        internal System.Windows.Forms.TextBox edtNominalValue;
        internal System.Windows.Forms.TextBox edtCoeffRatioMax;
        internal System.Windows.Forms.TextBox edtCoeffRatioMin;
    }
}