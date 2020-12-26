using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Loto_6_49
{
    public partial class Form1 : Form
    {
        private short _nrCheck;
        private bool _valid;
        readonly List<CheckBox> _chkList = new List<CheckBox>();
        readonly Button _btn = new Button();
        readonly Label _lblNr = new Label();

        public Form1()
        {
            InitializeComponent();

            InitializeUI();
        }

        // ReSharper disable once InconsistentNaming
        private void InitializeUI()
        {
            int n = 1;
            for (int i = 1; i <= 7; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    var chkNr = new CheckBox
                    {
                        Appearance = Appearance.Button,
                        Size = new Size(32, 32),
                        Location = new Point(32 * j, 32 * i),
                        Text = (n).ToString(CultureInfo.InvariantCulture)
                    };
                    chkNr.Click += chkNr_Click;
                    _chkList.Add(chkNr);
                    n++;
                }
            }

            foreach (CheckBox chkNr in _chkList)
            {
                Controls.Add(chkNr);
            }

            _btn.Location = new Point(5, 5);
            _btn.Text = @"Generate";
            _btn.Click += btn_Click;
            Controls.Add(_btn);

            _lblNr.Location = new Point(90, 6);
            Controls.Add(_lblNr);
        }
        private void chkNr_Click(object sender, EventArgs e)
        {
            _nrCheck = 0;
            foreach (CheckBox chkNr in _chkList)
            {
                if (chkNr.Checked)
                {
                    _nrCheck++;
                    if (_nrCheck == 6)
                    {
                        _valid = true;
                    }
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (!_valid)
                return;
            _lblNr.Text = "";
            var rand = new Random();
            var nrCastigatoare = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                int x = rand.Next(1, 50);
                for (int j = 0; j < i; j++)
                    if (x == nrCastigatoare[j])
                        x = rand.Next(1, 50);
                nrCastigatoare.Add(x);
                _lblNr.Text += x;
                _lblNr.Text += @" ";
            }

            var file = new System.IO.StreamWriter("numere.txt", true);
            file.WriteLine(_lblNr.Text);
            file.Close();

            _nrCheck = 0;
            _valid = false;
            foreach (CheckBox chkNr in _chkList)
                chkNr.Checked = false;
        }
    }
}
