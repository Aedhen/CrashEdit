using Crash;
using Crash.UI;
using DiscUtils.Iso9660;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading.Tasks;
using CrashEdit.Properties;

namespace CrashEdit
{
    public sealed class OldMainForm : Form
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
                imglist.Images.Add("tb_patchnsd",OldResources.SaveImage);
                imglist.Images.Add("tb_close",OldResources.FolderImage);
                imglist.Images.Add("tb_find",OldResources.BinocularsImage);
                imglist.Images.Add("tb_findnext",OldResources.BinocularsNextImage);
            }
            catch
            {
                imglist.Images.Clear();
            }
        }

        private ToolStrip tsToolbar;
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
        private TabControl tbcTabs;
        private GameVersionForm dlgGameVersion;
        private ToolStripButton tbbPAL;

        private FolderBrowserDialog dlgMakeBINDir = new FolderBrowserDialog();
        private SaveFileDialog dlgMakeBINFile = new SaveFileDialog();

        private static bool PAL = false;
        private const int RateNTSC = 30;
        private const int RatePAL = 25;

        public OldMainForm()
        {
            tbbOpen = new ToolStripButton
            {
                Text = Resources.Toolbar_Open,
                ImageKey = "tb_open",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbOpen.Click += new EventHandler(tbbOpen_Click);

            tbbSave = new ToolStripButton
            {
                Text = Resources.Toolbar_Save,
                ImageKey = "tb_save",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbSave.Click += new EventHandler(tbbSave_Click);

            tbbPatchNSD = new ToolStripButton
            {
                Text = Resources.Toolbar_PatchNSD,
                ImageKey = "tb_patchnsd",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbPatchNSD.Click += new EventHandler(tbbPatchNSD_Click);

            tbbClose = new ToolStripButton
            {
                Text = Resources.Toolbar_Close,
                ImageKey = "tb_close",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbClose.Click += new EventHandler(tbbClose_Click);

            tbbFind = new ToolStripButton
            {
                Text = Resources.Toolbar_Find,
                ImageKey = "tb_find",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbFind.Click += new EventHandler(tbbFind_Click);

            tbbFindNext = new ToolStripButton
            {
                Text = Resources.Toolbar_FindNext,
                ImageKey = "tb_findnext",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbFindNext.Click += new EventHandler(tbbFindNext_Click);

            tbxMakeBIN = new ToolStripMenuItem();
            tbxMakeBIN.Text = Properties.Resources.OldMainForm_tbxMakeBIN;
            tbxMakeBIN.Click += new EventHandler(tbxMakeBIN_Click);

            tbxMakeBINUSA = new ToolStripMenuItem();
            tbxMakeBINUSA.Text = Properties.Resources.OldMainForm_tbxMakeBINUSA;
            tbxMakeBINUSA.Click += new EventHandler(tbxMakeBIN_Click);

            tbxMakeBINEUR = new ToolStripMenuItem();
            tbxMakeBINEUR.Text = Properties.Resources.OldMainForm_tbxMakeBINEUR;
            tbxMakeBINEUR.Click += new EventHandler(tbxMakeBIN_Click);

            tbxMakeBINJAP = new ToolStripMenuItem();
            tbxMakeBINJAP.Text = Properties.Resources.OldMainForm_tbxMakeBINJAP;
            tbxMakeBINJAP.Click += new EventHandler(tbxMakeBIN_Click);

            tbxConvertVHVB = new ToolStripMenuItem();
            tbxConvertVHVB.Text = Properties.Resources.OldMainForm_tbxConvertVHVB;
            tbxConvertVHVB.Click += new EventHandler(tbxConvertVHVB_Click);

            tbxConvertVAB = new ToolStripMenuItem();
            tbxConvertVAB.Text = Properties.Resources.OldMainForm_tbxConvertVAB;
            tbxConvertVAB.Click += new EventHandler(tbxConvertVAB_Click);

            tbbExtra = new ToolStripDropDownButton();
            tbbExtra.Text = Properties.Resources.OldMainForm_tbbExtra;
            tbbExtra.DropDown = new ToolStripDropDown { LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow };
            tbbExtra.DropDown.Items.Add(tbxMakeBIN);
            tbbExtra.DropDown.Items.Add(tbxMakeBINUSA);
            tbbExtra.DropDown.Items.Add(tbxMakeBINEUR);
            tbbExtra.DropDown.Items.Add(tbxMakeBINJAP);
            tbbExtra.DropDown.Items.Add("-");
            tbbExtra.DropDown.Items.Add(tbxConvertVHVB);
            tbbExtra.DropDown.Items.Add(tbxConvertVAB);

            tbbPAL = new ToolStripButton
            {
                Text = "PAL",
                TextImageRelation = TextImageRelation.ImageAboveText,
                Checked = false,
                CheckOnClick = true
            };
            tbbPAL.Click += new EventHandler(tbbPAL_Click);

            tbbPlay = new ToolStripButton
            {
                Text = "Play",
                TextImageRelation = TextImageRelation.ImageAboveText
            };
            tbbPlay.Click += new EventHandler(tbbPlay_Click);

            tsToolbar = new ToolStrip
            {
                Dock = DockStyle.Top,
                ImageList = imglist
            };
            tsToolbar.Items.Add(tbbOpen);
            tsToolbar.Items.Add(tbbSave);
            tsToolbar.Items.Add(tbbPatchNSD);
            tsToolbar.Items.Add(tbbClose);
            tsToolbar.Items.Add(new ToolStripSeparator());
            tsToolbar.Items.Add(tbbFind);
            tsToolbar.Items.Add(tbbFindNext);
            tsToolbar.Items.Add(new ToolStripSeparator());
            tsToolbar.Items.Add(tbbExtra);
            tsToolbar.Items.Add(tbbPAL);
            tsToolbar.Items.Add(new ToolStripSeparator());
            tsToolbar.Items.Add(tbbPlay);

            tbcTabs = new TabControl
            {
                Dock = DockStyle.Fill
            };
            tbcTabs.SelectedIndexChanged += tbcTabs_SelectedIndexChanged;

            TabPage configtab = new TabPage("CrashEdit")
            {
                Tag = new ConfigEditor() { Dock = DockStyle.Fill }
            };
            configtab.Controls.Add((ConfigEditor)configtab.Tag);

            tbcTabs.TabPages.Add(configtab);

            tbcTabs_SelectedIndexChanged(null,null);

            dlgGameVersion = new GameVersionForm();

            Icon = OldResources.CBHacksIcon;
            Width = Settings.Default.DefaultFormW;
            Height = Settings.Default.DefaultFormH;
            Text = $"CrashEdit v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            Controls.Add(tbcTabs);
            Controls.Add(tsToolbar);

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
            tbbPlay.Enabled = tab != null && tab.Tag is NSFBox;
        }

        void tbbPAL_Click(object sender, EventArgs e)
        {
            PAL = tbbPAL.Checked;
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
                MessageBox.Show(string.Format(Resources.Playtest_Error1, nsfFilename), Resources.Playtest_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(string.Format(Resources.Playtest_Error2, nsfFilename), Resources.Playtest_Title, MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(nsdFilename)) {
                MessageBox.Show(string.Format(Resources.Playtest_Error3, nsdFilename), Resources.Playtest_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Resources.Playtest_Error4, Resources.Playtest_Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            PatchNSD(nsdFilename, true, nsfBox.NSFController, true);
            SaveNSF(nsfFilename, nsf, true);
            var fs = new CDBuilder();
            fs.AddFile("S0\\" + Path.GetFileName(nsfFilename) + ";1", nsfFilename);
            fs.AddFile("S0\\" + Path.GetFileName(nsdFilename) + ";1", nsdFilename);
            fs.AddFile("PSX.EXE;1", exeFilename);
            if (warpscusFilename != null) fs.AddFile("S0\\" + Path.GetFileName(warpscusFilename) + ";1", warpscusFilename);
            if (kdatFilename != null) fs.AddFile("S3\\" + Path.GetFileName(kdatFilename) + ";1", kdatFilename);

            string binPath = Path.Combine(basePath, "game.bin");
            using (var bin = new FileStream(binPath, FileMode.Create, FileAccess.Write))
            using (var iso = fs.Build()) {
                ISO2PSX.Run(iso, bin);
            }

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

        void tbbFindNext_Click(object sender,EventArgs e)
        {
            FindNext();
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
            NSFBox nsfbox = new NSFBox(nsf, gameversion)
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
            if (tbcTabs.SelectedTab != null)
            {
                string filename = tbcTabs.SelectedTab.Text;
                NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
                SaveNSF(filename,nsfbox.NSF,ignore_warnings);
            }
        }

        public void SaveNSF(string filename,NSF nsf,bool ignore_warnings)
        {
            try
            {
                byte[] nsfdata = nsf.Save();
                if (ignore_warnings ? true : MessageBox.Show(Resources.SaveNSF, Resources.Save_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.WriteAllBytes(filename,nsfdata);
                }
            }
            catch (PackingException ex)
            {
                MessageBox.Show(string.Format(Resources.SaveNSF_Error1, Entry.EIDToEName(ex.EID)), Resources.SaveNSF_Title, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(Resources.SaveNSF_Error2 + ex.Message, Resources.SaveNSF_Title, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(Resources.SaveNSF_Error3 + ex.Message, Resources.SaveNSF_Title, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void PatchNSD()
        {
            if (tbcTabs.SelectedTab != null)
            {
                string filename = tbcTabs.SelectedTab.Text;
                if (filename.EndsWith("F"))
                {
                    filename = filename.Remove(filename.Length - 1);
                    filename += "D";
                }
                else if (filename.EndsWith("f"))
                {
                    filename = filename.Remove(filename.Length - 1);
                    filename += "d";
                }
                else
                {
                    MessageBox.Show(string.Format(Resources.PatchNSD_Error1, filename), Resources.PatchNSD_Title1, MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
                bool exists = true;
                if (!File.Exists(filename))
                {
                    //if (MessageBox.Show("NSD file does not exist. Create one?", "Patch NSD", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) != DialogResult.Yes)
                    {
                        return;
                    }
                    if (nsfbox.NSFController.GameVersion != GameVersion.Crash1BetaMAR08 && MessageBox.Show("Default NSD file is not a valid NSD file and needs to be manually fixed using a hex editor. Continue anyway?", "Patch NSD", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    {
                        return;
                    }
                    exists = false;
                }
                PatchNSD(filename,exists,nsfbox.NSFController,false);
            }
        }

        public void PatchNSD(string filename, bool exists, NSFController nsfc, bool ignore_warnings)
        {
            NSF nsf = nsfc.NSF;
            byte[] data = exists ? File.ReadAllBytes(filename) : null;
            try
            {
                switch (nsfc.GameVersion)
                {
                    case GameVersion.Crash1BetaMAR08:
                        {
                            ProtoNSD nsd = data != null ? ProtoNSD.Load(data) : new ProtoNSD(new int[256], 0, new NSDLink[0]);
                            PatchNSD(nsd, nsf, filename, ignore_warnings);
                        }
                        break;
                    case GameVersion.Crash1:
                        {
                            OldNSD nsd = data != null ? OldNSD.Load(data) : new OldNSD(new int[256], 0, new int[4], 0, 0, new int[64], new NSDLink[0], 1, 0x3F, Entry.NullEID, 0, 0, new int[64], new byte[0xFC]);
                            PatchNSD(nsd, nsf, filename, ignore_warnings);
                        }
                        break;
                    case GameVersion.Crash2:
                        {
                            NSD nsd = data != null ? NSD.Load(data) : new NSD(new int[256], 0, new int[4], 0, 0, new int[64], new NSDLink[0], 0, 0x3F, 0, new int[64], new byte[0xFC], new NSDSpawnPoint[1] { new NSDSpawnPoint(Entry.NullEID, 0, 0, 0, 0, 0) }, new byte[0]);
                            PatchNSD(nsd, nsf, filename, ignore_warnings);
                        }
                        break;
                    case GameVersion.Crash3:
                        {
                            NewNSD nsd = data != null ? NewNSD.Load(data) : new NewNSD(new int[256], 0, new int[4], 0, 0, new int[64], new NSDLink[0], 0, 0x3F, 0, new int[128], new byte[0xFC], new NSDSpawnPoint[1] { new NSDSpawnPoint(Entry.NullEID, 0, 0, 0, 0, 0) }, new byte[0]);
                            PatchNSD(nsd, nsf, filename, ignore_warnings);
                        }
                        break;
                    default:
                        if (!ignore_warnings) MessageBox.Show(Resources.PatchNSD_Error2, Resources.PatchNSD_Title1, MessageBoxButtons.OK);
                        return;
                }
                nsfc.Node.TreeView.BeginUpdate();
                bool order_updated = false;
                foreach (TreeNode node in nsfc.Node.Nodes) // nsd patching might have moved entries, recreate moved entry chunks if that's the case
                {
                    if (node.Tag is EntryChunkController entrychunkcontroller)
                    {
                        int i = 0;
                        TreeNode[] nodes = new TreeNode[node.Nodes.Count];
                        foreach (TreeNode oldnode in node.Nodes)
                        {
                            nodes[i++] = oldnode;
                        }
                        for (i = 0; i < nodes.Length; ++i)
                        {
                            EntryController c = (EntryController)nodes[i].Tag;
                            if (c.Entry != entrychunkcontroller.EntryChunk.Entries[i])
                            {
                                for (i = 0; i < nodes.Length; ++i)
                                {
                                    if (nodes[i].Tag != null)
                                    {
                                        if (nodes[i].Tag is Controller t)
                                        {
                                            t.Dispose();
                                        }
                                    }
                                }
                                entrychunkcontroller.PopulateNodes();
                                order_updated = true;
                                break;
                            }
                        }
                    }
                }
                nsfc.Node.TreeView.EndUpdate();
                if (ignore_warnings ? true : (order_updated && MessageBox.Show(Resources.PatchNSD3, Resources.PatchNSD_Title1, MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    SaveNSF(true);
                }
            }
            catch (LoadAbortedException)
            {
            }
        }

        public void PatchNSD(NewNSD nsd, NSF nsf, string path, bool ignore_warnings)
        {
            nsd.ChunkCount = nsf.Chunks.Count;
            var indexdata = nsf.MakeNSDIndex();
            nsd.HashKeyMap = indexdata.Item1;
            nsd.Index = indexdata.Item2;
            PatchNSDGoolMap(nsd.GOOLMap, nsf);

            // patch object entity count
            nsd.EntityCount = 0;
            foreach (Chunk chunk in nsf.Chunks)
            {
                if (!(chunk is EntryChunk))
                    continue;
                foreach (Entry entry in ((EntryChunk)chunk).Entries)
                {
                    if (entry is NewZoneEntry zone)
                        foreach (Entity ent in zone.Entities)
                            if (ent.ID != null)
                                ++nsd.EntityCount;
                }
            }

            if (ignore_warnings ? true : MessageBox.Show(Resources.PatchNSD1, Resources.Save_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.WriteAllBytes(path, nsd.Save());
            }
            if (!ignore_warnings && MessageBox.Show(Resources.PatchNSD2, Resources.PatchNSD_Title2, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int[] eids = new int[nsd.Index.Count];
                for (int i = 0; i < eids.Length; ++i)
                    eids[i] = nsd.Index[i].EntryID;
                foreach (Chunk chunk in nsf.Chunks)
                {
                    if (!(chunk is EntryChunk))
                        continue;
                    foreach (Entry entry in ((EntryChunk)chunk).Entries)
                    {
                        if (entry is NewZoneEntry zone)
                        {
                            foreach (Entity ent in zone.Entities)
                            {
                                if (ent.LoadListA != null)
                                {
                                    foreach (EntityPropertyRow<int> row in ent.LoadListA.Rows)
                                    {
                                        List<int> values = (List<int>)row.Values;
                                        values.Sort(delegate (int a, int b) {
                                            return Array.IndexOf(eids,a) - Array.IndexOf(eids,b);
                                        });
                                        if (Settings.Default.DeleteInvalidEntries) values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                    }
                                }
                                if (ent.LoadListB != null)
                                {
                                    foreach (EntityPropertyRow<int> row in ent.LoadListB.Rows)
                                    {
                                        List<int> values = (List<int>)row.Values;
                                        values.Sort(delegate (int a, int b) {
                                            return Array.IndexOf(eids,a) - Array.IndexOf(eids,b);
                                        });
                                        if (Settings.Default.DeleteInvalidEntries) values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PatchNSD(NSD nsd, NSF nsf, string path, bool ignore_warnings)
        {
            /*
            nsd.ChunkCount = nsf.Chunks.Count;
            var indexdata = nsf.MakeNSDIndex();
            nsd.HashKeyMap = indexdata.Item1;
            nsd.Index = indexdata.Item2;
            PatchNSDGoolMap(nsd.GOOLMap, nsf);
            */

            nsd.ChunkCount = nsf.Chunks.Count;
            Dictionary<int, int> newindex = new Dictionary<int, int>();
            List<int> eids = new List<int>();
            for (int i = 0; i < nsf.Chunks.Count; i++)
            {
                if (nsf.Chunks[i] is IEntry ientry)
                {
                    newindex.Add(ientry.EID, i * 2 + 1);
                }
                if (nsf.Chunks[i] is EntryChunk chunk)
                {
                    foreach (Entry entry in chunk.Entries)
                    {
                        newindex.Add(entry.EID, i * 2 + 1);
                    }
                }
            }
            HashSet<NSDLink> unused = new HashSet<NSDLink>();
            foreach (NSDLink link in nsd.Index)
            {
                eids.Add(link.EntryID);
                if (newindex.ContainsKey(link.EntryID))
                {
                    link.ChunkID = newindex[link.EntryID];
                    newindex.Remove(link.EntryID);
                }
                else // NSD contains nonexistant entry
                {
                    unused.Add(link);
                }
            }
            if (unused.Count > 0)
            {
                foreach (NSDLink link in unused)
                {
                    nsd.Index.Remove(link);
                }
                for (int i = 0; i < 256; ++i)
                {
                    nsd.HashKeyMap[i] = Math.Min(nsd.HashKeyMap[i], nsd.Index.Count - 1);
                }
            }
            if (newindex.Count > 0)
            {
                List<string> neweids = new List<string>();
                foreach (KeyValuePair<int, int> kvp in newindex)
                {
                    neweids.Add(Entry.EIDToEName(kvp.Key));
                }
                string question = "The NSD is missing some entry ID's:\n\n";
                foreach (string eid in neweids)
                {
                    question += eid + "\n";
                }
                question += "\nDo you want to add these to the end of the NSD's entry index?";
                if (MessageBox.Show(question, "Patch NSD - New EID's", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (KeyValuePair<int, int> kvp in newindex)
                    {
                        nsd.Index.Add(new NSDLink(kvp.Value, kvp.Key));
                    }
                }
            }

            // check list
            for (int i = 0; i < nsf.Chunks.Count; i++)
            {
                if (nsf.Chunks[i] is EntryChunk chunk)
                {
                    List<int> nsdchunkentries = new List<int>();
                    for (int j = 0; j < nsd.Index.Count; ++j)
                    {
                        NSDLink link = nsd.Index[j];
                        if (i * 2 + 1 == link.ChunkID)
                        {
                            nsdchunkentries.Add(j);
                        }
                    }
                    for (int j = 0; j < chunk.Entries.Count; ++j)
                    {
                        Entry entry = chunk.Entries[j];
                        if (entry.EID != nsd.Index[nsdchunkentries[j]].EntryID)
                        {
                            /*
                            MessageBox.Show($"NSD hash map is not in correct order. Entry {entry.EName} in chunk {i * 2 + 1} will be swapped.", "NSD hash map mismatch");
                            */
                            int k = j;
                            for (; k < nsdchunkentries.Count; ++k)
                                if (entry.EID == nsd.Index[nsdchunkentries[k]].EntryID) break;
                            nsd.Index.Swap(nsdchunkentries[j], nsdchunkentries[k]);
                        }
                    }
                }
            }


            // patch object entity count
            nsd.EntityCount = 0;
            foreach (Chunk chunk in nsf.Chunks)
            {
                if (!(chunk is EntryChunk))
                    continue;
                foreach (Entry entry in ((EntryChunk)chunk).Entries)
                {
                    if (entry is ZoneEntry zone)
                        foreach (Entity ent in zone.Entities)
                            if (ent.ID != null)
                                ++nsd.EntityCount;
                }
            }
            if (Settings.Default.PatchNSDSavesNSF)
            {
                if (MessageBox.Show("Are you sure you want to overwrite the NSD file?\n\nEIDs will be swapped if NSD hash map is not in correct order,\nand all loadlists will be sorted according to the NSD.\n\nNSF file will be saved automatically.", Resources.Save_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.WriteAllBytes(path, nsd.Save());
                    foreach (Chunk chunk in nsf.Chunks)
                    {
                        if (!(chunk is EntryChunk))
                            continue;
                        foreach (Entry entry in ((EntryChunk)chunk).Entries)
                        {
                            if (entry is ZoneEntry zone)
                            {
                                foreach (Entity ent in zone.Entities)
                                {
                                    if (ent.LoadListA != null)
                                    {
                                        foreach (EntityPropertyRow<int> row in ent.LoadListA.Rows)
                                        {
                                            List<int> values = (List<int>)row.Values;
                                            values.Sort(delegate (int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries) values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                        }
                                    }
                                    if (ent.LoadListB != null)
                                    {
                                        foreach (EntityPropertyRow<int> row in ent.LoadListB.Rows)
                                        {
                                            List<int> values = (List<int>)row.Values;
                                            values.Sort(delegate (int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries) values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    SaveNSF(true);
                }
            }
            else if (MessageBox.Show("Are you sure you want to overwrite the NSD file?\n\nIf NSD hash map is not in correct order, EIDs will be swapped.\nAll loadlists will be sorted according to the NSD.", Resources.Save_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.WriteAllBytes(path, nsd.Save());
                /*}
                if (MessageBox.Show("Do you want to sort all loadlists according to the NSD?", "Loadlist autosorter", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {*/
                foreach (Chunk chunk in nsf.Chunks)
                {
                    if (!(chunk is EntryChunk))
                        continue;
                    foreach (Entry entry in ((EntryChunk)chunk).Entries)
                    {
                        if (entry is ZoneEntry zone)
                        {
                            foreach (Entity ent in zone.Entities)
                            {
                                if (ent.LoadListA != null)
                                {
                                    foreach (EntityPropertyRow<int> row in ent.LoadListA.Rows)
                                    {
                                        List<int> values = (List<int>)row.Values;
                                        values.Sort(delegate (int a, int b)
                                        {
                                            return eids.IndexOf(a) - eids.IndexOf(b);
                                        });
                                        if (Settings.Default.DeleteInvalidEntries) values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                    }
                                }
                                if (ent.LoadListB != null)
                                {
                                    foreach (EntityPropertyRow<int> row in ent.LoadListB.Rows)
                                    {
                                        List<int> values = (List<int>)row.Values;
                                        values.Sort(delegate (int a, int b)
                                        {
                                            return eids.IndexOf(a) - eids.IndexOf(b);
                                        });
                                        if (Settings.Default.DeleteInvalidEntries) values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PatchNSD(OldNSD nsd, NSF nsf, string path, bool ignore_warnings)
        {
            nsd.ChunkCount = nsf.Chunks.Count;
            var indexdata = nsf.MakeNSDIndex();
            nsd.HashKeyMap = indexdata.Item1;
            nsd.Index = indexdata.Item2;
            PatchNSDGoolMap(nsd.GOOLMap, nsf);
            if (ignore_warnings ? true : MessageBox.Show(Resources.PatchNSD1, Resources.Save_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.WriteAllBytes(path, nsd.Save());
            }
        }

        public void PatchNSD(ProtoNSD nsd, NSF nsf, string path, bool ignore_warnings)
        {
            nsd.ChunkCount = nsf.Chunks.Count;
            var indexdata = nsf.MakeNSDIndex();
            nsd.HashKeyMap = indexdata.Item1;
            nsd.Index = indexdata.Item2;
            if (ignore_warnings ? true : MessageBox.Show(Resources.PatchNSD1, Resources.Save_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.WriteAllBytes(path, nsd.Save());
            }
        }

        public void PatchNSDGoolMap(int[] map, NSF nsf)
        {
            for (int i = 0; i < map.Length; ++i)
            {
                map[i] = Entry.NullEID;
            }
            foreach (Chunk chunk in nsf.Chunks)
            {
                if (chunk is EntryChunk entrychunk)
                {
                    foreach (Entry entry in entrychunk.Entries)
                    {
                        if (entry is GOOLEntry gool)
                        {
                            if (gool.Format == 1)
                            {
                                map[BitConv.FromInt32(gool.Header, 0)] = gool.EID;
                            }
                        }
                    }
                }
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
            if (nsfdata == null || (nsfdata.Length == olddata.Length && nsfdata.SequenceEqual(olddata)) || MessageBox.Show(Resources.CloseNSF, Resources.Close_ConfirmationPrompt, MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            if (tbcTabs.SelectedTab != null)
            {
                NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
                using (InputWindow inputwindow = new InputWindow())
                {
                    if (inputwindow.ShowDialog(this) == DialogResult.OK)
                    {
                        nsfbox.Find(inputwindow.Input);
                    }
                }
            }
        }

        public void FindNext()
        {
            if (tbcTabs.SelectedTab != null)
            {
                NSFBox nsfbox = (NSFBox)tbcTabs.SelectedTab.Tag;
                nsfbox.FindNext();
            }
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

        void tbxMakeBIN_Click(object sender,EventArgs e)
        {
            var log = new StringBuilder();

            if (dlgMakeBINDir.ShowDialog(this) != DialogResult.OK)
                return;

            string cnffile = Path.Combine(dlgMakeBINDir.SelectedPath, "SYSTEM.CNF");
            string exefile = Path.Combine(dlgMakeBINDir.SelectedPath, "PSX.EXE");

            if (!File.Exists(cnffile) && !File.Exists(exefile)) {
                if (MessageBox.Show(Resources.MakeBIN1, Resources.MakeBIN_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) != DialogResult.Yes)
                    return;
            }

            if (dlgMakeBINFile.ShowDialog(this) != DialogResult.OK)
                return;

            var fs = new CDBuilder();
            AddDirectoryToISO(fs, "", new DirectoryInfo(dlgMakeBINDir.SelectedPath));

            using (var bin = new FileStream(dlgMakeBINFile.FileName, FileMode.Create, FileAccess.Write))
            using (var iso = fs.Build()) {
                ISO2PSX.Run(iso, bin);
            }

            log.AppendLine(Resources.MakeBIN2);
            log.AppendLine();

            string cueFilename = Path.ChangeExtension(dlgMakeBINFile.FileName, ".cue");
            if (!File.Exists(cueFilename)) {
                try {
                    using (var cue = new StreamWriter(cueFilename)) {
                        cue.WriteLine($"FILE \"{Path.GetFileName(dlgMakeBINFile.FileName)}\" BINARY");
                        cue.WriteLine("  TRACK 01 MODE2/2352");
                        cue.WriteLine("    INDEX 01 00:00:00");
                    }
                    log.AppendLine(Resources.MakeBin3);
                    log.AppendLine();
                } catch (IOException ex) {
                    log.AppendLine(string.Format(Resources.MakeBin4, ex));
                    log.AppendLine();
                }
            } else {
                log.AppendLine(Resources.MakeBin5);
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
                MessageBox.Show(log.ToString());
                return;
            }

            log.AppendLine(Resources.MakeBin_DRNSF1);
            try {
                if (ExternalTool.Invoke("drnsf", $"{imprintOpt} -- \"{dlgMakeBINFile.FileName}\"") != 0) {
                    log.AppendLine(Resources.MakeBin_DRNSF2);
                    log.AppendLine();
                } else {
                    log.AppendLine(Resources.MakeBin_DRNSF3);
                    log.AppendLine();
                }
            } catch (FileNotFoundException) {
                log.AppendLine(Resources.MakeBin_DRNSF4);
                log.AppendLine();
            } catch (Exception ex) {
                log.AppendLine(string.Format(Resources.MakeBin_DRNSF5, ex));
                log.AppendLine();
            }
            log.Append(Resources.Done);
            MessageBox.Show(log.ToString());
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
    }
}
