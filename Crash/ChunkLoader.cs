namespace Crash
{
    public abstract class ChunkLoader
    {
        public abstract Chunk Load(byte[] data);
    }
}
