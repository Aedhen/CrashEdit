using Crash;
using System.Windows.Forms;

namespace CrashEdit
{
    public sealed class EntityEntryController : EntryController
    {
        private EntityEntry entityentry;

        public EntityEntryController(EntryChunkController entrychunkcontroller,EntityEntry entityentry) : base(entrychunkcontroller,entityentry)
        {
            this.entityentry = entityentry;
            Node.Text = string.Format("Entity Entry ({0})",entityentry.EIDString);
            Node.ImageKey = "entityentry";
            Node.SelectedImageKey = "entityentry";
            AddNode(new ItemController(null,entityentry.Unknown1));
            AddNode(new ItemController(null,entityentry.Unknown2));
            foreach (Entity entity in entityentry.Entities)
            {
                AddNode(new EntityController(this,entity));
            }
        }

        protected override Control CreateEditor()
        {
            return new UndockableControl(new EntityEntryViewer(entityentry));
        }

        public EntityEntry EntityEntry
        {
            get { return entityentry; }
        }
    }
}
