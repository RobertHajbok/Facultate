using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_sum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //The 3-Sum Problem
            //Given N distinct integers, find all triplets that sum to exactly 0.

            var numbers = new List<int> { 5, -12, 3, -8, 10, 2, -5, 0 };
            var allTriplets = new List<Triplets>();
            var len = numbers.Count;

            //Brute-force algorithm: N^3 (N = Length of the array)

            //for (int i = 0; i < len; i++)
            //    for (int j = i + 1; j < len; j++)
            //        for (int k = j + 1; k < len; k++)
            //            if (checked(numbers[i] + numbers[j] + numbers[k]) == 0)
            //                allTriplets.Add(new Triplets(numbers[i], numbers[j], numbers[k]));

            //Step 1: Shuffle the array (For making Quick sort efficient)
            //Step 2: Sort the array using Quick Sort: N*logN
            //Step 3: Use Binary Search to find the 3rd number: -(n1 + n2) : N^2 * logN

            numbers = numbers.Distinct().ToList();
            //Shuffle(numbers);

            //len = numbers.Count;

            QuickSort(numbers);
            //int location = 0;

            //for (int i = 0; i < len; i++)
            //    for (int j = i + 1; j < len - 1; j++)
            //        if ((location = TweakedBinarySearch(numbers, -(numbers[i] + numbers[j]), j + 1)) != -1)
            //            allTriplets.Add(new Triplets(numbers[i], numbers[j], numbers[location]));

            var sb = new StringBuilder();

            //allTriplets.ForEach(triplet => sb.Append(String.Format("[{0}, {1}, {2}]\n", triplet.A, triplet.B, triplet.C)));

            int a, b, c;
            int indJ, indK;

            for (int i = 0; i < numbers.Count - 2; i++)
            {
                a = numbers[i];
                indJ = i + 1;
                indK = numbers.Count - 1;

                while (indJ < indK)
                {
                    b = numbers[indJ];
                    c = numbers[indK];

                    if (a + b + c == 0)
                    {
                        allTriplets.Add(new Triplets(a, b, c));
                        indJ++;
                        indK--;
                        //break;
                    }
                    else if (a + b + c > 0)
                        indK--;
                    else
                        indJ++;
                }
            }
            allTriplets.ForEach(triplet => sb.Append(String.Format("[{0}, {1}, {2}]\n", triplet.A, triplet.B, triplet.C)));

            MessageBox.Show(sb.ToString());
        }

        public void QuickSort(List<int> numbers)
        {
            Shuffle(numbers);
            SortLogic(numbers, 0, numbers.Count - 1);
        }


        //Fisher-Yates Shuffle Algorithm
        public void Shuffle(List<int> values)
        {
            var random = new Random();

            for (int i = values.Count; i > 1; i--)
            {
                int j = random.Next(i);
                
                int temp = values[j];
                values[j] = values[i - 1];
                values[i - 1] = temp;
            }
        }

        public void SortLogic(List<int> a, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int j = Partition(a, low, high);
            SortLogic(a, low, j - 1);
            SortLogic(a, j + 1, high);
        }

        public int Partition(List<int> numList, int low, int high)
        {
            //Example:-
            
            //4 2 5 9 3 6
            //i j       l

            //4 2 5 9 3 6
            //l   i   j
            
            //Exchange i'th & j'th value
            //4 2 3 9 5 6
            //l   i   j

            //4 2 3 9 5 6
            //l   j i

            //Exchange low'th & j'th value
            //3 2 4 9 5 6
            //l   j i

            var i = low;
            var j = high + 1;

            while (true)
            {
                while (numList[++i] < numList[low])                
                    if (i == high)
                        break;                

                while (numList[low] < numList[--j])
                    if (j == low)
                        break;
                

                if (i >= j)                
                    break;                

                Exchange(numList, i, j);
            }

            //Swap with the partition element
            Exchange(numList, low, j);
            return j;
        }

        public void Exchange(List<int> a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public int TweakedBinarySearch(List<int> a, int key, int startIndex)
        {
            int lo = startIndex;
            int hi = a.Count - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else
                    return mid;
            }

            return -1;
        }
    }
}
