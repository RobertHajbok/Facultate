using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Drawing;

namespace Particule
{
    static class Generator
    {
        public static List<Particle> Particles = new List<Particle>();
        public static int birthRate = 6;
        public static int birthInterval = 1000;
        public static int lifeSpan = 5000;
        public static int radius = 100;
        public static Random rand = new Random();
        public static DateTime startTime;
        public static Timer timer = new Timer(500);

        public static void Start()
        {
            startTime = DateTime.Now;
            timer.Elapsed += new ElapsedEventHandler(UpdateParticles);

            int r = rand.Next(1, birthRate);
            for (int i = 0; i < r; i++)
            {
                Particle part = new Particle();
                part.BirthTime = startTime;
                part.Coords.X = rand.Next(20, ParticlesForm.particlesBox.Width - 40);
                part.Coords.Y = rand.Next(20, ParticlesForm.particlesBox.Height - 40);

                Console.WriteLine("Particle born (X:{0}, Y:{1})", part.Coords.X, part.Coords.Y);

                Particles.Add(part);
            }

            timer.Start();
        }

        static void UpdateParticles(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            List<Particle> oldParticles = Particles.ToList();

            foreach (Particle particle in oldParticles)
            {
                if (now.Subtract(particle.BirthTime).TotalMilliseconds >= lifeSpan)
                {
                    Console.WriteLine("Particle died (X:{0}, Y:{1})", particle.Coords.X, particle.Coords.Y);

                    Particles.Remove(particle);
                }
                else if (now.Subtract(startTime).TotalMilliseconds >= birthInterval)
                {
                    Console.WriteLine("Particle spawns children (X:{0}, Y:{1})", particle.Coords.X, particle.Coords.Y);
                    int r = rand.Next(1, birthRate);
                    for (int i = 0; i < r; i++)
                    {
                        Particle part = new Particle();
                        part.BirthTime = DateTime.Now;

                        int tempXMin = (int)(particle.Coords.X - radius / 2);
                        if (tempXMin < 20)
                        {
                            tempXMin = 20;
                        }
                        int tempXMax = (int)(particle.Coords.X + radius / 2);
                        if (tempXMin > (ParticlesForm.particlesBox.Width - 40))
                        {
                            tempXMin = (ParticlesForm.particlesBox.Width - 40);
                        }

                        int tempYMin = (int)(particle.Coords.Y - radius / 2);
                        if (tempYMin < 20)
                        {
                            tempXMin = 20;
                        }
                        int tempYMax = (int)(particle.Coords.Y + radius / 2);
                        if (tempYMin > (ParticlesForm.particlesBox.Height - 40))
                        {
                            tempYMin = (ParticlesForm.particlesBox.Height - 40);
                        }

                        part.Coords.X = rand.Next(tempXMin, tempXMax);
                        part.Coords.Y = rand.Next(tempYMin, tempYMax);

                        Console.WriteLine("     Particle born (X:{0}, Y:{1})", part.Coords.X, part.Coords.Y);

                        Particles.Add(part);
                    }

                    startTime = now;
                }
            }

            ParticlesForm.DrawParticles();
        }
    }
}
