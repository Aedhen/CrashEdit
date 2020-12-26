namespace CrashEdit.Forms
{
    partial class EidConvertWindow
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
            this.txbEidInt = new DarkUI.Controls.DarkTextBox();
            this.lblEid = new DarkUI.Controls.DarkLabel();
            this.lblEidInt = new DarkUI.Controls.DarkLabel();
            this.lblHex = new DarkUI.Controls.DarkLabel();
            this.lblEname = new DarkUI.Controls.DarkLabel();
            this.txbEidHex = new DarkUI.Controls.DarkTextBox();
            this.txbEname = new DarkUI.Controls.DarkTextBox();
            this.btnIntToName = new DarkUI.Controls.DarkButton();
            this.btnHexToName = new DarkUI.Controls.DarkButton();
            this.btnNameToNum = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // txbEidInt
            // 
            this.txbEidInt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txbEidInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbEidInt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txbEidInt.Location = new System.Drawing.Point(47, 25);
            this.txbEidInt.Name = "txbEidInt";
            this.txbEidInt.Size = new System.Drawing.Size(100, 20);
            this.txbEidInt.TabIndex = 0;
            // 
            // lblEid
            // 
            this.lblEid.AutoSize = true;
            this.lblEid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblEid.Location = new System.Drawing.Point(44, 9);
            this.lblEid.Name = "lblEid";
            this.lblEid.Size = new System.Drawing.Size(25, 13);
            this.lblEid.TabIndex = 1;
            this.lblEid.Text = "EID";
            // 
            // lblEidInt
            // 
            this.lblEidInt.AutoSize = true;
            this.lblEidInt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblEidInt.Location = new System.Drawing.Point(7, 27);
            this.lblEidInt.Name = "lblEidInt";
            this.lblEidInt.Size = new System.Drawing.Size(19, 13);
            this.lblEidInt.TabIndex = 2;
            this.lblEidInt.Text = "Int";
            // 
            // lblHex
            // 
            this.lblHex.AutoSize = true;
            this.lblHex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblHex.Location = new System.Drawing.Point(7, 53);
            this.lblHex.Name = "lblHex";
            this.lblHex.Size = new System.Drawing.Size(26, 13);
            this.lblHex.TabIndex = 3;
            this.lblHex.Text = "Hex";
            // 
            // lblEname
            // 
            this.lblEname.AutoSize = true;
            this.lblEname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblEname.Location = new System.Drawing.Point(216, 9);
            this.lblEname.Name = "lblEname";
            this.lblEname.Size = new System.Drawing.Size(42, 13);
            this.lblEname.TabIndex = 4;
            this.lblEname.Text = "EName";
            // 
            // txbEidHex
            // 
            this.txbEidHex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txbEidHex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbEidHex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txbEidHex.Location = new System.Drawing.Point(47, 51);
            this.txbEidHex.Name = "txbEidHex";
            this.txbEidHex.Size = new System.Drawing.Size(100, 20);
            this.txbEidHex.TabIndex = 5;
            // 
            // txbEname
            // 
            this.txbEname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txbEname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbEname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txbEname.Location = new System.Drawing.Point(219, 37);
            this.txbEname.Name = "txbEname";
            this.txbEname.Size = new System.Drawing.Size(100, 20);
            this.txbEname.TabIndex = 6;
            // 
            // btnIntToName
            // 
            this.btnIntToName.Location = new System.Drawing.Point(153, 25);
            this.btnIntToName.Name = "btnIntToName";
            this.btnIntToName.Padding = new System.Windows.Forms.Padding(5);
            this.btnIntToName.Size = new System.Drawing.Size(27, 20);
            this.btnIntToName.TabIndex = 7;
            this.btnIntToName.Text = ">";
            this.btnIntToName.Click += new System.EventHandler(this.btnIntToName_Click);
            // 
            // btnHexToName
            // 
            this.btnHexToName.Location = new System.Drawing.Point(153, 51);
            this.btnHexToName.Name = "btnHexToName";
            this.btnHexToName.Padding = new System.Windows.Forms.Padding(5);
            this.btnHexToName.Size = new System.Drawing.Size(27, 20);
            this.btnHexToName.TabIndex = 8;
            this.btnHexToName.Text = ">";
            this.btnHexToName.Click += new System.EventHandler(this.btnHexToName_Click);
            // 
            // btnNameToNum
            // 
            this.btnNameToNum.Location = new System.Drawing.Point(186, 37);
            this.btnNameToNum.Name = "btnNameToNum";
            this.btnNameToNum.Padding = new System.Windows.Forms.Padding(5);
            this.btnNameToNum.Size = new System.Drawing.Size(27, 20);
            this.btnNameToNum.TabIndex = 9;
            this.btnNameToNum.Text = "<";
            this.btnNameToNum.Click += new System.EventHandler(this.btnNameToNum_Click);
            // 
            // EidConvertWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 87);
            this.Controls.Add(this.btnNameToNum);
            this.Controls.Add(this.btnHexToName);
            this.Controls.Add(this.btnIntToName);
            this.Controls.Add(this.txbEname);
            this.Controls.Add(this.txbEidHex);
            this.Controls.Add(this.lblEname);
            this.Controls.Add(this.lblHex);
            this.Controls.Add(this.lblEidInt);
            this.Controls.Add(this.lblEid);
            this.Controls.Add(this.txbEidInt);
            this.Name = "EidConvertWindow";
            this.Text = "EidConvertWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkTextBox txbEidInt;
        private DarkUI.Controls.DarkLabel lblEid;
        private DarkUI.Controls.DarkLabel lblEidInt;
        private DarkUI.Controls.DarkLabel lblHex;
        private DarkUI.Controls.DarkLabel lblEname;
        private DarkUI.Controls.DarkTextBox txbEidHex;
        private DarkUI.Controls.DarkTextBox txbEname;
        private DarkUI.Controls.DarkButton btnIntToName;
        private DarkUI.Controls.DarkButton btnHexToName;
        private DarkUI.Controls.DarkButton btnNameToNum;
    }
}