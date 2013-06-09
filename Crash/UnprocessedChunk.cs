using System;

namespace Crash
{
    public sealed class UnprocessedChunk : Chunk
    {
        private byte[] data;

        public UnprocessedChunk(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (data.Length != Chunk.Length)
                throw new ArgumentException("Data must be 65536 bytes long.");
            this.data = data;
        }

        public override short Type
        {
            get { return BitConv.FromInt16(data,2); }
        }

        public byte[] Data
        {
            get { return data; }
        }

        public Chunk Process(int chunkid)
        {
            if (loaders.ContainsKey(Type))
            {
                return loaders[Type].Load(chunkid,data);
            }
            else
            {
                throw new LoadException();
            }
        }

        public override UnprocessedChunk Unprocess(int chunkid)
        {
            return this;
        }

        public override byte[] Save(int chunkid)
        {
            return data;
        }
    }
}
