using System;

namespace simon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (input.StartsWith("simon says "))
                {
                    Console.WriteLine(input.Replace("simon says ", string.Empty).Trim());
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}