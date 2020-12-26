using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestImageCreation
{
    class Program
    {

        static void Main(string[] args)
        {

            /*
            EscapeTimeFractal p = new EscapeTimeFractal(300, 300);
            p.MinX = -0.03;
            p.MinY = 0.68;
            p.MaxX = 0.03;
            p.MaxY = 0.62;
            
            p.Run();
            p.Save();*/

            Func<Complex, Func<Complex, Complex>> fc =
                  p0 =>
                    (c => (new Complex(
                              ((c.Img * c.Img) - Math.Sqrt(Math.Abs(c.Real))),
                              ((c.Real * c.Real) - Math.Sqrt(Math.Abs(c.Img)))))
                           + p0);

            EscapeTimeFractal p = new EscapeTimeFractal(300, 300, fc);
            p.MinX = -2;
            p.MinY = 2;
            p.MaxX = 2;
            p.MaxY = -2;
            p.MaxIteration = 127;
            p.OutputFileName = @"D:\Programare\C#\Fractal\output.bmp";

            p.Run();
            p.Save();

        }
    }
}
