using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class String
    {
        /// <summary>
        /// Checks to see if a string is a valid date
        /// </summary>
        /// <param name="s"></param>
        /// <returns>true, if the string is a valid date</returns>
        public static bool IsDate(this string s)
        {
            try
            {
                DateTime.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the string is a valid integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns>true, if the string is a valid integer</returns>
        public static bool IsInteger(this string s)
        {
            try
            {
                Int32.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if the string is a valid double
        /// </summary>
        /// <param name="s"></param>
        /// <returns>true, if the string is a valid double</returns>
        public static bool isDouble(this string s)
        {
            try
            {
                Double.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Reverses the string
        /// </summary>
        /// <param name="s"></param>
        /// <returns>The reversed string</returns>
        public static string Reversed(this string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Counts the number of non empty chars
        /// </summary>
        /// <param name="s"></param>
        /// <returns>The number of non empty chars</returns>
        public static int CountNonEmptyChars(this string s)
        {
            int count = 0;

            foreach (char c in s)
            {
                if (!Char.IsWhiteSpace(c))
                    count++;
            }

            return count;
        }
    }
}
