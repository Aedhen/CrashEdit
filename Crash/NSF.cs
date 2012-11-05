using System.Collections.Generic;

namespace Crash
{
    public sealed class NSF
    {
        public static NSF Load(byte[] data)
        {
            if (data.Length % Chunk.Length != 0)
            {
                throw new System.Exception();
            }
            Chunk[] chunks = new Chunk[data.Length / Chunk.Length];
            byte[] chunkdata;
            for (int i = 0;i < data.Length;i += Chunk.Length)
            {
                chunkdata = new byte [Chunk.Length];
                System.Array.Copy(data,i,chunkdata,0,Chunk.Length);
                chunks[i / Chunk.Length] = Chunk.Load(chunkdata);
            }
            return new NSF(chunks);
        }

        private List<Chunk> chunks;

        public NSF(IEnumerable<Chunk> chunks)
        {
            this.chunks = new List<Chunk>(chunks);
        }

        public IList<Chunk> Chunks
        {
            get { return chunks; }
        }

        public byte[] Save()
        {
            byte[] data = new byte [chunks.Count * Chunk.Length];
            for (int i = 0;i < chunks.Count;i++)
            {
                chunks[i].Save().CopyTo(data,i * Chunk.Length);
            }
            return data;
        }
    }
}
