using System;
using System.Linq;

namespace oddmanout
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            string input;
            var n = 1;
            while ((input = Console.ReadLine()) != null)
            {
                var codes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Array.Sort(codes);
                var i = 1;
                while (i < codes.Length && codes[i] == codes[i - 1]) i += 2;
                Console.WriteLine(string.Format("Case #{0}: {1}", n++, codes[i - 1]));
            }
        }
    }
}