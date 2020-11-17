using System.Collections.Generic;

namespace Crash
{
    public sealed class ZoneEntry : Entry
    {
        private List<Entity> entities;

        public ZoneEntry(byte[] header,byte[] layout,IEnumerable<Entity> entities,int eid) : base(eid)
        {
            Header = header;
            Layout = layout;
            this.entities = new List<Entity>(entities);
        }

        public override int Type => 7;
        public byte[] Header { get; }
        public byte[] Layout { get; }
        public IList<Entity> Entities => entities;

        public int InfoCount
        {
            get => BitConv.FromInt32(Header,0x184);
            set => BitConv.ToInt32(Header,0x184,value);
        }

        public int CameraCount
        {
            get => BitConv.FromInt32(Header,0x188);
            set => BitConv.ToInt32(Header,0x188,value);
        }

        public int EntityCount
        {
            get => BitConv.FromInt32(Header,0x18C);
            set => BitConv.ToInt32(Header,0x18C,value);
        }

        public int ZoneCount
        {
            get => BitConv.FromInt32(Header,0x190);
            set => BitConv.ToInt32(Header,0x190,value);
        }

        public int XOffset
        {
            get => BitConv.FromInt32(Layout, 0);
            set => BitConv.ToInt32(Layout, 0, value);
        }

        public int YOffset
        {
            get => BitConv.FromInt32(Layout, 4);
            set => BitConv.ToInt32(Layout, 4, value);
        }

        public int ZOffset
        {
            get => BitConv.FromInt32(Layout, 8);
            set => BitConv.ToInt32(Layout, 8, value);
        }

        public int Width
        {
            get => BitConv.FromInt32(Layout, 12);
            set => BitConv.ToInt32(Layout, 12, value);
        }

        public int Height
        {
            get => BitConv.FromInt32(Layout, 16);
            set => BitConv.ToInt32(Layout, 16, value);
        }

        public int Depth
        {
            get => BitConv.FromInt32(Layout, 20);
            set => BitConv.ToInt32(Layout, 20, value);
        }

        public override UnprocessedEntry Unprocess()
        {
            byte[][] items = new byte [2 + entities.Count][];
            items[0] = Header;
            items[1] = Layout;
            for (int i = 0;i < entities.Count;i++)
            {
                items[2 + i] = entities[i].Save();
            }
            return new UnprocessedEntry(items,EID,Type);
        }
    }
}
