using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc_Memorie
{
    public partial class Form1 : Form
    {
        byte bt = 0;
        PictureBox pb;
        byte perechiRamase = 8;
        byte time = 60;

        public Form1()
        {
            InitializeComponent();
        }

        void Initializare()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Properties.Resources._0;
                }
            }
        }

        void TagInitial()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Tag = "_0";
                }
            }
        }

        void Cartonase()
        {
            int[] imagini = new int[16];
            Random r = new Random();
            byte b = 0, i = 0;            

            while (i < 16)
            {
                int n = r.Next(1, 17);
                if (Array.IndexOf(imagini, n) == -1)
                {
                    imagini[i] = n;
                    i++;
                }
            }

            for (i = 0; i < 16; i++)
            {
                if (imagini[i] > 8)
                {
                    imagini[i] -= 8;
                }
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Tag = imagini[b].ToString();
                    b++;
                }
            }
        }

        void Perechi(PictureBox a, PictureBox b)
        {
            if (a.Tag.ToString() == b.Tag.ToString())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                a.Visible = false;
                b.Visible = false;                
                perechiRamase--;
                if (perechiRamase == 0)
                {
                    label2.Text = "Perechi ramase : 0";
                    timer1.Enabled = false;
                    MessageBox.Show("Felicitari! Ati castigat!");
                }
                else
                {
                    label2.Text = "Perechi ramase : " + perechiRamase;
                }
            }
            else
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                a.Image = Image.FromFile("0.png");
                b.Image = Image.FromFile("0.png");                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initializare();
            TagInitial();
            Cartonase();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pict = (sender as PictureBox);
            pict.Image = Image.FromFile((sender as PictureBox).Tag.ToString() + ".png");
            if (bt == 0)
            {
                pb = pict;
                bt++;
            }
            else if (pb == pict)
            {
                MessageBox.Show("Ati selectat deja aceasta imagine");
                bt = 0;
                pb.Image = Image.FromFile("0.png");
            }
            else
            {
                Perechi(pb, pict);
                bt = 0;
            }
        }

        void VeziSolutia()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Image.FromFile(x.Tag.ToString() + ".png");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VeziSolutia();
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Image.FromFile("0.png");
                }
            }
            bt = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Initializare();
            TagInitial();
            Cartonase();
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Visible = true;
                }
            }

            time = 60;
            timer1.Enabled = true;

            perechiRamase = 8;
            label2.Text = "Perechi ramase : " + perechiRamase;
            bt = 0;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time -= 1;
            label1.Text = "Timp : " + time;
            if (time == 0)              
            {
                timer1.Enabled = false;
                MessageBox.Show("Ne pare rau! Timpul a expirat!");                
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox)
                    {
                        (x as PictureBox).Enabled = false;
                    }
                }
            }
        }
    }
}
