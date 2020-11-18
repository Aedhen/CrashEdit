namespace CrashEdit.Forms
{
    using System.Collections.Generic;
    using System.Linq;
    using Crash;
    using Crash.UI.Properties;
    using DarkUI.Collections;
    using DarkUI.Controls;
    using DarkUI.Forms;

    public partial class LoadListView : DarkForm
    {
        private readonly NSF _nsf;
        private List<LoadListViewZone> _loadListTreeData;

        // https://stackoverflow.com/questions/19226857/winform-treeview-find-node-by-tag

        public LoadListView(NSF nsf)
        {
            _nsf = nsf;

            InitializeComponent();
            SetLoadListTree();
        }

        private void SetLoadListTree()
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
                        AddLoadListToTree(entity.LoadListA, treeItem.LoadListA);
                        AddLoadListToTree(entity.LoadListB, treeItem.LoadListB);
                    }

                    _loadListTreeData.Add(treeItem);
                }
            }

            tvwLoadList.Nodes = new ObservableList<DarkTreeNode>();
            foreach (var treeItem in _loadListTreeData)
            {
                var zoneNode = new DarkTreeNode(treeItem.Zone);
                zoneNode.Nodes = new ObservableList<DarkTreeNode>();

                var listANode = CreateListNodes(treeItem.LoadListA, "Load List A");
                var listBNode = CreateListNodes(treeItem.LoadListB, "Load List B");

                zoneNode.Nodes.Add(listANode);
                zoneNode.Nodes.Add(listBNode);

                tvwLoadList.Nodes.Add(zoneNode);
            }
        }

        private DarkTreeNode CreateListNodes(List<LoadListViewLoadItem> loadItems, string nodeText)
        {
            var normalChunkCount = loadItems.Count(x => x.ChunkType == 0);
            var textureChunkCount = loadItems.Count(x => x.ChunkType == 1);
            var soundChunkCount = loadItems.Count(x => x.ChunkType == 2 || x.ChunkType == 3);
            var waveChunkCount = loadItems.Count(x => x.ChunkType == 4);
            var speechChunkCount = loadItems.Count(x => x.ChunkType == 5);
            var listANode =
                new DarkTreeNode(
                    $"{nodeText} (normal: {normalChunkCount}, texture: {textureChunkCount}, sound: {soundChunkCount}, wave: {waveChunkCount}, speech: {speechChunkCount})");
            listANode.Nodes = new ObservableList<DarkTreeNode>();
            foreach (var item in loadItems)
            {
                var itemNode = new DarkTreeNode(GetChunkText(item.ChunkType, item.ChunkIndex, item.ChunkEid));
                itemNode.Nodes = new ObservableList<DarkTreeNode>();
                foreach (var entry in item.Entries)
                    itemNode.Nodes.Add(new DarkTreeNode($"{entry.Position} - {entry.Entry}"));

                listANode.Nodes.Add(itemNode);
            }

            return listANode;
        }

        private void AddLoadListToTree(EntityT4Property loadList, List<LoadListViewLoadItem> treeLoadList)
        {
            if (loadList == null || loadList.RowCount <= 0)
            {
                return;
            }

            foreach (var loadListAItem in loadList.Rows)
            {
                if (loadListAItem.Values == null || loadListAItem.Values.Count == 0)
                {
                    continue;
                }

                foreach (var itemEid in loadListAItem.Values)
                {
                    var itemAsChunkIndex = FindChunkIndexForEntryEid(itemEid);
                    if (itemAsChunkIndex != null)
                    {
                        var itemAsChunk = _nsf.Chunks[itemAsChunkIndex.Value];
                        var loadItem = new LoadListViewLoadItem();
                        loadItem.ChunkEid = itemEid;
                        loadItem.ChunkIndex = itemAsChunkIndex.Value;
                        loadItem.ChunkType = itemAsChunk.Type;
                        treeLoadList.Add(loadItem);
                        continue;
                    }

                    var chunkForItemIndex = FindChunkIndexForChunkEid(itemEid);
                    if (chunkForItemIndex == null)
                    {
                        continue;
                    }

                    var chunkForItem = _nsf.Chunks[chunkForItemIndex.Value] as EntryChunk;
                    var itemAsEntry = chunkForItem.FindEID<IEntry>(itemEid);
                    var alreadyAddedLoadListItem =
                        treeLoadList.FirstOrDefault(x => x.ChunkIndex == chunkForItemIndex.Value);
                    if (alreadyAddedLoadListItem != null)
                    {
                        alreadyAddedLoadListItem.Entries.Add(new LoadListViewLoadItemEntry
                        {
                            Entry = itemAsEntry.EName,
                            Position = loadListAItem.MetaValue
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
                            Entry = itemAsEntry.EName,
                            Position = loadListAItem.MetaValue
                        });
                        treeLoadList.Add(loadItem);
                    }
                }
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

        private string GetChunkText(short? type, int chunkIndex, int? chunkEid = null)
        {
            if (!type.HasValue)
            {
                return string.Empty;
            }

            var chunkNumber = chunkIndex * 2 + 1;
            switch (type.Value)
            {
                case 0:
                    return string.Format(Resources.NormalChunkController_Text, chunkNumber);
                case 1:
                    return string.Format(Resources.TextureChunkController_Text, Entry.EIDToEName(chunkEid.Value),
                        chunkNumber);
                case 2:
                case 3:
                    return string.Format(Resources.SoundChunkController_Text, chunkNumber);
                case 4:
                    return string.Format(Resources.WavebankChunkController_Text, chunkNumber);
                case 5:
                    return string.Format(Resources.SpeechChunkController_Text, chunkNumber);
            }

            return type.ToString();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            SetLoadListTree();
        }
    }

    public class LoadListViewZone
    {
        public LoadListViewZone()
        {
            LoadListA = new List<LoadListViewLoadItem>();
            LoadListB = new List<LoadListViewLoadItem>();
        }

        public string Zone { get; set; }

        public List<LoadListViewLoadItem> LoadListA { get; set; }

        public List<LoadListViewLoadItem> LoadListB { get; set; }
    }

    public class LoadListViewLoadItem
    {
        public LoadListViewLoadItem()
        {
            Entries = new List<LoadListViewLoadItemEntry>();
        }

        public int ChunkEid { get; set; }

        public short ChunkType { get; set; }

        public int ChunkIndex { get; set; }

        public List<LoadListViewLoadItemEntry> Entries { get; set; }
    }

    public class LoadListViewLoadItemEntry
    {
        public short? Position { get; set; }

        public string Entry { get; set; }
    }
}