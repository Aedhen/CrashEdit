using System;
using System.Collections.Generic;

namespace Crash.Audio
{
    [ChunkType(5)]
    public sealed class SpeechChunkLoader : EntryChunkLoader
    {
        public override Chunk Load(Entry[] entries,int unknown2)
        {
            if (entries == null)
                throw new ArgumentNullException("entries");
            List<SpeechEntry> speechentries = new List<SpeechEntry>();
            foreach (Entry entry in entries)
            {
                if (entry is SpeechEntry)
                {
                    speechentries.Add((SpeechEntry)entry);
                }
                else
                {
                    throw new LoadException();
                }
            }
            return new SpeechChunk(speechentries,unknown2);
        }
    }
}
