using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Parole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            using (StreamWriter writer = new StreamWriter(@"D:\Programare\C#\Generator Parole\Parole.txt", true))
            {
                writer.Write(text);
                writer.Write("\r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r, k;
            int passwordLength = (Int32)numericUpDown1.Value;
            int nrPasswords = (Int32)numericUpDown2.Value;
            string password = "";
            char[] upperCase = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] lowerCase = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] signs = { '`', '~', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '=', '-', ':', '"', '|', '<', '>', '?', '/', '.', ',' };
            Random rRandom = new Random();

            if (nrPasswords == 0)
                MessageBox.Show("Specify number of passwords!");
            else if (passwordLength == 0)
                MessageBox.Show("Specify password lenght!");
            else if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked && !checkBox4.Checked)
                MessageBox.Show("No characters to generate passwords with!");
            else
                for (int j = 0; j < nrPasswords; j++)
                {
                    for (int i = 0; i < passwordLength; i++)
                    {
                        r = rRandom.Next(4);

                        if (r == 0)
                        {
                            if (checkBox1.Checked)
                            {
                                k = rRandom.Next(0, 25);
                                password += upperCase[k];
                            }
                            else if (checkBox2.Checked)
                            {
                                k = rRandom.Next(0, 25);
                                password += lowerCase[k];
                            }
                            else if (checkBox3.Checked)
                            {
                                k = rRandom.Next(0, 9);
                                password += numbers[k];
                            }
                            else
                            {
                                k = rRandom.Next(0, 9);
                                password += signs[k];
                            }
                        }
                        else if (r == 1)
                        {
                            if (checkBox2.Checked)
                            {
                                k = rRandom.Next(0, 25);
                                password += lowerCase[k];
                            }
                            else if (checkBox3.Checked)
                            {
                                k = rRandom.Next(0, 9);
                                password += numbers[k];
                            }
                            else if (checkBox4.Checked)
                            {
                                k = rRandom.Next(0, 23);
                                password += signs[k];
                            }
                            else
                            {
                                k = rRandom.Next(0, 25);
                                password += upperCase[k];
                            }
                        }
                        else if (r == 2)
                        {
                            if (checkBox3.Checked)
                            {
                                k = rRandom.Next(0, 9);
                                password += numbers[k];
                            }
                            else if (checkBox4.Checked)
                            {
                                k = rRandom.Next(0, 23);
                                password += signs[k];
                            }
                            else if (checkBox1.Checked)
                            {
                                k = rRandom.Next(0, 25);
                                password += upperCase[k];
                            }
                            else
                            {
                                k = rRandom.Next(0, 25);
                                password += lowerCase[k];
                            }
                        }
                        else
                        {
                            if (checkBox4.Checked)
                            {
                                k = rRandom.Next(0, 23);
                                password += signs[k];
                            }
                            else if (checkBox1.Checked)
                            {
                                k = rRandom.Next(0, 25);
                                password += upperCase[k];
                            }
                            else if (checkBox2.Checked)
                            {
                                k = rRandom.Next(0, 25);
                                password += lowerCase[k];
                            }
                            else
                            {
                                k = rRandom.Next(0, 9);
                                password += numbers[k];
                            }
                        }
                    }

                    password += "\r\n";
                }

            textBox1.Text = password;
        }
    }
}