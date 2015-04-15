using System;
using System.Collections.Generic;

namespace engineeringenglish
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seen = new HashSet<string>();
            var output = new List<List<string>>();
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                var line = new List<string>();
                foreach (var word in input.Split(' '))
                {
                    var lc = word.ToLower();
                    if (!seen.Contains(lc))
                    {
                        seen.Add(lc);
                        line.Add(word);
                    }
                    else
                    {
                        line.Add(".");
                    }
                }
                output.Add(line);
            }
            foreach (var str in output)
            {
                Console.WriteLine(string.Join(" ", str));
            }
        }
    }
}