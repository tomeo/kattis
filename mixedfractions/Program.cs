using System;
using System.Linq;

namespace mixedfractions
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (numbers[0] == 0 || numbers[1] == 0) break;
                Console.WriteLine(numbers[0] / numbers[1] + " " + numbers[0] % numbers[1] + " / " + numbers[1]);
            }
        }
    }
}
