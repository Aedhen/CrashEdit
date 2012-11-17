using System.Collections.Generic;

namespace Crash.Audio
{
    public sealed class SampleSet
    {
        public static SampleSet Load(byte[] data)
        {
            if (data.Length % 16 != 0)
            {
                throw new System.Exception();
            }
            int samplelinecount = (data.Length / 16) - 1;
            SampleLine[] samplelines = new SampleLine [samplelinecount];
            for (int i = 0;i < samplelinecount;i++)
            {
                byte[] linedata = new byte [16];
                System.Array.Copy(data,(i + 1) * 16,linedata,0,16);
                samplelines[i] = SampleLine.Load(linedata);
            }
            return new SampleSet(samplelines);
        }

        private List<SampleLine> samplelines;

        public SampleSet(IEnumerable<SampleLine> samplelines)
        {
            this.samplelines = new List<SampleLine>(samplelines);
        }

        public IList<SampleLine> SampleLines
        {
            get { return samplelines; }
        }

        public byte[] Save()
        {
            byte[] data = new byte [(samplelines.Count + 1) * 16];
            for (int i = 0;i < samplelines.Count;i++)
            {
                samplelines[i].Save().CopyTo(data,(i + 1) * 16);
            }
            return data;
        }
    }
}
