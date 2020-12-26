using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Particule
{
    public partial class ParticlesForm : Form
    {
        public static Graphics graphics;
        public static Bitmap bitmap;
        public static Pen particlePen = new Pen(Color.Black, 2);
        public static Pen radiusPen = new Pen(Color.LightGray, 1);
        public static PictureBox particlesBox;

        public ParticlesForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics = Graphics.FromImage(bitmap);

            particlesBox = pictureBox1;

            graphics.Clear(Color.White);

            Generator.Start();
        }

        public static void DrawParticles()
        {
            graphics.Clear(Color.White);

            foreach (Particle particle in Generator.Particles)
            {
                graphics.DrawEllipse(particlePen, particle.Coords.X - 1, particle.Coords.Y - 1, 2, 2);
                graphics.DrawEllipse(radiusPen, particle.Coords.X - (Generator.radius / 2), particle.Coords.Y - (Generator.radius / 2), Generator.radius, Generator.radius);
            }

            particlesBox.Image = bitmap;
        }
    }
}
