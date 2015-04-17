using System;
using System.Collections.Generic;

namespace judging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var results = new string[2*n];
            for (var i = 0; i < results.Length; i++) results[i] = Console.ReadLine();
            Console.WriteLine(
                Solve(
                    CreateResultDictionary(results, 0, n),
                    CreateResultDictionary(results, n, 2*n)));
        }

        private static int Solve(Dictionary<string, int> dom, Dictionary<string, int> kattis)
        {
            var count = 0;
            foreach (var dvp in dom)
            {
                for (var i = 0; i < dvp.Value; i++)
                {
                    if (kattis.ContainsKey(dvp.Key) && kattis[dvp.Key] > 0)
                    {
                        kattis[dvp.Key]--;
                        count++;
                    }
                }
            }
            return count;
        }

        private static Dictionary<string, int> CreateResultDictionary(string[] results, int offset, int end)
        {
            var dict = new Dictionary<string, int>();
            for (var i = offset; i < end; i++)
            {
                if (dict.ContainsKey(results[i]))
                {
                    dict[results[i]]++;
                }
                else
                {
                    dict.Add(results[i], 1);
                }
            }
            return dict;
        }
    }
}