using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Spanzuratoare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string cuv = "";
        List<Label> labels = new List<Label>();
        int nr = 0;

        enum PartiCorp
        {
            Cap,
            Ochi_st,
            Ochi_dr,
            Gura,
            Mana_st,
            Mana_dr,
            Corp,
            Picior_st,
            Picior_dr
        }

        void Spanzuratoare()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(130, 218), new Point(130, 5));
            g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            g.DrawLine(p, new Point(60, 0), new Point(60, 50));
            Labels();
        }

        void Deseneaza(PartiCorp pc)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 3);
            if (pc == PartiCorp.Cap)
            {
                g.DrawEllipse(p, 40, 50, 40, 40);
            }
            else if (pc == PartiCorp.Ochi_st)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 50, 60, 5, 5);
            }
            else if (pc == PartiCorp.Ochi_dr)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 63, 60, 5, 5);
            }
            else if (pc == PartiCorp.Gura)
            {
                g.DrawArc(p, 50, 60, 20, 20, 45, 90);
            }
            else if (pc == PartiCorp.Corp)
            {
                g.DrawLine(p, new Point(60, 90), new Point(60, 170));
            }
            else if (pc == PartiCorp.Mana_st)
            {
                g.DrawLine(p, new Point(60, 100), new Point(30, 85));
            }
            else if (pc == PartiCorp.Mana_dr)
            {
                g.DrawLine(p, new Point(60, 100), new Point(90, 85));
            }
            else if (pc == PartiCorp.Picior_st)
            {
                g.DrawLine(p, new Point(60, 170), new Point(30, 190));
            }
            else if (pc == PartiCorp.Picior_dr)
            {
                g.DrawLine(p, new Point(60, 170), new Point(90, 190));
            }
        }

        String GenereazaCuvant()
        {
            WebClient web = new WebClient();
            string listaCuv = web.DownloadString("http://dictionary-thesaurus.com/wordlists/Animals%2865%29.txt");
            string[] cuvinte = listaCuv.Split('\n');
            Random r = new Random();
            return cuvinte[r.Next(0, cuvinte.Length - 1)].ToLower();
        }

        void Labels()
        {
            cuv = GenereazaCuvant();
            char[] chars = cuv.ToCharArray();
            int intre = 330 / chars.Length - 1;
            for (int i = 0; i < chars.Length - 1; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * intre) + 10, 80);
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
                label1.Text = "Lungimea Cuvantului: " + (chars.Length - 1).ToString();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Spanzuratoare();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                char litera = textBox1.Text.ToLower().ToCharArray()[0];
                if (!char.IsLetter(litera))
                {
                    MessageBox.Show("Puteti introduce doar litere!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (cuv.Contains(litera))
                {
                    char[] litere = cuv.ToCharArray();
                    for (int i = 0; i < litere.Length; i++)
                    {
                        if (litere[i] == litera)
                        {
                            labels[i].Text = litera.ToString();
                        }
                    }
                    foreach (Label l in labels)
                        if (l.Text == "_")
                        {
                            return;
                        }
                    MessageBox.Show("Ati castigat!", "Congrats");
                    ReseteazaJocul();
                }
                else
                {
                    label2.Text += " " + litera.ToString() + ",";
                    Deseneaza((PartiCorp)nr);
                    nr++;
                    if (nr == 9)
                    {
                        MessageBox.Show("Ne pare rau, ati pierdut! Cuvantul este " + cuv);
                        ReseteazaJocul();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        void ReseteazaJocul()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            GenereazaCuvant();
            Labels();
            Spanzuratoare();
            label2.Text = "Ratari: ";
            textBox1.Text = "";
            nr = 0;
        }
    }
}
