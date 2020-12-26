namespace CrashEdit.Forms
{
    using System;
    using System.Globalization;
    using Crash;
    using DarkUI.Forms;

    public partial class EidConvertWindow : DarkForm
    {
        public EidConvertWindow()
        {
            InitializeComponent();
        }

        private void btnIntToName_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txbEidInt.Text) || !int.TryParse(txbEidInt.Text, out var intInput))
            {
                return;
            }

            try
            {
                txbEname.Text = Entry.EIDToEName(intInput);
                txbEidHex.Text = intInput.ToString("X");
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private void btnHexToName_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txbEidHex.Text))
            {
                return;
            }

            try
            {
                int intValue = int.Parse(txbEidHex.Text, NumberStyles.HexNumber);
                txbEidInt.Text = intValue.ToString();
                txbEidHex.Text = intValue.ToString("X");
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private void btnNameToNum_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txbEname.Text))
            {
                return;
            }

            try
            {
                var eid = Entry.ENameToEID(txbEname.Text);
                txbEidInt.Text = eid.ToString();
                txbEidHex.Text = eid.ToString("X");
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}
