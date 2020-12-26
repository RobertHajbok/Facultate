using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monoalphabetic_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void key_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void input_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8 && ch != 32)
            {
                e.Handled = true;
            }
        }

        private void output_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (true)
            {
                e.Handled = true;
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkKey(string key)
        {
            int length = key.Length;
            if (length != 26)
            {
                return false;
            }
            else
            {
                char ch = 'A';
                while (ch <= 'Z')
                {
                    bool flag = false;
                    int counter = 0;
                    while (counter <= 25)
                    {
                        if (key[counter] == ch || key[counter] == ch + 32)
                        {
                            flag = true;
                            break;
                        }
                        counter++;
                    }
                    if (flag == true)
                    {
                        ch++;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

        }
        private void encryptButton_Click(object sender, EventArgs e)
        {
            string key;
            key = key_input.Text;
            if (checkKey(key))
            {
                string inputText = input_text.Text;
                string outputText = null;
                int len = inputText.Length;
                int i = 0;
                while (i < len)
                {
                    char tempch = inputText[i];
                    if (tempch == 32)
                    {
                        outputText = outputText + " ";
                        i++;
                    }
                    else
                    {
                        char cur_sm = 'a';
                        char cur_lr = 'A';
                        int j = 0;
                        while (true)
                        {
                            if (tempch == cur_sm || tempch == cur_lr)
                            {
                                outputText = outputText + key[j];
                                i++;
                                break;
                            }
                            else
                            {
                                cur_lr++;
                                cur_sm++;
                                j++;
                            }
                        }
                    }
                }
                output_text.Text = outputText;
            }
            else
            {
                MessageBox.Show("Eroare: Cheia nu este valida! Introduceti o cheie care sa contina toate literele alfabetului englezesc astfel incat nici o litera sa nu se repete ");
            }
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            string key;
            key = key_input.Text;
            if (checkKey(key))
            {
                string inputText = input_text.Text;
                string outputText = null;
                int len = inputText.Length;
                int i = 0;
                while (i < len)
                {
                    char tempch = inputText[i];
                    if (tempch == 32)
                    {
                        outputText = outputText + " ";
                        i++;
                    }
                    else
                    {
                        char cur_sm = 'a';
                        char cur_lr = 'A';
                        int j = 0;
                        while (j <= 25)
                        {
                            if (tempch == key[j])
                            {
                                if (tempch >= 65 && tempch <= 90)
                                    outputText = outputText + cur_lr;
                                else
                                    outputText = outputText + cur_sm;
                                i++;
                                break;
                            }
                            else
                            {
                                cur_sm++;
                                cur_lr++;
                                j++;
                            }
                        }
                    }
                }
                output_text.Text = outputText;
            }
            else
            {
                MessageBox.Show("Eroare: Cheia nu este valida! Introduceti o cheie care sa contina toate literele alfabetului englezesc astfel incat nici o litera sa nu se repete ");
            }
        }
    }
}
