using System;

namespace ladder
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            Console.WriteLine(Math.Ceiling(int.Parse(input[0]) / Math.Sin(int.Parse(input[1])*(Math.PI / 180.0))));
        }
    }
}