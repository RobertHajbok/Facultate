using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyalphabetic_Cipher
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
            string key1;
            key1 = key1_input.Text;
            string key2;
            key2 = key2_input.Text;
            string key3;
            key3 = key3_input.Text;
            if (input_text.Text.Length == 0)
            {
                MessageBox.Show("Eroare: Introduceti un text pentru criptare");
            }
            if (!checkKey(key1))
            {
                MessageBox.Show("Eroare: Cheia 1 nu este valida! Introduceti o cheie care sa contina toate literele alfabetului englezesc astfel incat nici o litera sa nu se repete ");
            }
            else if (!checkKey(key2))
            {
                MessageBox.Show("Eroare: Cheia 2 nu este valida! Introduceti o cheie care sa contina toate literele alfabetului englezesc astfel incat nici o litera sa nu se repete ");
            }
            else if (!checkKey(key3))
            {
                MessageBox.Show("Eroare: Cheia 3 nu este valida! Introduceti o cheie care sa contina toate literele alfabetului englezesc astfel incat nici o litera sa nu se repete ");
            }            
            else
            {
                string inputText = input_text.Text;
                string outputText = null;
                int i = 0, nr_paranteze = 0;
                while (i < inputText.Length)
                {
                    char tempch = inputText[i];
                    if (tempch == 32)
                    {
                        outputText = outputText + " ";
                        nr_paranteze++;
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
                                switch ((i - nr_paranteze) % 3)
                                {
                                    case (0): outputText = outputText + key1[j];
                                        break;
                                    case (1): outputText = outputText + key2[j];
                                        break;
                                    case (2): outputText = outputText + key3[j];
                                        break;
                                }                              
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
        }

        private void frequeButton_Click(object sender, EventArgs e)
        {

            int[] c = new int[(int)char.MaxValue];
            string s = input_text.Text.ToUpper().Replace(" ","");
            

            if (input_text.Text.Length != 0)
            {
                foreach (char t in s)
                {
                    c[(int)t]++;
                }

                for (int i = 0; i < (int)char.MaxValue; i++)
                {
                    if (c[i] > 0 && char.IsLetter((char)i))
                    {
                        output_text.Text += (char)i + "-" + (float)(c[i])*100/s.Length + "%\t";
                    }
                }
            }
            else
            {
                MessageBox.Show("Eroare: Introduceti un text pentru analiza frecventei literelor");
            }
        }
    }
}
