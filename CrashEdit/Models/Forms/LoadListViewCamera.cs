namespace CrashEdit.Models.Forms
{
    using System.Collections.Generic;

    public class LoadListViewCamera
    {
        public LoadListViewCamera()
        {
            LoadListA = new SortedList<int, LoadListViewLoadItem>();
            LoadListB = new SortedList<int, LoadListViewLoadItem>();
        }

        public SortedList<int, LoadListViewLoadItem> LoadListA { get; set; }

        public SortedList<int, LoadListViewLoadItem> LoadListB { get; set; }
    }
}