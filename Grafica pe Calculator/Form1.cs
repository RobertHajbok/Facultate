using System;
using System.Drawing;
using System.Windows.Forms;
using Grafica_pe_Calculator.Properties;

namespace Grafica_pe_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AppEngine.sursa = new Bitmap(Resources.download);

            AppEngine.x = AppEngine.sursa.Width;
            AppEngine.y = AppEngine.sursa.Height;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var clrDest = Color.FromArgb(clrSrc.R, 0, 0);
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var t = (clrSrc.R + clrSrc.G + clrSrc.B)/3;
                    var clrDest = Color.FromArgb(t, t, t);
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var clrDest = Color.FromArgb(255 - clrSrc.R, 255 - clrSrc.G, 255 - clrSrc.B);
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var t = (clrSrc.R + clrSrc.G + clrSrc.B)/3;
                    var clrDest = t < 128 ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);
            var k = (int) numericUpDown1.Value;

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var clrDest = Color.FromArgb(Math.Max(0, clrSrc.R - k), Math.Max(0, clrSrc.G - k),
                        Math.Max(0, clrSrc.B - k));
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);
            var k = (int) numericUpDown1.Value;

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var clrDest = Color.FromArgb(Math.Min(255, clrSrc.R + k), Math.Min(255, clrSrc.G + k),
                        Math.Min(255, clrSrc.B + k));
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);
            var k = (int) numericUpDown1.Value;

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var t = (clrSrc.R + clrSrc.G + clrSrc.B)/3;
                    var clrDest = t < 128
                        ? Color.FromArgb(Math.Max(0, clrSrc.R - k), Math.Max(0, clrSrc.G - k), Math.Max(0, clrSrc.B - k))
                        : Color.FromArgb(Math.Min(255, clrSrc.R + k), Math.Min(255, clrSrc.G + k),
                            Math.Min(255, clrSrc.B + k));
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);
            const int k = 3;

            for (var i = k; i < AppEngine.x - k; i++)
                for (var j = k; j < AppEngine.y - k; j++)
                {
                    int sumaR = 0, sumaG = 0, sumaB = 0;

                    for (var l = i - k; l < i + k; l++)
                    {
                        for (var m = j - k; m < j + k; m++)
                        {
                            sumaR += AppEngine.sursa.GetPixel(l, m).R;
                            sumaG += AppEngine.sursa.GetPixel(l, m).G;
                            sumaB += AppEngine.sursa.GetPixel(l, m).B;
                        }
                    }

                    var clrDest = Color.FromArgb(sumaR/((2*k + 1)*(2*k + 1)), sumaG/((2*k + 1)*(2*k + 1)),
                        sumaB/((2*k + 1)*(2*k + 1)));
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x, AppEngine.y);

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var clrDest = Color.FromArgb(clrSrc.R - clrSrc.R%64, clrSrc.G - clrSrc.G%64, clrSrc.B - clrSrc.B%64);
                    AppEngine.dest.SetPixel(i, j, clrDest);
                }

            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AppEngine.dest = new Bitmap(AppEngine.x*2, AppEngine.y*2);

            for (var i = 0; i < AppEngine.x; i++)
                for (var j = 0; j < AppEngine.y; j++)
                {
                    var clrSrc = AppEngine.sursa.GetPixel(i, j);
                    var clrDest = Color.FromArgb(clrSrc.R, clrSrc.G, clrSrc.B);
                    AppEngine.dest.SetPixel(i*2, j*2, clrDest);
                }

            for (var i = 0; i < AppEngine.x*2 - 1; i++)
                for (var j = 0; j < AppEngine.y*2 -1; j++)
                {
                    if (i%2 == 1 && j%2 == 1)
                    {
                        var clrSrc1 = AppEngine.dest.GetPixel(i - 1, j - 1);
                        var clrSrc2 = AppEngine.dest.GetPixel(i - 1, j + 1);
                        var clrSrc3 = AppEngine.dest.GetPixel(i + 1, j - 1);
                        var clrSrc4 = AppEngine.dest.GetPixel(i + 1, j + 1);

                        var clrDest = Color.FromArgb((clrSrc1.R + clrSrc2.R + clrSrc3.R + clrSrc4.R)/4,
                            (clrSrc1.G + clrSrc2.G + clrSrc3.G + clrSrc4.G)/4,
                            (clrSrc1.B + clrSrc2.B + clrSrc3.B + clrSrc4.B)/4);
                        AppEngine.dest.SetPixel(i, j, clrDest);
                    }
                    else if (i%2 == 0 && j%2 == 1)
                    {
                        var clrSrc1 = AppEngine.dest.GetPixel(i, j - 1);
                        var clrSrc2 = AppEngine.dest.GetPixel(i, j + 1);
                        var clrDest = Color.FromArgb((clrSrc1.R + clrSrc2.R)/2, (clrSrc1.G + clrSrc2.G)/2,
                            (clrSrc1.B + clrSrc2.B)/2);
                        AppEngine.dest.SetPixel(i, j, clrDest);
                    }
                    else if (i%2 == 1 && j%2 == 0)
                    {
                        var clrSrc1 = AppEngine.dest.GetPixel(i - 1, j);
                        var clrSrc2 = AppEngine.dest.GetPixel(i + 1, j);
                        var clrDest = Color.FromArgb((clrSrc1.R + clrSrc2.R)/2, (clrSrc1.G + clrSrc2.G)/2,
                            (clrSrc1.B + clrSrc2.B)/2);
                        AppEngine.dest.SetPixel(i, j, clrDest);
                    }
                }


            pictureBox1.Image = AppEngine.sursa;
            pictureBox2.Image = AppEngine.dest;
        }
    }
}
