using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace zigzag
{
    public class Program
    {
       public static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(new string(Solve()));
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }

        public static char[] Solve()
        {
            var v = 14;
            Console.WriteLine("v = {0}", v);
            // Solution length
            var l = CalculateMinLength(v);
            Console.WriteLine("l = {0}", l);
            var solution = new char[l];
            
            // Number of times 25 goes in v
            var q = v / 25;
            Console.WriteLine("q = {0}", q);
            // The remainder after dividing with 25
            var r = v % 25;
            Console.WriteLine("r = {0}", r);
            if (r == 0)
            {
                for (var i = 0; i < solution.Length; i++)
                    solution[i] = (i % 2 == 0) ? 'A' : 'Z';
                return solution;
            }

            // Prepare solution
            solution[0] = 'A';
            for (var i = 2; i < solution.Length; i++)
            {
                solution[i] = (i % 2 == 0) ? 'A' : 'Z';
            }

            // Min number of 25s in solution
            var t = (v % 2 == 0) ? l - q : l - q - 1;
            Console.WriteLine("t = {0}", t);

            if (v % 2 == 0)
            {
                var d = (v - 25 * t) % 26;
                solution[1] = (char)('A' + d / 2);
            }
            else
            {

            }
            return solution;
        }

        private static int CalculateMinLength(int value)
        {
            if (value <= 25) return 2;
            var quote = value/25;
            var rem = value%25;
            if (rem == 0) return quote + 1;
            return quote + 2;
        }

        private static char[] GenerateNew(int length)
        {
            var arr = new char[length];
            var current = 'Z';
            for (var i = arr.Length-1; i > 0; i--)
            {
                arr[i] = current;
                current = current == 'Z' ? 'A' : 'Z';
            }
            arr[0] = 'A';
            return arr;
        }

        public static int Calculate(char[] carr)
        {
            var str = new string(carr);
            var sum = 0;
            for (var i = 0; i < str.Length - 1; i++)
            {
                var tmp = (str[i] - 64) - (str[i + 1] - 64);
                if (tmp < 0) tmp *= (-1);
                sum += tmp;
            }
            return sum;
        }
    }
}
