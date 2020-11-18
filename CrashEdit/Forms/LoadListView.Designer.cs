namespace CrashEdit.Forms
{
    partial class LoadListView
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
            this.tvwLoadList = new DarkUI.Controls.DarkTreeView();
            this.btnRefresh = new DarkUI.Controls.DarkButton();
            this.SuspendLayout();
            // 
            // tvwLoadList
            // 
            this.tvwLoadList.Location = new System.Drawing.Point(12, 41);
            this.tvwLoadList.MaxDragChange = 20;
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
            // LoadListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 566);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tvwLoadList);
            this.Name = "LoadListView";
            this.Text = "LoadListView";
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkTreeView tvwLoadList;
        private DarkUI.Controls.DarkButton btnRefresh;
    }
}