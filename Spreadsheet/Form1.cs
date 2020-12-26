using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spreadsheet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void update(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                TextBox tb = sender as TextBox;
                String tbContents = tb.Text.Trim();

                String firstNum;
                String secondNum;

                if (tbContents.StartsWith("="))
                {
                    tbContents = tbContents.Substring(1, tbContents.Length - 1).Trim();
                    if (tbContents.Contains("+"))
                    {
                        firstNum = tbContents.Substring(0, tbContents.IndexOf('+')).Trim();
                        secondNum = tbContents.Substring(tbContents.IndexOf('+') + 1, (tbContents.Length - tbContents.IndexOf('+')) - 1).Trim();
                        double fNum = double.Parse(firstNum);
                        double sNum = double.Parse(secondNum);
                        double total = fNum + sNum;
                        tb.Text = total.ToString();
                    }

                    if (tbContents.Contains("-"))
                    {
                        firstNum = tbContents.Substring(0, tbContents.IndexOf('-')).Trim();
                        secondNum = tbContents.Substring(tbContents.IndexOf('-') + 1, (tbContents.Length - tbContents.IndexOf('-')) - 1).Trim();
                        double fNum = double.Parse(firstNum);
                        double sNum = double.Parse(secondNum);
                        double total = fNum - sNum;
                        tb.Text = total.ToString();
                    }

                    if (tbContents.Contains("*"))
                    {
                        firstNum = tbContents.Substring(0, tbContents.IndexOf('*')).Trim();
                        secondNum = tbContents.Substring(tbContents.IndexOf('*') + 1, (tbContents.Length - tbContents.IndexOf('*')) - 1).Trim();
                        double fNum = double.Parse(firstNum);
                        double sNum = double.Parse(secondNum);
                        double total = fNum * sNum;
                        tb.Text = total.ToString();
                    }

                    if (tbContents.Contains("/"))
                    {
                        firstNum = tbContents.Substring(0, tbContents.IndexOf('/')).Trim();
                        secondNum = tbContents.Substring(tbContents.IndexOf('/') + 1, (tbContents.Length - tbContents.IndexOf('/')) - 1).Trim();
                        double fNum = double.Parse(firstNum);
                        double sNum = double.Parse(secondNum);
                        double total = fNum / sNum;
                        tb.Text = total.ToString();
                    }
                }
            }
        }
    }
}
