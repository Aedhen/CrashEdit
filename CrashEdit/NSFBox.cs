using Crash;
using Crash.Game;
using Crash.Graphics;
using Crash.Unknown0;
using Crash.Unknown3;
using Crash.Unknown4;
using Crash.Unknown5;
using System.Drawing;
using System.Windows.Forms;

namespace CrashEdit
{
    public sealed class NSFBox : UserControl
    {
        private static ImageList imglist;

        static NSFBox()
        {
            imglist = new ImageList();
            try
            {
                imglist.Images.Add("default",Resources.FileIcon);
                imglist.Images.Add("trv_nsf",Resources.FileIcon);
                imglist.Images.Add("trv_normalchunk",Resources.YellowJournalIcon);
                imglist.Images.Add("trv_texturechunk",Resources.ImageIcon);
                imglist.Images.Add("trv_t3chunk",Resources.BlueJournalIcon);
                imglist.Images.Add("trv_t4chunk",Resources.MusicIcon);
                imglist.Images.Add("trv_t5chunk",Resources.WhiteJournalIcon);
                imglist.Images.Add("trv_unknownchunk",Resources.FileIcon);
                imglist.Images.Add("trv_t1entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t2entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t3entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t4entry",Resources.ThingIcon);
                imglist.Images.Add("trv_entityentry",Resources.ThingIcon);
                imglist.Images.Add("trv_t11entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t12entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t13entry",Resources.MusicIcon);
                imglist.Images.Add("trv_t14entry",Resources.MusicIcon);
                imglist.Images.Add("trv_t15entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t17entry",Resources.ThingIcon);
                imglist.Images.Add("trv_demoentry",Resources.ThingIcon);
                imglist.Images.Add("trv_t20entry",Resources.ThingIcon);
                imglist.Images.Add("trv_t21entry",Resources.ThingIcon);
                imglist.Images.Add("trv_unknownentry",Resources.ThingIcon);
                imglist.Images.Add("trv_entity",Resources.ArrowIcon);
            }
            catch
            {
                imglist.Images.Clear();
            }
        }

        private NSF nsf;

        private SplitContainer pnSplit;
        private TreeView trvMain;

        public NSFBox(NSF nsf)
        {
            this.nsf = nsf;

            TreeNode rootnode = Populate(nsf);
            rootnode.Expand();

            trvMain = new TreeView();
            trvMain.Dock = DockStyle.Fill;
            trvMain.ImageList = imglist;
            trvMain.HideSelection = false;
            trvMain.Nodes.Add(rootnode);
            trvMain.SelectedNode = rootnode;
            trvMain.AfterSelect += new TreeViewEventHandler(trvMain_AfterSelect);

            pnSplit = new SplitContainer();
            pnSplit.Dock = DockStyle.Fill;
            pnSplit.Panel1.Controls.Add(trvMain);

            this.Controls.Add(pnSplit);
        }

        void trvMain_AfterSelect(object sender,TreeViewEventArgs e)
        {
            Control control;
            if (e.Node != null)
            {
                control = Display(e.Node.Tag);
            }
            else
            {
                control = DisplayNothing();
            }
            pnSplit.Panel2.Controls.Clear();
            pnSplit.Panel2.Controls.Add(control);
        }

        private TreeNode Populate(NSF nsf)
        {
            TreeNode node = new TreeNode();
            node.Tag = nsf;
            node.Text = "NSF File";
            node.ImageKey = "trv_nsf";
            node.SelectedImageKey = "trv_nsf";
            foreach (Chunk chunk in nsf.Chunks)
            {
                node.Nodes.Add(Populate(chunk));
            }
            return node;
        }

        public TreeNode Populate(Chunk chunk)
        {
            if (chunk is NormalChunk)
            {
                return Populate((NormalChunk)chunk);
            }
            else if (chunk is TextureChunk)
            {
                return Populate((TextureChunk)chunk);
            }
            else if (chunk is T3Chunk)
            {
                return Populate((T3Chunk)chunk);
            }
            else if (chunk is T4Chunk)
            {
                return Populate((T4Chunk)chunk);
            }
            else if (chunk is T5Chunk)
            {
                return Populate((T5Chunk)chunk);
            }
            else if (chunk is UnknownChunk)
            {
                return Populate((UnknownChunk)chunk);
            }
            else
            {
                throw new System.Exception();
            }
        }

