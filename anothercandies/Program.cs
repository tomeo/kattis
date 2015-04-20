using System;
using System.Numerics;

namespace anothercandies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cases = BigInteger.Parse(Console.ReadLine());
            for (var c = 0; c < cases; c++)
            {
                Console.ReadLine();
                var kids = BigInteger.Parse(Console.ReadLine());
                BigInteger sum = 0;
                for (var kid = 0; kid < kids; kid++)
                {
                    sum += BigInteger.Parse(Console.ReadLine());
                }
                Console.WriteLine((sum % kids == 0) ? "YES" : "NO");
            }
        }
    }
}