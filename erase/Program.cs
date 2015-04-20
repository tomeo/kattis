using System;
using System.Linq;

namespace erase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var before = Console.ReadLine();
            var after = Console.ReadLine();
            Console.WriteLine(Verify(n, before, after) ? "Deletion succeeded" : "Deletion failed");
        }

        public static bool Verify(int n, string before, string after)
        {
            if (n%2 == 0)
            {
                return before == after;
            }
            return !before.Where((t, i) => t == after[i]).Any();
        }
    }
}