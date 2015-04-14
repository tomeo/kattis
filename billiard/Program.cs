using System;
using System.Collections.Generic;
using System.Linq;

namespace billiard
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (input == "0 0 0 0 0") return;
                Console.WriteLine(Solve(input.Split(' ').Select(int.Parse).ToArray()));
            }
        }

        private static string Solve(int[] input)
        {
            return string.Format("{0} {1}", input[0], input[1]);
        }
    }
}
