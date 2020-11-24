namespace CrashEdit.Forms
{
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Windows.Forms;
    using DarkUI.Controls;

    sealed partial class DrawListView
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
            this.tvwDrawList = new System.Windows.Forms.TreeView();
            this.btnRefresh = new DarkUI.Controls.DarkButton();
            this.txbFilter = new DarkUI.Controls.DarkTextBox();
            this.lblFilter = new DarkUI.Controls.DarkLabel();
            this.dpdFilter = new DarkUI.Controls.DarkDropdownList();
            this.btnExpandTree = new DarkUI.Controls.DarkButton();
            this.btnCollapseTree = new DarkUI.Controls.DarkButton();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.darkSeparator2 = new DarkUI.Controls.DarkSeparator();
            this.SuspendLayout();
            // 
            // tvwDrawList
            // 
            this.tvwDrawList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.tvwDrawList.Font = new System.Drawing.Font("Arial", 9F);
            this.tvwDrawList.ForeColor = System.Drawing.SystemColors.Window;
            this.tvwDrawList.LineColor = System.Drawing.Color.BlanchedAlmond;
            this.tvwDrawList.Location = new System.Drawing.Point(12, 41);
            this.tvwDrawList.Name = "tvwDrawList";
            this.tvwDrawList.Size = new System.Drawing.Size(492, 513);
            this.tvwDrawList.TabIndex = 0;
            this.tvwDrawList.Text = "darkTreeView1";
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
            this.txbFilter.Location = new System.Drawing.Point(336, 15);
            this.txbFilter.Name = "txbFilter";
            this.txbFilter.Size = new System.Drawing.Size(100, 20);
            this.txbFilter.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblFilter.Location = new System.Drawing.Point(296, 16);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(34, 15);
            this.lblFilter.TabIndex = 3;
            this.lblFilter.Text = "Filter";
            // 
            // dpdFilter
            // 
            this.dpdFilter.Location = new System.Drawing.Point(442, 12);
            this.dpdFilter.Name = "dpdFilter";
            this.dpdFilter.Size = new System.Drawing.Size(63, 23);
            this.dpdFilter.TabIndex = 4;
            this.dpdFilter.Text = "darkDropdownList1";
            // 
            // btnExpandTree
            // 
            this.btnExpandTree.Location = new System.Drawing.Point(109, 12);
            this.btnExpandTree.Name = "btnExpandTree";
            this.btnExpandTree.Padding = new System.Windows.Forms.Padding(5);
            this.btnExpandTree.Size = new System.Drawing.Size(75, 23);
            this.btnExpandTree.TabIndex = 5;
            this.btnExpandTree.Text = "Expand";
            this.btnExpandTree.Click += new System.EventHandler(this.btnExpandTree_Click);
            // 
            // btnCollapseTree
            // 
            this.btnCollapseTree.Location = new System.Drawing.Point(190, 12);
            this.btnCollapseTree.Name = "btnCollapseTree";
            this.btnCollapseTree.Padding = new System.Windows.Forms.Padding(5);
            this.btnCollapseTree.Size = new System.Drawing.Size(75, 23);
            this.btnCollapseTree.TabIndex = 6;
            this.btnCollapseTree.Text = "Collapse";
            this.btnCollapseTree.Click += new System.EventHandler(this.btnCollapseTree_Click);
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 0);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(516, 2);
            this.darkSeparator1.TabIndex = 1;
            // 
            // darkSeparator2
            // 
            this.darkSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator2.Location = new System.Drawing.Point(0, 2);
            this.darkSeparator2.Name = "darkSeparator2";
            this.darkSeparator2.Size = new System.Drawing.Size(516, 2);
            this.darkSeparator2.TabIndex = 0;
            // 
            // DrawListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 566);
            this.Controls.Add(this.darkSeparator2);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.btnCollapseTree);
            this.Controls.Add(this.btnExpandTree);
            this.Controls.Add(this.dpdFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.txbFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tvwDrawList);
            this.Name = "DrawListView";
            this.Text = "Draw List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView tvwDrawList;
        private DarkUI.Controls.DarkButton btnRefresh;
        private DarkUI.Controls.DarkTextBox txbFilter;
        private DarkUI.Controls.DarkLabel lblFilter;
        private DarkUI.Controls.DarkDropdownList dpdFilter;
        private DarkButton btnExpandTree;
        private DarkButton btnCollapseTree;
        private DarkSeparator darkSeparator1;
        private DarkSeparator darkSeparator2;
    }
}