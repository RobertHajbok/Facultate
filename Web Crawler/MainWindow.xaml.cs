using System.Threading;
using System.Windows;

namespace Web_Crawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly HtmlPage _mPgTest = new HtmlPage();

        public MainWindow()
        {
            InitializeComponent();
            _mPgTest.LoadProgress += m_pgTest_LoadProgress;
            _mPgTest.LoadStatus += m_pgTest_LoadStatus;
        }

        //Put Load Progress to the Progress Bar
        private void m_pgTest_LoadProgress
            (string url, long maximum, long value)
        {
            var intMaximum = (int) maximum;
            var intValue = (int) value;
            try
            {
                if (!((intMaximum < 0) || (intValue < 0)))
                    if (intMaximum + intValue == 0)
                        PutStatus("Loading: " + url);
                    else if (intMaximum == intValue)
                    {
                        PutStatus("");
                        intMaximum = 0;
                    }
                PbLoadProgress.Maximum = intMaximum;
                PbLoadProgress.Minimum = 0;
                PbLoadProgress.Value = intValue;
            }
            catch
            {
            }
        }

        //Put Load Status to Status Bar
        private void m_pgTest_LoadStatus
            (string url, string description)
        {
            try
            {
                PutStatus(description + ": " + url);
            }
            catch
            {
            }
        }

        private void btnLoadSource_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Text = "";
            if (_mPgTest.LoadSource(TxtUrl.Text))
            {
                TxtSource.Text = _mPgTest.Source;
                BtnText.IsEnabled = true;
                BtnGetTagsByName.IsEnabled = true;
                TxtTagName.IsEnabled = true;
                BtnGetHRefs.IsEnabled = true;
                BtnGetAllTags.IsEnabled = true;
            }
            else
                MessageBox.Show("Unable to load " + TxtUrl.Text);
        }

        private void btnText_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Text = _mPgTest.Text;
        }

        private void btnGetTagsByName_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Text = "";
            var strTags = _mPgTest.GetTagsByName(TxtTagName.Text);
            if (strTags == null) return;
            int i;
            for (i = 0; i < strTags.Length; i++)
                TxtOutput.Text = TxtOutput.Text + strTags[i] + "\r\n\r\n";
        }

        private void btnGetHRefs_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Text = "";
            var strHRefs
                = _mPgTest.GetHRefs();
            if (strHRefs == null) return;
            int i;
            for (i = 0; i < strHRefs.Length; i++)
                TxtOutput.Text = TxtOutput.Text + strHRefs[i] + "\r\n\r\n";
        }

        private void btnGetAllTags_Click(object sender, RoutedEventArgs e)
        {
            TxtOutput.Text = "";
            PutStatus("Loading all tags - please wait...");
            var strTags
                = _mPgTest.GetAllTags();
            if (strTags != null)
            {
                PbLoadProgress.Value = 0;
                PbLoadProgress.Maximum = strTags.Length;
                int i;
                for (i = 0; i < strTags.Length; i++)
                {
                    PbLoadProgress.Value = i;
                    TxtOutput.Text = TxtOutput.Text + strTags[i] + "\r\n\r\n";
                }
            }
            PutStatus("");
            PbLoadProgress.Value = 0;
        }

        private void PutStatus(string strPutThis)
        {
            try
            {
                StsText.Text = strPutThis;
            }
            catch
            {
            }
        }
    }
}