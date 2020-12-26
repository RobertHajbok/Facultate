using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lines_Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p = new Pen(Color.Black, 1);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int k = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void black_Click(object sender, EventArgs e)
        {
            p.Color = black.BackColor;
            default1.BackColor = black.BackColor;
        }

        private void dimgray_Click(object sender, EventArgs e)
        {
            p.Color = dimgray.BackColor;
            default1.BackColor = dimgray.BackColor;
        }

        private void silver_Click(object sender, EventArgs e)
        {
            p.Color = silver.BackColor;
            default1.BackColor = silver.BackColor;
        }

        private void lightcoral_Click(object sender, EventArgs e)
        {
            p.Color = lightcoral.BackColor;
            default1.BackColor = lightcoral.BackColor;
        }

        private void orange_Click(object sender, EventArgs e)
        {
            p.Color = orange.BackColor;
            default1.BackColor = orange.BackColor;
        }

        private void gold_Click(object sender, EventArgs e)
        {
            p.Color = gold.BackColor;
            default1.BackColor = gold.BackColor;
        }

        private void lawngreen_Click(object sender, EventArgs e)
        {
            p.Color = lawngreen.BackColor;
            default1.BackColor = lawngreen.BackColor;
        }

        private void green_Click(object sender, EventArgs e)
        {
            p.Color = green.BackColor;
            default1.BackColor = green.BackColor;
        }

        private void darkturquoise_Click(object sender, EventArgs e)
        {
            p.Color = darkturquoise.BackColor;
            default1.BackColor = darkturquoise.BackColor;
        }

        private void royalblue_Click(object sender, EventArgs e)
        {
            p.Color = royalblue.BackColor;
            default1.BackColor = royalblue.BackColor;
        }

        private void darkblue_Click(object sender, EventArgs e)
        {
            p.Color = darkblue.BackColor;
            default1.BackColor = darkblue.BackColor;
        }

        private void indigo_Click(object sender, EventArgs e)
        {
            p.Color = indigo.BackColor;
            default1.BackColor = indigo.BackColor;
        }

        private void white_Click(object sender, EventArgs e)
        {
            p.Color = white.BackColor;
            default1.BackColor = white.BackColor;
        }

        private void gainsboro_Click(object sender, EventArgs e)
        {
            p.Color = gainsboro.BackColor;
            default1.BackColor = gainsboro.BackColor;
        }

        private void wheat_Click(object sender, EventArgs e)
        {
            p.Color = wheat.BackColor;
            default1.BackColor = wheat.BackColor;
        }

        private void pink_Click(object sender, EventArgs e)
        {
            p.Color = pink.BackColor;
            default1.BackColor = pink.BackColor;
        }

        private void indianred_Click(object sender, EventArgs e)
        {
            p.Color = indianred.BackColor;
            default1.BackColor = indianred.BackColor;
        }

        private void red_Click(object sender, EventArgs e)
        {
            p.Color = red.BackColor;
            default1.BackColor = red.BackColor;
        }

        private void tan_Click(object sender, EventArgs e)
        {
            p.Color = tan.BackColor;
            default1.BackColor = tan.BackColor;
        }

        private void limegreen_Click(object sender, EventArgs e)
        {
            p.Color = limegreen.BackColor;
            default1.BackColor = limegreen.BackColor;
        }

        private void aquamarine_Click(object sender, EventArgs e)
        {
            p.Color = aquamarine.BackColor;
            default1.BackColor = aquamarine.BackColor;
        }

        private void teal_Click(object sender, EventArgs e)
        {
            p.Color = teal.BackColor;
            default1.BackColor = teal.BackColor;
        }

        private void brown_Click(object sender, EventArgs e)
        {
            p.Color = brown.BackColor;
            default1.BackColor = brown.BackColor;
        }

        private void violet_Click(object sender, EventArgs e)
        {
            p.Color = violet.BackColor;
            default1.BackColor = violet.BackColor;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            sp = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                k = 1;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            k = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (k == 1)
            {
                ep = e.Location;
                g = this.CreateGraphics();
                g.DrawLine(p, sp, ep);
            }
            sp = ep;
        }
    }
}
