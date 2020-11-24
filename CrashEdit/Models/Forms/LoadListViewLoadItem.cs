namespace CrashEdit.Models.Forms
{
    using System.Collections.Generic;

    public class LoadListViewLoadItem
    {
        public LoadListViewLoadItem()
        {
            LoadCount = 1;
            Entries = new List<LoadListViewLoadItemEntry>();
        }

        public int ChunkEid { get; set; }

        public short ChunkType { get; set; }

        public int ChunkIndex { get; set; }

        public List<LoadListViewLoadItemEntry> Entries { get; set; }

        public int LoadCount { get; set; }
    }
}