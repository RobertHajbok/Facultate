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
    enum Tools { Line, Rectangle}
    
    public partial class Form1 : Form
    {
        Tools tool = Tools.Line;
        Color color = Color.Black;
        int lineThickness = 4;
        private Point p1, p2;
        List<Shape> shapes = new List<Shape>();
        public Form1()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in shapes)
            {
                item.Draw(e.Graphics);
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = Tools.Line;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = Tools.Rectangle;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = colorDialog.ShowDialog();
            if (ret == DialogResult.OK)
                color = colorDialog.Color;
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            p1 = e.Location;
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            p2 = e.Location;
            switch (tool)
            {
                case Tools.Line:
                    shapes.Add(new Segment(p1, p2, color, lineThickness));
                    break;
                case Tools.Rectangle:
                    shapes.Add(new Dreptunghi(p1, p2, color, lineThickness));
                    break;
                default:
                    break;
            }
            panel.Invalidate();
        }

        private void lineThicknessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LineThicknessDialog lineThicknessDialog = new LineThicknessDialog(lineThickness);
            if (lineThicknessDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lineThickness = lineThicknessDialog.LineThickness;
            }
        }
    }
}
