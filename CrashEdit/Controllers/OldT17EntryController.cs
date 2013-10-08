using Crash;

namespace CrashEdit
{
    public sealed class OldT17EntryController : MysteryMultiItemEntryController
    {
        private OldT17Entry oldt17entry;

        public OldT17EntryController(EntryChunkController entrychunkcontroller,OldT17Entry oldt17entry) : base(entrychunkcontroller,oldt17entry)
        {
            this.oldt17entry = oldt17entry;
            Node.Text = string.Format("Old T17 Entry ({0})",oldt17entry.EIDString);
            Node.ImageKey = "oldt17entry";
            Node.SelectedImageKey = "oldt17entry";
        }

        public OldT17Entry OldT17Entry
        {
            get { return oldt17entry; }
        }
    }
}