        public TreeNode Populate(NormalChunk chunk)
        {
            TreeNode node = new TreeNode();
            node.Tag = chunk;
            node.Text = "Normal Chunk";
            node.ImageKey = "trv_normalchunk";
            node.SelectedImageKey = "trv_normalchunk";
            foreach (Entry entry in chunk.Entries)
            {
                node.Nodes.Add(Populate(entry));
            }
            return node;
        }

        private TreeNode Populate(TextureChunk chunk)
        {
            TreeNode node = new TreeNode();
            node.Tag = chunk;
            node.Text = "Texture Chunk";
            node.ImageKey = "trv_texturechunk";
            node.SelectedImageKey = "trv_texturechunk";
            return node;
        }

        private TreeNode Populate(T3Chunk chunk)
        {
            TreeNode node = new TreeNode();
            node.Tag = chunk;
            node.Text = "T3 Chunk";
            node.ImageKey = "trv_t3chunk";
            node.SelectedImageKey = "trv_t3chunk";
            foreach (T12Entry entry in chunk.Entries)
            {
                node.Nodes.Add(Populate(entry));
            }
            return node;
        }

        private TreeNode Populate(T4Chunk chunk)
        {
            TreeNode node = Populate(chunk.Entry);
            node.Tag = chunk;
            node.Text = "T4 Chunk";
            node.ImageKey = "trv_t4chunk";
            node.SelectedImageKey = "trv_t4chunk";
            return node;
        }

        private TreeNode Populate(T5Chunk chunk)
        {
            TreeNode node = new TreeNode();
            node.Tag = chunk;
            node.Text = "T5 Chunk";
            node.ImageKey = "trv_t5chunk";
            node.SelectedImageKey = "trv_t5chunk";
            foreach (T20Entry entry in chunk.Entries)
            {
                node.Nodes.Add(Populate(entry));
            }
            return node;
        }

        private TreeNode Populate(UnknownChunk chunk)
        {
            TreeNode node = new TreeNode();
            node.Tag = chunk;
            node.Text = "Unknown Chunk";
            node.ImageKey = "trv_unknownchunk";
            node.SelectedImageKey = "trv_unknownchunk";
            return node;
        }

        private TreeNode Populate(Entry entry)
        {
            if (entry is T1Entry)
            {
                return Populate((T1Entry)entry);
            }
            else if (entry is T2Entry)
            {
                return Populate((T2Entry)entry);
            }
            else if (entry is T3Entry)
            {
                return Populate((T3Entry)entry);
            }
            else if (entry is T4Entry)
            {
                return Populate((T4Entry)entry);
            }
            else if (entry is EntityEntry)
            {
                return Populate((EntityEntry)entry);
            }
            else if (entry is T11Entry)
            {
                return Populate((T11Entry)entry);
            }
            else if (entry is T12Entry)
            {
                return Populate((T12Entry)entry);
            }
            else if (entry is T13Entry)
            {
                return Populate((T13Entry)entry);
            }
            else if (entry is T14Entry)
            {
                return Populate((T14Entry)entry);
            }
            else if (entry is T15Entry)
            {
                return Populate((T15Entry)entry);
            }
            else if (entry is T17Entry)
            {
                return Populate((T17Entry)entry);
            }
            else if (entry is DemoEntry)
            {
                return Populate((DemoEntry)entry);
            }
            else if (entry is T20Entry)
            {
                return Populate((T20Entry)entry);
            }
            else if (entry is T21Entry)
            {
                return Populate((T21Entry)entry);
            }
            else if (entry is UnknownEntry)
            {
                return Populate((UnknownEntry)entry);
            }
            else
            {
                throw new System.Exception();
            }
        }

        private TreeNode Populate(T1Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T1 Entry";
            node.ImageKey = "trv_t1entry";
            node.SelectedImageKey = "trv_t1entry";
            return node;
        }

        private TreeNode Populate(T2Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T2 Entry";
            node.ImageKey = "trv_t2entry";
            node.SelectedImageKey = "trv_t2entry";
            return node;
        }

        private TreeNode Populate(T3Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T3 Entry";
            node.ImageKey = "trv_t3entry";
            node.SelectedImageKey = "trv_t3entry";
            return node;
        }

