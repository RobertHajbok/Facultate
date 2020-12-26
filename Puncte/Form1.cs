using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puncte
{
    public partial class Form1 : Form
    {
        List<Point> currentPoints = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            Timer creator = new Timer();
            creator.Interval = 1000;
            creator.Tick += creator_Tick;
            creator.Start();

            Timer painter = new Timer();
            painter.Interval = 1000 / 25; // 25 fps
            painter.Tick += painter_Tick;
            painter.Start();

            CreatePoints();
        }

        void painter_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        void creator_Tick(object sender, EventArgs e)
        {
            CreatePoints();
        }

        public void CreatePoints()
        {
            Random r = new Random();
            for (int i = 0; i < 25; i++)
            {
                Point p = new Point();
                p.X = r.Next(this.Size.Width);
                p.Y = r.Next(this.Size.Height);

                currentPoints.Add(p);
            }
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            List<Point> newPoints = new List<Point>();

            foreach (Point p in currentPoints)
            {
                Point np = p;

                if (np.X > 0 && np.Y > 0 && np.X < this.Width && np.Y < this.Height)
                {
                    if (np.X < this.Width / 2 && np.Y < this.Height / 2) // Top left
                    {
                        np.X -= 1;
                        np.Y -= 1;
                    }
                    else if (np.X > this.Width / 2 && np.Y < this.Height / 2) // Top right
                    {
                        np.X += 1;
                        np.Y -= 1;
                    }
                    else if (np.X < this.Width / 2 && np.Y > this.Height / 2) // Bottom left
                    {
                        np.X -= 1;
                        np.Y += 1;
                    }
                    else if (np.X > this.Width / 2 && np.Y > this.Height / 2) // Bottom right
                    {
                        np.X += 1;
                        np.Y += 1;
                    }
                    else // Everything else
                    {
                        np.X += 1;
                        np.Y += 1;
                    }

                    e.Graphics.FillEllipse(Brushes.Black, np.X, np.Y, 4, 4);

                    newPoints.Add(np);
                }
            }

            currentPoints = newPoints;
        }
    }
}
