using System;

namespace Crash.Audio
{
    [EntryType(13)]
    public sealed class MusicEntryLoader : EntryLoader
    {
        public override Entry Load(byte[][] items,int eid)
        {
            if (items == null)
                throw new ArgumentNullException("items");
            if (items.Length != 3)
            {
                throw new LoadException();
            }
            if (items[0].Length != 36)
            {
                throw new LoadException();
            }
            int seqcount = BitConv.FromInt32(items[0],0);
            int vheid = BitConv.FromInt32(items[0],4);
            int vb0eid = BitConv.FromInt32(items[0],8);
            int vb1eid = BitConv.FromInt32(items[0],12);
            int vb2eid = BitConv.FromInt32(items[0],16);
            int vb3eid = BitConv.FromInt32(items[0],20);
            if (BitConv.FromInt32(items[0],24) != Entry.NullEID ||
                BitConv.FromInt32(items[0],28) != Entry.NullEID ||
                BitConv.FromInt32(items[0],32) != Entry.NullEID)
            {
                throw new LoadException();
            }
            VH vh;
            if (items[1].Length != 0)
            {
                vh = VH.Load(items[1]);
            }
            else
            {
                vh = null;
            }
            SEP sep = SEP.Load(items[2],seqcount);
            return new MusicEntry(vheid,vb0eid,vb1eid,vb2eid,vb3eid,vh,sep,eid);
        }
    }
}
