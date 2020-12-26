using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace Standard_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int clear = 1;
        decimal result, mresult = 0;
        string op;
        int Clear(int cl)
        {
            switch (cl)
            {
                case 1:
                    {
                        label1.Text = "";
                    } break;
                case 2:
                    {
                        label1.Text = "";
                        label2.Text = "";
                        op = "";
                    } break;
                case 3:
                    {
                        label1.Text = "";
                        label2.Text = label2.Text.Remove(label2.Text.IndexOf('r'));
                    } break;
                case 4:
                    {
                        label1.Text = "";
                        label2.Text = label2.Text.Remove(label2.Text.IndexOf('s'));
                    } break;
                case 5:
                    {
                        label1.Text = "";
                        label2.Text = label2.Text.Remove(label2.Text.LastIndexOf(' ') + 1);
                    } break;
            }
            return 0;
        }

        decimal eval(string op)
        {
            clear = 1;
            try
            {
                switch (op)
                {
                    case "+": result = result + Convert.ToDecimal(label1.Text); break;
                    case "-": result = result - Convert.ToDecimal(label1.Text); break;
                    case "/": result = result / Convert.ToDecimal(label1.Text); break;
                    case "*": result = result * Convert.ToDecimal(label1.Text); break;
                    case "Mod": result = result % Convert.ToDecimal(label1.Text); break;
                    default: result = Convert.ToDecimal(label1.Text); break;
                }
            }
            catch (OverflowException)
            {
                label2.Text = "";
                label2.Text = "Overflow";
                clear = 2;
                SystemSounds.Asterisk.Play();
            }
            catch (DivideByZeroException)
            {
                label2.Text = "";
                label2.Text = "Cannot divide by zero";
                clear = 2;
                SystemSounds.Asterisk.Play();
            }
            return result;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "0";
            else
                SystemSounds.Beep.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "1";
            else
                SystemSounds.Beep.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "2";
            else
                SystemSounds.Beep.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "3";
            else
                SystemSounds.Beep.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "4";
            else
                SystemSounds.Beep.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "5";
            else
                SystemSounds.Beep.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "6";
            else
                SystemSounds.Beep.Play();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "7";
            else
                SystemSounds.Beep.Play();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "8";
            else
                SystemSounds.Beep.Play();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            clear = Clear(clear);
            if (label1.Text.Length < 28)
                label1.Text = label1.Text + "9";
            else
                SystemSounds.Beep.Play();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (label1.Text.Contains('.'))
            {
                SystemSounds.Beep.Play();
            }
            else
                label1.Text = label1.Text + ".";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (clear == 3 || clear == 4 || clear == 5)
                label2.Text = label2.Text + " + ";
            else
                label2.Text = label2.Text + label1.Text + " + ";
            label1.Text = eval(op).ToString();
            op = "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (clear == 3 || clear == 4 || clear == 5)
                label2.Text = label2.Text + " - ";
            else
                label2.Text = label2.Text + label1.Text + " - ";
            label1.Text = eval(op).ToString();
            op = "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (clear == 3 || clear == 4 || clear == 5)
                label2.Text = label2.Text + " / ";
            else
                label2.Text = label2.Text + label1.Text + " / ";
            label1.Text = eval(op).ToString();
            op = "/";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (clear == 3 || clear == 4 || clear == 5)
                label2.Text = label2.Text + " * ";
            else
                label2.Text = label2.Text + label1.Text + " * ";
            label1.Text = eval(op).ToString();
            op = "*";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (clear == 3 || clear == 4 || clear == 5)
                label2.Text = label2.Text + " Mod ";
            else
                label2.Text = label2.Text + label1.Text + " Mod ";
            label1.Text = eval(op).ToString();
            op = "Mod";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (label2.Text.Contains("reciproc"))
            {
                label2.Text = label2.Text.Insert(label2.Text.IndexOf('r'), "reciproc(");
                label2.Text = label2.Text.Insert(label2.Text.IndexOf(')'), ")");
            }
            else
                label2.Text = label2.Text + "reciproc(" + label1.Text + ")";
            label1.Text = (1 / Convert.ToDecimal(label1.Text)).ToString();
            clear = 3;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (label2.Text.Contains("sqrt"))
            {
                label2.Text = label2.Text.Insert(label2.Text.IndexOf('s'), "sqrt(");
                label2.Text = label2.Text.Insert(label2.Text.IndexOf(')'), ")");
            }
            else
                label2.Text = label2.Text + "sqrt(" + label1.Text + ")";
            label1.Text = Math.Sqrt(Convert.ToDouble(label1.Text)).ToString();
            clear = 4;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text = (result * Convert.ToDecimal(label1.Text) / 100).ToString();
            label2.Text = label2.Text + label1.Text;
            clear = 5;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (label1.Text.Contains('-'))
            {
                label1.Text = label1.Text.Remove(label1.Text.IndexOf('-'), 1);
            }
            else
                label1.Text = "-" + label1.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (clear != 3 && clear != 4 && clear != 5)
                label2.Text = label2.Text + label1.Text;
            label1.Text = eval(op).ToString();
            clear = 2;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Clear(2);
            clear = 1;
            label1.Text = "0";
            result = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Clear(1);
            clear = 1;
            label1.Text = "0";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            mresult = Convert.ToDecimal(label1.Text);
            clear = 1;
            label3.Text = "M";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            label1.Text = mresult.ToString();
            clear = 1;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            mresult = mresult + Convert.ToDecimal(label1.Text);
            clear = 1;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            mresult = mresult - Convert.ToDecimal(label1.Text);
            clear = 1;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            mresult = 0;
            clear = 1;
            label3.Text = "";
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text.Length <= 20)
            {
                Font font = new Font("Consolas", 14, FontStyle.Regular);
                label1.Font = font;
            }
            else if (label1.Text.Length > 20 && label1.Text.Length <= 26)
            {
                Font font = new Font("Consolas", 11, FontStyle.Regular);
                label1.Font = font;
            }
            else
            {
                Font font = new Font("Consolas", 9, FontStyle.Regular);
                label1.Font = font;
            }
        }
    }
}
