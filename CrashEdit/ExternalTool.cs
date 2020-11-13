using System.IO;
using System.Diagnostics;

namespace CrashEdit
{
    using System;
    using CrashEdit.Properties;
    using DarkUI.Forms;

    public static class ExternalTool
    {
        private static string FindEXEInDir(string name, DirectoryInfo dir)
        {
            name = name.ToLower();

            // Search for "foo.exe", "foo.cmd", "foo", etc.
            foreach (var file in dir.GetFiles()) {
                if (Path.GetFileNameWithoutExtension(file.Name).ToLower() == name) {
                    return file.FullName;
                }
            }

            // Otherwise, recursively check each subdirectory named "foo".
            foreach (var subdir in dir.GetDirectories()) {
                if (subdir.Name.ToLower() != name)
                    continue;

                var result = FindEXEInDir(name, subdir);
                if (result != null) {
                    return result;
                }
            }

            // Otherwise, not found.
            return null;
        }

        public static string FindEXE(string name)
        {
            DirectoryInfo dir = null;
            if (!string.IsNullOrEmpty(Settings.Default.ExternalToolDir))
            {
                try
                {
                    dir = GetDirectoryInfo(Settings.Default.ExternalToolDir);
                }
                catch (Exception ex)
                {
                    DarkMessageBox.ShowInformation("ExternalTools path invalid. Using CrashEdit directory.", "Find");
                }
            }

            if (dir == null)
            {
                dir = GetDirectoryInfo(System.Reflection.Assembly.GetEntryAssembly().Location);
            }

            var result = FindEXEInDir(name, dir);
            if (result != null)
                return result;

            result = FindEXEInDir(name, dir.Parent);
            if (result != null)
                return result;

            throw new FileNotFoundException();
        }

        public static int Invoke(string name, string args)
        {
            var exe = FindEXE(name);
            var psi = new ProcessStartInfo(exe)
            {
                Arguments = args,
                WorkingDirectory = Path.GetDirectoryName(exe),
                UseShellExecute = false
            };
            using (var proc = Process.Start(psi)) {
                proc.WaitForExit();
                return proc.ExitCode;
            }
        }

        private static DirectoryInfo GetDirectoryInfo(string path)
        {
            var ceDir = Path.GetDirectoryName(path);
            return new DirectoryInfo(ceDir);
        }
    }
}
