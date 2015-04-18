using System;

namespace anothercandies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cases = Int64.Parse(Console.ReadLine());
            for (var i = 0; i < cases; i++)
            {
                Console.ReadLine();
                var kids = Int64.Parse(Console.ReadLine());
                var sum = 0L;
                for (var j = 0; j < kids; j++)
                {
                    sum += Int64.Parse(Console.ReadLine());
                }
                Console.WriteLine((sum % kids == 0) ? "YES" : "NO");
            }
        }
    }
}