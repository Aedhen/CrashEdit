namespace CrashEdit.Models.Forms
{
    using System.Collections.Generic;

    public class DrawListViewCamera
    {
        public DrawListViewCamera()
        {
            DrawListA = new SortedList<int, DrawListViewDrawItemEntity>();
            DrawListB = new SortedList<int, DrawListViewDrawItemEntity>();
        }

        public SortedList<int, DrawListViewDrawItemEntity> DrawListA { get; set; }

        public SortedList<int, DrawListViewDrawItemEntity> DrawListB { get; set; }
    }
}