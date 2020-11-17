namespace CrashEdit.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Crash;
    using Crash.Formats.Crash_Formats.NSD;
    using CrashEdit.Properties;
    using DarkUI.Forms;

    public static class NsdHelper
    {
        public static void SaveNsdFile<T>(T nsd, string filename) where T : NsdBase
        {
            var nsdFilename = GetNsdFilename(filename);
            File.WriteAllBytes(nsdFilename, nsd.Save());
        }

        public static string GetNsdFilename(string nsfFilename)
        {
            var nsdFileName = nsfFilename;
            if (!nsdFileName.EndsWith("D") && !nsdFileName.EndsWith("d"))
            {
                if (nsdFileName.EndsWith("F"))
                {
                    nsdFileName = nsdFileName.Remove(nsdFileName.Length - 1);
                    nsdFileName += "D";
                }
                else if (nsdFileName.EndsWith("f"))
                {
                    nsdFileName = nsdFileName.Remove(nsdFileName.Length - 1);
                    nsdFileName += "d";
                }
                else
                {
                    DarkMessageBox.ShowError(string.Format(Resources.PatchNSD_Error1, nsdFileName),
                        Resources.PatchNSD_Title1);
                    return null;
                }
            }

            if (!File.Exists(nsdFileName))
            {
                return null;
            }

            return nsdFileName;
        }

        public static NsdBase LoadNsdFile(string filename, bool exists, GameVersion version)
        {
            try
            {
                var nsdFilename = GetNsdFilename(filename);
                var data = exists ? File.ReadAllBytes(nsdFilename) : null;
                switch (version)
                {
                    case GameVersion.Crash1BetaMAR08:
                        return data != null
                            ? ProtoNSD.Load(data)
                            : new ProtoNSD(new int[256], 0, new NSDLink[0]);
                    case GameVersion.Crash1:
                        return data != null
                            ? OldNSD.Load(data)
                            : new OldNSD(new int[256], 0, new int[4], 0, 0, new int[64], new NSDLink[0], 1, 0x3F,
                                Entry.NullEID, 0, 0, new int[64], new byte[0xFC]);
                    case GameVersion.Crash2:
                        return data != null
                            ? NSD.Load(data)
                            : new NSD(new int[256], 0, new int[4], 0, 0, new int[64], new NSDLink[0], 0, 0x3F, 0,
                                new int[64], new byte[0xFC],
                                new NSDSpawnPoint[1] {new NSDSpawnPoint(Entry.NullEID, 0, 0, 0, 0, 0)}, new byte[0]);
                    case GameVersion.Crash3:
                        return data != null
                            ? NewNSD.Load(data)
                            : new NewNSD(new int[256], 0, new int[4], 0, 0, new int[64], new NSDLink[0], 0, 0x3F, 0,
                                new int[128], new byte[0xFC],
                                new NSDSpawnPoint[1] {new NSDSpawnPoint(Entry.NullEID, 0, 0, 0, 0, 0)}, new byte[0]);
                    default:
                        DarkMessageBox.ShowError("Unable to load NSD file", "Load NSD");
                        return null;
                }
            }
            catch (LoadAbortedException)
            {
            }

            return null;
        }

        public static void PatchNSD(NsdBase nsd, string filename, bool exists, NSFController nsfc, bool ignore_warnings)
        {
            var nsf = nsfc.NSF;
            var nsdFilename = GetNsdFilename(filename);
            try
            {
                switch (nsfc.GameVersion)
                {
                    case GameVersion.Crash1BetaMAR08:
                        PatchNSD(nsd as ProtoNSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    case GameVersion.Crash1:
                        PatchNSD(nsd as OldNSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    case GameVersion.Crash2:
                        PatchNSD(nsd as NSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    case GameVersion.Crash3:
                        PatchNSD(nsd as NewNSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    default:
                        if (!ignore_warnings)
                        {
                            DarkMessageBox.ShowError(Resources.PatchNSD_Error2, Resources.PatchNSD_Title1);
                        }

                        return;
                }

                nsfc.Node.TreeView.BeginUpdate();
                var order_updated = false;
                foreach (TreeNode node in nsfc.Node.Nodes
                ) // nsd patching might have moved entries, recreate moved entry chunks if that's the case
                    if (node.Tag is EntryChunkController entryChunkController)
                    {
                        var i = 0;
                        var nodes = new TreeNode[node.Nodes.Count];
                        foreach (TreeNode oldNode in node.Nodes) nodes[i++] = oldNode;
                        for (i = 0; i < nodes.Length; ++i)
                        {
                            var c = (EntryController) nodes[i].Tag;
                            if (c.Entry != entryChunkController.EntryChunk.Entries[i])
                            {
                                for (i = 0; i < nodes.Length; ++i)
                                {
                                    if (nodes[i].IsSelected)
                                    {
                                        nodes[i].TreeView.SelectedNode = nodes[i].Parent;
                                    }

                                    if (nodes[i].Tag != null)
                                    {
                                        if (nodes[i].Tag is Controller t)
                                        {
                                            t.Dispose();
                                        }
                                    }
                                }

                                entryChunkController.PopulateNodes();
                                order_updated = true;
                                break;
                            }
                        }
                    }

                nsfc.Node.TreeView.EndUpdate();
                if (ignore_warnings || (order_updated &&
                                        DarkMessageBox.ShowInformation(Resources.PatchNSD3, Resources.PatchNSD_Title1,
                                            DarkDialogButton.YesNo) == DialogResult.Yes))
                {
                    NsfHelper.SaveNSF(true, filename, nsf, nsfc.GameVersion);
                }
            }
            catch (LoadAbortedException)
            {
            }
        }

        private static void PatchNSD(OldNSD nsd, NSF nsf, string path, bool ignore_warnings)
        {
            nsd.ChunkCount = nsf.Chunks.Count;
            var indexdata = nsf.MakeNSDIndex();
            nsd.HashKeyMap = indexdata.Item1;
            nsd.Index = indexdata.Item2;
            PatchNSDGoolMap(nsd.GOOLMap, nsf, ignore_warnings);
            if (ignore_warnings || DarkMessageBox.ShowInformation(Resources.PatchNSD1,
                    Resources.Save_ConfirmationPrompt,
                    DarkDialogButton.YesNo) == DialogResult.Yes)
            {
                SaveNsdFile(nsd, path);
            }
        }

        private static void PatchNSD(ProtoNSD nsd, NSF nsf, string path, bool ignore_warnings)
        {
            nsd.ChunkCount = nsf.Chunks.Count;
            var indexdata = nsf.MakeNSDIndex();
            nsd.HashKeyMap = indexdata.Item1;
            nsd.Index = indexdata.Item2;
            if (ignore_warnings || DarkMessageBox.ShowInformation(Resources.PatchNSD1,
                    Resources.Save_ConfirmationPrompt,
                    DarkDialogButton.YesNo) == DialogResult.Yes)
            {
                SaveNsdFile(nsd, path);
            }
        }

        private static void PatchNSDGoolMap(int[] map, NSF nsf, bool ignore_warnings)
        {
            for (var i = 0; i < map.Length; ++i) map[i] = Entry.NullEID;

            foreach (var chunk in nsf.Chunks)
                if (chunk is EntryChunk entrychunk)
                {
                    foreach (var entry in entrychunk.Entries)
                        if (entry is GOOLEntry gool)
                        {
                            if (gool.Format == 1)
                            {
                                var gool_id = BitConv.FromInt32(gool.Header, 0);
                                if (gool_id >= map.Length)
                                {
                                    if (!ignore_warnings)
                                    {
                                        DarkMessageBox.ShowWarning(
                                            string.Format(
                                                "GOOL entry {0} has invalid object typeID {1} (cannot be larger than {2}).",
                                                gool.EName, gool_id, map.Length - 1),
                                            Resources.Save_ConfirmationPrompt);
                                    }
                                }
                                else if (gool_id < 0)
                                {
                                    if (!ignore_warnings)
                                    {
                                        DarkMessageBox.ShowWarning(
                                            string.Format(
                                                "GOOL entry {0} has invalid object typeID {1} (cannot be negative).",
                                                gool.EName, gool_id), Resources.Save_ConfirmationPrompt);
                                    }
                                }
                                else
                                {
                                    map[BitConv.FromInt32(gool.Header, 0)] = gool.EID;
                                }
                            }
                        }
                }
        }

        ////public static void PatchNSD(NSF nsf, string nsdFilename, bool exists, bool ignore_warnings, GameVersion gameVersion)
        ////{
        ////    try
        ////    {
        ////        var nsd = LoadNsdFile(nsdFilename, exists, gameVersion);
        ////        switch (gameVersion)
        ////        {
        ////            case GameVersion.Crash1BetaMAR08:
        ////                PatchNSD(nsd as ProtoNSD, nsf, nsdFilename, ignore_warnings);
        ////                break;
        ////            case GameVersion.Crash1:
        ////                PatchNSD(nsd as OldNSD, nsf, nsdFilename, ignore_warnings);
        ////                break;
        ////            case GameVersion.Crash2:
        ////                PatchNSD(nsd as NSD, nsf, nsdFilename, ignore_warnings);
        ////                break;
        ////            case GameVersion.Crash3:
        ////                PatchNSD(nsd as NewNSD, nsf, nsdFilename, ignore_warnings);
        ////                break;
        ////            default:
        ////                if (!ignore_warnings)
        ////                {
        ////                    DarkMessageBox.ShowError(Resources.PatchNSD_Error2, Resources.PatchNSD_Title1);
        ////                }

        ////                return;
        ////        }
        ////    }
        ////    catch (LoadAbortedException)
        ////    {
        ////    }
        ////}

        public static void PatchNSD(string nsdFilename, bool exists, NSFController nsfc, bool ignore_warnings)
        {
            var nsf = nsfc.NSF;
            try
            {
                var nsd = LoadNsdFile(nsdFilename, exists, nsfc.GameVersion);
                switch (nsfc.GameVersion)
                {
                    case GameVersion.Crash1BetaMAR08:
                        PatchNSD(nsd as ProtoNSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    case GameVersion.Crash1:
                        PatchNSD(nsd as OldNSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    case GameVersion.Crash2:
                        PatchNSD(nsd as NSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    case GameVersion.Crash3:
                        PatchNSD(nsd as NewNSD, nsf, nsdFilename, ignore_warnings);
                        break;
                    default:
                        if (!ignore_warnings)
                        {
                            DarkMessageBox.ShowError(Resources.PatchNSD_Error2, Resources.PatchNSD_Title1);
                        }

                        return;
                }

                nsfc.Node.TreeView.BeginUpdate();
                var order_updated = false;
                foreach (TreeNode node in nsfc.Node.Nodes
                ) // nsd patching might have moved entries, recreate moved entry chunks if that's the case
                    if (node.Tag is EntryChunkController entrychunkcontroller)
                    {
                        var i = 0;
                        var nodes = new TreeNode[node.Nodes.Count];
                        foreach (TreeNode oldnode in node.Nodes) nodes[i++] = oldnode;
                        for (i = 0; i < nodes.Length; ++i)
                        {
                            var c = (EntryController)nodes[i].Tag;
                            if (c.Entry != entrychunkcontroller.EntryChunk.Entries[i])
                            {
                                for (i = 0; i < nodes.Length; ++i)
                                {
                                    if (nodes[i].IsSelected)
                                    {
                                        nodes[i].TreeView.SelectedNode = nodes[i].Parent;
                                    }

                                    if (nodes[i].Tag != null)
                                    {
                                        if (nodes[i].Tag is Controller t)
                                        {
                                            t.Dispose();
                                        }
                                    }
                                }

                                entrychunkcontroller.PopulateNodes();
                                order_updated = true;
                                break;
                            }
                        }
                    }

                nsfc.Node.TreeView.EndUpdate();
                if (ignore_warnings
                    ? true
                    : (order_updated &&
                       DarkMessageBox.ShowInformation(Resources.PatchNSD3, Resources.PatchNSD_Title1,
                           DarkDialogButton.YesNo) == DialogResult.Yes))
                {
                    NsfHelper.SaveNSF(true, nsdFilename, nsf, nsfc.GameVersion);
                }
            }
            catch (LoadAbortedException)
            {
            }
        }

        private static void PatchNSD(NewNSD nsd, NSF nsf, string filename, bool ignore_warnings)
        {
            if (Settings.Default.OldPatchNSD)
            {
            }
            else
            {
                var indexData = nsf.MakeNSDIndex();
                nsd.HashKeyMap = indexData.Item1;
                nsd.Index = indexData.Item2;
                PatchNSDGoolMap(nsd.GOOLMap, nsf, ignore_warnings);
            }

            nsd.ChunkCount = nsf.Chunks.Count;
            var newIndex = new Dictionary<int, int>();
            var eids = new List<int>();
            for (var i = 0; i < nsf.Chunks.Count; i++)
            {
                if (nsf.Chunks[i] is IEntry ientry)
                {
                    newIndex.Add(ientry.EID, i * 2 + 1);
                }

                if (nsf.Chunks[i] is EntryChunk chunk)
                {
                    foreach (var entry in chunk.Entries) newIndex.Add(entry.EID, i * 2 + 1);
                }
            }

            var unused = new HashSet<NSDLink>();
            foreach (var link in nsd.Index)
            {
                eids.Add(link.EntryID);
                if (newIndex.ContainsKey(link.EntryID))
                {
                    link.ChunkID = newIndex[link.EntryID];
                    newIndex.Remove(link.EntryID);
                }
                else // NSD contains nonexistant entry
                {
                    unused.Add(link);
                }
            }

            if (unused.Count > 0)
            {
                foreach (var link in unused) nsd.Index.Remove(link);
                for (var i = 0; i < 256; ++i) nsd.HashKeyMap[i] = Math.Min(nsd.HashKeyMap[i], nsd.Index.Count - 1);
            }

            if (newIndex.Count > 0)
            {
                var neweids = new List<string>();
                foreach (var kvp in newIndex) neweids.Add(Entry.EIDToEName(kvp.Key));
                var question = "The NSD is missing some entry ID's:\n\n";
                foreach (var eid in neweids) question += eid + "\n";
                question += "\nDo you want to add these to the end of the NSD's entry index?";
                if (DarkMessageBox.ShowInformation(question, "Patch NSD - New EID's", DarkDialogButton.YesNo) ==
                    DialogResult.Yes)
                {
                    foreach (var kvp in newIndex) nsd.Index.Add(new NSDLink(kvp.Value, kvp.Key));
                }
            }

            // check list
            for (var i = 0; i < nsf.Chunks.Count; i++)
                if (nsf.Chunks[i] is EntryChunk chunk)
                {
                    var nsdchunkentries = new List<int>();
                    for (var j = 0; j < nsd.Index.Count; ++j)
                    {
                        var link = nsd.Index[j];
                        if (i * 2 + 1 == link.ChunkID)
                        {
                            nsdchunkentries.Add(j);
                        }
                    }

                    for (var j = 0; j < chunk.Entries.Count; ++j)
                    {
                        var entry = chunk.Entries[j];
                        if (entry.EID != nsd.Index[nsdchunkentries[j]].EntryID)
                        {
                            //MessageBox.Show($"NSD hash map is not in correct order. Entry {entry.EName} in chunk {i * 2 + 1} will be swapped.", "NSD hash map mismatch");
                            var k = j;
                            for (; k < nsdchunkentries.Count; ++k)
                                if (entry.EID == nsd.Index[nsdchunkentries[k]].EntryID)
                                {
                                    break;
                                }

                            nsd.Index.Swap(nsdchunkentries[j], nsdchunkentries[k]);
                        }
                    }
                }

            // patch object entity count
            nsd.EntityCount = 0;
            foreach (var chunk in nsf.Chunks)
            {
                if (!(chunk is EntryChunk))
                {
                    continue;
                }

                foreach (var entry in ((EntryChunk) chunk).Entries)
                    if (entry is NewZoneEntry zone)
                    {
                        foreach (var ent in zone.Entities)
                            if (ent.ID != null)
                            {
                                ++nsd.EntityCount;
                            }
                    }
            }

            if (Settings.Default.PatchNSDSavesNSF)
            {
                if (DarkMessageBox.ShowInformation(
                        "Are you sure you want to overwrite the NSD file?\n\nEIDs will be swapped if NSD hash map is not in correct order,\nand all loadlists will be sorted according to the NSD.\n\nThe NSF file will be saved automatically.",
                        Resources.Save_ConfirmationPrompt, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    SaveNsdFile(nsd, filename);
                    foreach (var chunk in nsf.Chunks)
                    {
                        if (!(chunk is EntryChunk))
                        {
                            continue;
                        }

                        foreach (var entry in ((EntryChunk) chunk).Entries)
                            if (entry is NewZoneEntry zone)
                            {
                                foreach (var ent in zone.Entities)
                                {
                                    if (ent.LoadListA != null)
                                    {
                                        foreach (var row in ent.LoadListA.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort(delegate(int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }

                                    if (ent.LoadListB != null)
                                    {
                                        foreach (var row in ent.LoadListB.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort((a, b) => eids.IndexOf(a) - eids.IndexOf(b));
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }
                                }
                            }
                    }

                    NsfHelper.SaveNSF(true, filename, nsf, GameVersion.Crash3);
                }
            }
            else
            {
                if (DarkMessageBox.ShowInformation(
                        "Are you sure you want to overwrite the NSD file?\n\nEIDs will be swapped if NSD hash map is not in correct order,\nand all loadlists will be sorted according to the NSD.\n\nThe NSF file will be saved automatically.",
                        Resources.Save_ConfirmationPrompt, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    SaveNsdFile(nsd, filename);
                    foreach (var chunk in nsf.Chunks)
                    {
                        if (!(chunk is EntryChunk))
                        {
                            continue;
                        }

                        foreach (var entry in ((EntryChunk) chunk).Entries)
                            if (entry is NewZoneEntry zone)
                            {
                                foreach (var ent in zone.Entities)
                                {
                                    if (ent.LoadListA != null)
                                    {
                                        foreach (var row in ent.LoadListA.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort((a, b) => eids.IndexOf(a) - eids.IndexOf(b));
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }

                                    if (ent.LoadListB != null)
                                    {
                                        foreach (var row in ent.LoadListB.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort((a, b) => eids.IndexOf(a) - eids.IndexOf(b));
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }
                                }
                            }
                    }
                }
            }
        }

        private static void PatchNSD(NSD nsd, NSF nsf, string filename, bool ignore_warnings)
        {
            if (Settings.Default.OldPatchNSD)
            {
            }
            else
            {
                var indexdata = nsf.MakeNSDIndex();
                nsd.HashKeyMap = indexdata.Item1;
                nsd.Index = indexdata.Item2;
                PatchNSDGoolMap(nsd.GOOLMap, nsf, ignore_warnings);
            }

            nsd.ChunkCount = nsf.Chunks.Count;
            var newindex = new Dictionary<int, int>();
            var eids = new List<int>();
            for (var i = 0; i < nsf.Chunks.Count; i++)
            {
                if (nsf.Chunks[i] is IEntry ientry)
                {
                    newindex.Add(ientry.EID, i * 2 + 1);
                }

                if (nsf.Chunks[i] is EntryChunk chunk)
                {
                    foreach (var entry in chunk.Entries) newindex.Add(entry.EID, i * 2 + 1);
                }
            }

            var unused = new HashSet<NSDLink>();
            foreach (var link in nsd.Index)
            {
                eids.Add(link.EntryID);
                if (newindex.ContainsKey(link.EntryID))
                {
                    link.ChunkID = newindex[link.EntryID];
                    newindex.Remove(link.EntryID);
                }
                else // NSD contains nonexistant entry
                {
                    unused.Add(link);
                }
            }

            if (unused.Count > 0)
            {
                foreach (var link in unused) nsd.Index.Remove(link);
                for (var i = 0; i < 256; ++i) nsd.HashKeyMap[i] = Math.Min(nsd.HashKeyMap[i], nsd.Index.Count - 1);
            }

            if (newindex.Count > 0)
            {
                var neweids = new List<string>();
                foreach (var kvp in newindex) neweids.Add(Entry.EIDToEName(kvp.Key));
                var question = "The NSD is missing some entry ID's:\n\n";
                foreach (var eid in neweids) question += eid + "\n";
                question += "\nDo you want to add these to the end of the NSD's entry index?";
                if (DarkMessageBox.ShowInformation(question, "Patch NSD - New EID's", DarkDialogButton.YesNo) ==
                    DialogResult.Yes)
                {
                    foreach (var kvp in newindex) nsd.Index.Add(new NSDLink(kvp.Value, kvp.Key));
                }
            }

            // check list
            for (var i = 0; i < nsf.Chunks.Count; i++)
                if (nsf.Chunks[i] is EntryChunk chunk)
                {
                    var nsdchunkentries = new List<int>();
                    for (var j = 0; j < nsd.Index.Count; ++j)
                    {
                        var link = nsd.Index[j];
                        if (i * 2 + 1 == link.ChunkID)
                        {
                            nsdchunkentries.Add(j);
                        }
                    }

                    for (var j = 0; j < chunk.Entries.Count; ++j)
                    {
                        var entry = chunk.Entries[j];
                        if (entry.EID != nsd.Index[nsdchunkentries[j]].EntryID)
                        {
                            //MessageBox.Show($"NSD hash map is not in correct order. Entry {entry.EName} in chunk {i * 2 + 1} will be swapped.", "NSD hash map mismatch");
                            var k = j;
                            for (; k < nsdchunkentries.Count; ++k)
                                if (entry.EID == nsd.Index[nsdchunkentries[k]].EntryID)
                                {
                                    break;
                                }

                            nsd.Index.Swap(nsdchunkentries[j], nsdchunkentries[k]);
                        }
                    }
                }


            // patch object entity count
            nsd.EntityCount = 0;
            foreach (var chunk in nsf.Chunks)
            {
                if (!(chunk is EntryChunk))
                {
                    continue;
                }

                foreach (var entry in ((EntryChunk) chunk).Entries)
                    if (entry is ZoneEntry zone)
                    {
                        foreach (var ent in zone.Entities)
                            if (ent.ID != null)
                            {
                                ++nsd.EntityCount;
                            }
                    }
            }

            if (Settings.Default.PatchNSDSavesNSF)
            {
                if (DarkMessageBox.ShowInformation(
                        "Are you sure you want to overwrite the NSD file?\n\nEIDs will be swapped if NSD hash map is not in correct order,\nand all loadlists will be sorted according to the NSD.\n\nThe NSF file will be saved automatically.",
                        Resources.Save_ConfirmationPrompt, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    SaveNsdFile(nsd, filename);
                    foreach (var chunk in nsf.Chunks)
                    {
                        if (!(chunk is EntryChunk))
                        {
                            continue;
                        }

                        foreach (var entry in ((EntryChunk) chunk).Entries)
                            if (entry is ZoneEntry zone)
                            {
                                foreach (var ent in zone.Entities)
                                {
                                    if (ent.LoadListA != null)
                                    {
                                        foreach (var row in ent.LoadListA.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort(delegate(int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }

                                    if (ent.LoadListB != null)
                                    {
                                        foreach (var row in ent.LoadListB.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort(delegate(int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }
                                }
                            }
                    }

                    NsfHelper.SaveNSF(true, filename, nsf, GameVersion.Crash2);
                }
            }
            else
            {
                if (DarkMessageBox.ShowInformation(
                        "Are you sure you want to overwrite the NSD file?\n\nIf NSD hash map is not in correct order, EIDs will be swapped.\nAll loadlists will be sorted according to the NSD.",
                        Resources.Save_ConfirmationPrompt, DarkDialogButton.YesNo) == DialogResult.Yes)
                {
                    SaveNsdFile(nsd, filename);
                    //if (MessageBox.Show("Do you want to sort all loadlists according to the NSD?", "Loadlist autosorter", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    foreach (var chunk in nsf.Chunks)
                    {
                        if (!(chunk is EntryChunk))
                        {
                            continue;
                        }

                        foreach (var entry in ((EntryChunk) chunk).Entries)
                            if (entry is ZoneEntry zone)
                            {
                                foreach (var ent in zone.Entities)
                                {
                                    if (ent.LoadListA != null)
                                    {
                                        foreach (var row in ent.LoadListA.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort(delegate(int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }

                                    if (ent.LoadListB != null)
                                    {
                                        foreach (var row in ent.LoadListB.Rows)
                                        {
                                            var values = (List<int>) row.Values;
                                            values.Sort(delegate(int a, int b)
                                            {
                                                return eids.IndexOf(a) - eids.IndexOf(b);
                                            });
                                            if (Settings.Default.DeleteInvalidEntries)
                                            {
                                                values.RemoveAll(eid => nsf.FindEID<IEntry>(eid) == null);
                                            }
                                        }
                                    }
                                }
                            }
                    }
                }
            }
        }
    }
}