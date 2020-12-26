using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Hash_Calculator
{
    public partial class Form1 : Form
    {
        public enum HashMode { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 };

        public Form1()
        {
            InitializeComponent();
            cmb_Mode.DataSource = Enum.GetValues(typeof(HashMode));
            btn_Calculate1.Enabled = false;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txt_File.Text = openFileDialog1.FileName;
            btn_Calculate1.Enabled = true;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        public void WorkThreadFunction()
        {
            CalculateHash(txt_File.Text, cmb_Mode.Text);
        }

        private void CalculateHash(String inName, String mode)
        {
            HashAlgorithm hash = HashAlgorithm.Create(mode);
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);

            byte[] hashValue = hash.ComputeHash(fin);

            txt_Hash.Text = PrintByteArray(hashValue);
        }

        private static string PrintByteArray(byte[] array)
        {
            int i;
            StringBuilder sb = new StringBuilder();

            for (i = 0; i < array.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", array[i]));
                if ((i % 4) == 3) sb.Append(" ");
            }
            return sb.ToString();
        }

        private void btn_Calculate1_Click(object sender, EventArgs e)
        {
            CalculateHash(txt_File.Text, cmb_Mode.Text);
            btn_Calculate1.Enabled = false;
        }
    }
}
