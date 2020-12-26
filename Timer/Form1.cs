using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {
        int n;

        public Form1()
        {
            InitializeComponent();

            // Se da o valoare de start, din secunda in secunda deduceti valoarea cu o unitate, cand ajunge la 0 se opreste
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = n.ToString();

            n--;

            if (n < 0)
            {
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = 100;

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
