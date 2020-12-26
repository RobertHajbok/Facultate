using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanoi_Grafic
{
    public partial class Form1 : Form
    {
        List<Disk>[] allStands;
        List<Disk> Stand1plates = new List<Disk>();
        List<Disk> Stand2plates = new List<Disk>();
        List<Disk> Stand3plates = new List<Disk>();

        Form2 fnext = new Form2();

        public Form1()
        {
            InitializeComponent();
            allStands = new List<Disk>[] { Stand1plates, Stand2plates, Stand3plates };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Maroon);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(10, 500, 675, 15));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            numericUpDown1.Enabled = false;
            button1.Enabled = false;
            solution.Text = "Solution:";

            //Clear stands
            Stand1plates.Clear();
            Stand2plates.Clear();
            Stand3plates.Clear();

            Random rnd = new Random();

            for (int i = (int)numericUpDown1.Value; i > 0; i--)
            {
                int red = rnd.Next(1, 256);
                int green = rnd.Next(1, 256);
                int blue = rnd.Next(1, 256);
                Disk plt = new Disk(i, Color.FromArgb(red, green, blue));
                
                Stand1plates.Add(plt);
            }

            RedrawPanels();

            fnext.Location = new Point(this.Location.X + 400, this.Location.Y + 42);
            fnext.ShowDialog();
            SolveTowers((int)numericUpDown1.Value, 1, 2, 3);

            numericUpDown1.Enabled = true;
            button1.Enabled = true;
        }

        void SolveTowers(int count, int source, int dest, int inter)
        {
            if (count == 1)
            {
                MoveFromTo(source, dest);
                {
                    solution.Text += "\n " + source.ToString() + " -> " + dest.ToString();
                    solution.SelectionStart = solution.Text.Length;
                    solution.ScrollToCaret();
                    fnext.Location = new Point(this.Location.X + 400, this.Location.Y + 42);
                    fnext.ShowDialog();
                }
            }

            else
            {
                SolveTowers(count - 1, source, inter, dest);
                SolveTowers(1, source, dest, inter);
                SolveTowers(count - 1, inter, dest, source);
            }
        }

        private void MoveFromTo(int source, int dest)
        {
            Disk top = allStands[source - 1][allStands[source - 1].Count - 1];
            allStands[source - 1].Remove(top);
            allStands[dest - 1].Add(top);

            RedrawPanels();
        }

        private void RedrawPanels()
        {
            panel1.Invalidate();
            panel2.Invalidate();
            panel3.Invalidate();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            Graphics pnlGraphix = e.Graphics;
            DrawTheStand(pnlGraphix, p);            
            DrawPlates(pnlGraphix, p, p.TabIndex);
        }

        private void DrawTheStand(Graphics graphics, Panel p)
        {
            graphics.FillRectangle(new SolidBrush(Color.Maroon), new Rectangle(p.Width/2, p.Width/2, 20, p.Height - 20));
        }

        private void DrawPlates(Graphics graphics, Panel p, int StandNo)
        {
            if (Stand1plates == null) return;
            Stand1plates.OrderBy(i => i.PlateNo);
            //Stand1plates.Reverse();

            switch (StandNo)
            {
                case 11:
                    DrawStandPlates(graphics, Stand1plates, p); break;
                case 12:
                    DrawStandPlates(graphics, Stand2plates, p); break;
                case 13:
                    DrawStandPlates(graphics, Stand3plates, p); break;
            }
        }

        private void DrawStandPlates(Graphics graphics, List<Disk> plates, Panel p)
        {
            int i = 0;
            foreach (Disk plateNo in plates)
            {
                i++;
                graphics.FillRectangle(new SolidBrush(plateNo.Color), new Rectangle(p.Width / 2 - (plateNo.PlateNo * 16) / 2, p.Height - i * 20, plateNo.PlateNo * 16 + 15, 20));
                graphics.DrawString(plateNo.PlateNo.ToString(), new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold), Brushes.Black, new Rectangle(p.Width / 2, p.Height - i * 20, plateNo.PlateNo * 30, 20));
            }
        }
    }
}
