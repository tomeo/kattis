using System;
using System.Linq;

namespace pet
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var max = 0;
            var winner = 0;
            var i = 1;
            while ((input = Console.ReadLine()) != null)
            {
                var current = input.Split(' ').Select(int.Parse).Sum();
                if (current > max)
                {
                    max = current;
                    winner = i;
                }
                i++;
            }
            Console.WriteLine("{0} {1}", winner, max);
        }
    }
}