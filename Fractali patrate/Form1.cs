using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractali_patrate
{
    public partial class Form1 : Form
    {
        // Bitmap b;
        // Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        void patrat(int x, int y, int l)
        {
            AppEngine.g.DrawRectangle(Pens.Blue, x - l / 2, y - l / 2, l, l);
            //AppEngine.g.FillRectangle(Brushes.Blue, x - l / 2, y - l / 2, l, l);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            g.DrawLine(Pens.Red, 0, 0, 100, 100);
            pictureBox1.Image = b;*/

            AppEngine.initGraph(pictureBox1.Width, pictureBox1.Height);
            //patrat(100, 100, 70);
            Rec(100, 100, 70);
            RefreshImage();
        }

        void RefreshImage()
        {
            pictureBox1.Image = AppEngine.b;
        }

        void Rec(int x, int y, int l)
        {
            if (l <= 1)
                return;

            patrat(x, y, l);
            Rec(x - l / 2, y - l / 2, l / 2);
            //Rec(x + l/2, y - l/2, l/2); 
            Rec(x + l / 2, y + l / 2, l / 2);
            //Rec(x - l/2, y + l/2, l/2);
        }
    }
}
