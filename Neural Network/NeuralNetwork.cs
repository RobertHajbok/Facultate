using System;
using System.Collections.Generic;
using System.Linq;

namespace Neural_Network
{
    public class NeuralNetwork
    {
        private int numInput;
        private int numHidden;
        private int numOutput;
        private double[] inputs;
        private double[][] ihWeights;
        private double[] hBiases;
        private double[] hOutputs;
        private double[][] hoWeights;
        private double[] oBiases;
        private double[] outputs;

        private Random rnd;

        public NeuralNetwork(int numInput, int numHidden,
            int numOutput)
        {
            this.numInput = numInput;
            this.numHidden = numHidden;
            this.numOutput = numOutput;
            inputs = new double[numInput];
            ihWeights = MakeMatrix(numInput, numHidden);
            hBiases = new double[numHidden];
            hOutputs = new double[numHidden];
            hoWeights = MakeMatrix(numHidden, numOutput);
            oBiases = new double[numOutput];
            outputs = new double[numOutput];
            rnd = new Random(0);
        }

        private static double[][] MakeMatrix(int rows, int cols)
        {
            var result = new double[rows][];
            for (var r = 0; r < result.Length; ++r)
                result[r] = new double[cols];
            return result;
        }

        public void SetWeights(double[] weights)
        {
            var numWeights = (numInput * numHidden) +
                             (numHidden * numOutput) + numHidden + numOutput;
            if (weights.Length != numWeights)
                throw new Exception("Lungimea vectorului de greutati este gresita");

            var k = 0;

            for (var i = 0; i < numInput; ++i)
                for (var j = 0; j < numHidden; ++j)
                    ihWeights[i][j] = weights[k++];
            for (var i = 0; i < numHidden; ++i)
                hBiases[i] = weights[k++];
            for (var i = 0; i < numHidden; ++i)
                for (var j = 0; j < numOutput; ++j)
                    hoWeights[i][j] = weights[k++];
            for (var i = 0; i < numOutput; ++i)
                oBiases[i] = weights[k++];
        }

        public double[] ComputeOutputs(double[] xValues)
        {
            // mecanism "feed-forward" pentru clasificarea retelei neuronale
            if (xValues.Length != numInput)
                throw new Exception("Lungimea vectorului xValues este gresita");

            var hSums = new double[numHidden];
            var oSums = new double[numOutput];

            for (var i = 0; i < xValues.Length; ++i)
                inputs[i] = xValues[i];

            for (var j = 0; j < numHidden; ++j)
                for (var i = 0; i < numInput; ++i)
                    hSums[j] += inputs[i] * ihWeights[i][j];

            for (var i = 0; i < numHidden; ++i)
                hSums[i] += hBiases[i];

            for (var i = 0; i < numHidden; ++i)
                hOutputs[i] = HyperTanFunction(hSums[i]);

            for (var j = 0; j < numOutput; ++j)
                for (var i = 0; i < numHidden; ++i)
                    oSums[j] += hOutputs[i] * hoWeights[i][j];

            for (var i = 0; i < numOutput; ++i)
                oSums[i] += oBiases[i];

            var softOut = Softmax(oSums);
            Array.Copy(softOut, outputs, softOut.Length);

            var retResult = new double[numOutput];
            Array.Copy(outputs, retResult, retResult.Length);
            return retResult;
        }

        private static double HyperTanFunction(double x)
        {
            if (x < -20.0) return -1.0;
            return x > 20.0 ? 1.0 : Math.Tanh(x);
        }

        private static double[] Softmax(IReadOnlyList<double> oSums)
        {
            var max = oSums[0];
            max = oSums.Concat(new[] {max}).Max();

            // determine scaling factor
            var scale = oSums.Sum(t => Math.Exp(t - max));

            var result = new double[oSums.Count];
            for (var i = 0; i < oSums.Count; ++i)
                result[i] = Math.Exp(oSums[i] - max) / scale;

            return result; // scaled so xi sum to 1.0
        }

