using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date
{
    public class Date
    {
        public Date(int zi, int luna, int an)
        {
            this.zi = zi;
            this.luna = luna;
            this.an = an;
        }

        public Date(string data)
        {
            char[] delimitator = { ':', '.' };
            string[] s = data.Split(delimitator);
            if (s.Length != 3)
                Console.WriteLine("Data incorecta.");
            else
            {
                zi = Convert.ToInt32(s[0]);
                luna = Convert.ToInt32(s[1]);
                an = Convert.ToInt32(s[2]);
            }
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}.{1}.{2}", zi, luna, an);
            return s.ToString();
        }
        public static bool operator ==(Date d1, Date d2)
        {
            if (d1.an == d2.an && d1.luna == d2.luna && d1.zi == d2.zi)
                return true;
            return false;
        }
        public static bool operator !=(Date d1, Date d2)
        {
            return !(d1 == d2);
        }
        public static bool operator <(Date d1, Date d2)
        {
            if (d1.an < d2.an)
                return true;
            if (d1.an == d2.an && d1.luna < d2.luna)
                return true;
            if (d1.an == d2.an && d1.luna == d2.luna && d1.zi < d2.zi)
                return true;
            return false;
        }
        public static bool operator <=(Date d1, Date d2)
        {
            return (d1 < d2 && d1 == d2);
        }
        public static bool operator >(Date d1, Date d2)
        {
            return !(d1 <= d2);
        }
        public static bool operator >=(Date d1, Date d2)
        {
            return !(d1 < d2);
        }

        public static int GetDays(Date d)
        {
            int zile = 0;
            for (int i = 1; i < d.an; i++)
                zile += (DateTime.IsLeapYear(i)) ? 366 : 365;
            for (int i = 1; i < d.luna; i++)
                zile += DateTime.DaysInMonth(d.an, i);
            zile = d.zi;
            return zile;
        }

        public static int operator -(Date d1, Date d2)
        {
            return Math.Abs(GetDays(d1) - GetDays(d2));
        }

        int zi, luna, an;
    }
}
