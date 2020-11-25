using Crash;
using Crash.GOOLIns;
using System.Windows.Forms;

namespace CrashEdit
{
    using System.Collections.Generic;
    using System.IO;
    using CrashEdit.Properties;
    using DarkUI.Forms;

    public sealed class GOOLEntryController : EntryController
    {
        public GOOLEntryController(EntryChunkController entrychunkcontroller,GOOLEntry goolentry) : base(entrychunkcontroller,goolentry)
        {
            GOOLEntry = goolentry;
            foreach (int ext_eid in goolentry.Externals)
            {
                GOOLEntry ext_gool = EntryChunkController.NSFController.NSF.FindEID<GOOLEntry>(ext_eid);
                if (ext_gool != null)
                {
                    ext_gool.ParentGOOL = goolentry;
                }
            }
            InvalidateNode();
            InvalidateNodeImage();
            //if (GOOLEntry.Version == GOOLVersion.Version0)
            //    AddMenu("Export as Crash 1 GOOL", Menu_ExportAsC1);
            if (GOOLEntry.Version == GOOLVersion.Version2)
            {
                AddMenu("Export GOOL with references", ExportGoolWithReferences);
            }
        }

        public override void InvalidateNode()
        {
            switch (GOOLEntry.Version)
            {
                case GOOLVersion.Version0:
                    Node.Text = string.Format(Crash.UI.Properties.Resources.GOOLv0EntryController_Text,GOOLEntry.EName);
                    break;
                case GOOLVersion.Version1:
                    Node.Text = string.Format(Crash.UI.Properties.Resources.GOOLv1EntryController_Text,GOOLEntry.EName);
                    break;
                case GOOLVersion.Version2:
                    Node.Text = string.Format(Crash.UI.Properties.Resources.GOOLv2EntryController_Text,GOOLEntry.EName);
                    break;
                case GOOLVersion.Version3:
                    Node.Text = string.Format(Crash.UI.Properties.Resources.GOOLv3EntryController_Text,GOOLEntry.EName);
                    break;
            }
        }

        public override void InvalidateNodeImage()
        {
            Node.ImageKey = "codeb";
            Node.SelectedImageKey = "codeb";
        }

        protected override Control CreateEditor()
        {
            return new UndockableControl(new GOOLBox(GOOLEntry));
        }

        public GOOLEntry GOOLEntry { get; }

        public void Menu_ExportAsC1()
        {
            byte[] newinstructions = new byte [GOOLEntry.Instructions.Count * 4];
            for (int i = 0; i < GOOLEntry.Instructions.Count; ++i)
            {
                if (GOOLEntry.Instructions[i] is Cfl_95 cfl)
                {
                    int newval = cfl.Save();
                    newval = (newval & ~0x3FF) | cfl.Args['I'].Value & 0x3FF;
                    newval = (newval & ~0b11110000000000) | (cfl.Args['V'].Value << 10);
                    BitConv.ToInt32(newinstructions,i*4, newval);
                }
                else
                    BitConv.ToInt32(newinstructions,i*4,GOOLEntry.Instructions[i].Save());
            }
            GOOLEntry newgool = new GOOLEntry(GOOLVersion.Version1,GOOLEntry.Header,newinstructions,GOOLEntry.Data,GOOLEntry.StateMap,GOOLEntry.StateDescriptors,GOOLEntry.Anims,GOOLEntry.EID);
            FileUtil.SaveFile(newgool.Save(), FileFilters.NSEntry, FileFilters.Any);
        }

