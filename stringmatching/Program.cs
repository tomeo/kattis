using System;
using System.Collections.Generic;

namespace stringmatching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string pattern;
            while ((pattern = Console.ReadLine()) != null)
            {
                var text = Console.ReadLine();
                var indeces = new List<int>();
                var index = 0;
                while (index < text.Length)
                {
                    index = text.IndexOf(pattern, index, StringComparison.Ordinal);
                    if (index == -1) break;
                    indeces.Add(index);
                    index++;
                }
                Console.WriteLine(string.Join(" ", indeces));
            }
        }
    }
}