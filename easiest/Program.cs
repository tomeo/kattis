using System;
using System.Linq;

namespace easiest
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (input == "0") return;
                Console.WriteLine(Solve(int.Parse(input))); 
            }            
        }

        private static int Solve(int input)
        {
            var current = 11;
            var inputSum = Sum(input);
            while (true)
            {
                if (inputSum == Sum(input*current))
                {
                    return current;
                }
                current++;
            }
        }

        private static int Sum(int value)
        {
            return value.ToString().Sum(c => int.Parse(c.ToString()));
        }
    }
}