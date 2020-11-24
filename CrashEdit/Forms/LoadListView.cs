namespace CrashEdit.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Crash;
    using Crash.UI.Properties;
    using DarkUI.Forms;

    public sealed partial class LoadListView : DarkForm
    {
        private readonly NSF _nsf;
        private List<LoadListViewZone> _loadListTreeData;

        private readonly ContextMenu _nodeContextMenu;

        // https://stackoverflow.com/questions/19226857/winform-treeview-find-node-by-tag

        public LoadListView(NSF nsf)
        {
            _nsf = nsf;

            InitializeComponent();
            txbFilter.KeyDown += txtInput_KeyDown;
            txbFilter.KeyPress += txtInput_KeyPress;
            InitTreeView();

            _nodeContextMenu = new ContextMenu();
            AddMenu("Copy name", CopyToClipboard);
            tvwLoadList.MouseUp += tvwLoadList_MouseUp;
        }

        private void InitTreeView()
        {
            _loadListTreeData = new List<LoadListViewZone>();

            foreach (var chunk in _nsf.Chunks)
            {
                var normalChunk = chunk as NormalChunk;
                if (normalChunk == null)
                {
                    continue;
                }

                foreach (var entry in normalChunk.Entries)
                {
                    var zoneEntry = entry as ZoneEntry;
                    if (zoneEntry == null)
                    {
                        continue;
                    }

                    var treeItem = new LoadListViewZone
                    {
                        Zone = zoneEntry.EName
                    };

                    foreach (var entity in zoneEntry.Entities)
                    {
                        if ((entity.LoadListA == null || entity.LoadListA.RowCount <= 0) && (entity.LoadListB == null || entity.LoadListB.RowCount <= 0))
                        {
                            continue;
                        }

                        var camera = new LoadListViewCamera();
                        AddLoadListToTree(entity.LoadListA, camera.LoadListA);
                        AddLoadListToTree(entity.LoadListB, camera.LoadListB);
                        treeItem.Cameras.Add(camera);
                    }

                    _loadListTreeData.Add(treeItem);
                }
            }

            _loadListTreeData = _loadListTreeData.OrderBy(x => x.Zone, StringComparer.Ordinal).ToList();

            SetTreeViewNodes();
        }

        private void SetTreeViewNodes(string filter = null)
        {
            tvwLoadList.Nodes.Clear();
            foreach (var treeItem in _loadListTreeData)
            {
                var zoneNode = new TreeNode(treeItem.Zone);

                for (var i = 0; i < treeItem.Cameras.Count; i++)
                {
                    var camera = treeItem.Cameras[i];
                    var cameraNode = new TreeNode($"Camera {i+1}");

                    var listANode = CreateListNodes(camera.LoadListA, "Load List A", filter);
                    if (filter == null || listANode.Nodes.Count > 0)
                    {
                        cameraNode.Nodes.Add(listANode);
                    }

                    var listBNode = CreateListNodes(camera.LoadListB, "Load List B", filter);
                    if (filter == null || listBNode.Nodes.Count > 0)
                    {
                        cameraNode.Nodes.Add(listBNode);
                    }

                    if (filter == null || cameraNode.Nodes.Count > 0)
                    {
                        zoneNode.Nodes.Add(cameraNode);
                    }
                }

                if (filter == null || zoneNode.Nodes.Count > 0)
                {
                    tvwLoadList.Nodes.Add(zoneNode);
                }
            }
        }

        private TreeNode CreateListNodes(SortedList<int, LoadListViewLoadItem> loadItems, string nodeText, string filter = null)
        {
            var listANode = CreateLoadListNode(loadItems, nodeText);
            foreach (var item in loadItems)
            {
                var chunkName = Entry.EIDToEName(item.Value.ChunkEid);
                if (!string.IsNullOrEmpty(filter) && item.Value.ChunkEid != 0)
                {
                    if (!string.Equals(chunkName, filter, StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                }

                var itemNode = new TreeNode(GetChunkNodeText(item.Value));
                if (item.Value.LoadCount > 1)
                {
                    itemNode.BackColor = Color.Red;
                }

                if (item.Value.Entries.Count > 0)
                {
                    foreach (var entry in item.Value.Entries)
                    {
                        if (!string.IsNullOrEmpty(filter) && !string.Equals(entry.Name, filter, StringComparison.InvariantCultureIgnoreCase))
                        {
                            continue;
                        }

                        itemNode.Nodes.Add(new TreeNode($"{entry.Position} - {entry.Name}") { Tag = entry.Name });
                    }
                }
                else
                {
                    itemNode.Tag = chunkName;
                }

                if (filter == null || itemNode.Nodes.Count > 0)
                {
                    listANode.Nodes.Add(itemNode);
                }
            }

            return listANode;
        }

        private static TreeNode CreateLoadListNode(SortedList<int, LoadListViewLoadItem> loadItems, string loadListName)
        {
            var normalChunkCount = loadItems.Count(x => x.Value.ChunkType == 0);
            var textureChunkCount = loadItems.Count(x => x.Value.ChunkType == 1);
            var soundChunkCount = loadItems.Count(x => x.Value.ChunkType == 2 || x.Value.ChunkType == 3);
            var waveChunkCount = loadItems.Count(x => x.Value.ChunkType == 4);
            var speechChunkCount = loadItems.Count(x => x.Value.ChunkType == 5);
            var unknownChunkCount = loadItems.Count(x => x.Value.ChunkType != 0 && x.Value.ChunkType != 1 
                                                                                && x.Value.ChunkType != 2 && x.Value.ChunkType != 3 && x.Value.ChunkType != 4 && x.Value.ChunkType != 5);
            var listANode =
                new TreeNode(
                    $"{loadListName} (normal: {normalChunkCount}, texture: {textureChunkCount}, sound: {soundChunkCount}, wave: {waveChunkCount}, speech: {speechChunkCount}, unknown: {unknownChunkCount})");

            if (normalChunkCount > 21 || textureChunkCount > 8 || soundChunkCount + waveChunkCount > 8)
            {
                listANode.BackColor = Color.Red;
            }
            
            return listANode;
        }

        private void AddLoadListToTree(EntityT4Property loadList, SortedList<int, LoadListViewLoadItem> treeLoadList)
        {
            if (loadList == null || loadList.RowCount <= 0)
            {
                return;
            }

            foreach (var loadListRow in loadList.Rows)
            {
                if (loadListRow.Values == null || loadListRow.Values.Count == 0)
                {
                    continue;
                }

                for (var listEntryIndex = 0; listEntryIndex < loadListRow.Values.Count; listEntryIndex++)
                {
                    var itemEid = loadListRow.Values[listEntryIndex];
                    var itemAsChunkIndex = FindChunkIndexForEntryEid(itemEid);
                    if (itemAsChunkIndex != null)
                    {
                        if (treeLoadList.ContainsKey(itemAsChunkIndex.Value))
                        {
                            treeLoadList[itemAsChunkIndex.Value].LoadCount += 1;
                        }
                        else
                        {
                            var itemAsChunk = _nsf.Chunks[itemAsChunkIndex.Value];
                            var loadItem = new LoadListViewLoadItem();
                            loadItem.ChunkEid = itemEid;
                            loadItem.ChunkIndex = itemAsChunkIndex.Value;
                            loadItem.ChunkType = itemAsChunk.Type;
                            treeLoadList.Add(itemAsChunkIndex.Value, loadItem);
                        }

                        continue;
                    }

                    var chunkForItemIndex = FindChunkIndexForChunkEid(itemEid);
                    if (chunkForItemIndex == null)
                    {
                        continue;
                    }

                    var chunkForItem = _nsf.Chunks[chunkForItemIndex.Value] as EntryChunk;
                    var itemAsEntry = chunkForItem.FindEID<IEntry>(itemEid);
                    if (treeLoadList.ContainsKey(chunkForItemIndex.Value))
                    {
                        treeLoadList[chunkForItemIndex.Value].Entries.Add(new LoadListViewLoadItemEntry
                        {
                            Name = itemAsEntry.EName,
                            Position = loadListRow.MetaValue,
                            ListIndex = listEntryIndex
                        });
                    }
                    else
                    {
                        var loadItem = new LoadListViewLoadItem();
                        loadItem.ChunkEid = itemEid;
                        loadItem.ChunkIndex = chunkForItemIndex.Value;
                        loadItem.ChunkType = chunkForItem.Type;
                        loadItem.Entries.Add(new LoadListViewLoadItemEntry
                        {
                            Name = itemAsEntry.EName,
                            Position = loadListRow.MetaValue,
                            ListIndex = listEntryIndex
                        });
                        treeLoadList.Add(chunkForItemIndex.Value, loadItem);
                    }
                }
            }
        }

        private void AddMenu(string text, ControllerMenuDelegate proc)
        {
            void handler(object sender, EventArgs e)
            {
                try
                {
                    ErrorManager.EnterSubject(new Object());
                    proc();
                }
                catch (GUIException ex)
                {
                    MessageBox.Show(ex.Message, text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ErrorManager.ExitSubject();
                }
            }
            _nodeContextMenu.MenuItems.Add(text, handler);
        }

        private void tvwLoadList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvwLoadList.SelectedNode = tvwLoadList.GetNodeAt(e.X, e.Y);
                if (tvwLoadList.SelectedNode?.Tag != null)
                {
                    _nodeContextMenu.Show(tvwLoadList, e.Location);
                }
            }
        }

        private void CopyToClipboard()
        {
            if (tvwLoadList?.SelectedNode != null)
            {
                Clipboard.SetText((string)tvwLoadList.SelectedNode.Tag);
            }
        }

        private int? FindChunkIndexForEntryEid(int eid)
        {
            if (eid == Entry.NullEID)
            {
                return null;
            }

            for (var i = 0; i < _nsf.Chunks.Count; i++)
            {
                var chunk = _nsf.Chunks[i];
                if (!(chunk is IEntry iEntryChunk))
                {
                    continue;
                }

                if (iEntryChunk.EID == eid)
                {
                    return i;
                }
            }

            return null;
        }

        private int? FindChunkIndexForChunkEid(int eid)
        {
            if (eid == Entry.NullEID)
            {
                return null;
            }

            for (var i = 0; i < _nsf.Chunks.Count; i++)
            {
                var chunk = _nsf.Chunks[i];
                if (!(chunk is EntryChunk entryChunk))
                {
                    continue;
                }

                var entry = entryChunk.FindEID<IEntry>(eid);
                if (entry != null)
                {
                    return i;
                }
            }

            return null;
        }

        private string GetChunkNodeText(LoadListViewLoadItem loadItem)
        {
            string chunkText;
            List<string> chunkTextInterpolationArgs = new List<string>();
            switch (loadItem.ChunkType)
            {
                case 0:
                    chunkText = Resources.NormalChunkController_Text;
                    break;
                case 1:
                    chunkText = Resources.TextureChunkController_Text;
                    chunkTextInterpolationArgs.Add(Entry.EIDToEName(loadItem.ChunkEid));
                    break;
                case 2:
                case 3:
                    chunkText = Resources.SoundChunkController_Text;
                    break;
                case 4:
                    chunkText = Resources.WavebankChunkController_Text;
                    break;
                case 5:
                    chunkText = Resources.SpeechChunkController_Text;
                    break;
                default:
                    chunkText = "Unknown Chunk";
                    break;
            }

            var chunkNumber = loadItem.ChunkIndex * 2 + 1;
            chunkTextInterpolationArgs.Add(chunkNumber.ToString());

            chunkText = string.Format(chunkText, chunkTextInterpolationArgs.ToArray());
            if (loadItem.LoadCount > 1)
            {
                chunkText = $"{chunkText} (times loaded: {loadItem.LoadCount})";
            }

            return chunkText;
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            InitTreeView();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            SetTreeViewNodes(txbFilter.Text);
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent beeping
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.LineFeed)
            {
                e.Handled = true;
            }
        }
    }

    public class LoadListViewZone
    {
        public LoadListViewZone()
        {
            Cameras = new List<LoadListViewCamera>();
        }

        public string Zone { get; set; }

        public List<LoadListViewCamera> Cameras { get; set; }
    }

    public class LoadListViewCamera
    {
        public LoadListViewCamera()
        {
            LoadListA = new SortedList<int, LoadListViewLoadItem>();
            LoadListB = new SortedList<int, LoadListViewLoadItem>();
        }

        public SortedList<int, LoadListViewLoadItem> LoadListA { get; set; }

        public SortedList<int, LoadListViewLoadItem> LoadListB { get; set; }
    }

    public class LoadListViewLoadItem
    {
        public LoadListViewLoadItem()
        {
            LoadCount = 1;
            Entries = new List<LoadListViewLoadItemEntry>();
        }

        public int ChunkEid { get; set; }

        public short ChunkType { get; set; }

        public int ChunkIndex { get; set; }

        public List<LoadListViewLoadItemEntry> Entries { get; set; }

        public int LoadCount { get; set; }
    }

    public class LoadListViewLoadItemEntry
    {
        public short? Position { get; set; }

        public string Name { get; set; }

        public int ListIndex { get; set; }
    }
}