        public double[] Train(double[][] trainData,
            int popSize, int maxGeneration, double exitError,
            double mutateRate, double mutateChange, double tau)
        {
            // foloseste optimizarea evolutionara pentru formarea retelei neuronale

            var numWeights = (numInput * numHidden) +
                             (numHidden * numOutput) +
                             numHidden + numOutput; // = numGenes

            const double minX = -10.0;
            const double maxX = 10.0;
            
            // initializarea populatiei
            var population = new Individual[popSize];
            var bestSolution = new double[numWeights]; // luam oricare individ ca fiind cea mai buna solutie
            var bestError = double.MaxValue; // cu cat mai mic cu atat mai bine

            // !!!  PASUL 2: GENERAREA POPULATIEI INITIALE !!!
            for (var i = 0; i < population.Length; ++i)
            {
                population[i] = new Individual(numWeights, minX, maxX);
                // !!!  PASUL 3: CALCULAREA VALORII DE ADECVARE !!!
                var error = MeanSquaredError(trainData, population[i].chromosome);
                population[i].error = error;
                if (!(population[i].error < bestError)) continue;
                bestError = population[i].error;
                Array.Copy(population[i].chromosome, bestSolution, numWeights);
            }

            var gen = 0;
            var done = false;
            // !!!  PASUL 7: CRITERIUL DE OPRIRE !!!
            while (gen < maxGeneration && done == false)
            {
                // !!!  PASUL 4: MECANISMUL DE SELECTIE !!!
                var parents = Select(2, population, tau); // selectam doi indivizi buni
                // !!!  PASUL 5: OPERATORII GENETICI !!!
                var children = Reproduce(parents[0], parents[1], minX, maxX,
                    mutateRate, mutateChange); // cream 2 cromozomi
                children[0].error = MeanSquaredError(trainData, children[0].chromosome);
                children[1].error = MeanSquaredError(trainData, children[1].chromosome);

                // !!!  PASUL 6: INLOCUIREA !!!
                Place(children[0], children[1], population); // sortam populatia si inlocuim cei mai slabi doi indivizi

                // Emigrarea
                // Inlocuim al treilea cel mai rau individ cu un individ nou, presupunand ca populatia este sortata
                var immigrant = new Individual(numWeights, minX, maxX);
                immigrant.error = MeanSquaredError(trainData, immigrant.chromosome);
                population[population.Length - 3] = immigrant; // inlocuim al treilea cel mai rau individ

                for (var i = popSize - 3; i < popSize; ++i) // verificam cei trei indivizi noi
                {
                    if (!(population[i].error < bestError)) continue;
                    bestError = population[i].error;
                    population[i].chromosome.CopyTo(bestSolution, 0);
                    if (!(bestError < exitError)) continue;
                    done = true;
                    Console.WriteLine("\nEarly exit at generation " + gen);
                }
                ++gen;
            }
            return bestSolution;
        }

        // Metoda creeaza ordine aleatoare a indicilor populatiei si apoi selecteaza tau-% din acei indivizi aleatori. 
        // Indivizii selectati sunt sortati in functie de eroare, si primii n din acesti indivizi sunt returnati. 
        private Individual[] Select(int n, IReadOnlyList<Individual> population, double tau)
        {
            var popSize = population.Count;
            var indexes = new int[popSize];
            for (var i = 0; i < indexes.Length; ++i)
                indexes[i] = i;

            for (var i = 0; i < indexes.Length; ++i) // amestecam
            {
                var r = rnd.Next(i, indexes.Length);
                var tmp = indexes[r];
                indexes[r] = indexes[i];
                indexes[i] = tmp;
            }

            var tournSize = (int)(tau * popSize);
            if (tournSize < n) tournSize = n;
            var candidates = new Individual[tournSize];

            for (var i = 0; i < tournSize; ++i)
                candidates[i] = population[indexes[i]];
            Array.Sort(candidates);

            var results = new Individual[n];
            for (var i = 0; i < n; ++i)
                results[i] = candidates[i];

            return results;
        }

