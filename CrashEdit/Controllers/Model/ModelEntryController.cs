using Crash;

namespace CrashEdit
{
    public sealed class ModelEntryController : EntryController
    {
        public ModelEntryController(EntryChunkController entrychunkcontroller,ModelEntry modelentry) : base(entrychunkcontroller,modelentry)
        {
            ModelEntry = modelentry;
            InvalidateNode();
        }

        public override void InvalidateNode()
        {
            if (ModelEntry.Positions == null)
            {
                Node.Text = string.Format("Model ({0})", ModelEntry.EName);
                Node.ImageKey = "crimsonb";
                Node.SelectedImageKey = "crimsonb";
            }
            else
            {
                Node.Text = string.Format("Compressed Model ({0})", ModelEntry.EName);
                Node.ImageKey = "crimsonb"; // would prefer red but whatever
                Node.SelectedImageKey = "crimsonb";
            }
        }

        public ModelEntry ModelEntry { get; }
    }
}
