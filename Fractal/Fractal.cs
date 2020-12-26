using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestImageCreation
{
    public class EscapeTimeFractal
    {
        private int maxIteration = 255;
        private Bitmap b;
        private double minX = -1.0, maxX = 1.0, minY = -1.0, maxY = 1.0;

        private string outputFileName;

        public string OutputFileName
        {
            get { return outputFileName; }
            set { outputFileName = value; }
        }

        public int MaxIteration
        {
            get { return maxIteration; }
            set { maxIteration = value; }
        }
        public double MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }

        public double MinY
        {
            get { return minY; }
            set { minY = value; }
        }

        public double MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }

        public double MinX
        {
            get { return minX; }
            set { minX = value; }
        }

        private Func<Complex, Func<Complex, Complex>> functionConstructor;

        public EscapeTimeFractal(int width, int height)
        {
            b = new Bitmap(width, height);
            this.functionConstructor =
                p0 => (c => c.Multiply(c).Add(p0)); // Use Mandelbrot formula by default

        }
        public EscapeTimeFractal(int width, int height, Func<Complex, Func<Complex, Complex>> functionConstructor)
        {
            b = new Bitmap(width, height);
            this.functionConstructor = functionConstructor;
        }

        IEnumerable<Complex> ApplyFunction(Func<Complex, Complex> function, Complex initial)
        {

            Complex last = initial;
            while (true)
            {
                last = function(last);
                yield return last;
            }
        }

        void CreateFractal(double minX, double minY, double maxX, double maxY, int imageWidth, int imageHeight)
        {
            Func<double, double> xF = MathUtils.InterpFunc(0, minX, imageWidth, maxX);
            Func<double, double> yF = MathUtils.InterpFunc(0, minY, imageHeight, maxY);

            foreach (var p in from yi in Enumerable.Range(0, imageHeight)
                              from xi in Enumerable.Range(0, imageWidth)
                              select new
                              {
                                  x = xi,
                                  y = yi,
                                  xD = xF(xi),
                                  yD = yF(yi)
                              })
            {

                Complex p0 = new Complex(p.xD, p.yD);
                Func<Complex, Complex> function = functionConstructor(p0);

                int i = ApplyFunction(function, p0)
                          .TakeWhile(
                             (x, j) => j < maxIteration && x.NormSquared() < 4.0)
                          .Count();

                HandlePixel(p.x, p.y, i);
            }

        }
        void MandelbrotCS(double minX, double minY, double maxX, double maxY, int imageWidth, int imageHeight)
        {
            Func<double, double> xF = MathUtils.InterpFunc(0, minX, imageWidth, maxX);
            Func<double, double> yF = MathUtils.InterpFunc(0, minY, imageHeight, maxY);

            foreach (var pY in from v in Enumerable.Range(0, imageHeight)
                               select new { y = v, yD = yF(v) })
            {
                foreach (var pX in from v in Enumerable.Range(0, imageWidth)
                                   select new { x = v, xD = xF(v) })
                {

                    Complex p0 = new Complex(pX.xD, pY.yD);
                    Complex p = p0;
                    int maxIteration = 255 * 3;
                    int i = 0;
                    while (p.NormSquared() < 4.0 && i < maxIteration)
                    {
                        p = p.Multiply(p).Add(p0);
                        i++;
                    }
                    //HandlePixel(pX.x, pY.y, (int)(i + 1 - Math.Log(p.Norm()) / Math.Log(2)));
                    HandlePixel(pX.x, pY.y, i);
                }
            }

        }

        private void HandlePixel(int x, int y, int idx)
        {
            b.SetPixel(x, y, GetColor(idx));
        }

        private Color GetColor(int idx)
        {

            //return Color.FromArgb(255 - Math.Abs((idx * 2 % 128)), 255 - Math.Abs((idx * 2 % 128)), 255);
            //return Color.FromArgb(255 - Math.Abs((idx / 2 % 128)), 255 - Math.Abs((idx / 2 % 128)), 255);
            if (idx == MaxIteration) return Color.Black;

            return Color.FromArgb(((MaxIteration - idx) % 16) * 15, 5 * (idx % 32), ((MaxIteration - idx) % 64) * 2);

        }


        public void Run()
        {
            CreateFractal(minX, minY, maxX, maxY, b.Width, b.Height);
        }
        public void Save()
        {
            b.Save(outputFileName);
        }
    }
}
