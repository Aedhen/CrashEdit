namespace CrashEdit.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Forms;
    using Crash;
    using CrashEdit.Forms;
    using CrashEdit.Helpers;
    using DarkUI.Controls;
    using DarkUI.Forms;

    public partial class NsdBox : UserControl
    {
        private readonly NSD _nsd;
        private readonly NSF _nsf;
        private readonly string _filename;
        private List<SpawnPointListModel> _spawnPointList;
        public LoadListView frmLoadListView = null;
        public DrawListView frmDrawListView = null;

        public NsdBox(NSD nsd, NSF nsf, string filename)
        {
            InitializeComponent();

            _nsd = nsd;
            _nsf = nsf;
            _filename = filename;
            InitSpawnPointList();
        }

        private void InitSpawnPointList()
        {
            _spawnPointList = new List<SpawnPointListModel>();
            foreach (var spawn in _nsd.Spawns)
            {
                var zoneEntry = _nsf.FindEID<ZoneEntry>(spawn.ZoneEID);
                _spawnPointList.Add(new SpawnPointListModel
                {
                    OriginalZoneEid = spawn.ZoneEID,
                    ZoneName = Entry.EIDToEName(spawn.ZoneEID),
                    Position = CalculateSpawnPositionInZone(new Position(spawn.SpawnX, spawn.SpawnY, spawn.SpawnZ), zoneEntry)
                });
            }

            var listItems = new ObservableCollection<DarkListItem>();
            foreach(var spawn in _spawnPointList)
            {
                listItems.Add(new DarkListItem
                {
                    Text = spawn.ZoneName
                });
            }

            lstSpawnPoints.Items = listItems;
            lstSpawnPoints.SelectedIndicesChanged += lstSpawnPoints_SelectedIndexChanged;

            numX.Enabled = false;
            numX.ValueChanged += numX_ValueChanged;
            numY.Enabled = false;
            numY.ValueChanged += numY_ValueChanged;
            numZ.Enabled = false;
            numZ.ValueChanged += numZ_ValueChanged;
        }

        private void lstSpawnPoints_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            numX.Enabled = true;
            numY.Enabled = true;
            numZ.Enabled = true;

            var selectedIndex = lstSpawnPoints.SelectedIndices[0];
            var selectedGlobalSpawn = _spawnPointList[selectedIndex];
            txbName.Text = selectedGlobalSpawn.ZoneName;
            txbName.TextChanged += txbName_TextChanged;

            numX.Value = (decimal)selectedGlobalSpawn.Position.X;
            numY.Value = (decimal)selectedGlobalSpawn.Position.Y;
            numZ.Value = (decimal)selectedGlobalSpawn.Position.Z;
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            var selectedIndex = lstSpawnPoints.SelectedIndices[0];
            lstSpawnPoints.Items[selectedIndex].Text = txbName.Text;
            lstSpawnPoints.Refresh();
             _spawnPointList[selectedIndex].ZoneName = txbName.Text;
        }

        private void SetNewZoneNames()
        {
            for (int i = 0; i < _spawnPointList.Count; i++)
            {
                try
                {
                    var eid = Entry.ENameToEID(_spawnPointList[i].ZoneName);
                    var zoneEntry = _nsf.FindEID<ZoneEntry>(eid);
                    if (zoneEntry == null)
                    {
                        DarkMessageBox.ShowError($"Invalid zone name: zone {txbName.Text} not found in NSF. Changes for this spawn are not saved.", "Zone");
                        continue;
                    }

                    var spawnToUpdate = _nsd.Spawns.FirstOrDefault(x => x.ZoneEID == _spawnPointList[i].OriginalZoneEid);
                    if (spawnToUpdate == null)
                    {
                        DarkMessageBox.ShowError($"Could not determine which spawn should be updated. Spawn with zone EID {_spawnPointList[i].OriginalZoneEid} not found. Changes for this spawn are not saved.", "Zone");
                        continue;
                    }

                    _spawnPointList[i].OriginalZoneEid = eid;
                    spawnToUpdate.ZoneEID = eid;
                    spawnToUpdate.SpawnX = CalculateGlobalSpawnCoordinate((int)_spawnPointList[i].Position.X, zoneEntry.XOffset);
                    spawnToUpdate.SpawnY = CalculateGlobalSpawnCoordinate((int)_spawnPointList[i].Position.Y, zoneEntry.YOffset);
                    spawnToUpdate.SpawnZ = CalculateGlobalSpawnCoordinate((int)_spawnPointList[i].Position.Z, zoneEntry.ZOffset);
                }
                catch (Exception ex)
                {
                    DarkMessageBox.ShowError("Invalid zone name", "Zone");
                }
            }
        }

        private void numX_ValueChanged(object sender, EventArgs e)
        {
            var inputX = (int)numX.Value;
            var selectedIndex = lstSpawnPoints.SelectedIndices[0];
            var oldPosition = _spawnPointList[selectedIndex].Position;
            _spawnPointList[selectedIndex].Position = new Position(inputX, oldPosition.Y, oldPosition.Z);
        }

        private void numY_ValueChanged(object sender, EventArgs e)
        {
            var inputY = (int)numY.Value;
            var selectedIndex = lstSpawnPoints.SelectedIndices[0];
            var oldPosition = _spawnPointList[selectedIndex].Position;
            _spawnPointList[selectedIndex].Position = new Position(oldPosition.X, inputY, oldPosition.Z);
        }

        private void numZ_ValueChanged(object sender, EventArgs e)
        {
            var inputZ = (int)numZ.Value;
            var selectedIndex = lstSpawnPoints.SelectedIndices[0];
            var oldPosition = _spawnPointList[selectedIndex].Position;
            _spawnPointList[selectedIndex].Position = new Position(oldPosition.X, oldPosition.Y, inputZ);
        }

        private Position CalculateSpawnPositionInZone(Position globalSpawnPosition, ZoneEntry zone)
        {
            var zoneSpawnX = CalculateSpawnCoordinateInZone((int)globalSpawnPosition.X, zone.XOffset);
            var zoneSpawnY = CalculateSpawnCoordinateInZone((int)globalSpawnPosition.Y, zone.YOffset);
            var zoneSpawnZ = CalculateSpawnCoordinateInZone((int)globalSpawnPosition.Z, zone.ZOffset);
            return new Position(zoneSpawnX, zoneSpawnY, zoneSpawnZ);
        }

        private int CalculateSpawnCoordinateInZone(int globalSpawnCoordinate, int zoneCoordinate)
        {
            return ((globalSpawnCoordinate >> 8) - zoneCoordinate) / 4;
        }

        private int CalculateGlobalSpawnCoordinate(int spawnCoordinateInZone, int zoneCoordinate)
        {
            return (zoneCoordinate + (4 * spawnCoordinateInZone)) << 8;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetNewZoneNames();
            NsdHelper.SaveNsdFile(_nsd, _filename);
        }

        private void btnViewLoadList_Click(object sender, EventArgs e)
        {
            if (frmLoadListView == null || frmLoadListView.IsDisposed)
            {
                frmLoadListView = new LoadListView(_nsf);
            }

            if (!frmLoadListView.Visible)
            {
                frmLoadListView.Show();
            }
            else
            {
                frmLoadListView.Activate();
            }
        }

        private void btnViewDrawList_Click(object sender, EventArgs e)
        {
            if (frmDrawListView == null || frmDrawListView.IsDisposed)
            {
                frmDrawListView = new DrawListView(_nsf);
            }

            if (!frmDrawListView.Visible)
            {
                frmDrawListView.Show();
            }
            else
            {
                frmDrawListView.Activate();
            }
        }
    }

    public class SpawnPointListModel
    {
        public int OriginalZoneEid { get; set; }

        public string ZoneName { get; set; }

        public Position Position { get; set; }
    }
}