using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hello_World
{
    /// <summary> Clasa Hello afişează un mesaj
    /// pe ecran
    /// </summary>
    class Program
    {
        /// <remarks> Folosim I/E la consolă.
        /// Pentru mai multe informaţii despreWriteLine,
        /// <seealso cref="System.Console.WriteLine"/>
        /// </remarks>
        public static void Main()
        {
            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
