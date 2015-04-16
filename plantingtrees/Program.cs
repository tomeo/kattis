using System;
using System.Linq;

namespace plantingtrees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            var days = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(days, (x, y) => y.CompareTo(x));
            for (var i = 0; i < days.Length; i++) days[i] += i + 1;
            Console.WriteLine(days.Max()+1);
        }
    }
}