using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invelitori_Convexe
{
    public class BruteForce
    {
        public static void AlgoritmulSlab(List<PointF> points, PaintEventArgs e)
        {
            for (int p = 0; p < points.Count - 1; p++)
            {
                for (int q = p + 1; q < points.Count; q++)
                {
                    bool valid = true;
                    int initSign = 0;
                    float coefA = points[q].Y - points[p].Y;
                    float coefB = points[p].X - points[q].X;
                    float coefC = points[p].X * points[q].Y - points[p].Y * points[q].X;
                    for (int r = 0; r < points.Count; r++)
                    {
                        //Testeaza daca r este la dreapta laturii
                        float pRegion = coefA * points[r].X + coefB * points[r].Y - coefC;
                        if (initSign != 0)
                        {
                            if (pRegion > 0 && initSign < 0)
                            {
                                valid = false;
                                break;
                            }
                            else if (pRegion < 0 && initSign > 0)
                            {
                                valid = false;
                                break;
                            }
                        }
                        else
                        {
                            if (pRegion > 0)
                            {
                                initSign = 1;
                            }
                            else if (pRegion < 0)
                            {
                                initSign = -1;
                            }
                        }                        
                    }
                    if (valid)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Red), points[p], points[q]);
                    }
                }
            }            
        }
    }
}