        private TreeNode Populate(T4Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T4 Entry";
            node.ImageKey = "trv_t4entry";
            node.SelectedImageKey = "trv_t4entry";
            return node;
        }

        private TreeNode Populate(EntityEntry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "Entity Entry";
            node.ImageKey = "trv_entityentry";
            node.SelectedImageKey = "trv_entityentry";
            foreach (Entity entity in entry.Entities)
            {
                node.Nodes.Add(Populate(entity));
            }
            return node;
        }

        private TreeNode Populate(T11Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T11 Entry";
            node.ImageKey = "trv_t11entry";
            node.SelectedImageKey = "trv_t11entry";
            return node;
        }

        private TreeNode Populate(T12Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T12 Entry";
            node.ImageKey = "trv_t12entry";
            node.SelectedImageKey = "trv_t12entry";
            return node;
        }

        private TreeNode Populate(T13Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T13 Entry";
            node.ImageKey = "trv_t13entry";
            node.SelectedImageKey = "trv_t13entry";
            return node;
        }

        private TreeNode Populate(T14Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T14 Entry";
            node.ImageKey = "trv_t14entry";
            node.SelectedImageKey = "trv_t14entry";
            return node;
        }

        private TreeNode Populate(T15Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T15 Entry";
            node.ImageKey = "trv_t15entry";
            node.SelectedImageKey = "trv_t15entry";
            return node;
        }

        private TreeNode Populate(T17Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T17 Entry";
            node.ImageKey = "trv_t17entry";
            node.SelectedImageKey = "trv_t17entry";
            return node;
        }

        private TreeNode Populate(DemoEntry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "Demo Entry";
            node.ImageKey = "trv_demoentry";
            node.SelectedImageKey = "trv_demoentry";
            return node;
        }

        private TreeNode Populate(T20Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T20 Entry";
            node.ImageKey = "trv_t20entry";
            node.SelectedImageKey = "trv_t20entry";
            return node;
        }

        private TreeNode Populate(T21Entry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "T21 Entry";
            node.ImageKey = "trv_t21entry";
            node.SelectedImageKey = "trv_t21entry";
            return node;
        }

        private TreeNode Populate(UnknownEntry entry)
        {
            TreeNode node = new TreeNode();
            node.Tag = entry;
            node.Text = "Unknown Entry";
            node.ImageKey = "trv_unknownentry";
            node.SelectedImageKey = "trv_unknownentry";
            return node;
        }

        private TreeNode Populate(Entity entity)
        {
            TreeNode node = new TreeNode();
            node.Tag = entity;
            if (entity.Name != null)
            {
                node.Text = string.Format("Entity ({0})",entity.Name);
            }
            else
            {
                node.Text = "Unnamed Entity";
            }
            node.ImageKey = "trv_entity";
            node.SelectedImageKey = "trv_entity";
            return node;
        }

        private Control Display(object obj)
        {
            if (obj is Entity)
            {
                return DisplayEntity((Entity)obj);
            }
            else
            {
                return DisplayNothing();
            }
        }

        private Control DisplayEntity(Entity entity)
        {
            TabControl tabctl = new TabControl();
            tabctl.Dock = DockStyle.Fill;
            foreach (EntityField field in entity.Fields)
            {
                TabPage tab = new TabPage();
                tab.Text = field.Type.ToString("X");
                tab.Controls.Add(DisplayEntityField(field));
                tabctl.TabPages.Add(tab);
            }
            return tabctl;
        }

        private Control DisplayEntityField(EntityField field)
        {
            Label label = new Label();
            label.Dock = DockStyle.Fill;
            label.Text = "Field\n";
            label.Text += string.Format("\nType: 0x{0:X}",field.Type);
            label.Text += string.Format("\n???: {0}",field.Unknown1);
            label.Text += string.Format("\nElement Size: {0}",field.ElementSize);
            label.Text += string.Format("\n???: {0}",field.Unknown2);
            label.Text += string.Format("\nElement Count: {0}",field.ElementCount);
            label.Text += string.Format("\n???: {0}",field.Unknown3);
            return label;
        }

        private Control DisplayNothing()
        {
            Label label = new Label();
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = "No options available.";
            return label;
        }
    }
}
