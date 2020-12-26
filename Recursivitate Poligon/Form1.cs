using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Recursivitate_Poligon
{
    public partial class Form1 : Form
    {
       public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var rnd = new Random();
            const int nrPuncte = 4;

            var puncte = new Point[nrPuncte];

            for (var i = 0; i < nrPuncte; i++)
            {
                puncte[i].X = rnd.Next(1, 450);
                puncte[i].Y = rnd.Next(1, 450);
            }

            var g = e.Graphics;

            DeseneazaPoligoane(puncte, g);
        }

        private static void DeseneazaPoligoane(IList<Point> puncte, Graphics g)
        {
            var gasit = true;
            for (var i = 0; i < puncte.Count - 1; i++)
                if (puncte[i].X != puncte[i + 1].X || puncte[i].Y != puncte[i + 1].Y)
                    gasit = false;
            if (gasit)
                g.DrawEllipse(new Pen(Color.Red), puncte[0].X, puncte[0].Y, 3, 3);
            else
            {
                var poligonAux = new Point[puncte.Count];
                for (var i = 0; i < puncte.Count - 1; i++)
                {
                    poligonAux[i].X = (puncte[i].X + puncte[i + 1].X)/2;
                    poligonAux[i].Y = (puncte[i].Y + puncte[i + 1].Y) / 2;
                    g.DrawLine(new Pen(Color.Black), puncte[i], puncte[i+1]);
                }
                poligonAux[puncte.Count - 1].X = (puncte[puncte.Count - 1].X + puncte[0].X)/2;
                poligonAux[puncte.Count - 1].Y = (puncte[puncte.Count - 1].Y + puncte[0].Y)/2;
                g.DrawLine(new Pen(Color.Black), puncte[puncte.Count - 1], puncte[0]);
                Thread.Sleep(300);

                DeseneazaPoligoane(poligonAux, g);
            }
        }
    }
}
