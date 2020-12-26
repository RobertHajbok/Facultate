using System;
using System.Windows.Forms;

namespace SerialCOMPort
{
    public partial class FrmMain : Form
    {
        readonly CommunicationManager _comm = new CommunicationManager();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadValues();
            SetDefaults();
            SetControlState();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            _comm.Parity = cboParity.Text;
            _comm.StopBits = cboStop.Text;
            _comm.DataBits = cboData.Text;
            _comm.BaudRate = cboBaud.Text;
            _comm.DisplayWindow = rtbDisplay;
            _comm.OpenPort();

            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }

        /// <summary>
        /// Method to initialize serial port
        /// values to standard defaults
        /// </summary>
        private void SetDefaults()
        {
            //cboPort.SelectedIndex = 0;
            cboBaud.SelectedText = "9600";
            cboParity.SelectedIndex = 0;
            cboStop.SelectedIndex = 1;
            cboData.SelectedIndex = 1;
        }

        /// <summary>
        /// methos to load our serial
        /// port option values
        /// </summary>
        private void LoadValues()
        {
            _comm.SetPortNameValues(cboPort);
            _comm.SetParityValues(cboParity);
            _comm.SetStopBitValues(cboStop);
        }

        /// <summary>
        /// method to set the state of controls
        /// when the form first loads
        /// </summary>
        private void SetControlState()
        {
            rdoText.Checked = true;
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            _comm.WriteData(txtSend.Text);
        }

        private void rdoHex_CheckedChanged(object sender, EventArgs e)
        {
            _comm.CurrentTransmissionType = rdoHex.Checked ? CommunicationManager.TransmissionType.Hex : CommunicationManager.TransmissionType.Text;
        }
    }
}