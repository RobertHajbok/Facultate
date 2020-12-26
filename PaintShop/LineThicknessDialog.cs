using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintShop
{
    public partial class LineThicknessDialog : Form
    {
        private int lineThickness;
        public int LineThickness
        {
            get
            {
                return lineThickness;
            }
        }

        public LineThicknessDialog(int lineThickness)
        {
            InitializeComponent();

            this.lineThickness = lineThickness;
            trkThickness.Value = lineThickness;
            numThickness.Value = lineThickness;
        }

        private void trkThickness_Scroll(object sender, EventArgs e)
        {
            lineThickness = trkThickness.Value;
            numThickness.Value = lineThickness;
        }

        private void numThickness_ValueChanged(object sender, EventArgs e)
        {
            lineThickness = (int)numThickness.Value;
            trkThickness.Value = lineThickness;
        }
    }
}
