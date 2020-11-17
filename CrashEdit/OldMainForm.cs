using Crash;
using Crash.UI;
using CrashEdit.Forms;
using CrashEdit.Properties;
using DiscUtils.Iso9660;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using MetroFramework.Controls;

namespace CrashEdit
{
    using CrashEdit.Helpers;

    public sealed class OldMainForm : DarkForm
    {
        private static ImageList imglist;

        static OldMainForm()
        {
            imglist = new ImageList { ColorDepth = ColorDepth.Depth32Bit };
            try
            {
                imglist.Images.Add("default",OldResources.FileImage);
                imglist.Images.Add("tb_open",OldResources.OpenImage);
                imglist.Images.Add("tb_save",OldResources.SaveImage);
                imglist.Images.Add("tb_patchnsd",OldResources.SaveImage2);
                imglist.Images.Add("tb_close",OldResources.FolderImage);
                imglist.Images.Add("tb_find",OldResources.BinocularsImage);
                imglist.Images.Add("tb_findnext",OldResources.BinocularsNextImage);
            }
            catch
            {
                imglist.Images.Clear();
            }
        }

        private DarkMenuStrip msMenu;
        private ToolStripMenuItem mnuOpen;
        private ToolStripMenuItem mnuSave;
        private ToolStripMenuItem mnuPatchNSD;
        private ToolStripMenuItem mnuClose;
        private ToolStripMenuItem mnuFind;
        private ToolStripMenuItem mnuFindNext;
        private ToolStripMenuItem mnuPlay;
        private DarkToolStrip tsToolbar;
        private ToolStripButton tbbOpen;
        private ToolStripButton tbbSave;
        private ToolStripButton tbbPatchNSD;
        private ToolStripButton tbbClose;
        private ToolStripButton tbbFind;
        private ToolStripButton tbbFindNext;
        private ToolStripMenuItem tbxMakeBIN;
        private ToolStripMenuItem tbxMakeBINUSA;
        private ToolStripMenuItem tbxMakeBINEUR;
        private ToolStripMenuItem tbxMakeBINJAP;
        private ToolStripMenuItem tbxConvertVHVB;
        private ToolStripMenuItem tbxConvertVAB;
        private ToolStripDropDownButton tbbExtra;
        private ToolStripButton tbbPlay;
        private MetroTabControl tbcTabs;
        private GameVersionForm dlgGameVersion;
        private ToolStripButton tbbPAL;
        //private MetroTextBox txtInput;
        private ToolStripTextBox txtInput;

        private FolderBrowserDialog dlgMakeBINDir = new FolderBrowserDialog();
        private SaveFileDialog dlgMakeBINFile = new SaveFileDialog();

        private BackgroundWorker bgwMakeBIN;
        private ProgressBarForm dlgProgress;

        private static bool PAL = Settings.Default.PAL;
        private const int RateNTSC = 30;
        private const int RatePAL = 25;

        public string Input => txtInput.Text;
        private static bool changetext = true;

