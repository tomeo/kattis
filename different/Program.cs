using System;

namespace different
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var d = Int64.Parse(input[0]) - Int64.Parse(input[1]);
            if (d < 0) d *= -1;
            Console.WriteLine(d);
        }
    }
}