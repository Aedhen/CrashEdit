using System.Collections.Generic;

namespace Crash.Unknown3
{
    public sealed class T3Chunk : EntryChunk
    {
        private List<T12Entry> entries;
        private int unknown1;
        private int unknown2;

        public T3Chunk(IEnumerable<T12Entry> entries,int unknown1,int unknown2)
        {
            this.entries = new List<T12Entry>(entries);
            this.unknown1 = unknown1;
            this.unknown2 = unknown2;
        }

        public override short Type
        {
            get { return 3; }
        }

        public IList<T12Entry> Entries
        {
            get { return entries; }
        }

        public override byte[] Save()
        {
            Entry[] entries = new Entry [this.entries.Count];
            for (int i = 0;i < this.entries.Count;i++)
            {
                entries[i] = this.entries[i];
            }
            return Save(entries,unknown1,unknown2);
        }
    }
}
