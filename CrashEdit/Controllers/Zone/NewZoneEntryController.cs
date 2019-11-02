using Crash;
using System.Windows.Forms;

namespace CrashEdit
{
    public sealed class NewZoneEntryController : EntryController
    {
        public NewZoneEntryController(EntryChunkController entrychunkcontroller,NewZoneEntry zoneentry) : base(entrychunkcontroller,zoneentry)
        {
            NewZoneEntry = zoneentry;
            AddNode(new ItemController(null,zoneentry.Header));
            AddNode(new ItemController(null,zoneentry.Layout));
            foreach (Entity entity in zoneentry.Entities)
            {
                AddNode(new NewEntityController(this,entity));
            }
            InvalidateNode();
        }

        public override void InvalidateNode()
        {
            Node.Text = string.Format("Zone ({0})",NewZoneEntry.EName);
            Node.ImageKey = "violetb";
            Node.SelectedImageKey = "violetb";
        }

        protected override Control CreateEditor()
        {
            int linkedsceneryentrycount = BitConv.FromInt32(NewZoneEntry.Header,0);
            NewSceneryEntry[] linkedsceneryentries = new NewSceneryEntry [linkedsceneryentrycount];
            for (int i = 0;i < linkedsceneryentrycount;i++)
            {
                linkedsceneryentries[i] = FindEID<NewSceneryEntry>(BitConv.FromInt32(NewZoneEntry.Header,4 + i * 48));
            }
            int linkedzoneentrycount = BitConv.FromInt32(NewZoneEntry.Header,400);
            NewZoneEntry[] linkedzoneentries = new NewZoneEntry [linkedzoneentrycount];
            for (int i = 0;i < linkedzoneentrycount;i++)
            {
                linkedzoneentries[i] = FindEID<NewZoneEntry>(BitConv.FromInt32(NewZoneEntry.Header,404 + i * 4));
            }
            return new UndockableControl(new NewZoneEntryViewer(NewZoneEntry,linkedsceneryentries,linkedzoneentries));
        }

        public NewZoneEntry NewZoneEntry { get; }
    }
}
