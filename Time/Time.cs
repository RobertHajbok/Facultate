using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    class Time
    {
        int ora;
        int minute;
        int secunde;
        int milisecunde;

        #region Constructors
        void setup(int ora, int minute, int secunde, int milisecunde)
        {
            this.ora = ora;
            this.minute = minute;
            this.secunde = secunde;
            this.milisecunde = milisecunde;
        }

        public Time(int ora, int minute)
        {
            setup(ora, minute, 0, 0);
        }

        public Time(int ora, int minute, int secunde)
        {
            setup(ora, minute, secunde, 0);
        }

        public Time(int ora, int minute, int secunde, int milisecunde)
        {
            setup(ora, minute, secunde, milisecunde);
        }

        public Time(string time)
        {
            string[] componente = time.Split(',');
            if (componente.Length == 4)
            {
                ora = int.Parse(componente[0]);
                minute = int.Parse(componente[1]);
                secunde = int.Parse(componente[2]);
                milisecunde = int.Parse(componente[3]);
            }
        }
        #endregion

        #region Overloaded operators
        public static bool operator ==(Time t1, Time t2)
        {
            return ((t1.ora == t2.ora) && (t1.minute == t2.minute) && (t1.secunde == t2.secunde) && (t1.milisecunde == t2.milisecunde));
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }
        public static bool operator >(Time t1, Time t2)
        {
            if (t1.ora > t2.ora)
            {
                return true;
            }
            else
            {
                if (t1.minute > t2.minute)
                {
                    return true;
                }
                else
                {
                    if (t1.secunde > t2.secunde)
                    {
                        return true;
                    }
                    else
                    {
                        if (t1.milisecunde > t2.milisecunde)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        public static bool operator <(Time t1, Time t2)
        {
            return (t2 > t1);
        }
        public static bool operator >=(Time t1, Time t2)
        {
            if (t1 == t2)
            {
                return true;
            }
            else
            {
                return t1 > t2;
            }
        }
        public static bool operator <=(Time t1, Time t2)
        {
            return (t2 >= t1);
        }

        public static Time operator +(Time t1, Time t2)
        {
            //TimeSpan span = new DateTime(0, 0, 0, t1.ora, t1.minute, t1.secunde, t1.milisecunde) - new DateTime(0, 0, 0, t2.ora, t2.minute, t2.secunde, t2.milisecunde);
            //return new Time((int)span.TotalHours, (int)span.TotalMinutes, (int)span.TotalSeconds, (int)span.TotalMilliseconds);

            TimeSpan span1 = new TimeSpan(0, t1.ora, t1.minute, t1.secunde, t1.milisecunde);
            TimeSpan span2 = new TimeSpan(0, t2.ora, t2.minute, t2.secunde, t2.milisecunde);

            TimeSpan result = span1.Add(span2);

            return new Time((int)result.Hours, (int)result.Minutes, (int)result.Seconds, (int)result.Milliseconds);
        }

        public static Time operator -(Time t1, Time t2)
        {
            //TimeSpan span = new DateTime(0, 0, 0, t1.ora, t1.minute, t1.secunde, t1.milisecunde) - new DateTime(0, 0, 0, t2.ora, t2.minute, t2.secunde, t2.milisecunde);
            //return new Time((int)span.TotalHours, (int)span.TotalMinutes, (int)span.TotalSeconds, (int)span.TotalMilliseconds);

            TimeSpan span1 = new TimeSpan(0, t1.ora, t1.minute, t1.secunde, t1.milisecunde);
            TimeSpan span2 = new TimeSpan(0, t2.ora, t2.minute, t2.secunde, t2.milisecunde);

            TimeSpan result = span1.Subtract(span2);

            return new Time((int)result.Hours, (int)result.Minutes, (int)result.Seconds, (int)result.Milliseconds);
        }
        #endregion

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0:00}:{1:00}:{2:00}.{3:00}", ora, minute, secunde, milisecunde);
            return s.ToString();
        }
    }
}
