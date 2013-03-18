using Crash;
using Crash.Game;
using System.Windows.Forms;

namespace CrashEdit
{
    public sealed class EntityController : Controller
    {
        private EntityEntryController entityentrycontroller;
        private Entity entity;

        public EntityController(EntityEntryController entityentrycontroller,Entity entity)
        {
            this.entityentrycontroller = entityentrycontroller;
            this.entity = entity;
            if (entity.Name != null)
            {
                Node.Text = string.Format("Entity ({0})",entity.Name);
            }
            else
            {
                Node.Text = "Entity";
            }
            Node.ImageKey = "entity";
            Node.SelectedImageKey = "entity";
        }

        protected override Control CreateEditor()
        {
            EntityBox box = new EntityBox(entity);
            box.Dock = DockStyle.Fill;
            return box;
        }

        public EntityEntryController EntityEntryController
        {
            get { return entityentrycontroller; }
        }

        public Entity Entity
        {
            get { return entity; }
        }
    }
}
