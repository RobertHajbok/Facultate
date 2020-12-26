using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polish_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0.0;
            MathText.ReversePolishNotation rpn = new MathText.ReversePolishNotation();
            rpn.Parse("3+4*2/(1-5)^2^3");
            result = rpn.Evaluate();
            Console.WriteLine("orig:   {0}", rpn.OriginalExpression);
            Console.WriteLine("tran:   {0}", rpn.TransitionExpression);
            Console.WriteLine("post:   {0}", rpn.PostfixExpression);
            Console.WriteLine("result: {0}", result);

            Console.WriteLine();
            rpn.Parse("-4.5* sin(-pi/6) + e -0.25");
            result = rpn.Evaluate();
            Console.WriteLine("orig:   {0}", rpn.OriginalExpression);
            Console.WriteLine("tran:   {0}", rpn.TransitionExpression);
            Console.WriteLine("post:   {0}", rpn.PostfixExpression);
            Console.WriteLine("result: {0}", result);

            Console.WriteLine();
            rpn.Parse("-4^-2");
            result = rpn.Evaluate();
            Console.WriteLine("orig:   {0}", rpn.OriginalExpression);
            Console.WriteLine("tran:   {0}", rpn.TransitionExpression);
            Console.WriteLine("post:   {0}", rpn.PostfixExpression);
            Console.WriteLine("result: {0}", result);

            Console.WriteLine();
            rpn.Parse("(A+B)*(C+D)");            
            Console.WriteLine("orig:   {0}", rpn.OriginalExpression);
            Console.WriteLine("tran:   {0}", rpn.TransitionExpression);
            Console.WriteLine("post:   {0}", rpn.PostfixExpression);

            Console.WriteLine("End of program");
            Console.ReadLine();
        }
    }
}
