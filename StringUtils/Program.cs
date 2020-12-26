using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace StringUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "This is awesome.";

            Console.WriteLine("The string '{0}' {1} a valid integer.", s, s.IsInteger() ? "is" : "is NOT");
            Console.WriteLine("The string '{0}' {1} a valid double.", s, s.isDouble() ? "is" : "is NOT");
            Console.WriteLine("The string '{0}' {1} a valid date.", s, s.IsDate() ? "is" : "is NOT");
            Console.WriteLine("The string '{0}' has {1} non-empty chars.", s, s.CountNonEmptyChars());
            Console.ReadKey();
        }
    }
}
