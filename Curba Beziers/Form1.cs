using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Curba_Beziers
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        PointF[] v = new PointF[4];
        Graphics graf;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double u = 2 * i * Math.PI / 100;
            v[0].X = cx / 2 + cx / 2 * (float)Math.Cos(u);
            v[0].Y = 5 * cy / 8 + cy / 16 * (float)Math.Sin(u);
            v[1] = new PointF(cx / 2, -cy);
            v[2] = new PointF(cx / 2, 2 * cy);
            u += Math.PI / 4;
            v[3].X = cx / 2 + cx / 4 * (float)Math.Cos(u);
            v[3].Y = cy / 2 + cy / 16 * (float)Math.Sin(u);
            Pen p = new Pen(Color.FromArgb(r.Next(2), r.Next(200), r.Next(2)));
            graf.DrawBeziers(p, v);
            i++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graf = this.CreateGraphics();
            timer1.Start();
        }
    }
}
