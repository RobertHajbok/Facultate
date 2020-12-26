using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);

            int w = this.Size.Width - 16;
            int h = this.Size.Height - 38;

            // Diagonalele
            e.Graphics.DrawLines(p, new Point[] { new Point(0, 0), new Point(w, h), new Point(w, 0), new Point(0, h) });

            // Cerc
            e.Graphics.DrawEllipse(p, new Rectangle(0, 0, w, h));

            // Elipsa
            e.Graphics.FillEllipse(Brushes.DarkGreen, new Rectangle(w / 2 - 80, h / 2 - 40, 160, 80));

            // Romb
            e.Graphics.DrawLines(p, new Point[] { new Point(w / 2, 0), new Point(w, h / 2), new Point(w / 2, h), new Point(0, h / 2), new Point(w / 2, 0) });

            // Dreptunghi
            e.Graphics.FillRectangle(Brushes.Blue, 0, h - 40, 80, 40);

            // Stea
            e.Graphics.FillPolygon(Brushes.Red, Calculate5StarPoints(new PointF(w - 40, h - 40), 40, 20), System.Drawing.Drawing2D.FillMode.Alternate);
        }

        private PointF[] Calculate5StarPoints(PointF Orig, float outerradius, float innerradius)
        {
            // Define some variables to avoid as much calculations as possible
            // conversions to radians
            double Ang36 = Math.PI / 5.0; // 36° x PI/180
            double Ang72 = 2.0 * Ang36; // 72° x PI/180
            // some sine and cosine values we need
            float Sin36 = (float)Math.Sin(Ang36);
            float Sin72 = (float)Math.Sin(Ang72);
            float Cos36 = (float)Math.Cos(Ang36);
            float Cos72 = (float)Math.Cos(Ang72);
            // Fill array with 10 origin points
            PointF[] pnts = { Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig };
            pnts[0].Y -= outerradius; // top off the star, or on a clock this is 12:00 or 0:00 hours
            pnts[1].X += innerradius * Sin36; pnts[1].Y -= innerradius * Cos36; // 0:06 hours
            pnts[2].X += outerradius * Sin72; pnts[2].Y -= outerradius * Cos72; // 0:12 hours
            pnts[3].X += innerradius * Sin72; pnts[3].Y += innerradius * Cos72; // 0:18
            pnts[4].X += outerradius * Sin36; pnts[4].Y += outerradius * Cos36; // 0:24
            // Phew! Glad I got that trig working.
            pnts[5].Y += innerradius;
            // I use the symmetry of the star figure here
            pnts[6].X += pnts[6].X - pnts[4].X; pnts[6].Y = pnts[4].Y; // mirror point
            pnts[7].X += pnts[7].X - pnts[3].X; pnts[7].Y = pnts[3].Y; // mirror point
            pnts[8].X += pnts[8].X - pnts[2].X; pnts[8].Y = pnts[2].Y; // mirror point
            pnts[9].X += pnts[9].X - pnts[1].X; pnts[9].Y = pnts[1].Y; // mirror point
            return pnts;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