        // Functia de reproducere (intersectie si mutatie) care foloseste un singur punct de intersectie
        private Individual[] Reproduce(Individual parent1, Individual parent2,
            double minGene, double maxGene, double mutateRate, double mutateChange)
        {
            var numGenes = parent1.chromosome.Length;

            var cross = rnd.Next(0, numGenes - 1); // punctul de intersectie. 0 inseamna 'intre 0 si 1'.

            var child1 = new Individual(numGenes, minGene, maxGene); // cromozom aleator
            var child2 = new Individual(numGenes, minGene, maxGene);

            for (var i = 0; i <= cross; ++i)
                child1.chromosome[i] = parent1.chromosome[i];
            for (var i = cross + 1; i < numGenes; ++i)
                child2.chromosome[i] = parent1.chromosome[i];
            for (var i = 0; i <= cross; ++i)
                child2.chromosome[i] = parent2.chromosome[i];
            for (var i = cross + 1; i < numGenes; ++i)
                child1.chromosome[i] = parent2.chromosome[i];

            Mutate(child1, maxGene, mutateRate, mutateChange);
            Mutate(child2, maxGene, mutateRate, mutateChange);

            var result = new Individual[2];
            result[0] = child1;
            result[1] = child2;

            return result;
        }

        // Functia de mutatie, care este apelata din functia de reproducere
        private void Mutate(Individual child, double maxGene, double mutateRate,
            double mutateChange)
        {
            var hi = mutateChange * maxGene;
            var lo = -hi;
            for (var i = 0; i < child.chromosome.Length; ++i)
            {
                if (!(rnd.NextDouble() < mutateRate)) continue;
                var delta = (hi - lo) * rnd.NextDouble() + lo;
                child.chromosome[i] += delta;
            }
        }

        // Functia de inlocuire a celor mai slabi doi indivizi
        private static void Place(Individual child1, Individual child2,
            Individual[] population)
        {
            // adauga child1 si child2 inlocuind cei mai slabi doi indivizi
            var popSize = population.Length;
            Array.Sort(population);
            population[popSize - 1] = child1;
            population[popSize - 2] = child2;
        }

        // Masoara cat de departe este solutia de solutia dorita (gaseste cei mai buni cromozomi)
        private double MeanSquaredError(IReadOnlyList<double[]> trainData,
            double[] weights)
        {
            SetWeights(weights);

            var xValues = new double[numInput];
            var tValues = new double[numOutput];
            var sumSquaredError = 0.0;
            for (var i = 0; i < trainData.Count; ++i)
            {
                Array.Copy(trainData[i], xValues, numInput);
                Array.Copy(trainData[i], numInput, tValues, 0,
                    numOutput);
                var yValues = ComputeOutputs(xValues);
                for (var j = 0; j < yValues.Length; ++j)
                    sumSquaredError += ((yValues[j] - tValues[j]) *
                                        (yValues[j] - tValues[j]));
            }
            return sumSquaredError / trainData.Count;
        }

        // Procentajul clasificarilor corecte
        public double Accuracy(double[][] testData)
        {
            var numCorrect = 0;
            var numWrong = 0;
            var xValues = new double[numInput];
            var tValues = new double[numOutput];
            double[] yValues;

            for (var i = 0; i < testData.Length; ++i)
            {
                Array.Copy(testData[i], xValues, numInput);
                Array.Copy(testData[i], numInput, tValues, 0,
                    numOutput);
                yValues = ComputeOutputs(xValues);

                var maxIndex = MaxIndex(yValues);

                if (tValues[maxIndex] == 1.0)
                    ++numCorrect;
                else
                    ++numWrong;
            }
            return (numCorrect * 1.0) / (numCorrect + numWrong);
        }

        // Functia ajutatoare pentru stabilirarea celui mai mare index
        private static int MaxIndex(IReadOnlyList<double> vector)
        {
            var bigIndex = 0;
            var biggestVal = vector[0];
            for (var i = 0; i < vector.Count; ++i)
            {
                if (!(vector[i] > biggestVal)) continue;
                biggestVal = vector[i];
                bigIndex = i;
            }
            return bigIndex;
        }
    }
}
