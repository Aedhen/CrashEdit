using System;

namespace Crash.Unknown0
{
    [EntryType(15)]
    public sealed class T15EntryLoader : EntryLoader
    {
        public override Entry Load(byte[][] items,int eid)
        {
            if (items == null)
                throw new ArgumentNullException("items");
            if (items.Length != 1)
            {
                ErrorManager.SignalError("T15Entry: Wrong number of items");
            }
            return new T15Entry(items[0],eid);
        }
    }
}
