using System;

namespace zigzag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new string(Solve(int.Parse(Console.ReadLine()))).ToLower());
        }

        public static char[] Solve(int v)
        {
            var l = CalculateMinLength(v);
            var solution = new char[l];
            var r = v%25;
            var t = (l - 3) > 0 ? l - 3 : 0;
            var d = v - t * 25;
            if (r == 0)
            {
                for (var i = 0; i < solution.Length; i++)
                    solution[i] = (i%2 == 0) ? 'A' : 'Z';
                return solution;
            }
            //Console.WriteLine("d/2 = {0}, d%2={1}", d/2, d%2);
            var x = d/2 + d%2;
            solution[0] = 'A';
            solution[1] = (char) ('A' + x);

            for (var i = 2; i < solution.Length; i++)
            {
                solution[i] = (i%2 == 0) ? 'A' : 'Z';
            }

            var y = d%2;
            if (y != 0) solution[solution.Length - 1] = (char) ('A' + y);
            var c = Calculate(solution);
            var diff = v - c;
            if (diff != 0)
            {
                solution[solution.Length - 1] = (char) (solution[solution.Length - 1] + diff);
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

        public static int Calculate(char[] carr)
        {
            if (carr.Length == 1) return carr[0] - 64;
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