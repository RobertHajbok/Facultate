using System;
using System.Windows.Forms;

namespace MVP_OrosH
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblOSVersion.Text = @"OS Version " + Environment.OSVersion.VersionString;
            lblAppName.Text = Application.ProductName;
            lblAppVersion.Text = @"App Version " + Application.ProductVersion;
        }
    }
}
