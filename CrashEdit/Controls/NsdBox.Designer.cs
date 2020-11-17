﻿namespace CrashEdit.Controls
{
    partial class NsdBox
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
            this.lblZ = new DarkUI.Controls.DarkLabel();
            this.lblY = new DarkUI.Controls.DarkLabel();
            this.lblX = new DarkUI.Controls.DarkLabel();
            this.lstSpawnPoints = new DarkUI.Controls.DarkListView();
            this.gpbSpawnPoints = new System.Windows.Forms.GroupBox();
            this.numZ = new DarkUI.Controls.DarkNumericUpDown();
            this.numY = new DarkUI.Controls.DarkNumericUpDown();
            this.numX = new DarkUI.Controls.DarkNumericUpDown();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.txbName = new DarkUI.Controls.DarkTextBox();
            this.lblName = new DarkUI.Controls.DarkLabel();
            this.gpbSpawnPoints.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).BeginInit();
            this.SuspendLayout();
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lblZ.Font = new System.Drawing.Font("Arial", 9F);
            this.lblZ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblZ.Location = new System.Drawing.Point(7, 192);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(14, 15);
            this.lblZ.TabIndex = 3;
            this.lblZ.Text = "Z";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lblY.Font = new System.Drawing.Font("Arial", 9F);
            this.lblY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblY.Location = new System.Drawing.Point(7, 166);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(14, 15);
            this.lblY.TabIndex = 2;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(40)))));
            this.lblX.Font = new System.Drawing.Font("Arial", 9F);
            this.lblX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblX.Location = new System.Drawing.Point(7, 139);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(14, 15);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X";
            // 
            // lstSpawnPoints
            // 
            this.lstSpawnPoints.Location = new System.Drawing.Point(10, 20);
            this.lstSpawnPoints.Name = "lstSpawnPoints";
            this.lstSpawnPoints.Size = new System.Drawing.Size(164, 84);
            this.lstSpawnPoints.TabIndex = 0;
            // 
            // gpbSpawnPoints
            // 
            this.gpbSpawnPoints.Controls.Add(this.lblName);
            this.gpbSpawnPoints.Controls.Add(this.txbName);
            this.gpbSpawnPoints.Controls.Add(this.lblY);
            this.gpbSpawnPoints.Controls.Add(this.lblZ);
            this.gpbSpawnPoints.Controls.Add(this.numZ);
            this.gpbSpawnPoints.Controls.Add(this.numY);
            this.gpbSpawnPoints.Controls.Add(this.numX);
            this.gpbSpawnPoints.Controls.Add(this.lblX);
            this.gpbSpawnPoints.Controls.Add(this.lstSpawnPoints);
            this.gpbSpawnPoints.Font = new System.Drawing.Font("Arial", 9F);
            this.gpbSpawnPoints.ForeColor = System.Drawing.SystemColors.Window;
            this.gpbSpawnPoints.Location = new System.Drawing.Point(3, 3);
            this.gpbSpawnPoints.Name = "gpbSpawnPoints";
            this.gpbSpawnPoints.Size = new System.Drawing.Size(186, 220);
            this.gpbSpawnPoints.TabIndex = 2;
            this.gpbSpawnPoints.TabStop = false;
            this.gpbSpawnPoints.Text = "Spawn Points";
            // 
            // numZ
            // 
            this.numZ.Location = new System.Drawing.Point(54, 190);
            this.numZ.Maximum = new decimal(new int[] {
            327670000,
            0,
            0,
            0});
            this.numZ.Minimum = new decimal(new int[] {
            327670000,
            0,
            0,
            -2147483648});
            this.numZ.Name = "numZ";
            this.numZ.Size = new System.Drawing.Size(120, 21);
            this.numZ.TabIndex = 3;
            // 
            // numY
            // 
            this.numY.Location = new System.Drawing.Point(54, 164);
            this.numY.Maximum = new decimal(new int[] {
            327670000,
            0,
            0,
            0});
            this.numY.Minimum = new decimal(new int[] {
            327670000,
            0,
            0,
            -2147483648});
            this.numY.Name = "numY";
            this.numY.Size = new System.Drawing.Size(120, 21);
            this.numY.TabIndex = 2;
            // 
            // numX
            // 
            this.numX.Location = new System.Drawing.Point(54, 137);
            this.numX.Maximum = new decimal(new int[] {
            327670000,
            0,
            0,
            0});
            this.numX.Minimum = new decimal(new int[] {
            327670000,
            0,
            0,
            -2147483648});
            this.numX.Name = "numX";
            this.numX.Size = new System.Drawing.Size(120, 21);
            this.numX.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(424, 436);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txbName
            // 
            this.txbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txbName.Location = new System.Drawing.Point(54, 110);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(120, 21);
            this.txbName.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblName.Location = new System.Drawing.Point(7, 112);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 15);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Zone";
            // 
            // NsdBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gpbSpawnPoints);
            this.Name = "NsdBox";
            this.Size = new System.Drawing.Size(502, 462);
            this.gpbSpawnPoints.ResumeLayout(false);
            this.gpbSpawnPoints.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DarkUI.Controls.DarkListView lstSpawnPoints;
        private DarkUI.Controls.DarkLabel lblZ;
        private DarkUI.Controls.DarkLabel lblY;
        private DarkUI.Controls.DarkLabel lblX;
        private System.Windows.Forms.GroupBox gpbSpawnPoints;
        private DarkUI.Controls.DarkNumericUpDown numZ;
        private DarkUI.Controls.DarkNumericUpDown numY;
        private DarkUI.Controls.DarkNumericUpDown numX;
        private DarkUI.Controls.DarkButton btnSave;
        private DarkUI.Controls.DarkLabel lblName;
        private DarkUI.Controls.DarkTextBox txbName;
    }
}