        public OldMainForm()
        {
            tbbOpen = new ToolStripButton
            {
                //Text = Resources.Toolbar_Open,
                ToolTipText = "Open (Ctrl+O)",
                ImageKey = "tb_open",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbOpen.Click += new EventHandler(tbbOpen_Click);
            tbbOpen.Size = new Size(48, 40);

            tbbSave = new ToolStripButton
            {
                //Text = Resources.Toolbar_Save,
                ToolTipText = "Save (Ctrl+Shift+S)",
                ImageKey = "tb_save",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbSave.Click += new EventHandler(tbbSave_Click);
            tbbSave.Size = new Size(48, 40);

            tbbPatchNSD = new ToolStripButton
            {
                //Text = Resources.Toolbar_PatchNSD,
                ToolTipText = "Patch NSD (Ctrl+S)",
                ImageKey = "tb_patchnsd",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbPatchNSD.Click += new EventHandler(tbbPatchNSD_Click);
            tbbPatchNSD.Size = new Size(64, 40);

            tbbClose = new ToolStripButton
            {
                ToolTipText = "Close (Ctrl+Shift+C)",
                ImageKey = "tb_close",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbClose.Click += new EventHandler(tbbClose_Click);
            tbbClose.Size = new Size(48, 40);

            tbbFind = new ToolStripButton
            {
                ToolTipText = "Find (Ctrl+F / Enter / Ctrl+Enter)",
                ImageKey = "tb_find",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbFind.Click += new EventHandler(tbbFind_Click);
            tbbFind.Size = new Size(64, 39);

            tbbFindNext = new ToolStripButton
            {
                ToolTipText = "Find Next (F3)",
                ImageKey = "tb_findnext",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbFindNext.Click += new EventHandler(tbbFindNext_Click);
            tbbFindNext.Size = new Size(64, 40);
            tbbFindNext.BackColor = Color.FromArgb(30, 30, 30);
            tbbFindNext.ForeColor = SystemColors.Control;

            tbxMakeBIN = new ToolStripMenuItem();
            tbxMakeBIN.Text = Resources.OldMainForm_tbxMakeBIN;
            tbxMakeBIN.Click += new EventHandler(tbxMakeBIN_Click);
            tbxMakeBIN.BackColor = Color.FromArgb(30, 30, 30);
            tbxMakeBIN.ForeColor = SystemColors.Control;

            tbxMakeBINUSA = new ToolStripMenuItem();
            tbxMakeBINUSA.Text = Resources.OldMainForm_tbxMakeBINUSA;
            tbxMakeBINUSA.Click += new EventHandler(tbxMakeBIN_Click);
            tbxMakeBINUSA.BackColor = Color.FromArgb(30, 30, 30);
            tbxMakeBINUSA.ForeColor = SystemColors.Control;

            tbxMakeBINEUR = new ToolStripMenuItem();
            tbxMakeBINEUR.Text = Resources.OldMainForm_tbxMakeBINEUR;
            tbxMakeBINEUR.Click += new EventHandler(tbxMakeBIN_Click);
            tbxMakeBINEUR.BackColor = Color.FromArgb(30, 30, 30);
            tbxMakeBINEUR.ForeColor = SystemColors.Control;

            tbxMakeBINJAP = new ToolStripMenuItem();
            tbxMakeBINJAP.Text = Resources.OldMainForm_tbxMakeBINJAP;
            tbxMakeBINJAP.Click += new EventHandler(tbxMakeBIN_Click);
            tbxMakeBINJAP.BackColor = Color.FromArgb(30, 30, 30);
            tbxMakeBINJAP.ForeColor = SystemColors.Control;

            tbxConvertVHVB = new ToolStripMenuItem();
            tbxConvertVHVB.Text = Resources.OldMainForm_tbxConvertVHVB;
            tbxConvertVHVB.Click += new EventHandler(tbxConvertVHVB_Click);
            tbxConvertVHVB.BackColor = Color.FromArgb(30, 30, 30);
            tbxConvertVHVB.ForeColor = SystemColors.Control;

            tbxConvertVAB = new ToolStripMenuItem();
            tbxConvertVAB.Text = Resources.OldMainForm_tbxConvertVAB;
            tbxConvertVAB.Click += new EventHandler(tbxConvertVAB_Click);
            tbxConvertVAB.BackColor = Color.FromArgb(30, 30, 30);
            tbxConvertVAB.ForeColor = SystemColors.Control;

            tbbExtra = new ToolStripDropDownButton();
            tbbExtra.Text = Resources.OldMainForm_tbbExtra;
            tbbExtra.DropDown.Items.Add(tbxMakeBIN);
            tbbExtra.DropDown.Items.Add(tbxMakeBINUSA);
            tbbExtra.DropDown.Items.Add(tbxMakeBINEUR);
            tbbExtra.DropDown.Items.Add(tbxMakeBINJAP);
            tbbExtra.DropDown.Items.Add("-");
            tbbExtra.DropDown.Items.Add(tbxConvertVHVB);
            tbbExtra.DropDown.Items.Add(tbxConvertVAB);
            tbbExtra.Size = new Size(56, 40);

            tbbPAL = new ToolStripButton
            {
                Text = "PAL",
                TextImageRelation = TextImageRelation.ImageAboveText,
                Checked = Settings.Default.PAL,
                CheckOnClick = true
            };
            tbbPAL.Click += new EventHandler(tbbPAL_Click);
            tbbPAL.Size = new Size(40, 40);

            tbbPlay = new ToolStripButton
            {
                Text = "Play",
                ToolTipText = "Play (F1)",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbPlay.Click += new EventHandler(tbbPlay_Click);
            tbbPlay.Size = new Size(40, 40);

            txtInput = new ToolStripTextBox
            {
                Size = new Size(64, 20),
                BackColor = Color.FromArgb(35, 35, 38),
                Text = "Find",
                ToolTipText = "Find (Ctrl+F / Enter / Ctrl+Enter)",
                Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel)
            };
            txtInput.TextChanged += new EventHandler(txtInput_Change);
            txtInput.Click += new EventHandler(txtInput_Click);
            txtInput.KeyDown += new KeyEventHandler(txtInput_KeyDown);
            txtInput.KeyPress += new KeyPressEventHandler(txtInput_KeyPress);

            tsToolbar = new DarkToolStrip
            {
                Dock = DockStyle.Top,
                ImageList = imglist
            };
            tsToolbar.Size = new Size(747, 40);
            tsToolbar.GripStyle = ToolStripGripStyle.Hidden;
            tsToolbar.Items.Add(tbbOpen);
            tsToolbar.Items.Add(tbbSave);
            tsToolbar.Items.Add(tbbPatchNSD);
            tsToolbar.Items.Add(tbbClose);
            tsToolbar.Items.Add(new ToolStripSeparator());
            tsToolbar.Items.Add(tbbFind);
            tsToolbar.Items.Add(tbbFindNext);
            tsToolbar.Items.Add(txtInput);
            tsToolbar.Items.Add(new ToolStripSeparator());
            tsToolbar.Items.Add(tbbExtra);
            tsToolbar.Items.Add(tbbPAL);
            tsToolbar.Items.Add(new ToolStripSeparator());
            tsToolbar.Items.Add(tbbPlay);
            tsToolbar.Font = new Font("Arial", 9F);

           tbcTabs = new MetroTabControl
            {
                Dock = DockStyle.Fill
            };
            tbcTabs.SelectedIndexChanged += tbcTabs_SelectedIndexChanged;
            tbcTabs.FontSize = MetroFramework.MetroTabControlSize.Small;
            tbcTabs.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            tbcTabs.Style = MetroFramework.MetroColorStyle.Blue;
            tbcTabs.Theme = MetroFramework.MetroThemeStyle.Dark;
            tbcTabs.Font = new Font("Arial", 9F);

            TabPage configtab = new TabPage("CrashEdit")
            {
                Tag = new ConfigEditor() { Dock = DockStyle.Fill }
            };
            configtab.Controls.Add((ConfigEditor)configtab.Tag);

            tbcTabs.TabPages.Add(configtab);

            tbcTabs_SelectedIndexChanged(null,null);

            dlgGameVersion = new GameVersionForm();

            msMenu = new DarkMenuStrip
            {
            };

            mnuOpen = new ToolStripMenuItem
            {
                Text = Resources.Toolbar_Open
            };

            mnuSave = new ToolStripMenuItem
            {
                Text = Resources.Toolbar_Save
            };

            mnuPatchNSD = new ToolStripMenuItem
            {
                Text = Resources.Toolbar_PatchNSD
            };

            mnuClose = new ToolStripMenuItem
            {
                Text = Resources.Toolbar_Close
            };

            mnuFind = new ToolStripMenuItem
            {
                Text = Resources.Toolbar_Find
            };

            mnuFindNext = new ToolStripMenuItem
            {
                Text = Resources.Toolbar_FindNext
            };

            mnuPlay = new ToolStripMenuItem
            {
                Text = "Play"
            };

            msMenu.Visible = false;
            msMenu.Font = new Font("Arial", 9F);
            msMenu.Items.AddRange(new ToolStripItem[] {
            mnuOpen,
            mnuSave,
            mnuPatchNSD,
            mnuClose,
            mnuFind,
            mnuFindNext,
            mnuPlay});

            mnuOpen.Click += new EventHandler(tbbOpen_Click);
            mnuOpen.ShortcutKeys = Keys.Control | Keys.O;

            mnuSave.Click += new EventHandler(tbbSave_Click);
            mnuSave.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

            mnuPatchNSD.Click += new EventHandler(tbbPatchNSD_Click);
            mnuPatchNSD.ShortcutKeys = Keys.Control | Keys.S;

            mnuClose.Click += new EventHandler(tbbClose_Click);
            mnuClose.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;

            mnuFind.Click += new EventHandler(tbbFind_Shortcut);
            mnuFind.ShortcutKeys = Keys.Control | Keys.F;

            mnuFindNext.Click += new EventHandler(tbbFindNext_Click);
            mnuFindNext.ShortcutKeys = Keys.F3;

            mnuPlay.Click += new EventHandler(tbbPlay_Click);
            mnuPlay.ShortcutKeys = Keys.F1;

            bgwMakeBIN = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = false
            };
            bgwMakeBIN.DoWork += new DoWorkEventHandler(bgwMakeBIN_DoWork);
            bgwMakeBIN.ProgressChanged += new ProgressChangedEventHandler(bgwMakeBIN_ProgressChanged);
            bgwMakeBIN.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwMakeBIN_RunWorkerCompleted);
            dlgProgress = null;

            Icon = OldResources.CBHacksIcon;
            Load += new EventHandler(OldMainForm_Load);
            FormClosing += new FormClosingEventHandler(OldMainForm_FormClosing);
            Text = $"CrashEdit-tweaked v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            //Controls.Add(txtInput);
            Controls.Add(tbcTabs);
            Controls.Add(tsToolbar);
            Controls.Add(msMenu);

            dlgMakeBINFile.Filter = "Playstation Disc Images (*.bin)|*.bin";
        }

        private void tbcTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage tab = tbcTabs.SelectedTab;
            tbbSave.Enabled =
            tbbPatchNSD.Enabled =
            tbbClose.Enabled =
            tbbFind.Enabled =
            tbbFindNext.Enabled =
            tbbPlay.Enabled =
            txtInput.Enabled = tab != null && tab.Tag is NSFBox;
        }

        void tbbPAL_Click(object sender, EventArgs e)
        {
            PAL = tbbPAL.Checked;
            Settings.Default.PAL = tbbPAL.Checked;
            Settings.Default.Save();
        }

        void tbbPlay_Click(object sender, EventArgs e)
        {
            var tab = tbcTabs.SelectedTab;
            if (tab == null || !(tab.Tag is NSFBox))
                return;

            var nsfBox = (NSFBox)tab.Tag;
            var nsf = nsfBox.NSF;

            var nsfFilename = tbcTabs.SelectedTab.Text;

            var nsfFilenameBase = Path.GetFileName(nsfFilename);
            if (nsfFilenameBase.Length != 12) {
                DarkMessageBox.ShowError(string.Format(Resources.Playtest_Error1, nsfFilename), Resources.Playtest_Title);
                return;
            }
            var levelID = int.Parse(nsfFilenameBase.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);

            string nsdFilename;
            if (nsfFilename.EndsWith("F"))
            {
                nsdFilename = nsfFilename.Remove(nsfFilename.Length - 1);
                nsdFilename += "D";
            }
            else if (nsfFilename.EndsWith("f"))
            {
                nsdFilename = nsfFilename.Remove(nsfFilename.Length - 1);
                nsdFilename += "d";
            }
            else
            {
                DarkMessageBox.ShowError(string.Format(Resources.Playtest_Error2, nsfFilename), Resources.Playtest_Title);
                return;
            }

            if (!File.Exists(nsdFilename)) {
                DarkMessageBox.ShowError(string.Format(Resources.Playtest_Error3, nsdFilename), Resources.Playtest_Title);
                return;
            }

            string exeFilename = null;
            var isofsPath = Path.GetDirectoryName(Path.GetDirectoryName(nsfFilename));
            foreach (string s in Directory.GetFiles(isofsPath)) {
                if (Regex.IsMatch(Path.GetFileName(s).ToUpper(), @"^(S[CL][UEP]S_\d\d\d\.\d\d|PSX\.EXE)$")) {
                    exeFilename = s;
                    break;
                }
            }
            if (exeFilename == null) {
                DarkMessageBox.ShowError(Resources.Playtest_Error4, Resources.Playtest_Title);
                return;
            }

            string kdatDir = Path.Combine(isofsPath, "S3");
            string kdatFilename = null;
            if (Directory.Exists(kdatDir)) {
                foreach (string s in Directory.GetFiles(kdatDir)) {
                    if (Path.GetFileName(s).ToUpper() == "KDAT.DAT") {
                        kdatFilename = s;
                        break;
                    }
                }
            }

            string warpscusDir = Path.Combine(isofsPath, "S0");
            string warpscusFilename = null;
            if (Directory.Exists(warpscusDir)) {
                foreach (string s in Directory.GetFiles(warpscusDir)) {
                    if (Regex.IsMatch(Path.GetFileName(s).ToUpper(), @"^WARPSC[UEP]S\.BIN$")) {
                        warpscusFilename = s;
                        break;
                    }
                }
            }

            string basePath;
            do {
                basePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            } while (Directory.Exists(basePath));
            Directory.CreateDirectory(basePath);

            File.Copy(nsfFilename, Path.Combine(basePath, Path.GetFileName(nsfFilename)));
            File.Copy(nsdFilename, Path.Combine(basePath, Path.GetFileName(nsdFilename)));
            nsfFilename = Path.Combine(basePath, Path.GetFileName(nsfFilename));
            nsdFilename = Path.Combine(basePath, Path.GetFileName(nsdFilename));
            //PatchNSD(nsdFilename, true, nsfBox.NSFController, true);
            NsfHelper.SaveNSF(nsfFilename, nsf, true);
            var fs = new CDBuilder();
            fs.AddFile("S0\\" + Path.GetFileName(nsfFilename) + ";1", nsfFilename);
            fs.AddFile("S0\\" + Path.GetFileName(nsdFilename) + ";1", nsdFilename);
            fs.AddFile("PSX.EXE;1", exeFilename);
            if (warpscusFilename != null) fs.AddFile("S0\\" + Path.GetFileName(warpscusFilename) + ";1", warpscusFilename);
            if (kdatFilename != null) fs.AddFile("S3\\" + Path.GetFileName(kdatFilename) + ";1", kdatFilename);

            string binPath = Path.Combine(basePath, "game.bin");
            MakeBinWithProgressBar(fs, binPath);

            var regionStr = PAL ? "pal" : "ntsc";

            Task.Run(() => {
                ExternalTool.Invoke("pcsx-hdbg", $"gamefile=\"{binPath}\" bootlevel={levelID} region={regionStr}");
                Directory.Delete(basePath, true);
            });
        }

        public static int GetRate()
        {
            return PAL ? RatePAL : RateNTSC;
        }

        void tbbOpen_Click(object sender,EventArgs e)
        {
            OpenNSF();
        }

        void tbbSave_Click(object sender,EventArgs e)
        {
            SaveNSF(false);
        }

        void tbbPatchNSD_Click(object sender,EventArgs e)
        {
            PatchNSD();
        }

        void tbbClose_Click(object sender,EventArgs e)
        {
            CloseNSF();
        }

        void tbbFind_Click(object sender,EventArgs e)
        {
            Find();
        }

        void tbbFind_Shortcut(object sender, EventArgs e)
        {
            FindShortcut();
        }

        void tbbFindNext_Click(object sender,EventArgs e)
        {
            FindNext();
        }

        void txtInput_Change(object sender, EventArgs e)
        {
            changetext = true;
        }

        void txtInput_Click(object sender, EventArgs e)
        {
            txtInput.SelectAll();
        }

        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            if (e.Control)
            {
                Find();
            }
            else
            {
                FindNext();
            }
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent beeping
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.LineFeed)
            {
                e.Handled = true;
            }
        }

        public void OpenNSF()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = FileFilters.NSF + "|" + FileFilters.Any;
                dialog.Multiselect = true;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (string filename in dialog.FileNames)
                    {
                        OpenNSF(filename);
                    }
                }
            }
        }

        public void OpenNSF(string filename)
        {
            try
            {
                byte[] nsfdata = File.ReadAllBytes(filename);
                if (dlgGameVersion.ShowDialog(this) == DialogResult.OK)
                {
                    NSF nsf = NSF.LoadAndProcess(nsfdata,dlgGameVersion.SelectedVersion);
                    OpenNSF(filename,nsf,dlgGameVersion.SelectedVersion);
                }
            }
            catch (LoadAbortedException)
            {
            }
        }

        public void OpenNSF(string filename,NSF nsf,GameVersion gameversion)
        {
            NSFBox nsfbox = new NSFBox(nsf, gameversion, filename)
            {
                Dock = DockStyle.Fill
            };

            TabPage nsftab = new TabPage(filename)
            {
                Tag = nsfbox
            };
            nsftab.Controls.Add(nsfbox);

            tbcTabs.TabPages.Add(nsftab);
            tbcTabs.SelectedTab = nsftab;
        }

        public void SaveNSF(bool ignore_warnings)
        {
            if (tbcTabs.SelectedTab == null)
            {
                return;
            }

            string filename = tbcTabs.SelectedTab.Text;
            NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
            NSF nsf = nsfbox.NSF;

            NsfHelper.SaveNSF(ignore_warnings, filename, nsf, nsfbox.NSFController.GameVersion);
        }

        public void PatchNSD()
        {
            if (tbcTabs.SelectedTab != null)
            {
                string nsfFileName = tbcTabs.SelectedTab.Text;
                var nsdFileName = NsdHelper.GetNsdFilename(nsfFileName);
                if (nsdFileName == null)
                {
                    return;
                }

                NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
                NsdHelper.PatchNSD(nsdFileName, true, nsfbox.NSFController, false);
            }
        }

        public void CloseNSF()
        {
            string filename = tbcTabs.SelectedTab.Text;
            NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
            byte[] nsfdata;
            try
            {
                nsfdata = nsfbox.NSF.Save();
            }
            catch
            {
                nsfdata = null;
            }
            byte[] olddata = File.ReadAllBytes(filename);
            if (nsfdata == null || (nsfdata.Length == olddata.Length && nsfdata.SequenceEqual(olddata)) || DarkMessageBox.ShowWarning(Resources.CloseNSF, Resources.Close_ConfirmationPrompt, DarkDialogButton.YesNo) == DialogResult.Yes)
            {
                TabPage tab = tbcTabs.SelectedTab;
                if (tab != null)
                {
                    tbcTabs.TabPages.Remove(tab);
                    tab.Dispose();
                }
            }
        }

        public void Find()
        {
            txtInput.Select();
            txtInput.SelectAll();

            HandleNewFind();
        }

        public void FindShortcut()
        {
            txtInput.Select();
            txtInput.SelectAll();

            txtInput.Focus();
        }

        public void FindNext()
        {
            txtInput.Select();
            txtInput.SelectAll();

            if (changetext)
            {
                HandleNewFind();
            }
            else if (tbcTabs.SelectedTab != null)
            {
                var nsfBox = (NSFBox)tbcTabs.SelectedTab.Tag;
                nsfBox.FindNext();
            }
        }

        private void HandleNewFind()
        {
            if (tbcTabs.SelectedTab != null)
            {
                var nsfBox = (NSFBox) tbcTabs.SelectedTab.Tag;
                nsfBox.Find(Input);
            }

            changetext = false;
        }

        void AddDirectoryToISO(CDBuilder fs, string prefix, DirectoryInfo dir)
        {
            foreach (DirectoryInfo subdir in dir.GetDirectories()) {
                AddDirectoryToISO(fs, $"{prefix}{subdir.Name}\\", subdir);
            }
            foreach (FileInfo file in dir.GetFiles()) {
                fs.AddFile($"{prefix}{file.Name};1", file.FullName);
            }
        }

        private void bgwMakeBIN_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = (object[])e.Argument;
            CDBuilder fs = (CDBuilder)args[0];
            string filename = (string)args[1];
            while (!dlgProgress.IsShown) ;
            using (FileStream output = new FileStream(filename, FileMode.Create, FileAccess.Write))
            using (Stream input = fs.Build())
            {
                ISO2PSX.Run(input, output, bgwMakeBIN);
            }
        }

        private void bgwMakeBIN_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dlgProgress.ProgressBar.Value = e.ProgressPercentage;
        }

        private void bgwMakeBIN_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dlgProgress.Close();
        }

        internal void MakeBinWithProgressBar(CDBuilder fs, string filename)
        {
            using (dlgProgress = new ProgressBarForm())
            {
                dlgProgress.ProgressBar.ForeColor = Color.Red;
                dlgProgress.ProgressBar.Style = ProgressBarStyle.Blocks;
                dlgProgress.ProgressBar.Value = 0;
                dlgProgress.Text = Resources.MakeBIN_Making;
                bgwMakeBIN.RunWorkerAsync(new object[] { fs, filename });
                dlgProgress.ShowDialog(this);
            }
        }

        void tbxMakeBIN_Click(object sender,EventArgs e)
        {

            if (dlgMakeBINDir.ShowDialog(this) != DialogResult.OK)
                return;
            
            string cnffile = Path.Combine(dlgMakeBINDir.SelectedPath, "SYSTEM.CNF");
            string exefile = Path.Combine(dlgMakeBINDir.SelectedPath, "PSX.EXE");

            if (!File.Exists(cnffile) && !File.Exists(exefile)) {
                if (DarkMessageBox.ShowWarning(Resources.MakeBIN_NoSystemFiles, Resources.MakeBIN_Title, DarkDialogButton.YesNo) != DialogResult.Yes)
                    return;
            }

            if (dlgMakeBINFile.ShowDialog(this) != DialogResult.OK)
                return;

            var fs = new CDBuilder();
            AddDirectoryToISO(fs, "", new DirectoryInfo(dlgMakeBINDir.SelectedPath));

            MakeBinWithProgressBar(fs, dlgMakeBINFile.FileName);

            var log = new StringBuilder();
            log.AppendLine(Resources.MakeBIN_NoRegOK);
            log.AppendLine();

            string cueFilename = Path.ChangeExtension(dlgMakeBINFile.FileName, ".cue");
            if (!File.Exists(cueFilename)) {
                try {
                    using (var cue = new StreamWriter(cueFilename)) {
                        cue.WriteLine($"FILE \"{Path.GetFileName(dlgMakeBINFile.FileName)}\" BINARY");
                        cue.WriteLine("  TRACK 01 MODE2/2352");
                        cue.WriteLine("    INDEX 01 00:00:00");
                    }
                    log.AppendLine(Resources.MakeBIN_CueSuccess);
                    log.AppendLine();
                } catch (IOException ex) {
                    log.AppendLine(string.Format(Resources.MakeBIN_CueFail, ex));
                    log.AppendLine();
                }
            } else {
                log.AppendLine(Resources.MakeBIN_CueExists);
                log.AppendLine();
            }

            string imprintOpt;
            if (sender == tbxMakeBINUSA) {
                imprintOpt = ":cdxa-imprint --psx-scea";
            } else if (sender == tbxMakeBINEUR) {
                imprintOpt = ":cdxa-imprint --psx-scee";
            } else if (sender == tbxMakeBINJAP) {
                imprintOpt = ":cdxa-imprint --psx-scei";
            } else {
                log.Append(Resources.Done);
                DarkMessageBox.ShowInformation(log.ToString(), "Make BIN");
                return;
            }

            log.AppendLine(Resources.MakeBIN_DRNSF_Launch);
            try {
                if (ExternalTool.Invoke("drnsf", $"{imprintOpt} -- \"{dlgMakeBINFile.FileName}\"") != 0) {
                    log.AppendLine(Resources.MakeBIN_DRNSF_Error);
                    log.AppendLine();
                } else {
                    log.AppendLine(Resources.MakeBIN_DRNSF_Success);
                    log.AppendLine();
                }
            } catch (FileNotFoundException) {
                log.AppendLine(Resources.MakeBIN_DRNSF_Unavailable);
                log.AppendLine();
            } catch (Exception ex) {
                log.AppendLine(string.Format(Resources.MakeBIN_DRNSF_Fail, ex));
                log.AppendLine();
            }
            log.Append(Resources.Done);
            DarkMessageBox.ShowInformation(log.ToString(), "Make BIN");
        }

        void tbxConvertVHVB_Click(object sender,EventArgs e)
        {
            try
            {
                byte[] vh_data = FileUtil.OpenFile(FileFilters.VH, FileFilters.Any);
                if (vh_data == null) throw new LoadAbortedException();
                byte[] vb_data = FileUtil.OpenFile(FileFilters.VB, FileFilters.Any);
                if (vb_data == null) throw new LoadAbortedException();

                VH vh = VH.Load(vh_data);

                if (vb_data.Length / 16 != vh.VBSize)
                {
                    ErrorManager.SignalIgnorableError(Resources.ConvertVHVB_Error);
                }
                SampleLine[] vb = new SampleLine [vb_data.Length / 16];
                byte[] line_data = new byte[16];
                for (int i = 0; i < vb.Length; i++)
                {
                    Array.Copy(vb_data, i * 16, line_data, 0, 16);
                    vb[i] = SampleLine.Load(line_data);
                }

                VAB vab = VAB.Join(vh, vb);

                FileUtil.SaveFile(vab.ToDLS().Save(), FileFilters.DLS, FileFilters.Any);
            }
            catch (LoadAbortedException)
            {
            }
        }

        void tbxConvertVAB_Click(object sender,EventArgs e)
        {
            try
            {
                byte[] vab_data = FileUtil.OpenFile(FileFilters.VAB, FileFilters.Any);

                if (vab_data == null) throw new LoadAbortedException();

                VH vh = VH.Load(vab_data);

                int vb_offset = 2592+32*16*vh.Programs.Count;
                if ((vab_data.Length - vb_offset) % 16 != 0)
                {
                    ErrorManager.SignalIgnorableError(Resources.ConvertVAB_Error);
                }
                vh.VBSize = (vab_data.Length - vb_offset) / 16;
                SampleLine[] vb = new SampleLine [vh.VBSize];
                byte[] line_data = new byte[16];
                for (int i = 0; i < vb.Length; i++)
                {
                    Array.Copy(vab_data, vb_offset + i * 16, line_data, 0, 16);
                    vb[i] = SampleLine.Load(line_data);
                }

                VAB vab = VAB.Join(vh, vb);

                FileUtil.SaveFile(vab.ToDLS().Save(), FileFilters.DLS, FileFilters.Any);
            }
            catch (LoadAbortedException)
            {
            }
        }

        public void ResetConfig()
        {
            TabPage configtab = tbcTabs.TabPages[0];
            if (configtab.Tag is ConfigEditor)
            {
                configtab.Controls.Clear();
                configtab.Tag = new ConfigEditor() { Dock = DockStyle.Fill };
                configtab.Controls.Add((ConfigEditor)configtab.Tag);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OldMainForm
            // 
            this.ClientSize = new System.Drawing.Size(747, 560);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Name = "OldMainForm";
            this.ResumeLayout(false);
        }

        private void OldMainForm_Load(object sender, EventArgs e)
        {
            Bounds = Settings.Default.FormBounds;
            WindowState = Settings.Default.FormWindowState;
        }

        private void OldMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.FormBounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
            Settings.Default.FormWindowState = WindowState;
            Settings.Default.Save();
        }
    }
}
