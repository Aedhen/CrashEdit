using System;
using System.Collections.Generic;

namespace Crash
{
    public abstract class EntryChunkLoader : ChunkLoader
    {
        public sealed override Chunk Load(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (data.Length != Chunk.Length)
                throw new ArgumentException("Data must be 65536 bytes long.");
            int unknown1 = BitConv.FromWord(data,4);
            int entrycount = BitConv.FromWord(data,8);
            int unknown2 = BitConv.FromWord(data,12);
            int headersize = 20 + entrycount * 4;
            if (entrycount < 0)
            {
                throw new LoadException();
            }
            if (headersize > data.Length)
            {
                throw new LoadException();
            }
            Entry[] entries = new Entry [entrycount];
            byte[] entrydata;
            for (int i = 0;i < entrycount;i++)
            {
                int entrystart = BitConv.FromWord(data,16 + i * 4);
                int entryend = BitConv.FromWord(data,20 + i * 4);
                if (entrystart < 0)
                {
                    throw new LoadException();
                }
                if (entryend < entrystart)
                {
                    throw new LoadException();
                }
                if (entryend > data.Length)
                {
                    throw new LoadException();
                }
                int entrysize = entryend - entrystart;
                entrydata = new byte [entrysize];
                Array.Copy(data,entrystart,entrydata,0,entrysize);
                entries[i] = Entry.Load(entrydata);
            }
            return Load(entries,unknown1,unknown2);
        }

        public abstract Chunk Load(Entry[] entries,int unknown1,int unknown2);
    }
}
