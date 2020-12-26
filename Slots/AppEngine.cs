using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Slots
{
    public static class AppEngine
    {
        public static int Credit;
        public static int Bet;
        public static int BetTotal;
        public static int Lines;
        public static int Win;
        public static int[,] matrix = new int[5, 3];
        public static Random random = new Random();
        public static Label[,] labels;

        public static int maxLines = 9;
        public static int maxBet = 5;

        public static void initLabels(Panel display)
        {
            labels = new Label[5, 3];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    labels[i, j] = new Label();
                    labels[i, j].Parent = display;
                    labels[i, j].Location = new Point(10 + i * 50, 20 + j * 40);
                    labels[i, j].Size = new Size(32, 32);
                    //labels[i, j].BorderStyle = BorderStyle.FixedSingle;
                    labels[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    //labels[i, j].Text = i.ToString() + j.ToString();
                }
            }
        }
    }
}
