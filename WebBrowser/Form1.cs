﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(comboBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            webBrowser2.GoBack();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            webBrowser2.GoForward();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            webBrowser2.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            webBrowser2.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(comboBox2.Text);
        }
    }
}
