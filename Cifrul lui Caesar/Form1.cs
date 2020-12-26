using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Cifrul_lui_Caesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            string encrypt = tboxIO.Text;
            encrypt.ToLower();


            bool tbNull = tboxIO.Text == "";
            bool tbNull2 = tbShift.Text == "";

            if (tbNull)
            {
                MessageBox.Show("There is nothing to encrypt.");
            }
            else if (tbNull2)
            {
                MessageBox.Show("Enter Shifts number.");
            }
            else
            {
                char[] array = encrypt.ToCharArray();

                for (int i = 0; i < array.Length; i++)
                {
                    int num = (int)array[i];
                    if (num >= 'a' && num <= 'z')
                    {
                        num += Convert.ToInt32(tbShift.Text);
                        if (num > 'z')
                        {
                            num = num - 26;
                        }
                    }
                    else if (num >= 'A' && num <= 'Z')
                    {
                        num += Convert.ToInt32(tbShift.Text);
                        if (num > 'Z')
                        {
                            num = num - 26;
                        }
                    }
                    array[i] = (char)num;
                }
                lblIO.Text = "Encrypted Message";
                tboxIO.Text = new string(array).ToLower();
            }

            tboxIO.Copy();
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            string decrypt = tboxIO.Text;
            decrypt.ToLower();

            bool tbNull = tboxIO.Text == "";
            bool tbNull2 = tbShift.Text == "";

            if (tbNull)
            {
                MessageBox.Show("There is nothing to decrypt.");
            }
            else if (tbNull2)
            {
                MessageBox.Show("Enter Shifts number.");
            }
            else
            {
                char[] array = decrypt.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    int num = (int)array[i];
                    if (num >= 'a' && num <= 'z')
                    {
                        num -= Convert.ToInt32(tbShift.Text);
                        if (num > 'z')
                            num = num - 26;

                        if (num < 'a')
                            num = num + 26;
                    }
                    else if (num >= 'A' && num <= 'Z')
                    {
                        num -= Convert.ToInt32(tbShift.Text);
                        if (num > 'Z')
                            num = num - 26;

                        if (num < 'A')
                            num = num + 26;
                    }
                    array[i] = (char)num;
                }
                lblIO.Text = "Decrypted Message";
                tboxIO.Text = new string(array).ToUpper();
            }

            tboxIO.Copy();
        }

        private void tboxIO_MouseClick(object sender, MouseEventArgs e)
        {
            tboxIO.SelectAll();
            tboxIO.Copy();
        }

        private void tbShift_MouseClick(object sender, MouseEventArgs e)
        {
            tbShift.SelectAll();
        }           
    }
}
