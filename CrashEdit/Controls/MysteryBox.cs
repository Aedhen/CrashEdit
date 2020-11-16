using System;
using System.Windows.Forms;
using DarkUI.Controls;

namespace CrashEdit
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using DarkUI.Forms;

    public sealed class MysteryBox : UserControl
    {
        private byte[] data;
        private bool saving;
        private int nextFindIndex = 0;

        private DarkToolStrip tsToolbar;
        private ToolStripButton tbbExport;
        private ToolStripLabel lblFindBytes;
        private ToolStripTextBox txbFindBytes;
        private HexBox hbData;

        public MysteryBox(byte[] data)
        {
            this.data = data;
            saving = false;

            tbbExport = new ToolStripButton();
            tbbExport.Text = "Export";
            tbbExport.Click += tbbExport_Click;
            tbbExport.Padding = new Padding(0,0,5,0);

            lblFindBytes = new ToolStripLabel();
            lblFindBytes.Text = "Find:";

            txbFindBytes = new ToolStripTextBox();
            txbFindBytes.CharacterCasing = CharacterCasing.Upper;
            txbFindBytes.KeyPress += txbFindBytes_KeyPress;
            txbFindBytes.KeyDown += txbFindBytes_KeyDown;

            tsToolbar = new DarkToolStrip();
            tsToolbar.Dock = DockStyle.Top;
            tsToolbar.Items.Add(tbbExport);
            tsToolbar.Items.Add(lblFindBytes);
            tsToolbar.Items.Add(txbFindBytes);

            // DarkToolStrip resets size to (24,24) when adding the item
            tbbExport.Size = new Size(48, 23);

            hbData = new HexBox();
            hbData.Dock = DockStyle.Fill;
            hbData.Data = data;

            Controls.Add(hbData);
            Controls.Add(tsToolbar);
        }

        void tbbExport_Click(object sender,EventArgs e)
        {
            if (!saving)
            {
                saving = true;
                FileUtil.SaveFile(data, FileFilters.Any);
                saving = false;
            }
        }

        void txbFindBytes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Uri.IsHexDigit(e.KeyChar) && !char.IsControl(e.KeyChar) || e.KeyChar == (char) 13)
            {
                e.Handled = true;
                return;
            }

            nextFindIndex = 0;
        }

        void txbFindBytes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            Find();
        }

        private void Find()
        {
            var input = txbFindBytes.Text;
            var splitInput = SplitHexString(input, 2);
            var findValues = splitInput.Select(x => Convert.ToByte(x, 16)).ToList();

            var nextResultFound = HandleFindLoop(findValues, nextFindIndex, data.Length);
            if (nextResultFound)
            {
                return;
            }

            nextResultFound = HandleFindLoop(findValues, 0, nextFindIndex);
            if (nextResultFound)
            {
                return;
            }

            DarkMessageBox.ShowInformation("No results found.", "Find hex");
        }

        private bool HandleFindLoop(List<byte> findValues, int startIndex, int endIndex)
        {
            var nextResultFound = false;
            for (var i = startIndex; i < endIndex; i++)
            {
                for (var j = 0; j < findValues.Count; j++)
                {
                    if (i + j >= endIndex || data[i + j] != findValues[j])
                    {
                        nextResultFound = false;
                        break;
                    }

                    nextResultFound = true;
                }

                if (!nextResultFound)
                {
                    continue;
                }

                nextFindIndex = i + 1;
                hbData.Position = i;
                break;
            }

            return nextResultFound;
        }
        private IEnumerable<string> SplitHexString(string input, int partLength)
        {
            if (input.Length % 2 == 1)
            {
                input = "0" + input;
            }

            for (var i = 0; i < input.Length; i += partLength)
            {
                yield return input.Substring(i, Math.Min(partLength, input.Length - i));
            }
        }
    }
}
