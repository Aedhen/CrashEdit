using System.Collections.Generic;

namespace Crash
{
    public sealed class EntitySettingProperty : EntityBasicProperty<EntitySetting>
    {
        public EntitySettingProperty()
        {
        }

        public EntitySettingProperty(IEnumerable<EntityPropertyRow<EntitySetting>> rows) : base(rows)
        {
        }

        public override byte Type
        {
            get { return 5; }
        }

        public override byte ElementSize
        {
            get { return 4; }
        }

        protected override void SaveElement(byte[] data,EntitySetting value)
        {
            data[0] = value.ValueA;
            BitConv.ToInt24(data,1,value.ValueB);
        }
    }
}
