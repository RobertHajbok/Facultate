using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphical
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Total = 100;
        int Current = 100;
        bool adding = false;

        Graphics g;
        Bitmap btm;
        Rectangle r;
        Pen p;

        Timer t = new Timer();

        Rectangle progressbar = new Rectangle(20, 20, 200, 40);
        Rectangle secondbar = new Rectangle(20, 200, 300, 40);

        StatusBar statusone;
        StatusBar stat;

        Graphics gr;

        public class StatusBar
        {
            int Total = 100;
            int Current = 100;
            bool adding = false;

            Graphics g;
            Bitmap btm;
            Rectangle r;
            Pen p;
            Color theme;

            Timer t = new Timer();

            public StatusBar(Rectangle Area, Color Theme)
            {
                p = new Pen(new SolidBrush(Theme));
                btm = new Bitmap(Area.Width, Area.Height);
                g = Graphics.FromImage(btm);
                r = new Rectangle(0, 0, Area.Width, Area.Height);

                t.Interval = 10;
                t.Tick += new EventHandler(t_Tick);
                t.Start();

                theme = Theme;
            }
            public int percent(double total, double current)
            {
                return (int)((current / total) * 100);
            }
            public void DrawBar()
            {
                SolidBrush color = new SolidBrush(theme);
                g.Clear(Color.White);
                g.DrawRectangle(new Pen(color), r);
                g.FillRectangle(color, new Rectangle(r.X, r.Y, (r.Width * (percent(Total, Current))) / 100, r.Height));
            }
            void t_Tick(object sender, EventArgs e)
            {
                if (adding)
                {
                    if (Current < Total)
                    {
                        Current++;
                    }
                    if (Current == 100)
                    {
                        adding = false;
                    }
                }
                else
                {
                    if (Current > 1)
                    {
                        Current--;
                    }
                    if (Current == 1)
                    {
                        adding = true;
                    }
                }
                DrawBar();
            }

            public Bitmap GiveGraphics()
            {
                return btm;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = btm;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = btm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);

            statusone = new StatusBar(progressbar, Color.Violet);
            stat = new StatusBar(secondbar, Color.Wheat);

            t.Start();

        }

        void t_Tick(object sender, EventArgs e)
        {
            g.DrawImage(statusone.GiveGraphics(), progressbar);
            g.DrawImage(stat.GiveGraphics(), secondbar);
        }
    }
}
