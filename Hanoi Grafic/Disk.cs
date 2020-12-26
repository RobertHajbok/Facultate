using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi_Grafic
{
    class Disk
    {
        private int plateNo;
        private Color color;

        public Disk(int plateNo, Color color)
        {
            this.plateNo = plateNo;
            this.color = color;
        }

        public int PlateNo
        {
            get { return plateNo; }
        }

        public Color Color
        {
            get { return color; }
        }
    }
}
