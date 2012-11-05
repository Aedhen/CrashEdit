using System.Collections.Generic;

namespace Crash.Unknown0
{
    public sealed class T11Entry : Entry
    {
        private List<byte[]> items;

        public T11Entry(IEnumerable<byte[]> items,int unknown) : base(unknown)
        {
            this.items = new List<byte[]>(items);
        }

        public override int Type
        {
            get { return 11; }
        }

        public IList<byte[]> Items
        {
            get { return items; }
        }

        public override byte[] Save()
        {
            return Save(items);
        }
    }
}
