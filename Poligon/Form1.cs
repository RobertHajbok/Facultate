using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Poligon
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics = Graphics.FromImage(bitmap);
            pen = new Pen(Color.Black, 1);

            pictureBox1.Image = bitmap;

            List<PointF> puncte = new List<PointF>();

            // Citire din fisier
            TextReader reader = new StreamReader("D:\\Programare\\C#\\Poligon\\puncte.txt");
            String linie;

            while ((linie = reader.ReadLine()) != null)
            {
                PointF punct = new PointF();
                String[] valori = linie.Split(',');

                punct.X = float.Parse(valori[0]);
                punct.Y = float.Parse(valori[1]);

                puncte.Add(punct);
            }
            reader.Close();

            CalculeazaPoligon(puncte);
        }

        private void CalculeazaPoligon(List<PointF> puncte)
        {
            double perimetrul = CalculeazaPerimetrul(puncte);
            if (perimetrul < 1) { return; }

            Console.WriteLine("Perimetrul = {0}", perimetrul);

            List<PointF> puncteNoi = new List<PointF>();

            PointF punctulDeStart = puncte[0];
            PointF punct = new PointF();
            for (int i = 1; i < puncte.Count; i++)
            {
                Console.WriteLine("{0} , {1}", punctulDeStart.X, punctulDeStart.Y);

                punct = puncte[i];
                PointF punctFinal = new PointF();

                punctFinal.X = (punctulDeStart.X + punct.X) / 2;
                punctFinal.Y = (punctulDeStart.Y + punct.Y) / 2;

                puncteNoi.Add(punctFinal);
                punctulDeStart = punct;
            }

            PointF ultimulPunct = new PointF();
            ultimulPunct.X = (puncte[0].X + punct.X) / 2;
            ultimulPunct.Y = (puncte[0].Y + punct.Y) / 2;
            puncteNoi.Add(ultimulPunct);

            Console.WriteLine("");

            DeseneazaPoligon(puncte);
            CalculeazaPoligon(puncteNoi);
        }

        private void DeseneazaPoligon(List<PointF> puncte)
        {
            //graphics.Clear(Color.Transparent);

            PointF punctulDeStart = puncte[0];
            foreach (PointF punct in puncte)
            {
                graphics.DrawLine(pen, punctulDeStart, punct);

                punctulDeStart = punct;
            }

            graphics.DrawLine(pen, punctulDeStart, puncte[0]);

            pictureBox1.Image = bitmap;
        }

        private double CalculeazaPerimetrul(List<PointF> puncte)
        {
            double perimetrul = 0;

            PointF punctulDeStart = puncte[0];
            PointF punct = new PointF();
            for (int i = 1; i < puncte.Count; i++)
            {
                punct = puncte[i];

                perimetrul += Math.Sqrt((punctulDeStart.X - punct.X) * (punctulDeStart.X - punct.X) + (punctulDeStart.Y - punct.Y) * (punctulDeStart.Y - punct.Y));
                punctulDeStart = punct;
            }

            perimetrul += Math.Sqrt((puncte[0].X - punct.X) * (puncte[0].X - punct.X) + (puncte[0].Y - punct.Y) * (puncte[0].Y - punct.Y));

            return perimetrul;
        }
    }
}
