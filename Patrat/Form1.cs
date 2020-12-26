using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patrat
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap b;
        Pen p;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            p = new Pen(Color.White);
            pictureBox1.Image = b;

            g.Clear(Color.Black);

            //for (int i = 1; i < 100; i++)
            //{
            //    //patrat(100 + i, 100 + i, 100 + (i + 10));
            //    //patrat(pictureBox1.Width / 2, pictureBox1.Height / 2, 150 + i);
            //    patrat(pictureBox1.Width / (2 * i), pictureBox1.Height / (2 * i), 399 / (2 * i));
            //}

            recursiv(pictureBox1.Width / 2, pictureBox1.Height / 2, 200);
        }

        void recursiv(int x, int y, int l)
        {
            if (l > 1)
            {
                patrat(x, y, l);
                recursiv(x - l / 2, y - l / 2, l / 2);
                recursiv(x + l / 2, y - l / 2, l / 2);
                recursiv(x - l / 2, y + l / 2, l / 2);
                recursiv(x + l / 2, y + l / 2, l / 2);
            }
        }

        void patrat(int x, int y, int l)
        {
            PointF A = new PointF();
            A.X = x - l / 2;
            A.Y = y - l / 2;

            PointF B = new PointF();
            B.X = x + l / 2;
            B.Y = y - l / 2;

            PointF C = new PointF();
            C.X = x + l / 2;
            C.Y = y + l / 2;

            PointF D = new PointF();
            D.X = x - l / 2;
            D.Y = y + l / 2;

            g.DrawLine(p, A, B);
            g.DrawLine(p, B, C);
            g.DrawLine(p, C, D);
            g.DrawLine(p, D, A);

            pictureBox1.Refresh();
        }
    }
}
