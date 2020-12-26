using System;

namespace Neural_Network
{
    public class Individual : IComparable<Individual>
    {
        public double[] chromosome; // potentiala solutie
        public double error; // marja de eroare, cu cat mai mica cu atat mai bine

        static Random rnd = new Random(0); // folosit de constructor pentru a crea gene aleatoare

        public Individual(int numGenes, double minGene, double maxGene)
        {
            chromosome = new double[numGenes];
            for (var i = 0; i < chromosome.Length; ++i)
                chromosome[i] = (maxGene - minGene) * rnd.NextDouble() + minGene;
        }

        public int CompareTo(Individual other) // de la cea mai mica eroare la cea mai mare
        {
            if (error < other.error) return -1;
            return error > other.error ? 1 : 0;
        }
    }
}
