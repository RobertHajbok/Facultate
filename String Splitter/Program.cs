using System;

namespace String_Splitter
{
    class Program
    {
        static void Main()
        {
            string resourceData = Properties.Resources.Dictionary;
            string[] dictionary = resourceData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var ws = new WordSplitter(dictionary);

            string test = ws.SplitToWords("Bobhasagreenhat".ToLower());
            Console.WriteLine(test);

            string test2 = ws.SplitToWords("Thereisnowealthbutlife".ToLower());
            Console.WriteLine(test2);

            string test3 = ws.SplitToWords("Itisnotinthestarstoholdourdestinybutinourselves".ToLower());
            Console.WriteLine(test3);

            Console.ReadKey();
        }
    }
}
