using System;
using System.Collections.Generic;

namespace cd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                var nm = input.Split(' ');
                Console.WriteLine(Solve(long.Parse(nm[0]), long.Parse(nm[1])));
                Console.ReadLine();
            }
        }

        public static int Solve(long n, long m)
        {
            var jack = new HashSet<string>();
            for (var i = 0; i < n; i++) jack.Add(Console.ReadLine());
            var sum = 0;
            for (var i = 0; i < m; i++) if (jack.Contains(Console.ReadLine())) sum++;
            return sum;
        }
    }
}