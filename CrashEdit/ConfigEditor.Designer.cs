namespace CrashEdit
{
    using System.Windows.Forms;

    partial class ConfigEditor
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
            this.components = new System.ComponentModel.Container();
            this.fraLang = new System.Windows.Forms.GroupBox();
            this.dpdLang = new MetroFramework.Controls.MetroComboBox();
            this.cdlClearCol = new System.Windows.Forms.ColorDialog();
            this.fraClearCol = new System.Windows.Forms.GroupBox();
            this.picClearCol = new System.Windows.Forms.PictureBox();
            this.cmdClearCol = new DarkUI.Controls.DarkButton();
            this.fraAnimGrid = new System.Windows.Forms.GroupBox();
            this.numAnimGrid = new DarkUI.Controls.DarkNumericUpDown();
            this.lblAnimGrid = new System.Windows.Forms.Label();
            this.chkAnimGrid = new MetroFramework.Controls.MetroCheckBox();
            this.chkOldPatchNSD = new MetroFramework.Controls.MetroCheckBox();
            this.chkPatchNSDSavesNSF = new MetroFramework.Controls.MetroCheckBox();
            this.chkDeleteInvalidEntries = new MetroFramework.Controls.MetroCheckBox();
            this.chkUseAnimLinks = new MetroFramework.Controls.MetroCheckBox();
            this.chkCollisionDisplay = new MetroFramework.Controls.MetroCheckBox();
            this.chkNormalDisplay = new MetroFramework.Controls.MetroCheckBox();
            this.cmdReset = new MetroFramework.Controls.MetroButton();
            this.chkDetailedCollision = new MetroFramework.Controls.MetroCheckBox();
            this.tglKeyBinds = new MetroFramework.Controls.MetroToggle();
            this.fraKeyBinds = new System.Windows.Forms.GroupBox();
            this.cmdShortcuts = new MetroFramework.Controls.MetroButton();
            this.chkCustomCrates = new MetroFramework.Controls.MetroCheckBox();
            this.chkAnimViewPanel = new MetroFramework.Controls.MetroCheckBox();
            this.fraGeneral = new System.Windows.Forms.GroupBox();
            this.fraExternalTools = new System.Windows.Forms.GroupBox();
            this.lblExportGoolDir = new MetroFramework.Controls.MetroLabel();
            this.txbExportGoolDir = new MetroFramework.Controls.MetroTextBox();
            this.lblExternalToolsDir = new MetroFramework.Controls.MetroLabel();
            this.txbExternalToolsDir = new MetroFramework.Controls.MetroTextBox();
            this.fraFind = new System.Windows.Forms.GroupBox();
            this.chkFindWrap = new MetroFramework.Controls.MetroCheckBox();
            this.fra3dViewer = new System.Windows.Forms.GroupBox();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnEidConvert = new MetroFramework.Controls.MetroButton();
            this.fraLang.SuspendLayout();
            this.fraClearCol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClearCol)).BeginInit();
            this.fraAnimGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnimGrid)).BeginInit();
            this.fraKeyBinds.SuspendLayout();
            this.fraGeneral.SuspendLayout();
            this.fraExternalTools.SuspendLayout();
            this.fraFind.SuspendLayout();
            this.fra3dViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraLang
            // 
            this.fraLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.fraLang.Controls.Add(this.dpdLang);
            this.fraLang.Font = new System.Drawing.Font("Arial", 9F);
            this.fraLang.ForeColor = System.Drawing.SystemColors.Window;
            this.fraLang.Location = new System.Drawing.Point(15, 22);
            this.fraLang.Name = "fraLang";
            this.fraLang.Size = new System.Drawing.Size(162, 53);
            this.fraLang.TabIndex = 1;
            this.fraLang.TabStop = false;
            this.fraLang.Text = "Language (requires restart)";
            // 
            // dpdLang
            // 
            this.dpdLang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.dpdLang.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.dpdLang.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.dpdLang.FormattingEnabled = true;
            this.dpdLang.IntegralHeight = false;
            this.dpdLang.ItemHeight = 19;
            this.dpdLang.Location = new System.Drawing.Point(6, 20);
            this.dpdLang.Name = "dpdLang";
            this.dpdLang.Size = new System.Drawing.Size(150, 25);
            this.dpdLang.Style = MetroFramework.MetroColorStyle.Blue;
            this.dpdLang.TabIndex = 0;
            this.dpdLang.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.dpdLang.UseCustomBackColor = true;
            this.dpdLang.UseSelectable = true;
            // 
            // cdlClearCol
            // 
            this.cdlClearCol.AnyColor = true;
            this.cdlClearCol.FullOpen = true;
            this.cdlClearCol.SolidColorOnly = true;
            // 
            // fraClearCol
            // 
            this.fraClearCol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.fraClearCol.Controls.Add(this.picClearCol);
            this.fraClearCol.Controls.Add(this.cmdClearCol);
            this.fraClearCol.Font = new System.Drawing.Font("Arial", 9F);
            this.fraClearCol.ForeColor = System.Drawing.SystemColors.Window;
            this.fraClearCol.Location = new System.Drawing.Point(183, 25);
            this.fraClearCol.Name = "fraClearCol";
            this.fraClearCol.Size = new System.Drawing.Size(128, 74);
            this.fraClearCol.TabIndex = 4;
            this.fraClearCol.TabStop = false;
            this.fraClearCol.Text = "Background Color";
            // 
            // picClearCol
            // 
            this.picClearCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picClearCol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClearCol.Location = new System.Drawing.Point(6, 20);
            this.picClearCol.Name = "picClearCol";
            this.picClearCol.Size = new System.Drawing.Size(60, 49);
            this.picClearCol.TabIndex = 0;
            this.picClearCol.TabStop = false;
            this.picClearCol.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // cmdClearCol
            // 
            this.cmdClearCol.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmdClearCol.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmdClearCol.Location = new System.Drawing.Point(73, 42);
            this.cmdClearCol.Name = "cmdClearCol";
            this.cmdClearCol.Padding = new System.Windows.Forms.Padding(5);
            this.cmdClearCol.Size = new System.Drawing.Size(49, 26);
            this.cmdClearCol.TabIndex = 7;
            this.cmdClearCol.Text = "Reset";
            this.cmdClearCol.Click += new System.EventHandler(this.cmdClearCol_Click);
            // 
            // fraAnimGrid
            // 
            this.fraAnimGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.fraAnimGrid.Controls.Add(this.numAnimGrid);
            this.fraAnimGrid.Controls.Add(this.lblAnimGrid);
            this.fraAnimGrid.Controls.Add(this.chkAnimGrid);
            this.fraAnimGrid.Font = new System.Drawing.Font("Arial", 9F);
            this.fraAnimGrid.ForeColor = System.Drawing.SystemColors.Window;
            this.fraAnimGrid.Location = new System.Drawing.Point(317, 25);
            this.fraAnimGrid.Name = "fraAnimGrid";
            this.fraAnimGrid.Size = new System.Drawing.Size(185, 74);
            this.fraAnimGrid.TabIndex = 6;
            this.fraAnimGrid.TabStop = false;
            this.fraAnimGrid.Text = "Grid";
            // 
            // numAnimGrid
            // 
            this.numAnimGrid.Location = new System.Drawing.Point(62, 42);
            this.numAnimGrid.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numAnimGrid.Name = "numAnimGrid";
            this.numAnimGrid.Size = new System.Drawing.Size(88, 21);
            this.numAnimGrid.TabIndex = 2;
            this.numAnimGrid.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numAnimGrid.ValueChanged += new System.EventHandler(this.numAnimGrid_ValueChanged);
            // 
            // lblAnimGrid
            // 
            this.lblAnimGrid.AutoSize = true;
            this.lblAnimGrid.Location = new System.Drawing.Point(7, 46);
            this.lblAnimGrid.Name = "lblAnimGrid";
            this.lblAnimGrid.Size = new System.Drawing.Size(49, 15);
            this.lblAnimGrid.TabIndex = 1;
            this.lblAnimGrid.Text = "Amount";
            // 
            // chkAnimGrid
            // 
            this.chkAnimGrid.AutoSize = true;
            this.chkAnimGrid.Checked = true;
            this.chkAnimGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnimGrid.Location = new System.Drawing.Point(10, 22);
            this.chkAnimGrid.Name = "chkAnimGrid";
            this.chkAnimGrid.Size = new System.Drawing.Size(65, 15);
            this.chkAnimGrid.TabIndex = 0;
            this.chkAnimGrid.Text = "Enabled";
            this.chkAnimGrid.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkAnimGrid.UseCustomBackColor = true;
            this.chkAnimGrid.UseSelectable = true;
            this.chkAnimGrid.CheckedChanged += new System.EventHandler(this.chkAnimGrid_CheckedChanged);
            // 
            // chkOldPatchNSD
            // 
            this.chkOldPatchNSD.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.chkOldPatchNSD.Location = new System.Drawing.Point(15, 228);
            this.chkOldPatchNSD.Name = "chkOldPatchNSD";
            this.chkOldPatchNSD.Size = new System.Drawing.Size(335, 16);
            this.chkOldPatchNSD.TabIndex = 9;
            this.chkOldPatchNSD.Text = "(Patch NSD) Use old NSD patching from CrashEdit v0.2.49.0";
            this.chkOldPatchNSD.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkOldPatchNSD.UseCustomBackColor = true;
            this.chkOldPatchNSD.UseCustomForeColor = true;
            this.chkOldPatchNSD.UseSelectable = true;
            this.chkOldPatchNSD.CheckedChanged += new System.EventHandler(this.chkOldPatchNSD_CheckedChanged);
            // 
            // chkPatchNSDSavesNSF
            // 
            this.chkPatchNSDSavesNSF.Checked = true;
            this.chkPatchNSDSavesNSF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPatchNSDSavesNSF.ForeColor = System.Drawing.SystemColors.Control;
            this.chkPatchNSDSavesNSF.Location = new System.Drawing.Point(15, 205);
            this.chkPatchNSDSavesNSF.Name = "chkPatchNSDSavesNSF";
            this.chkPatchNSDSavesNSF.Size = new System.Drawing.Size(280, 16);
            this.chkPatchNSDSavesNSF.TabIndex = 8;
            this.chkPatchNSDSavesNSF.Text = "(Patch NSD) Always save NSF after NSD patching";
            this.chkPatchNSDSavesNSF.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkPatchNSDSavesNSF.UseCustomBackColor = true;
            this.chkPatchNSDSavesNSF.UseSelectable = true;
            this.chkPatchNSDSavesNSF.CheckedChanged += new System.EventHandler(this.chkPatchNSDSavesNSF_CheckedChanged);
            // 
            // chkDeleteInvalidEntries
            // 
            this.chkDeleteInvalidEntries.Location = new System.Drawing.Point(15, 183);
            this.chkDeleteInvalidEntries.Name = "chkDeleteInvalidEntries";
            this.chkDeleteInvalidEntries.Size = new System.Drawing.Size(309, 16);
            this.chkDeleteInvalidEntries.TabIndex = 5;
            this.chkDeleteInvalidEntries.Text = "(Patch NSD) Delete non-existent entries from load lists";
            this.chkDeleteInvalidEntries.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkDeleteInvalidEntries.UseCustomBackColor = true;
            this.chkDeleteInvalidEntries.UseSelectable = true;
            this.chkDeleteInvalidEntries.CheckedChanged += new System.EventHandler(this.chkDeleteInvalidEntries_CheckedChanged);
            // 
            // chkUseAnimLinks
            // 
            this.chkUseAnimLinks.Checked = true;
            this.chkUseAnimLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseAnimLinks.Location = new System.Drawing.Point(15, 175);
            this.chkUseAnimLinks.Name = "chkUseAnimLinks";
            this.chkUseAnimLinks.Size = new System.Drawing.Size(255, 16);
            this.chkUseAnimLinks.TabIndex = 3;
            this.chkUseAnimLinks.Text = "(Crash 3) Used saved animation-model links";
            this.chkUseAnimLinks.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkUseAnimLinks.UseCustomBackColor = true;
            this.chkUseAnimLinks.UseSelectable = true;
            this.chkUseAnimLinks.CheckedChanged += new System.EventHandler(this.chkUseAnimLinks_CheckedChanged);
            // 
            // chkCollisionDisplay
            // 
            this.chkCollisionDisplay.Location = new System.Drawing.Point(15, 130);
            this.chkCollisionDisplay.Name = "chkCollisionDisplay";
            this.chkCollisionDisplay.Size = new System.Drawing.Size(198, 16);
            this.chkCollisionDisplay.TabIndex = 2;
            this.chkCollisionDisplay.Text = "Display frame collision by default";
            this.chkCollisionDisplay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkCollisionDisplay.UseCustomBackColor = true;
            this.chkCollisionDisplay.UseSelectable = true;
            this.chkCollisionDisplay.CheckedChanged += new System.EventHandler(this.chkCollisionDisplay_CheckedChanged);
            // 
            // chkNormalDisplay
            // 
            this.chkNormalDisplay.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkNormalDisplay.Location = new System.Drawing.Point(15, 106);
            this.chkNormalDisplay.Name = "chkNormalDisplay";
            this.chkNormalDisplay.Size = new System.Drawing.Size(107, 16);
            this.chkNormalDisplay.TabIndex = 0;
            this.chkNormalDisplay.Text = "Display normals";
            this.chkNormalDisplay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkNormalDisplay.UseCustomBackColor = true;
            this.chkNormalDisplay.UseSelectable = true;
            this.chkNormalDisplay.CheckedChanged += new System.EventHandler(this.chkNormalDisplay_CheckedChanged);
            // 
            // cmdReset
            // 
            this.cmdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdReset.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.cmdReset.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.cmdReset.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.cmdReset.Location = new System.Drawing.Point(530, 463);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(99, 25);
            this.cmdReset.TabIndex = 10;
            this.cmdReset.Text = "Reset Settings";
            this.cmdReset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmdReset.UseCustomBackColor = true;
            this.cmdReset.UseCustomForeColor = true;
            this.cmdReset.UseSelectable = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // chkDetailedCollision
            // 
            this.chkDetailedCollision.Location = new System.Drawing.Point(15, 153);
            this.chkDetailedCollision.Name = "chkDetailedCollision";
            this.chkDetailedCollision.Size = new System.Drawing.Size(190, 16);
            this.chkDetailedCollision.TabIndex = 11;
            this.chkDetailedCollision.Text = "Display detailed collision type";
            this.chkDetailedCollision.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkDetailedCollision.UseCustomBackColor = true;
            this.chkDetailedCollision.UseSelectable = true;
            this.chkDetailedCollision.CheckedChanged += new System.EventHandler(this.chkDetailedCollision_CheckedChanged);
            // 
            // tglKeyBinds
            // 
            this.tglKeyBinds.AutoSize = true;
            this.tglKeyBinds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.tglKeyBinds.Location = new System.Drawing.Point(15, 22);
            this.tglKeyBinds.Name = "tglKeyBinds";
            this.tglKeyBinds.Size = new System.Drawing.Size(80, 19);
            this.tglKeyBinds.Style = MetroFramework.MetroColorStyle.Blue;
            this.tglKeyBinds.TabIndex = 12;
            this.tglKeyBinds.Text = "Off";
            this.tglKeyBinds.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tglKeyBinds.UseCustomBackColor = true;
            this.tglKeyBinds.UseSelectable = true;
            this.tglKeyBinds.CheckedChanged += new System.EventHandler(this.TglKeyBinds_CheckedChanged);
            // 
            // fraKeyBinds
            // 
            this.fraKeyBinds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.fraKeyBinds.Controls.Add(this.tglKeyBinds);
            this.fraKeyBinds.Font = new System.Drawing.Font("Arial", 9F);
            this.fraKeyBinds.ForeColor = System.Drawing.SystemColors.Window;
            this.fraKeyBinds.Location = new System.Drawing.Point(15, 25);
            this.fraKeyBinds.Name = "fraKeyBinds";
            this.fraKeyBinds.Size = new System.Drawing.Size(162, 53);
            this.fraKeyBinds.TabIndex = 13;
            this.fraKeyBinds.TabStop = false;
            this.fraKeyBinds.Text = "Alternate Keybindings";
            // 
            // cmdShortcuts
            // 
            this.cmdShortcuts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.cmdShortcuts.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.cmdShortcuts.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.cmdShortcuts.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmdShortcuts.Location = new System.Drawing.Point(530, 12);
            this.cmdShortcuts.Name = "cmdShortcuts";
            this.cmdShortcuts.Size = new System.Drawing.Size(99, 25);
            this.cmdShortcuts.Style = MetroFramework.MetroColorStyle.Blue;
            this.cmdShortcuts.TabIndex = 14;
            this.cmdShortcuts.Text = "Shortcuts";
            this.cmdShortcuts.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmdShortcuts.UseCustomBackColor = true;
            this.cmdShortcuts.UseCustomForeColor = true;
            this.cmdShortcuts.UseSelectable = true;
            this.cmdShortcuts.Click += new System.EventHandler(this.cmdShortcuts_Click);
            // 
            // chkCustomCrates
            // 
            this.chkCustomCrates.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.chkCustomCrates.Location = new System.Drawing.Point(15, 251);
            this.chkCustomCrates.Name = "chkCustomCrates";
            this.chkCustomCrates.Size = new System.Drawing.Size(231, 16);
            this.chkCustomCrates.TabIndex = 15;
            this.chkCustomCrates.Text = "Display custom crates (modded BoxsC)";
            this.chkCustomCrates.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkCustomCrates.UseCustomBackColor = true;
            this.chkCustomCrates.UseCustomForeColor = true;
            this.chkCustomCrates.UseSelectable = true;
            this.chkCustomCrates.CheckedChanged += new System.EventHandler(this.ChkCustomCrates_CheckedChanged);
            // 
            // chkAnimViewPanel
            // 
            this.chkAnimViewPanel.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkAnimViewPanel.Location = new System.Drawing.Point(267, 106);
            this.chkAnimViewPanel.Name = "chkAnimViewPanel";
            this.chkAnimViewPanel.Size = new System.Drawing.Size(210, 15);
            this.chkAnimViewPanel.TabIndex = 16;
            this.chkAnimViewPanel.Text = "Separate the panel in FrameBox";
            this.chkAnimViewPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkAnimViewPanel.UseCustomBackColor = true;
            this.chkAnimViewPanel.UseSelectable = true;
            this.chkAnimViewPanel.CheckedChanged += new System.EventHandler(this.ChkAnimViewPanel_CheckedChanged);
            // 
            // fraGeneral
            // 
            this.fraGeneral.Controls.Add(this.fraExternalTools);
            this.fraGeneral.Controls.Add(this.fraFind);
            this.fraGeneral.Controls.Add(this.fraLang);
            this.fraGeneral.Controls.Add(this.chkCustomCrates);
            this.fraGeneral.Controls.Add(this.chkDeleteInvalidEntries);
            this.fraGeneral.Controls.Add(this.chkPatchNSDSavesNSF);
            this.fraGeneral.Controls.Add(this.chkOldPatchNSD);
            this.fraGeneral.Font = new System.Drawing.Font("Arial", 9F);
            this.fraGeneral.ForeColor = System.Drawing.SystemColors.Window;
            this.fraGeneral.Location = new System.Drawing.Point(3, 3);
            this.fraGeneral.Name = "fraGeneral";
            this.fraGeneral.Size = new System.Drawing.Size(521, 278);
            this.fraGeneral.TabIndex = 18;
            this.fraGeneral.TabStop = false;
            this.fraGeneral.Text = "General";
            // 
            // fraExternalTools
            // 
            this.fraExternalTools.Controls.Add(this.lblExportGoolDir);
            this.fraExternalTools.Controls.Add(this.txbExportGoolDir);
            this.fraExternalTools.Controls.Add(this.lblExternalToolsDir);
            this.fraExternalTools.Controls.Add(this.txbExternalToolsDir);
            this.fraExternalTools.Font = new System.Drawing.Font("Arial", 9F);
            this.fraExternalTools.ForeColor = System.Drawing.SystemColors.Window;
            this.fraExternalTools.Location = new System.Drawing.Point(15, 81);
            this.fraExternalTools.Name = "fraExternalTools";
            this.fraExternalTools.Size = new System.Drawing.Size(309, 81);
            this.fraExternalTools.TabIndex = 17;
            this.fraExternalTools.TabStop = false;
            this.fraExternalTools.Text = "(Default) Directories";
            // 
            // lblExportGoolDir
            // 
            this.lblExportGoolDir.AutoSize = true;
            this.lblExportGoolDir.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblExportGoolDir.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblExportGoolDir.Location = new System.Drawing.Point(6, 49);
            this.lblExportGoolDir.Name = "lblExportGoolDir";
            this.lblExportGoolDir.Size = new System.Drawing.Size(91, 19);
            this.lblExportGoolDir.TabIndex = 3;
            this.lblExportGoolDir.Text = "Export GOOL";
            this.lblExportGoolDir.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblExportGoolDir.UseCustomBackColor = true;
            // 
            // txbExportGoolDir
            // 
            // 
            // 
            // 
            this.txbExportGoolDir.CustomButton.Image = null;
            this.txbExportGoolDir.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.txbExportGoolDir.CustomButton.Name = "";
            this.txbExportGoolDir.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbExportGoolDir.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbExportGoolDir.CustomButton.TabIndex = 1;
            this.txbExportGoolDir.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbExportGoolDir.CustomButton.UseSelectable = true;
            this.txbExportGoolDir.CustomButton.Visible = false;
            this.txbExportGoolDir.Lines = new string[0];
            this.txbExportGoolDir.Location = new System.Drawing.Point(114, 49);
            this.txbExportGoolDir.MaxLength = 32767;
            this.txbExportGoolDir.Name = "txbExportGoolDir";
            this.txbExportGoolDir.PasswordChar = '\0';
            this.txbExportGoolDir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbExportGoolDir.SelectedText = "";
            this.txbExportGoolDir.SelectionLength = 0;
            this.txbExportGoolDir.SelectionStart = 0;
            this.txbExportGoolDir.ShortcutsEnabled = true;
            this.txbExportGoolDir.Size = new System.Drawing.Size(189, 23);
            this.txbExportGoolDir.TabIndex = 2;
            this.txbExportGoolDir.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txbExportGoolDir.UseSelectable = true;
            this.txbExportGoolDir.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbExportGoolDir.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblExternalToolsDir
            // 
            this.lblExternalToolsDir.AutoSize = true;
            this.lblExternalToolsDir.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblExternalToolsDir.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblExternalToolsDir.Location = new System.Drawing.Point(6, 20);
            this.lblExternalToolsDir.Name = "lblExternalToolsDir";
            this.lblExternalToolsDir.Size = new System.Drawing.Size(92, 19);
            this.lblExternalToolsDir.TabIndex = 1;
            this.lblExternalToolsDir.Text = "External Tools";
            this.lblExternalToolsDir.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblExternalToolsDir.UseCustomBackColor = true;
            // 
            // txbExternalToolsDir
            // 
            // 
            // 
            // 
            this.txbExternalToolsDir.CustomButton.Image = null;
            this.txbExternalToolsDir.CustomButton.Location = new System.Drawing.Point(167, 1);
            this.txbExternalToolsDir.CustomButton.Name = "";
            this.txbExternalToolsDir.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txbExternalToolsDir.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbExternalToolsDir.CustomButton.TabIndex = 1;
            this.txbExternalToolsDir.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbExternalToolsDir.CustomButton.UseSelectable = true;
            this.txbExternalToolsDir.CustomButton.Visible = false;
            this.txbExternalToolsDir.Lines = new string[0];
            this.txbExternalToolsDir.Location = new System.Drawing.Point(114, 20);
            this.txbExternalToolsDir.MaxLength = 32767;
            this.txbExternalToolsDir.Name = "txbExternalToolsDir";
            this.txbExternalToolsDir.PasswordChar = '\0';
            this.txbExternalToolsDir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbExternalToolsDir.SelectedText = "";
            this.txbExternalToolsDir.SelectionLength = 0;
            this.txbExternalToolsDir.SelectionStart = 0;
            this.txbExternalToolsDir.ShortcutsEnabled = true;
            this.txbExternalToolsDir.Size = new System.Drawing.Size(189, 23);
            this.txbExternalToolsDir.TabIndex = 0;
            this.txbExternalToolsDir.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txbExternalToolsDir.UseSelectable = true;
            this.txbExternalToolsDir.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbExternalToolsDir.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // fraFind
            // 
            this.fraFind.Controls.Add(this.chkFindWrap);
            this.fraFind.ForeColor = System.Drawing.SystemColors.Window;
            this.fraFind.Location = new System.Drawing.Point(183, 22);
            this.fraFind.Name = "fraFind";
            this.fraFind.Size = new System.Drawing.Size(112, 53);
            this.fraFind.TabIndex = 16;
            this.fraFind.TabStop = false;
            this.fraFind.Text = "Find";
            // 
            // chkFindWrap
            // 
            this.chkFindWrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chkFindWrap.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkFindWrap.Location = new System.Drawing.Point(6, 20);
            this.chkFindWrap.Name = "chkFindWrap";
            this.chkFindWrap.Size = new System.Drawing.Size(104, 18);
            this.chkFindWrap.TabIndex = 0;
            this.chkFindWrap.Text = "Wrap around";
            this.chkFindWrap.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkFindWrap.UseCustomBackColor = true;
            this.chkFindWrap.UseSelectable = true;
            this.chkFindWrap.CheckedChanged += new System.EventHandler(this.chkFindWrap_CheckedChanged);
            // 
            // fra3dViewer
            // 
            this.fra3dViewer.Controls.Add(this.fraKeyBinds);
            this.fra3dViewer.Controls.Add(this.fraClearCol);
            this.fra3dViewer.Controls.Add(this.fraAnimGrid);
            this.fra3dViewer.Controls.Add(this.chkAnimViewPanel);
            this.fra3dViewer.Controls.Add(this.chkNormalDisplay);
            this.fra3dViewer.Controls.Add(this.chkCollisionDisplay);
            this.fra3dViewer.Controls.Add(this.chkUseAnimLinks);
            this.fra3dViewer.Controls.Add(this.chkDetailedCollision);
            this.fra3dViewer.Font = new System.Drawing.Font("Arial", 9F);
            this.fra3dViewer.ForeColor = System.Drawing.SystemColors.Window;
            this.fra3dViewer.Location = new System.Drawing.Point(3, 287);
            this.fra3dViewer.Name = "fra3dViewer";
            this.fra3dViewer.Size = new System.Drawing.Size(521, 201);
            this.fra3dViewer.TabIndex = 19;
            this.fra3dViewer.TabStop = false;
            this.fra3dViewer.Text = "3D Viewer";
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnEidConvert
            // 
            this.btnEidConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEidConvert.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnEidConvert.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnEidConvert.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEidConvert.Location = new System.Drawing.Point(530, 43);
            this.btnEidConvert.Name = "btnEidConvert";
            this.btnEidConvert.Size = new System.Drawing.Size(99, 25);
            this.btnEidConvert.TabIndex = 20;
            this.btnEidConvert.Text = "EID convert";
            this.btnEidConvert.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnEidConvert.UseCustomBackColor = true;
            this.btnEidConvert.UseSelectable = true;
            this.btnEidConvert.Click += new System.EventHandler(this.btnEidConvert_Click);
            // 
            // ConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.btnEidConvert);
            this.Controls.Add(this.fra3dViewer);
            this.Controls.Add(this.fraGeneral);
            this.Controls.Add(this.cmdShortcuts);
            this.Controls.Add(this.cmdReset);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Name = "ConfigEditor";
            this.Size = new System.Drawing.Size(639, 491);
            this.fraLang.ResumeLayout(false);
            this.fraClearCol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClearCol)).EndInit();
            this.fraAnimGrid.ResumeLayout(false);
            this.fraAnimGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAnimGrid)).EndInit();
            this.fraKeyBinds.ResumeLayout(false);
            this.fraKeyBinds.PerformLayout();
            this.fraGeneral.ResumeLayout(false);
            this.fraExternalTools.ResumeLayout(false);
            this.fraExternalTools.PerformLayout();
            this.fraFind.ResumeLayout(false);
            this.fra3dViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox dpdLang;
        private System.Windows.Forms.GroupBox fraLang;
        private MetroFramework.Controls.MetroCheckBox chkNormalDisplay;
        private MetroFramework.Controls.MetroCheckBox chkCollisionDisplay;
        private MetroFramework.Controls.MetroCheckBox chkUseAnimLinks;
        private System.Windows.Forms.ColorDialog cdlClearCol;
        private System.Windows.Forms.GroupBox fraClearCol;
        private System.Windows.Forms.PictureBox picClearCol;
        private MetroFramework.Controls.MetroCheckBox chkDeleteInvalidEntries;
        private System.Windows.Forms.GroupBox fraAnimGrid;
        private DarkUI.Controls.DarkNumericUpDown numAnimGrid;
        private System.Windows.Forms.Label lblAnimGrid;
        private MetroFramework.Controls.MetroCheckBox chkAnimGrid;
        private DarkUI.Controls.DarkButton cmdClearCol;
        private MetroFramework.Controls.MetroCheckBox chkPatchNSDSavesNSF;
        private MetroFramework.Controls.MetroCheckBox chkOldPatchNSD;
        private MetroFramework.Controls.MetroButton cmdReset;
        private MetroFramework.Controls.MetroCheckBox chkDetailedCollision;
        private System.Windows.Forms.GroupBox fraKeyBinds;
        private MetroFramework.Controls.MetroButton cmdShortcuts;
        private MetroFramework.Controls.MetroToggle tglKeyBinds;
        private MetroFramework.Controls.MetroCheckBox chkCustomCrates;
        private MetroFramework.Controls.MetroCheckBox chkAnimViewPanel;
        private System.Windows.Forms.GroupBox fraGeneral;
        private System.Windows.Forms.GroupBox fra3dViewer;
        private System.Windows.Forms.GroupBox fraFind;
        private MetroFramework.Controls.MetroCheckBox chkFindWrap;
        private System.Windows.Forms.GroupBox fraExternalTools;
        private MetroFramework.Controls.MetroTextBox txbExternalToolsDir;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MetroFramework.Controls.MetroLabel lblExternalToolsDir;
        private MetroFramework.Controls.MetroLabel lblExportGoolDir;
        private MetroFramework.Controls.MetroTextBox txbExportGoolDir;
        private MetroFramework.Controls.MetroButton btnEidConvert;
    }
}
