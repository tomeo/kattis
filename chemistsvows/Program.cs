using System;
using System.Collections.Generic;

namespace chemistsvows
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            string input;
            var pts = new PeriodicTableStringifyer();
            while ((input = Console.ReadLine()) != null)
            {
                Console.WriteLine(pts.CanBeCreated(input.ToLower(), 0) ? "YES" : "NO");
            }
        }

        public class PeriodicTableStringifyer
        {
            private readonly HashSet<string> _one = new HashSet<string>
            {
                {"b"},{"h"},{"c"},{"n"},{"o"},{"f"},{"p"},{"s"},{"k"},{"v"},{"y"},{"i"},{"u"},{"w"}
            };
            private readonly HashSet<string> _two = new HashSet<string>
            {
                {"he"},{"li"},{"be"},{"ne"},{"na"},{"mg"},{"al"},{"si"},{"cl"},{"ar"},{"ca"},{"sc"},
                {"ti"},{"cr"},{"mn"},{"fe"},{"co"},{"ni"},{"cu"},{"zn"},{"ga"},{"ge"},{"as"},{"se"},
                {"br"},{"kr"},{"rb"},{"sr"},{"zr"},{"nb"},{"mo"},{"tc"},{"ru"},{"rh"},{"pd"},{"ag"},
                {"cd"},{"in"},{"sn"},{"sb"},{"te"},{"xe"},{"cs"},{"ba"},{"hf"},{"ta"},{"re"},{"os"},
                {"ir"},{"pt"},{"au"},{"hg"},{"tl"},{"pb"},{"bi"},{"po"},{"at"},{"rn"},{"fr"},{"ra"},
                {"rf"},{"db"},{"sg"},{"bh"},{"hs"},{"mt"},{"ds"},{"rg"},{"cn"},{"fl"},{"lv"},{"la"},
                {"ce"},{"pr"},{"nd"},{"pm"},{"sm"},{"eu"},{"gd"},{"tb"},{"dy"},{"ho"},{"er"},{"tm"},
                {"yb"},{"lu"},{"ac"},{"th"},{"pa"},{"np"},{"pu"},{"am"},{"cm"},{"bk"},{"cf"},{"es"},
                {"fm"},{"md"},{"no"},{"lr"}
            };

            public bool CanBeCreated(string s, int index)
            {
                //Console.WriteLine(index + " " + s.Length);
                if (index >= s.Length) return true;
                var one = (index + 1 < s.Length) && _one.Contains(s.Substring(index, 1));
                //if (one)
                //{
                //    Console.WriteLine("We have the string {0}", s.Substring(0, index+1));
                //}
                var two = (index + 2 < s.Length) && _two.Contains(s.Substring(index, 2));
                //if (two)
                //{
                //    Console.WriteLine("We have the string {0}", s.Substring(0, index + 2));
                //}
                return (one && CanBeCreated(s, ++index)) || (two && CanBeCreated(s, index+2));
            }
        }
    }
}
