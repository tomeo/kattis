using System;

namespace catenyms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cases = int.Parse(Console.ReadLine());
            for (var i = 0; i < cases; i++)
            {
                Console.WriteLine("Case {0}", i);
                var n = int.Parse(Console.ReadLine());
                var words = new string[n];
                for (var j = 0; j < n; j++)
                {
                    words[j] = Console.ReadLine();
                }
                Console.WriteLine(Solve(words));
            }
        }

        private static string Solve(string[] words)
        {
            return string.Join("\n", words);
        }
    }
}
