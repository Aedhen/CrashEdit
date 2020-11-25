using System;
using System.IO;
using System.Windows.Forms;

namespace CrashEdit
{
    using System.Collections.Generic;
    using System.Linq;
    using Ookii.Dialogs.WinForms;

    public static class FileUtil
    {
        private static OpenFileDialog openfiledlg;
        private static SaveFileDialog savefiledlg;
        private static VistaFolderBrowserDialog folderBrowserDialog;

        static FileUtil()
        {
            openfiledlg = new OpenFileDialog();
            savefiledlg = new SaveFileDialog();
            folderBrowserDialog = new VistaFolderBrowserDialog {ShowNewFolderButton = true};
        }

        public static IWin32Window Owner { get; set; } = null;

        public static byte[] OpenFile(params string[] filters)
        {
            openfiledlg.Filter = string.Join("|",filters);
            openfiledlg.Multiselect = false;
            if (openfiledlg.ShowDialog(Owner) == DialogResult.OK)
            {
                return File.ReadAllBytes(openfiledlg.FileName);
            }
            else
            {
                return null;
            }
        }

        public static byte[][] OpenFiles(params string[] filters)
        {
            openfiledlg.Filter = string.Join("|",filters);
            openfiledlg.Multiselect = true;
            if (openfiledlg.ShowDialog(Owner) == DialogResult.OK)
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

        public static bool SaveFile(byte[] data,params string[] filters)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            savefiledlg.Filter = string.Join("|",filters);
            if (savefiledlg.ShowDialog(Owner) == DialogResult.OK)
            {
                File.WriteAllBytes(savefiledlg.FileName,data);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SaveFile(string defaultname,byte[] data,params string[] filters)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            savefiledlg.Filter = string.Join("|",filters);
            savefiledlg.FileName = defaultname;
            if (savefiledlg.ShowDialog(Owner) == DialogResult.OK)
            {
                File.WriteAllBytes(savefiledlg.FileName,data);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool SaveFiles(List<byte[]> files, List<string> fileNames, string targetPath = null)
        {
            if (files == null || files.Count == 0 || files.Any(x => x == null))
            {
                throw new ArgumentNullException("data");
            }

            if (targetPath != null)
            {
                folderBrowserDialog.SelectedPath = targetPath;
            }

            if (folderBrowserDialog.ShowDialog(Owner) != DialogResult.OK)
            {
                return false;
            }

            for (var i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var fileName = i < fileNames.Count ? fileNames[i] : i.ToString();
                File.WriteAllBytes($"{folderBrowserDialog.SelectedPath}\\{fileName}", file);
            }

            return true;
        }
    }
}
