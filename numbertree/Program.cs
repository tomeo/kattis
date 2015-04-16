using System;

namespace numbertree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var h = int.Parse(input[0]);
            var root = (2 << h) - 1;
            
        }
    }
}
