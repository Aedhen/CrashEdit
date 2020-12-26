namespace CrashEdit.Helpers
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Crash;
    using CrashEdit.Properties;
    using DarkUI.Forms;

    public static class NsfHelper
    {
        public static string GetNsfFilename(string nsdFilename)
        {
            var nsfFileName = nsdFilename;
            if (!nsfFileName.EndsWith("F") && !nsfFileName.EndsWith("f"))
            {
                if (nsfFileName.EndsWith("D"))
                {
                    nsfFileName = nsfFileName.Remove(nsfFileName.Length - 1);
                    nsfFileName += "F";
                }
                else if (nsfFileName.EndsWith("d"))
                {
                    nsfFileName = nsfFileName.Remove(nsfFileName.Length - 1);
                    nsfFileName += "f";
                }
                else
                {
                    DarkMessageBox.ShowError(string.Format(Resources.PatchNSD_Error1, nsfFileName),
                        Resources.PatchNSD_Title1);
                    return null;
                }
            }

            if (!File.Exists(nsfFileName))
            {
                return null;
            }

            return nsfFileName;
        }

        public static void SaveNSF(bool ignore_warnings, string filename, NSF nsf, GameVersion gameVersion)
        {
            switch (gameVersion)
            {
                case GameVersion.Crash1:
                    foreach (OldZoneEntry zone in nsf.GetEntries<OldZoneEntry>())
                    {
                        foreach (OldEntity entity in zone.Entities)
                        {
                            if (entity.ID >= 0x130)
                            {
                                MessageBox.Show(string.Format("An entity (ID {0}) exceeds maximum ID of 303.", entity.ID), "Entity ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (entity.ID <= 0)
                            {
                                MessageBox.Show(string.Format("An entity has invalid ID {0}.", entity.ID), "Entity ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    break;
                case GameVersion.Crash2:
                    foreach (ZoneEntry zone in nsf.GetEntries<ZoneEntry>())
                    {
                        foreach (Entity entity in zone.Entities)
                        {
                            if ((entity.ID != null && entity.ID >= 0x400) || (entity.AlternateID != null && entity.AlternateID >= 0x400))
                            {
                                if (entity.Name != null)
                                {
                                    MessageBox.Show(string.Format("Entity {0} (ID {1}) exceeds maximum ID of 1023.", entity.Name, entity.ID != null ? entity.ID : entity.AlternateID), "Entity ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("An entity (ID {0}) exceeds maximum ID of 1023.", entity.ID != null ? entity.ID : entity.AlternateID), "Entity ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if ((entity.ID != null && entity.ID <= 0) || (entity.AlternateID != null && entity.AlternateID <= 0))
                            {
                                if (entity.Name != null)
                                {
                                    MessageBox.Show(string.Format("Entity {0} has invalid ID {1}.", entity.Name, entity.ID != null ? entity.ID : entity.AlternateID), "Entity ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("An entity has invalid ID {0}.", entity.ID != null ? entity.ID : entity.AlternateID), "Entity ID Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    break;
            }

            SaveNSF(filename, nsf, ignore_warnings);
        }

        public static void SaveNSF(string filename, NSF nsf, bool ignore_warnings)
        {
            var nsfFilename = GetNsfFilename(filename);
            try
            {
                byte[] nsfdata = nsf.Save();
                if (ignore_warnings ? true : DarkMessageBox.ShowInformation(Resources.SaveNSF, Resources.Save_ConfirmationPrompt, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    File.WriteAllBytes(nsfFilename, nsfdata);
                }
            }
            catch (PackingException ex)
            {
                DarkMessageBox.ShowError(string.Format(Resources.SaveNSF_Error1, Entry.EIDToEName(ex.EID)), Resources.SaveNSF_Title);
            }
            catch (IOException ex)
            {
                DarkMessageBox.ShowError(Resources.SaveNSF_Error2 + ex.Message, Resources.SaveNSF_Title);
            }
            catch (UnauthorizedAccessException ex)
            {
                DarkMessageBox.ShowError(Resources.SaveNSF_Error3 + ex.Message, Resources.SaveNSF_Title);
            }
        }
    }
}
