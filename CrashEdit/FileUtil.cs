using System;
using System.IO;
using System.Windows.Forms;

namespace CrashEdit
{
    public static class FileUtil
    {
        private static OpenFileDialog openfiledlg;
        private static SaveFileDialog savefiledlg;

        static FileUtil()
        {
            openfiledlg = new OpenFileDialog();
            savefiledlg = new SaveFileDialog();
        }

        public static byte[] OpenFile(string filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            openfiledlg.Filter = filter;
            openfiledlg.Multiselect = false;
            if (openfiledlg.ShowDialog() == DialogResult.OK)
            {
                return File.ReadAllBytes(openfiledlg.FileName);
            }
            else
            {
                return null;
            }
        }

        public static byte[][] OpenFiles(string filter)
        {
            if (filter == null)
                throw new ArgumentNullException("filter");
            openfiledlg.Filter = filter;
            openfiledlg.Multiselect = true;
            if (openfiledlg.ShowDialog() == DialogResult.OK)
            {
                byte[][] result = new byte [openfiledlg.FileNames.Length][];
                for (int i = 0;i < openfiledlg.FileNames.Length;i++)
                {
                    result[i] = File.ReadAllBytes(openfiledlg.FileNames[i]);
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public static bool SaveFile(byte[] data,string filter)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (filter == null)
                throw new ArgumentNullException("filter");
            savefiledlg.Filter = filter;
            if (savefiledlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(savefiledlg.FileName,data);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
