namespace CrashEdit.Models.Forms
{
    using System.Collections.Generic;

    public class DrawListViewZone
    {
        public DrawListViewZone()
        {
            Cameras = new List<DrawListViewCamera>();
        }

        public string Zone { get; set; }

        public List<DrawListViewCamera> Cameras { get; set; }
    }
}