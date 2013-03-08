using System;
using System.Collections.Generic;

namespace Crash
{
    public abstract class EntryChunk : Chunk
    {
        private List<Entry> entries;
        private int unknown2;

        public EntryChunk(IEnumerable<Entry> entries,int unknown2)
        {
            if (entries == null)
                throw new ArgumentNullException("entries");
            this.entries = new List<Entry>(entries);
            this.unknown2 = unknown2;
        }

        public IList<Entry> Entries
        {
            get { return entries; }
        }

        protected abstract int Alignment
        {
            get;
        }

        protected abstract int AlignmentOffset
        {
            get;
        }

        public override byte[] Save(int chunkid)
        {
            return Save(chunkid,entries,unknown2);
        }

        protected byte[] Save(int chunkid,IList<Entry> entries,int unknown2)
        {
            return Save(chunkid,entries,unknown2,Alignment,AlignmentOffset);
        }

        protected byte[] Save(int chunkid,IList<Entry> entries,int unknown2,int align,int alignoffset)
        {
            if (entries == null)
                throw new ArgumentNullException("entries");
            if (align < 0)
                throw new ArgumentOutOfRangeException("align");
            if (alignoffset < 0 || alignoffset >= align)
                throw new ArgumentOutOfRangeException("alignoffset");
            byte[] data = new byte [Length];
            BitConv.ToHalf(data,0,Magic);
            BitConv.ToHalf(data,2,Type);
            BitConv.ToWord(data,4,chunkid);
            BitConv.ToWord(data,8,entries.Count);
            BitConv.ToWord(data,12,unknown2);
            int offset = 20 + entries.Count * 4;
            Aligner.Align(ref offset,align,alignoffset);
            BitConv.ToWord(data,16,offset);
            for (int i = 0;i < entries.Count;i++)
            {
                byte[] entrydata = entries[i].Save();
                if (offset + entrydata.Length > Length)
                {
                    throw new PackingException();
                }
                entrydata.CopyTo(data,offset);
                offset += entrydata.Length;
                if (i < entries.Count - 1)
                {
                    // Ugly hack
                    Aligner.Align(ref offset,align,alignoffset);
                }
                BitConv.ToWord(data,20 + i * 4,offset);
            }
            return data;
        }
    }
}
