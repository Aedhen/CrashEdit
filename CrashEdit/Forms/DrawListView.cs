namespace CrashEdit.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using Crash;
    using DarkUI.Controls;
    using DarkUI.Forms;

    public sealed partial class DrawListView : DarkForm
    {
        private readonly NSF _nsf;
        private List<DrawListViewZone> _drawListTreeData;

        private readonly ContextMenu _nodeContextMenu;

        private const string FilterTypeId = "ID";
        private const string FilterTypeName = "Name";

        public DrawListView(NSF nsf)
        {
            _nsf = nsf;

            InitializeComponent();
            InitFilter();
            InitTreeView();

            _nodeContextMenu = new ContextMenu();
            AddMenu("Copy ID", CopyToClipboard);

            tvwDrawList.MouseUp += TvwDrawListMouseUp;
        }

        private void InitFilter()
        {
            txbFilter.KeyDown += txtInput_KeyDown;
            txbFilter.KeyPress += txtInput_KeyPress;

            dpdFilter.Items.Add(new DarkDropdownItem(FilterTypeId));
            dpdFilter.Items.Add(new DarkDropdownItem(FilterTypeName));
            dpdFilter.SelectedItem = dpdFilter.Items[0];
        }

        private void InitTreeView()
        {
            _drawListTreeData = new List<DrawListViewZone>();

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

                    var treeItem = new DrawListViewZone
                    {
                        Zone = zoneEntry.EName
                    };

                    foreach (var entity in zoneEntry.Entities)
                    {
                        if ((entity.DrawListA == null || entity.DrawListA.RowCount <= 0) &&
                            (entity.DrawListB == null || entity.DrawListB.RowCount <= 0))
                        {
                            continue;
                        }

                        var camera = new DrawListViewCamera();
                        AddDrawListToTree(entity.DrawListA, camera.DrawListA);
                        AddDrawListToTree(entity.DrawListB, camera.DrawListB);
                        treeItem.Cameras.Add(camera);
                    }

                    _drawListTreeData.Add(treeItem);
                }
            }

            _drawListTreeData = _drawListTreeData.OrderBy(x => x.Zone, StringComparer.Ordinal).ToList();

            SetTreeViewNodes();
        }

        private void SetTreeViewNodes(bool applyFilter = false)
        {
            tvwDrawList.Nodes.Clear();
            foreach (var treeItem in _drawListTreeData)
            {
                var zoneNode = new TreeNode(treeItem.Zone);

                for (var i = 0; i < treeItem.Cameras.Count; i++)
                {
                    var camera = treeItem.Cameras[i];
                    var cameraNode = new TreeNode($"Camera {i + 1}");

                    var listANode = CreateDrawListNodes(camera.DrawListA, "Draw List A", applyFilter);
                    if (!applyFilter || listANode.Nodes.Count > 0)
                    {
                        cameraNode.Nodes.Add(listANode);
                    }

                    var listBNode = CreateDrawListNodes(camera.DrawListB, "Draw List B", applyFilter);
                    if (!applyFilter || listBNode.Nodes.Count > 0)
                    {
                        cameraNode.Nodes.Add(listBNode);
                    }

                    if (!applyFilter || cameraNode.Nodes.Count > 0)
                    {
                        zoneNode.Nodes.Add(cameraNode);
                    }
                }

                if (!applyFilter || zoneNode.Nodes.Count > 0)
                {
                    tvwDrawList.Nodes.Add(zoneNode);
                }
            }

            if (applyFilter)
            {
                tvwDrawList.ExpandAll();
            }
        }

        private TreeNode CreateDrawListNodes(SortedList<int, DrawListViewDrawItemEntity> drawItems, string nodeText,
            bool applyFilter)
        {
            var drawListNode = new TreeNode(nodeText);
            if (applyFilter && dpdFilter.SelectedItem.Text == FilterTypeId)
            {

            }

            foreach (var item in drawItems)
            {
                var itemNode = new TreeNode(item.Value.NodeText);
                itemNode.Tag = item.Value.Id.ToString();
                if (item.Value.LoadCount > 1)
                {
                    itemNode.BackColor = Color.Red;
                }

                if (applyFilter)
                {
                    if (dpdFilter.SelectedItem.Text == FilterTypeId)
                    {
                        if (int.TryParse(txbFilter.Text, out var filterInputId) && filterInputId == item.Value.Id)
                        {
                            drawListNode.Nodes.Add(itemNode);
                        }
                    } 
                    else if (dpdFilter.SelectedItem.Text == FilterTypeName)
                    {
                        if (item.Value.Name.Contains(txbFilter.Text))
                        {
                            drawListNode.Nodes.Add(itemNode);
                        }
                    }
                }
                else
                {
                    drawListNode.Nodes.Add(itemNode);
                }
            }

            return drawListNode;
        }

        private void AddDrawListToTree(EntityInt32Property drawList,
            SortedList<int, DrawListViewDrawItemEntity> treeDrawList)
        {
            if (drawList == null || drawList.RowCount <= 0)
            {
                return;
            }

            foreach (var drawListRow in drawList.Rows)
            {
                if (drawListRow.Values == null || drawListRow.Values.Count == 0)
                {
                    continue;
                }

                foreach (var entityIdRaw in drawListRow.Values)
                {
                    var entityId = entityIdRaw >> 8 & 0xFFFF;
                    foreach (var chunk in _nsf.Chunks)
                    {
                        if (!(chunk is EntryChunk entryChunk))
                        {
                            continue;
                        }

                        foreach (var entry in entryChunk.Entries)
                        {
                            if (!(entry is ZoneEntry zoneEntry))
                            {
                                continue;
                            }

                            foreach (var entity in zoneEntry.Entities)
                            {
                                if (!entity.ID.HasValue || entity.ID.Value != entityId)
                                {
                                    continue;
                                }

                                if (treeDrawList.ContainsKey(entityId))
                                {
                                    treeDrawList[entityId].LoadCount += 1;
                                }
                                else
                                {
                                    treeDrawList.Add(entityId, new DrawListViewDrawItemEntity
                                    {
                                        Position = drawListRow.MetaValue,
                                        Id = entity.ID.Value,
                                        Name = entity.Name,
                                        Type = entity.Type.Value,
                                        Subtype = entity.Subtype.Value,
                                    });
                                }
                            }
                        }
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

        private void TvwDrawListMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvwDrawList.SelectedNode = tvwDrawList.GetNodeAt(e.X, e.Y);
                if (tvwDrawList.SelectedNode?.Tag != null)
                {
                    _nodeContextMenu.Show(tvwDrawList, e.Location);
                }
            }
        }

        private void CopyToClipboard()
        {
            if (tvwDrawList?.SelectedNode != null)
            {
                Clipboard.SetText((string) tvwDrawList.SelectedNode.Tag);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
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
            SetTreeViewNodes(txbFilter.Text != string.Empty);
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent beeping
            if (e.KeyChar == (char) Keys.Enter || e.KeyChar == (char) Keys.Escape || e.KeyChar == (char) Keys.LineFeed)
            {
                e.Handled = true;
            }
        }

        private void btnExpandTree_Click(object sender, EventArgs e)
        {
            tvwDrawList.ExpandAll();
        }

        private void btnCollapseTree_Click(object sender, EventArgs e)
        {
            tvwDrawList.CollapseAll();
        }
    }

    public class DrawListViewZone
    {
        public DrawListViewZone()
        {
            Cameras = new List<DrawListViewCamera>();
        }

        public string Zone { get; set; }

        public List<DrawListViewCamera> Cameras { get; set; }
    }

    public class DrawListViewCamera
    {
        public DrawListViewCamera()
        {
            DrawListA = new SortedList<int, DrawListViewDrawItemEntity>();
            DrawListB = new SortedList<int, DrawListViewDrawItemEntity>();
        }

        public SortedList<int, DrawListViewDrawItemEntity> DrawListA { get; set; }

        public SortedList<int, DrawListViewDrawItemEntity> DrawListB { get; set; }
    }

    public class DrawListViewDrawItemEntity
    {
        public DrawListViewDrawItemEntity()
        {
            LoadCount = 1;
        }

        public short? Position { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public int Subtype { get; set; }

        public int LoadCount { get; set; }

        public string NodeText
        {
            get
            {
                var nodeText = $"{Position} - ID {Id}, {Name} - {Type} {Subtype}";
                if (LoadCount > 1)
                {
                    nodeText += $" (times loaded: {LoadCount})";
                }

                return nodeText;
            }
        }
    }
}