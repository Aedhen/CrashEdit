using Crash;
using Crash.Audio;
using System;

namespace CrashEdit
{
    public sealed class SEQController : Controller
    {
        private MusicEntryController musicentrycontroller;
        private SEQ seq;

        public SEQController(MusicEntryController musicentrycontroller,SEQ seq)
        {
            this.musicentrycontroller = musicentrycontroller;
            this.seq = seq;
            Node.Text = "SEQ";
            Node.ImageKey = "seq";
            Node.SelectedImageKey = "seq";
            AddMenu("Replace SEQ",Menu_Replace_SEQ);
            AddMenu("Delete SEQ",Menu_Delete_SEQ);
            AddMenuSeparator();
            AddMenu("Export SEQ",Menu_Export_SEQ);
            AddMenu("Export SEQ as MIDI",Menu_Export_SEQ_MIDI);
        }

        public MusicEntryController MusicEntryController
        {
            get { return musicentrycontroller; }
        }

        public SEQ SEQ
        {
            get { return seq; }
        }

        private void Menu_Replace_SEQ(object sender,EventArgs e)
        {
            int i = musicentrycontroller.MusicEntry.SEP.SEQs.IndexOf(seq);
            byte[] data = FileUtil.OpenFile(FileUtil.SEQFilter + "|" + FileUtil.AnyFilter);
            if (data != null)
            {
                seq = SEQ.Load(data);
                musicentrycontroller.MusicEntry.SEP.SEQs[i] = seq;
            }
        }

        private void Menu_Delete_SEQ(object sender,EventArgs e)
        {
            musicentrycontroller.MusicEntry.SEP.SEQs.Remove(seq);
            Dispose();
        }

        private void Menu_Export_SEQ(object sender,EventArgs e)
        {
            byte[] data = seq.Save();
            FileUtil.SaveFile(data,FileUtil.SEQFilter + "|" + FileUtil.AnyFilter);
        }

        private void Menu_Export_SEQ_MIDI(object sender,EventArgs e)
        {
            byte[] data = seq.ToMIDI();
            FileUtil.SaveFile(data,FileUtil.MIDIFilter + "|" + FileUtil.AnyFilter);
        }
    }
}
