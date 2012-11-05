namespace Crash.Unknown4
{
    [EntryType(14)]
    public sealed class T14EntryLoader : EntryLoader
    {
        public override Entry Load(byte[][] items,int unknown)
        {
            if (items.Length != 2)
            {
                throw new System.Exception();
            }
            if (items[0].Length != 8)
            {
                throw new System.Exception();
            }
            int id = BitConv.FromWord(items[0],0);
            int length = BitConv.FromWord(items[0],4);
            if (id < 0 || id > 3)
            {
                throw new System.Exception();
            }
            if (length != items[1].Length)
            {
                throw new System.Exception();
            }
            return new T14Entry(id,items[1],unknown);
        }
    }
}
