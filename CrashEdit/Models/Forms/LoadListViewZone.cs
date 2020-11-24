namespace CrashEdit.Models.Forms
{
    using System.Collections.Generic;

    public class LoadListViewZone
    {
        public LoadListViewZone()
        {
            Cameras = new List<LoadListViewCamera>();
        }

        public string Zone { get; set; }

        public List<LoadListViewCamera> Cameras { get; set; }
    }
}