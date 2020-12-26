using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Drupal_PhotoUpload
{
    public partial class Form1 : Form
    {
        public DrupalUtilities Db = null;

        public Form1()
        {
            InitializeComponent();

            pnl_Operations.Enabled = false;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (Db != null)
            {
                Db.Logout();
                // Remove the event listener
                Db.NewDrupalViewData -= HandleNewViewData;
                Db = null;
            }

            Db = new DrupalUtilities(txt_DrupalBaseURL.Text, txt_ServiceEndpoint.Text, txt_Username.Text,
                txt_Password.Text);
            Db.NewDrupalViewData += HandleNewViewData;
            Db.Login();

            if (txt_Operations.Text != "")
                pnl_Operations.Enabled = true;
        }

        /// <summary>
        /// Event called once drupal returns a list of paths for
        /// images. We get raw string output from the server here
        /// so its up to us to parse the xml ourselves here on
        /// an application specific basis.
        /// The objective is to extract a list of absolute images paths
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void HandleNewViewData(object sender, DrupalEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("handleNewViewData: ");
            // Create an XmlReader
            using (XmlReader.Create(new StringReader(args.TheMessage)))
            {
                try
                {
                    txt_Operations.Text = args.TheMessage;

                    switch (args.ResponseType)
                    {
                        case DrupalUtilities.MethodNodeRetrieve:

                            System.Diagnostics.Debug.WriteLine("Node Data: " + args.TheMessage);
                            break;

                        case DrupalUtilities.MethodViewRetrieve:
                            System.Diagnostics.Debug.WriteLine("View Data: " + args.TheMessage);

                            break;
                    }
                }
                catch (XmlException e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception parsing drupal result xml: {0}", e.ToString());
                }
            }
        }

        private void btn_GetNode_Click(object sender, EventArgs e)
        {
            if (txt_DrupalNodeNr.Text == "")
                MessageBox.Show(@"You must enter node number first!");
            if (Db != null)
            {
                Db.GetNode(Convert.ToInt32(txt_DrupalNodeNr.Text));
            }
        }

        private void btn_ChooseJPEG_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png",
                InitialDirectory = @"C:\",
                Title = @"Choose the JPEG image you want to upload"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txt_FilePath.Text = dialog.FileName;
            }
        }

        private void btn_UploadImage_Click(object sender, EventArgs e)
        {
            if (txt_FilePath.Text == "")
            {
                MessageBox.Show(@"You must choose the image first!");
            }
            else if (Db != null)
            {
                var bmp = new BitmapImage(new Uri(txt_FilePath.Text));
                // Ensure the image is a jpeg
                var encoder = new JpegBitmapEncoder();
                var memStream = new MemoryStream();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(memStream);

                var photoId = Guid.NewGuid();
                var photolocation = photoId + ".jpg"; //file name 
                var jpegEncodedImgBytes = memStream.GetBuffer();
                Db.SubmitFileB64(ref jpegEncodedImgBytes, photolocation, "image/jpeg");
            }
        }
    }
}
