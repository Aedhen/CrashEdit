namespace CrashEdit.Forms
{
    using System.Windows.Forms;

    sealed partial class LoadListView
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
            this.tvwLoadList = new System.Windows.Forms.TreeView();
            this.btnRefresh = new DarkUI.Controls.DarkButton();
            this.txbFilter = new DarkUI.Controls.DarkTextBox();
            this.lblFilter = new DarkUI.Controls.DarkLabel();
            this.SuspendLayout();
            // 
            // tvwLoadList
            // 
            this.tvwLoadList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.tvwLoadList.Font = new System.Drawing.Font("Arial", 9F);
            this.tvwLoadList.ForeColor = System.Drawing.SystemColors.Window;
            this.tvwLoadList.LineColor = System.Drawing.Color.BlanchedAlmond;
            this.tvwLoadList.Location = new System.Drawing.Point(12, 41);
            this.tvwLoadList.Name = "tvwLoadList";
            this.tvwLoadList.Size = new System.Drawing.Size(492, 513);
            this.tvwLoadList.TabIndex = 0;
            this.tvwLoadList.Text = "darkTreeView1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txbFilter
            // 
            this.txbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txbFilter.Location = new System.Drawing.Point(159, 15);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(100, 20);
            this.txbFilter.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblFilter.Location = new System.Drawing.Point(119, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(34, 15);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Filter";
            // 
            // LoadListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 566);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txbFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tvwLoadList);
            this.Name = "LoadListView";
            this.Text = "LoadListView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView tvwLoadList;
        private DarkUI.Controls.DarkButton btnRefresh;
        private DarkUI.Controls.DarkTextBox txbFilter;
        private DarkUI.Controls.DarkLabel lblFilter;
    }
}