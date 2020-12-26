using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractali_triunghiuri
{
    public partial class Form1 : Form
    {
        Random _randomiser = new Random();
        private Point[] points;
        private Point currentLocation;

        public Form1()
        {
            InitializeComponent();
        }

        private double HeightWidthRatio()
        {
            return Math.Sqrt(3) / 2;
        }

        private int SideLength()
        {
            int height = (int)Math.Min(
                (double)ClientSize.Width, ClientSize.Height / HeightWidthRatio());
            return (int)height - 2;
        }

        private void SetPointLocations(int sideLength)
        {
            Point midPoint = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            points = new Point[3];
            points[0] = new Point(midPoint.X,
                midPoint.Y - (int)(sideLength * HeightWidthRatio() / 2));
            points[1] = new Point(midPoint.X - sideLength / 2,
                midPoint.Y + (int)(sideLength * HeightWidthRatio() / 2));
            points[2] = new Point(midPoint.X + sideLength / 2,
                midPoint.Y + (int)(sideLength * HeightWidthRatio() / 2));
        }

        private void PlotPointLocations(Graphics g)
        {
            foreach (Point p in points)
            {
                PlotPoint(p, g);
            }
        }

        private void PlotPoint(Point p, Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, p.X, p.Y, 1, 1);
        }

        private void DrawNextPoint(Graphics g)
        {
            MoveTowardsRandomPoint();
            PlotPoint(currentLocation, g);
            Application.DoEvents();
        }

        private void MoveTowardsRandomPoint()
        {
            int moveTowards = _randomiser.Next(0, 3);
            currentLocation.X = (currentLocation.X + points[moveTowards].X) / 2;
            currentLocation.Y = (currentLocation.Y + points[moveTowards].Y) / 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            int sideLength = SideLength();
            SetPointLocations(sideLength);
            PlotPointLocations(g);
            currentLocation = new Point(points[0].X, points[0].Y);

            while (true)
            {
                DrawNextPoint(g);
            }
        }
    }
}
