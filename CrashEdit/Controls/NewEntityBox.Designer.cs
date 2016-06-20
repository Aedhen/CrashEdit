namespace CrashEdit
{
    partial class NewEntityBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkType = new System.Windows.Forms.CheckBox();
            this.numType = new System.Windows.Forms.NumericUpDown();
            this.fraType = new System.Windows.Forms.GroupBox();
            this.fraSubtype = new System.Windows.Forms.GroupBox();
            this.chkSubtype = new System.Windows.Forms.CheckBox();
            this.numSubtype = new System.Windows.Forms.NumericUpDown();
            this.fraPosition = new System.Windows.Forms.GroupBox();
            this.lblPositionIndex = new System.Windows.Forms.Label();
            this.cmdNextPosition = new System.Windows.Forms.Button();
            this.cmdPreviousPosition = new System.Windows.Forms.Button();
            this.cmdInsertPosition = new System.Windows.Forms.Button();
            this.lblZ = new System.Windows.Forms.Label();
            this.cmdRemovePosition = new System.Windows.Forms.Button();
            this.lblY = new System.Windows.Forms.Label();
            this.cmdAppendPosition = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.numZ = new System.Windows.Forms.NumericUpDown();
            this.numY = new System.Windows.Forms.NumericUpDown();
            this.numX = new System.Windows.Forms.NumericUpDown();
            this.cmdAppendVictim = new System.Windows.Forms.Button();
            this.cmdInsertVictim = new System.Windows.Forms.Button();
            this.fraID = new System.Windows.Forms.GroupBox();
            this.chkID2 = new System.Windows.Forms.CheckBox();
            this.numID2 = new System.Windows.Forms.NumericUpDown();
            this.chkID = new System.Windows.Forms.CheckBox();
            this.numID = new System.Windows.Forms.NumericUpDown();
            this.fraSettings = new System.Windows.Forms.GroupBox();
            this.lblSettingIndex = new System.Windows.Forms.Label();
            this.cmdNextSetting = new System.Windows.Forms.Button();
            this.cmdPreviousSetting = new System.Windows.Forms.Button();
            this.cmdAddSetting = new System.Windows.Forms.Button();
            this.cmdRemoveSetting = new System.Windows.Forms.Button();
            this.lblSettingB = new System.Windows.Forms.Label();
            this.lblSettingA = new System.Windows.Forms.Label();
            this.numSettingB = new System.Windows.Forms.NumericUpDown();
            this.numSettingA = new System.Windows.Forms.NumericUpDown();
            this.fraName = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.tbcTabs = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabSpecial = new System.Windows.Forms.TabPage();
            this.fraBoxCount = new System.Windows.Forms.GroupBox();
            this.chkBoxCount = new System.Windows.Forms.CheckBox();
            this.numBoxCount = new System.Windows.Forms.NumericUpDown();
            this.fraVictims = new System.Windows.Forms.GroupBox();
            this.cmdClearAllVictims = new System.Windows.Forms.Button();
            this.numVictimID = new System.Windows.Forms.NumericUpDown();
            this.cmdRemoveVictim = new System.Windows.Forms.Button();
            this.cmdNextVictim = new System.Windows.Forms.Button();
            this.cmdPreviousVictim = new System.Windows.Forms.Button();
            this.lblVictimIndex = new System.Windows.Forms.Label();
            this.fraScaling = new System.Windows.Forms.GroupBox();
            this.chkScaling = new System.Windows.Forms.CheckBox();
            this.numScaling = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numType)).BeginInit();
            this.fraType.SuspendLayout();
            this.fraSubtype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtype)).BeginInit();
            this.fraPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.fraID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).BeginInit();
            this.fraSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingA)).BeginInit();
            this.fraName.SuspendLayout();
            this.tbcTabs.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabSpecial.SuspendLayout();
            this.fraBoxCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxCount)).BeginInit();
            this.fraVictims.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVictimID)).BeginInit();
            this.fraScaling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).BeginInit();
            this.SuspendLayout();
            // 
            // chkType
            // 
            this.chkType.AutoSize = true;
            this.chkType.Location = new System.Drawing.Point(6, 19);
            this.chkType.Name = "chkType";
            this.chkType.Size = new System.Drawing.Size(65, 17);
            this.chkType.TabIndex = 0;
            this.chkType.Text = "Enabled";
            this.chkType.UseVisualStyleBackColor = true;
            this.chkType.CheckedChanged += new System.EventHandler(this.chkType_CheckedChanged);
            // 
            // numType
            // 
            this.numType.Location = new System.Drawing.Point(6, 42);
            this.numType.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numType.Name = "numType";
            this.numType.Size = new System.Drawing.Size(120, 20);
            this.numType.TabIndex = 1;
            this.numType.ValueChanged += new System.EventHandler(this.numType_ValueChanged);
            // 
            // fraType
            // 
            this.fraType.Controls.Add(this.chkType);
            this.fraType.Controls.Add(this.numType);
            this.fraType.Location = new System.Drawing.Point(209, 129);
            this.fraType.Name = "fraType";
            this.fraType.Size = new System.Drawing.Size(132, 72);
            this.fraType.TabIndex = 4;
            this.fraType.TabStop = false;
            this.fraType.Text = "Type";
            // 
            // fraSubtype
            // 
            this.fraSubtype.Controls.Add(this.chkSubtype);
            this.fraSubtype.Controls.Add(this.numSubtype);
            this.fraSubtype.Location = new System.Drawing.Point(209, 207);
            this.fraSubtype.Name = "fraSubtype";
            this.fraSubtype.Size = new System.Drawing.Size(132, 72);
            this.fraSubtype.TabIndex = 5;
            this.fraSubtype.TabStop = false;
            this.fraSubtype.Text = "Subtype";
            // 
            // chkSubtype
            // 
            this.chkSubtype.AutoSize = true;
            this.chkSubtype.Location = new System.Drawing.Point(6, 19);
            this.chkSubtype.Name = "chkSubtype";
            this.chkSubtype.Size = new System.Drawing.Size(65, 17);
            this.chkSubtype.TabIndex = 0;
            this.chkSubtype.Text = "Enabled";
            this.chkSubtype.UseVisualStyleBackColor = true;
            this.chkSubtype.CheckedChanged += new System.EventHandler(this.chkSubtype_CheckedChanged);
            // 
            // numSubtype
            // 
            this.numSubtype.Location = new System.Drawing.Point(6, 42);
            this.numSubtype.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSubtype.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numSubtype.Name = "numSubtype";
            this.numSubtype.Size = new System.Drawing.Size(120, 20);
            this.numSubtype.TabIndex = 1;
            this.numSubtype.ValueChanged += new System.EventHandler(this.numSubtype_ValueChanged);
            // 
            // fraPosition
            // 
            this.fraPosition.Controls.Add(this.lblPositionIndex);
            this.fraPosition.Controls.Add(this.cmdNextPosition);
            this.fraPosition.Controls.Add(this.cmdPreviousPosition);
            this.fraPosition.Controls.Add(this.cmdInsertPosition);
            this.fraPosition.Controls.Add(this.lblZ);
            this.fraPosition.Controls.Add(this.cmdRemovePosition);
            this.fraPosition.Controls.Add(this.lblY);
            this.fraPosition.Controls.Add(this.cmdAppendPosition);
            this.fraPosition.Controls.Add(this.lblX);
            this.fraPosition.Controls.Add(this.numZ);
            this.fraPosition.Controls.Add(this.numY);
            this.fraPosition.Controls.Add(this.numX);
            this.fraPosition.Location = new System.Drawing.Point(3, 81);
            this.fraPosition.Name = "fraPosition";
            this.fraPosition.Size = new System.Drawing.Size(200, 132);
            this.fraPosition.TabIndex = 1;
            this.fraPosition.TabStop = false;
            this.fraPosition.Text = "Position(s)";
            // 
            // lblPositionIndex
            // 
            this.lblPositionIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositionIndex.Location = new System.Drawing.Point(6, 19);
            this.lblPositionIndex.Name = "lblPositionIndex";
            this.lblPositionIndex.Size = new System.Drawing.Size(60, 23);
            this.lblPositionIndex.TabIndex = 5;
            this.lblPositionIndex.Text = "?? / ??";
            this.lblPositionIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNextPosition
            // 
            this.cmdNextPosition.Location = new System.Drawing.Point(136, 19);
            this.cmdNextPosition.Name = "cmdNextPosition";
            this.cmdNextPosition.Size = new System.Drawing.Size(58, 23);
            this.cmdNextPosition.TabIndex = 1;
            this.cmdNextPosition.Text = "Next";
            this.cmdNextPosition.UseVisualStyleBackColor = true;
            this.cmdNextPosition.Click += new System.EventHandler(this.cmdNextPosition_Click);
            // 
            // cmdPreviousPosition
            // 
            this.cmdPreviousPosition.Location = new System.Drawing.Point(72, 19);
            this.cmdPreviousPosition.Name = "cmdPreviousPosition";
            this.cmdPreviousPosition.Size = new System.Drawing.Size(58, 23);
            this.cmdPreviousPosition.TabIndex = 0;
            this.cmdPreviousPosition.Text = "Previous";
            this.cmdPreviousPosition.UseVisualStyleBackColor = true;
            this.cmdPreviousPosition.Click += new System.EventHandler(this.cmdPreviousPosition_Click);
            // 
            // cmdInsertPosition
            // 
            this.cmdInsertPosition.Location = new System.Drawing.Point(119, 75);
            this.cmdInsertPosition.Name = "cmdInsertPosition";
            this.cmdInsertPosition.Size = new System.Drawing.Size(75, 23);
            this.cmdInsertPosition.TabIndex = 6;
            this.cmdInsertPosition.Text = "Insert";
            this.cmdInsertPosition.UseVisualStyleBackColor = true;
            this.cmdInsertPosition.Click += new System.EventHandler(this.cmdInsertPosition_Click);
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(6, 106);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(14, 13);
            this.lblZ.TabIndex = 5;
            this.lblZ.Text = "Z";
            // 
            // cmdRemovePosition
            // 
            this.cmdRemovePosition.Location = new System.Drawing.Point(119, 101);
            this.cmdRemovePosition.Name = "cmdRemovePosition";
            this.cmdRemovePosition.Size = new System.Drawing.Size(75, 23);
            this.cmdRemovePosition.TabIndex = 7;
            this.cmdRemovePosition.Text = "Remove";
            this.cmdRemovePosition.UseVisualStyleBackColor = true;
            this.cmdRemovePosition.Click += new System.EventHandler(this.cmdRemovePosition_Click);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(6, 80);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 13);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y";
            // 
            // cmdAppendPosition
            // 
            this.cmdAppendPosition.Location = new System.Drawing.Point(119, 49);
            this.cmdAppendPosition.Name = "cmdAppendPosition";
            this.cmdAppendPosition.Size = new System.Drawing.Size(75, 23);
            this.cmdAppendPosition.TabIndex = 5;
            this.cmdAppendPosition.Text = "Append";
            this.cmdAppendPosition.UseVisualStyleBackColor = true;
            this.cmdAppendPosition.Click += new System.EventHandler(this.cmdAppendPosition_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(6, 54);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 13);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X";
            // 
            // numZ
            // 
            this.numZ.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numZ.Location = new System.Drawing.Point(26, 104);
            this.numZ.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numZ.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(86, 20);
            this.numZ.TabIndex = 4;
            this.numZ.ValueChanged += new System.EventHandler(this.numZ_ValueChanged);
            // 
            // numY
            // 
            this.numY.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numY.Location = new System.Drawing.Point(26, 78);
            this.numY.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(86, 20);
            this.numY.TabIndex = 3;
            this.numY.ValueChanged += new System.EventHandler(this.numY_ValueChanged);
            // 
            // numX
            // 
            this.numX.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numX.Location = new System.Drawing.Point(26, 52);
            this.numX.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(86, 20);
            this.numX.TabIndex = 2;
            this.numX.ValueChanged += new System.EventHandler(this.numX_ValueChanged);
            // 
            // cmdAppendVictim
            // 
            this.cmdAppendVictim.Location = new System.Drawing.Point(6, 154);
            this.cmdAppendVictim.Name = "cmdAppendVictim";
            this.cmdAppendVictim.Size = new System.Drawing.Size(120, 23);
            this.cmdAppendVictim.TabIndex = 5;
            this.cmdAppendVictim.Text = "Append";
            this.cmdAppendVictim.UseVisualStyleBackColor = true;
            this.cmdAppendVictim.Click += new System.EventHandler(this.cmdAppendVictim_Click);
            // 
            // cmdInsertVictim
            // 
            this.cmdInsertVictim.Location = new System.Drawing.Point(68, 96);
            this.cmdInsertVictim.Name = "cmdInsertVictim";
            this.cmdInsertVictim.Size = new System.Drawing.Size(58, 23);
            this.cmdInsertVictim.TabIndex = 6;
            this.cmdInsertVictim.Text = "Insert";
            this.cmdInsertVictim.UseVisualStyleBackColor = true;
            this.cmdInsertVictim.Click += new System.EventHandler(this.cmdInsertVictim_Click);
            // 
            // fraID
            // 
            this.fraID.Controls.Add(this.chkID2);
            this.fraID.Controls.Add(this.numID2);
            this.fraID.Controls.Add(this.chkID);
            this.fraID.Controls.Add(this.numID);
            this.fraID.Location = new System.Drawing.Point(209, 3);
            this.fraID.Name = "fraID";
            this.fraID.Size = new System.Drawing.Size(132, 120);
            this.fraID.TabIndex = 3;
            this.fraID.TabStop = false;
            this.fraID.Text = "ID";
            // 
            // chkID2
            // 
            this.chkID2.AutoSize = true;
            this.chkID2.Location = new System.Drawing.Point(6, 68);
            this.chkID2.Name = "chkID2";
            this.chkID2.Size = new System.Drawing.Size(65, 17);
            this.chkID2.TabIndex = 2;
            this.chkID2.Text = "Enabled";
            this.chkID2.UseVisualStyleBackColor = true;
            this.chkID2.CheckedChanged += new System.EventHandler(this.chkID2_CheckedChanged);
            // 
            // numID2
            // 
            this.numID2.Location = new System.Drawing.Point(6, 91);
            this.numID2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numID2.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numID2.Name = "numID2";
            this.numID2.Size = new System.Drawing.Size(120, 20);
            this.numID2.TabIndex = 3;
            this.numID2.ValueChanged += new System.EventHandler(this.numID2_ValueChanged);
            // 
            // chkID
            // 
            this.chkID.AutoSize = true;
            this.chkID.Location = new System.Drawing.Point(6, 19);
            this.chkID.Name = "chkID";
            this.chkID.Size = new System.Drawing.Size(65, 17);
            this.chkID.TabIndex = 0;
            this.chkID.Text = "Enabled";
            this.chkID.UseVisualStyleBackColor = true;
            this.chkID.CheckedChanged += new System.EventHandler(this.chkID_CheckedChanged);
            // 
            // numID
            // 
            this.numID.Location = new System.Drawing.Point(6, 42);
            this.numID.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numID.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numID.Name = "numID";
            this.numID.Size = new System.Drawing.Size(120, 20);
            this.numID.TabIndex = 1;
            this.numID.ValueChanged += new System.EventHandler(this.numID_ValueChanged);
            // 
            // fraSettings
            // 
            this.fraSettings.Controls.Add(this.lblSettingIndex);
            this.fraSettings.Controls.Add(this.cmdNextSetting);
            this.fraSettings.Controls.Add(this.cmdPreviousSetting);
            this.fraSettings.Controls.Add(this.cmdAddSetting);
            this.fraSettings.Controls.Add(this.cmdRemoveSetting);
            this.fraSettings.Controls.Add(this.lblSettingB);
            this.fraSettings.Controls.Add(this.lblSettingA);
            this.fraSettings.Controls.Add(this.numSettingB);
            this.fraSettings.Controls.Add(this.numSettingA);
            this.fraSettings.Location = new System.Drawing.Point(3, 219);
            this.fraSettings.Name = "fraSettings";
            this.fraSettings.Size = new System.Drawing.Size(200, 106);
            this.fraSettings.TabIndex = 2;
            this.fraSettings.TabStop = false;
            this.fraSettings.Text = "General Settings";
            // 
            // lblSettingIndex
            // 
            this.lblSettingIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingIndex.Location = new System.Drawing.Point(6, 19);
            this.lblSettingIndex.Name = "lblSettingIndex";
            this.lblSettingIndex.Size = new System.Drawing.Size(60, 23);
            this.lblSettingIndex.TabIndex = 5;
            this.lblSettingIndex.Text = "?? / ??";
            this.lblSettingIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNextSetting
            // 
            this.cmdNextSetting.Location = new System.Drawing.Point(136, 19);
            this.cmdNextSetting.Name = "cmdNextSetting";
            this.cmdNextSetting.Size = new System.Drawing.Size(58, 23);
            this.cmdNextSetting.TabIndex = 1;
            this.cmdNextSetting.Text = "Next";
            this.cmdNextSetting.UseVisualStyleBackColor = true;
            this.cmdNextSetting.Click += new System.EventHandler(this.cmdNextSetting_Click);
            // 
            // cmdPreviousSetting
            // 
            this.cmdPreviousSetting.Location = new System.Drawing.Point(72, 19);
            this.cmdPreviousSetting.Name = "cmdPreviousSetting";
            this.cmdPreviousSetting.Size = new System.Drawing.Size(58, 23);
            this.cmdPreviousSetting.TabIndex = 0;
            this.cmdPreviousSetting.Text = "Previous";
            this.cmdPreviousSetting.UseVisualStyleBackColor = true;
            this.cmdPreviousSetting.Click += new System.EventHandler(this.cmdPreviousSetting_Click);
            // 
            // cmdAddSetting
            // 
            this.cmdAddSetting.Location = new System.Drawing.Point(119, 49);
            this.cmdAddSetting.Name = "cmdAddSetting";
            this.cmdAddSetting.Size = new System.Drawing.Size(75, 23);
            this.cmdAddSetting.TabIndex = 4;
            this.cmdAddSetting.Text = "Add";
            this.cmdAddSetting.UseVisualStyleBackColor = true;
            this.cmdAddSetting.Click += new System.EventHandler(this.cmdAddSetting_Click);
            // 
            // cmdRemoveSetting
            // 
            this.cmdRemoveSetting.Location = new System.Drawing.Point(119, 75);
            this.cmdRemoveSetting.Name = "cmdRemoveSetting";
            this.cmdRemoveSetting.Size = new System.Drawing.Size(75, 23);
            this.cmdRemoveSetting.TabIndex = 5;
            this.cmdRemoveSetting.Text = "Remove";
            this.cmdRemoveSetting.UseVisualStyleBackColor = true;
            this.cmdRemoveSetting.Click += new System.EventHandler(this.cmdRemoveSetting_Click);
            // 
            // lblSettingB
            // 
            this.lblSettingB.AutoSize = true;
            this.lblSettingB.Location = new System.Drawing.Point(6, 80);
            this.lblSettingB.Name = "lblSettingB";
            this.lblSettingB.Size = new System.Drawing.Size(14, 13);
            this.lblSettingB.TabIndex = 4;
            this.lblSettingB.Text = "B";
            // 
            // lblSettingA
            // 
            this.lblSettingA.AutoSize = true;
            this.lblSettingA.Location = new System.Drawing.Point(6, 54);
            this.lblSettingA.Name = "lblSettingA";
            this.lblSettingA.Size = new System.Drawing.Size(14, 13);
            this.lblSettingA.TabIndex = 3;
            this.lblSettingA.Text = "A";
            // 
            // numSettingB
            // 
            this.numSettingB.Location = new System.Drawing.Point(26, 78);
            this.numSettingB.Maximum = new decimal(new int[] {
            8388607,
            0,
            0,
            0});
            this.numSettingB.Minimum = new decimal(new int[] {
            8388608,
            0,
            0,
            -2147483648});
            this.numSettingB.Name = "numSettingB";
            this.numSettingB.Size = new System.Drawing.Size(86, 20);
            this.numSettingB.TabIndex = 3;
            this.numSettingB.ValueChanged += new System.EventHandler(this.numSettingB_ValueChanged);
            // 
            // numSettingA
            // 
            this.numSettingA.Location = new System.Drawing.Point(26, 52);
            this.numSettingA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numSettingA.Name = "numSettingA";
            this.numSettingA.Size = new System.Drawing.Size(86, 20);
            this.numSettingA.TabIndex = 2;
            this.numSettingA.ValueChanged += new System.EventHandler(this.numSettingA_ValueChanged);
            // 
            // fraName
            // 
            this.fraName.Controls.Add(this.txtName);
            this.fraName.Controls.Add(this.chkName);
            this.fraName.Location = new System.Drawing.Point(3, 3);
            this.fraName.Name = "fraName";
            this.fraName.Size = new System.Drawing.Size(200, 72);
            this.fraName.TabIndex = 0;
            this.fraName.TabStop = false;
            this.fraName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(188, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(6, 19);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(65, 17);
            this.chkName.TabIndex = 0;
            this.chkName.Text = "Enabled";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // tbcTabs
            // 
            this.tbcTabs.Controls.Add(this.tabGeneral);
            this.tbcTabs.Controls.Add(this.tabSpecial);
            this.tbcTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcTabs.Location = new System.Drawing.Point(0, 0);
            this.tbcTabs.Name = "tbcTabs";
            this.tbcTabs.SelectedIndex = 0;
            this.tbcTabs.Size = new System.Drawing.Size(398, 454);
            this.tbcTabs.TabIndex = 7;
            // 
            // tabGeneral
            // 
            this.tabGeneral.AutoScroll = true;
            this.tabGeneral.Controls.Add(this.fraName);
            this.tabGeneral.Controls.Add(this.fraType);
            this.tabGeneral.Controls.Add(this.fraSubtype);
            this.tabGeneral.Controls.Add(this.fraSettings);
            this.tabGeneral.Controls.Add(this.fraPosition);
            this.tabGeneral.Controls.Add(this.fraID);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(390, 428);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabSpecial
            // 
            this.tabSpecial.AutoScroll = true;
            this.tabSpecial.Controls.Add(this.fraScaling);
            this.tabSpecial.Controls.Add(this.fraBoxCount);
            this.tabSpecial.Controls.Add(this.fraVictims);
            this.tabSpecial.Location = new System.Drawing.Point(4, 22);
            this.tabSpecial.Name = "tabSpecial";
            this.tabSpecial.Size = new System.Drawing.Size(390, 428);
            this.tabSpecial.TabIndex = 1;
            this.tabSpecial.Text = "Special";
            this.tabSpecial.UseVisualStyleBackColor = true;
            // 
            // fraBoxCount
            // 
            this.fraBoxCount.Controls.Add(this.chkBoxCount);
            this.fraBoxCount.Controls.Add(this.numBoxCount);
            this.fraBoxCount.Location = new System.Drawing.Point(141, 3);
            this.fraBoxCount.Name = "fraBoxCount";
            this.fraBoxCount.Size = new System.Drawing.Size(132, 72);
            this.fraBoxCount.TabIndex = 8;
            this.fraBoxCount.TabStop = false;
            this.fraBoxCount.Text = "Box Count";
            // 
            // chkBoxCount
            // 
            this.chkBoxCount.AutoSize = true;
            this.chkBoxCount.Location = new System.Drawing.Point(6, 19);
            this.chkBoxCount.Name = "chkBoxCount";
            this.chkBoxCount.Size = new System.Drawing.Size(65, 17);
            this.chkBoxCount.TabIndex = 0;
            this.chkBoxCount.Text = "Enabled";
            this.chkBoxCount.UseVisualStyleBackColor = true;
            this.chkBoxCount.CheckedChanged += new System.EventHandler(this.chkBoxCount_CheckedChanged);
            // 
            // numBoxCount
            // 
            this.numBoxCount.Location = new System.Drawing.Point(6, 42);
            this.numBoxCount.Maximum = new decimal(new int[] {
            8388607,
            0,
            0,
            0});
            this.numBoxCount.Minimum = new decimal(new int[] {
            8388608,
            0,
            0,
            -2147483648});
            this.numBoxCount.Name = "numBoxCount";
            this.numBoxCount.Size = new System.Drawing.Size(120, 20);
            this.numBoxCount.TabIndex = 1;
            this.numBoxCount.ValueChanged += new System.EventHandler(this.numBoxCount_ValueChanged);
            // 
            // fraVictims
            // 
            this.fraVictims.Controls.Add(this.cmdClearAllVictims);
            this.fraVictims.Controls.Add(this.numVictimID);
            this.fraVictims.Controls.Add(this.cmdRemoveVictim);
            this.fraVictims.Controls.Add(this.cmdInsertVictim);
            this.fraVictims.Controls.Add(this.cmdNextVictim);
            this.fraVictims.Controls.Add(this.cmdPreviousVictim);
            this.fraVictims.Controls.Add(this.lblVictimIndex);
            this.fraVictims.Controls.Add(this.cmdAppendVictim);
            this.fraVictims.Location = new System.Drawing.Point(3, 3);
            this.fraVictims.Name = "fraVictims";
            this.fraVictims.Size = new System.Drawing.Size(132, 185);
            this.fraVictims.TabIndex = 7;
            this.fraVictims.TabStop = false;
            this.fraVictims.Text = "Victims";
            // 
            // cmdClearAllVictims
            // 
            this.cmdClearAllVictims.Location = new System.Drawing.Point(6, 125);
            this.cmdClearAllVictims.Name = "cmdClearAllVictims";
            this.cmdClearAllVictims.Size = new System.Drawing.Size(120, 23);
            this.cmdClearAllVictims.TabIndex = 5;
            this.cmdClearAllVictims.Text = "Clear All";
            this.cmdClearAllVictims.UseVisualStyleBackColor = true;
            this.cmdClearAllVictims.Click += new System.EventHandler(this.cmdClearAllVictims_Click);
            // 
            // numVictimID
            // 
            this.numVictimID.Location = new System.Drawing.Point(6, 71);
            this.numVictimID.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numVictimID.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numVictimID.Name = "numVictimID";
            this.numVictimID.Size = new System.Drawing.Size(120, 20);
            this.numVictimID.TabIndex = 2;
            this.numVictimID.ValueChanged += new System.EventHandler(this.numVictimID_ValueChanged);
            // 
            // cmdRemoveVictim
            // 
            this.cmdRemoveVictim.Location = new System.Drawing.Point(6, 96);
            this.cmdRemoveVictim.Name = "cmdRemoveVictim";
            this.cmdRemoveVictim.Size = new System.Drawing.Size(58, 23);
            this.cmdRemoveVictim.TabIndex = 4;
            this.cmdRemoveVictim.Text = "Remove";
            this.cmdRemoveVictim.UseVisualStyleBackColor = true;
            this.cmdRemoveVictim.Click += new System.EventHandler(this.cmdRemoveVictim_Click);
            // 
            // cmdNextVictim
            // 
            this.cmdNextVictim.Location = new System.Drawing.Point(68, 19);
            this.cmdNextVictim.Name = "cmdNextVictim";
            this.cmdNextVictim.Size = new System.Drawing.Size(58, 23);
            this.cmdNextVictim.TabIndex = 1;
            this.cmdNextVictim.Text = "Next";
            this.cmdNextVictim.UseVisualStyleBackColor = true;
            this.cmdNextVictim.Click += new System.EventHandler(this.cmdNextVictim_Click);
            // 
            // cmdPreviousVictim
            // 
            this.cmdPreviousVictim.Location = new System.Drawing.Point(6, 19);
            this.cmdPreviousVictim.Name = "cmdPreviousVictim";
            this.cmdPreviousVictim.Size = new System.Drawing.Size(58, 23);
            this.cmdPreviousVictim.TabIndex = 0;
            this.cmdPreviousVictim.Text = "Previous";
            this.cmdPreviousVictim.UseVisualStyleBackColor = true;
            this.cmdPreviousVictim.Click += new System.EventHandler(this.cmdPreviousVictim_Click);
            // 
            // lblVictimIndex
            // 
            this.lblVictimIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVictimIndex.Location = new System.Drawing.Point(38, 45);
            this.lblVictimIndex.Name = "lblVictimIndex";
            this.lblVictimIndex.Size = new System.Drawing.Size(60, 23);
            this.lblVictimIndex.TabIndex = 7;
            this.lblVictimIndex.Text = "?? / ??";
            this.lblVictimIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fraScaling
            // 
            this.fraScaling.Controls.Add(this.chkScaling);
            this.fraScaling.Controls.Add(this.numScaling);
            this.fraScaling.Location = new System.Drawing.Point(3, 194);
            this.fraScaling.Name = "fraScaling";
            this.fraScaling.Size = new System.Drawing.Size(132, 72);
            this.fraScaling.TabIndex = 9;
            this.fraScaling.TabStop = false;
            this.fraScaling.Text = "Scaling Factor";
            // 
            // chkScaling
            // 
            this.chkScaling.AutoSize = true;
            this.chkScaling.Location = new System.Drawing.Point(6, 19);
            this.chkScaling.Name = "chkScaling";
            this.chkScaling.Size = new System.Drawing.Size(65, 17);
            this.chkScaling.TabIndex = 0;
            this.chkScaling.Text = "Enabled";
            this.chkScaling.UseVisualStyleBackColor = true;
            // 
            // numScaling
            // 
            this.numScaling.Location = new System.Drawing.Point(6, 42);
            this.numScaling.Maximum = new decimal(new int[] {
            8388607,
            0,
            0,
            0});
            this.numScaling.Minimum = new decimal(new int[] {
            8388608,
            0,
            0,
            -2147483648});
            this.numScaling.Name = "numScaling";
            this.numScaling.Size = new System.Drawing.Size(120, 20);
            this.numScaling.TabIndex = 1;
            // 
            // NewEntityBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbcTabs);
            this.Name = "NewEntityBox";
            this.Size = new System.Drawing.Size(398, 454);
            ((System.ComponentModel.ISupportInitialize)(this.numType)).EndInit();
            this.fraType.ResumeLayout(false);
            this.fraType.PerformLayout();
            this.fraSubtype.ResumeLayout(false);
            this.fraSubtype.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSubtype)).EndInit();
            this.fraPosition.ResumeLayout(false);
            this.fraPosition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.fraID.ResumeLayout(false);
            this.fraID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numID2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numID)).EndInit();
            this.fraSettings.ResumeLayout(false);
            this.fraSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingA)).EndInit();
            this.fraName.ResumeLayout(false);
            this.fraName.PerformLayout();
            this.tbcTabs.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabSpecial.ResumeLayout(false);
            this.fraBoxCount.ResumeLayout(false);
            this.fraBoxCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoxCount)).EndInit();
            this.fraVictims.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numVictimID)).EndInit();
            this.fraScaling.ResumeLayout(false);
            this.fraScaling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaling)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkType;
        private System.Windows.Forms.NumericUpDown numType;
        private System.Windows.Forms.GroupBox fraType;
        private System.Windows.Forms.GroupBox fraSubtype;
        private System.Windows.Forms.CheckBox chkSubtype;
        private System.Windows.Forms.NumericUpDown numSubtype;
        private System.Windows.Forms.GroupBox fraPosition;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.NumericUpDown numZ;
        private System.Windows.Forms.NumericUpDown numY;
        private System.Windows.Forms.NumericUpDown numX;
        private System.Windows.Forms.Button cmdInsertPosition;
        private System.Windows.Forms.Button cmdInsertVictim;
        private System.Windows.Forms.Button cmdRemovePosition;
        private System.Windows.Forms.Button cmdAppendPosition;
        private System.Windows.Forms.Button cmdNextPosition;
        private System.Windows.Forms.Button cmdPreviousPosition;
        private System.Windows.Forms.Label lblPositionIndex;
        private System.Windows.Forms.Label lblVictimIndex;
        private System.Windows.Forms.GroupBox fraID;
        private System.Windows.Forms.CheckBox chkID2;
        private System.Windows.Forms.NumericUpDown numID2;
        private System.Windows.Forms.CheckBox chkID;
        private System.Windows.Forms.NumericUpDown numID;
        private System.Windows.Forms.GroupBox fraSettings;
        private System.Windows.Forms.Label lblSettingIndex;
        private System.Windows.Forms.Button cmdNextSetting;
        private System.Windows.Forms.Button cmdPreviousSetting;
        private System.Windows.Forms.Button cmdAddSetting;
        private System.Windows.Forms.Button cmdRemoveSetting;
        private System.Windows.Forms.Label lblSettingB;
        private System.Windows.Forms.Label lblSettingA;
        private System.Windows.Forms.NumericUpDown numSettingB;
        private System.Windows.Forms.NumericUpDown numSettingA;
        private System.Windows.Forms.GroupBox fraName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.TabControl tbcTabs;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabSpecial;
        private System.Windows.Forms.GroupBox fraVictims;
        private System.Windows.Forms.NumericUpDown numVictimID;
        private System.Windows.Forms.Button cmdRemoveVictim;
        private System.Windows.Forms.Button cmdNextVictim;
        private System.Windows.Forms.Button cmdPreviousVictim;
        private System.Windows.Forms.GroupBox fraBoxCount;
        private System.Windows.Forms.CheckBox chkBoxCount;
        private System.Windows.Forms.NumericUpDown numBoxCount;
        private System.Windows.Forms.Button cmdClearAllVictims;
        private System.Windows.Forms.Button cmdAppendVictim;
        private System.Windows.Forms.GroupBox fraScaling;
        private System.Windows.Forms.CheckBox chkScaling;
        private System.Windows.Forms.NumericUpDown numScaling;
    }
}
