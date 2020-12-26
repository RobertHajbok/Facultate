using System;
using System.Collections.Generic;

namespace Neural_Network
{
    internal class Program
    {
        private static void Main()
        {
            // Formarea unei retele neuronale este procesul de a gasi un set de valori de greutate numerice astfel incat, pentru un 
            // anumit set de date cu valori de intrare si iesire cunoscute, valorile de iesire calculate retelei se potrivesc indeaproape 
            // valorilor de ieșire cunoscute. Dupa ce s-au gasit cele mai bune valori de greutate, ele pot fi plasate in reteaua neuronala
            // si utilizate pentru a prezice noi date de iesire care au datele de intrare cunoscute.

            //Acest program foloseste optimizarea evolutionara pentru a forma o retea neuronala care prezice speciile unei flori Iris 
            //("setosa," "versicolor," "virginica") in functie lungimea sepalei florii (frunze modificate care alcatuiesc caliciul unei 
            // flori), latimea sepalei, lungimea petalei si latimea petalei. Avem 24 de date pentru formare. Dupa terminarea formarii, 
            // cel mai bun set de lungimi este adaugat in reteaua neuronala. Reteaua prezice corect specia a 5/6 din datele de test.

            Console.WriteLine("Avem 30 de date de intrare pentru floarea Iris");
            Console.Write("Datele sunt lungimea sepalei, latimea sepalei, lungimea petalei, latimea petalei");
            Console.Write("\nSpeciile de Iris: Iris setosa = 0 0 1, Iris versicolor = 0 1 0, Iris virginica = 1 0 0 ");

            // !!! PASUL 1: DATELE DE INTRARE !!!
            var trainData = new double[24][];
            trainData[0] = new[] {6.3, 2.9, 5.6, 1.8, 1, 0, 0};
            trainData[1] = new[] {6.9, 3.1, 4.9, 1.5, 0, 1, 0};
            trainData[2] = new[] {4.6, 3.4, 1.4, 0.3, 0, 0, 1};
            trainData[3] = new[] {7.2, 3.6, 6.1, 2.5, 1, 0, 0};
            trainData[4] = new[] {4.7, 3.2, 1.3, 0.2, 0, 0, 1};
            trainData[5] = new[] {4.9, 3, 1.4, 0.2, 0, 0, 1};
            trainData[6] = new[] {7.6, 3, 6.6, 2.1, 1, 0, 0};
            trainData[7] = new[] {4.9, 2.4, 3.3, 1, 0, 1, 0};
            trainData[8] = new[] {5.4, 3.9, 1.7, 0.4, 0, 0, 1};
            trainData[9] = new[] {4.9, 3.1, 1.5, 0.1, 0, 0, 1};
            trainData[10] = new[] {5, 3.6, 1.4, 0.2, 0, 0, 1};
            trainData[11] = new[] {6.4, 3.2, 4.5, 1.5, 0, 1, 0};
            trainData[12] = new[] {4.4, 2.9, 1.4, 0.2, 0, 0, 1};
            trainData[13] = new[] {5.8, 2.7, 5.1, 1.9, 1, 0, 0};
            trainData[14] = new[] {6.3, 3.3, 6, 2.5, 1, 0, 0};
            trainData[15] = new[] {5.2, 2.7, 3.9, 1.4, 0, 1, 0};
            trainData[16] = new[] {7, 3.2, 4.7, 1.4, 0, 1, 0};
            trainData[17] = new[] {6.5, 2.8, 4.6, 1.5, 0, 1, 0};
            trainData[18] = new[] {4.9, 2.5, 4.5, 1.7, 1, 0, 0};
            trainData[19] = new[] {5.7, 2.8, 4.5, 1.3, 0, 1, 0};
            trainData[20] = new[] {5, 3.4, 1.5, 0.2, 0, 0, 1};
            trainData[21] = new[] {6.5, 3, 5.8, 2.2, 1, 0, 0};
            trainData[22] = new[] {5.5, 2.3, 4, 1.3, 0, 1, 0};
            trainData[23] = new[] {6.7, 2.5, 5.8, 1.8, 1, 0, 0};

            var testData = new double[6][];
            testData[0] = new[] {4.6, 3.1, 1.5, 0.2, 0, 0, 1};
            testData[1] = new[] {7.1, 3, 5.9, 2.1, 1, 0, 0};
            testData[2] = new[] {5.1, 3.5, 1.4, 0.2, 0, 0, 1};
            testData[3] = new[] {6.3, 3.3, 4.7, 1.6, 0, 1, 0};
            testData[4] = new[] {6.6, 2.9, 4.6, 1.3, 0, 1, 0};
            testData[5] = new[] {7.3, 2.9, 6.3, 1.8, 1, 0, 0};

            Console.WriteLine("\nDatele pentru formare sunt:");
            ShowMatrix(trainData, trainData.Length, 1, true);

            Console.WriteLine("Datele de test sunt:");
            ShowMatrix(testData, testData.Length, 1, true);

            Console.WriteLine("Cream reteaua neuronala initiala");
            // Numarul de tipuri de date de intrare (lungimea sepalei, latimea sepalei, lungimea petalei, latimea petalei)
            const int numInput = 4;
            // Numarul de noduri ascunse, se alege aleator
            const int numHidden = 6;
            // Numarul de tipuri de date de iesire ("setosa," "versicolor," "virginica")
            const int numOutput = 3;
            var nn = new NeuralNetwork(numInput, numHidden, numOutput);

            // Parametrii de formare specifici optimizarii evolutionare
            // Marimea populatiei este numarul de indivizi. Cu cat sunt mai multi indivizi, cu atat este mai buna solutia, dar scade si
            // performanta.
            var popSize = 8;
            // Numarul de iteratii maxim pe care optimizarea evolutionara le va executa in procesul de selectie-incrucisare-mutatie
            var maxGeneration = 500; 
            // Marja de eroare pentru un set de date pentru care se iese mai repede din proces
            var exitError = 0.0;
            // Rata de mutatie controleaza cate gene dintr-un cromozom nou vor suferi o mutatie
            var mutateRate = 0.20;
            // Magnitudinea schimbarii genei care a suferit o mutatie
            var mutateChange = 0.01;
            // Tau controleaza probabilitatea ca cei mai buni doi indivizi din populatie sa fie selectati ca parinti pentru reproducere.
            // Cu cat tau este mai mare, cu atat sansa ca cei mai buni doi indivizi sa fie selectati creste.
            var tau = 0.40;

            Console.WriteLine("\nSetam marimea populatiei = " +
                              popSize);
            Console.WriteLine("Setam numarul maxim de generatii = " + maxGeneration);
            Console.Write("Setam marja de eroare = ");
            Console.WriteLine(exitError.ToString("F3"));
            Console.Write("Setam rata de mutatie = ");
            Console.WriteLine(mutateRate.ToString("F3"));
            Console.Write("Setam magnitudinea schimbarii genei = ");
            Console.WriteLine(mutateChange.ToString("F3"));
            Console.Write("Setam tau = ");
            Console.WriteLine(tau.ToString("F3"));

            Console.WriteLine("\nIncepem formarea");
            var bestWeights = nn.Train(trainData, popSize, maxGeneration, exitError,
                mutateRate, mutateChange, tau);
            Console.WriteLine("Formarea incheiata");
            //Console.WriteLine("\nValori finale:");
            //ShowVector(bestWeights, 10, 3, true);

            nn.SetWeights(bestWeights);
            var trainAcc = nn.Accuracy(trainData);
            Console.Write("\nAcuratetea datelor de formare = ");
            Console.WriteLine(trainAcc.ToString("F4"));

            var testAcc = nn.Accuracy(testData);
            Console.Write("\nAcuratetea datelor de test = ");
            Console.WriteLine(testAcc.ToString("F4"));

            Console.ReadKey();

        }

        private static void ShowVector(double[] vector, int valsPerRow,
            int decimals, bool newLine)
        {
            for (var i = 0; i < vector.Length; ++i)
            {
                if (i%valsPerRow == 0) Console.WriteLine("");
                if (vector[i] >= 0.0) Console.Write(" ");
                Console.Write(vector[i].ToString("F" + decimals) + " ");
            }
            if (newLine)
                Console.WriteLine("");
        }

        //Afisarea matricii in consola sub forma convenabila
        private static void ShowMatrix(IReadOnlyList<double[]> matrix, int numRows,
            int decimals, bool newLine)
        {
            for (var i = 0; i < numRows; ++i)
            {
                Console.Write(i.ToString().PadLeft(3) + ": ");
                for (var j = 0; j < matrix[i].Length; ++j)
                {
                    Console.Write(matrix[i][j] >= 0.0 ? " " : "-");
                    Console.Write(Math.Abs(matrix[i][j]).ToString("F" + decimals) + " ");
                }
                Console.WriteLine("");
            }
            if (newLine)
                Console.WriteLine("");
        }
    }
}