        private void ExportGoolWithReferences()
        {
            var referenceAnimationEids = new List<int>();
            var referenceTextureEids = new List<int>();
            var anims = GOOLEntry.Anims;
            if (anims != null)
            {
                for (var i = 0; i < anims.Length; i += 4)
                {
                    if (i + 4 >= anims.Length)
                    {
                        break;
                    }

                    if (anims[i] == 1 && anims[i + 2] > 0)
                    {
                        var eid = BitConv.FromInt32(anims, i + 4);
                        referenceAnimationEids.Add(eid);
                        i += 4;
                    }
                    else if (anims[i] == 2)
                    {
                        var eid = BitConv.FromInt32(anims, i + 4);
                        referenceTextureEids.Add(eid);
                        i += 4;
                    }
                }
            }

            var items = new List<byte[]>();
            var itemNames = new List<string>();
            foreach (var referenceEid in referenceAnimationEids)
            {
                var referenceEntry = EntryChunkController.NSFController.NSF.FindEID<AnimationEntry>(referenceEid);
                if (referenceEntry == null)
                {
                    continue;
                }

                items.Add(referenceEntry.Save());
                itemNames.Add($"{GOOLEntry.EName}_T{referenceEntry.Type}-animation-{Entry.EIDToEName(referenceEid)}");

                var modelReferenceEid = referenceEntry.Frames[0].ModelEID;
                var referenceModelEntry = EntryChunkController.NSFController.NSF.FindEID<ModelEntry>(modelReferenceEid);
                if (referenceModelEntry == null)
                {
                    continue;
                }

                items.Add(referenceModelEntry.Save());
                itemNames.Add($"{GOOLEntry.EName}_T{referenceModelEntry.Type}-model-{Entry.EIDToEName(modelReferenceEid)}");

                var referenceModelTextureEids = referenceModelEntry.TextureReferenceEids;
                foreach (var referenceModelTextureEid in referenceModelTextureEids)
                {
                    var referenceModelTextureChunk = EntryChunkController.NSFController.NSF.FindEID<TextureChunk>(referenceModelTextureEid);
                    if (referenceModelTextureChunk == null)
                    {
                        continue;
                    }

                    items.Add(referenceModelTextureChunk.Save(0));
                    itemNames.Add($"{GOOLEntry.EName}_T{referenceModelTextureChunk.Type}-texture-{Entry.EIDToEName(referenceModelTextureEid)}");

                }
            }

            foreach (var referenceEid in referenceTextureEids)
            {
                var referenceChunk = EntryChunkController.NSFController.NSF.FindEID<TextureChunk>(referenceEid);
                if (referenceChunk == null)
                {
                    continue;
                }

                items.Add(referenceChunk.Save(0));
                itemNames.Add($"{GOOLEntry.EName}_T{referenceChunk.Type}-texture-{Entry.EIDToEName(referenceEid)}");
            }

            foreach (var goolDataItemEid in GOOLEntry.Data)
            {
                var soundEntry = EntryChunkController.NSFController.NSF.FindEID<SoundEntry>(goolDataItemEid);
                if (soundEntry == null)
                {
                    continue;
                }

                items.Add(soundEntry.Save());
                itemNames.Add($"{GOOLEntry.EName}_T{soundEntry.Type}-sound-{Entry.EIDToEName(goolDataItemEid)}");

            }

            var goolData = new List<int>();
            var item3 = GOOLEntry.Data;
            for (var i = 0; i < item3.Length; i += 4)
            {
                if (i + 4 >= item3.Length)
                {
                    break;
                }

                if (item3[i] == 1 && item3[i + 2] > 0)
                {
                    var eid = BitConv.FromInt32(anims, i + 4);
                    goolData.Add(eid);
                    i += 4;
                }
            }

            items.Add(GOOLEntry.Save());
            itemNames.Add($"{GOOLEntry.EName}_T{GOOLEntry.Type}-gool-{GOOLEntry.EName}");

            if (itemNames.Count != 0)
            {
                string defaultPath = null;
                if (!string.IsNullOrEmpty(Settings.Default.ExportGoolDefaultDir))
                {
                    if (!Directory.Exists(Settings.Default.ExportGoolDefaultDir))
                    {
                        DarkMessageBox.ShowWarning(
                            $"Path '{Settings.Default.ExportGoolDefaultDir}' does not exist.",
                            "Gool export");
                    }
                    else
                    {
                        defaultPath = Settings.Default.ExportGoolDefaultDir;
                    }
                }

                FileUtil.SaveFiles(items, itemNames, defaultPath);
            }
            else
            {
                DarkMessageBox.ShowWarning(
                    "Unable to export GOOL with references. This GOOL might not be supported by export function.",
                    "Gool export");
            }
        }
    }
}
