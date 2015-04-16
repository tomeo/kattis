using System;

namespace different
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                var values = input.Split(' ');
                var d = Int64.Parse(values[0]) - Int64.Parse(values[1]);
                if (d < 0) d *= -1;
                Console.WriteLine(d);
            }
        }
    }
}