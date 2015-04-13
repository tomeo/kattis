using System;
using System.Linq;

namespace dicegame
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gunnar = Console.ReadLine().Split(' ').Select(int.Parse).Sum();
            var emma = Console.ReadLine().Split(' ').Select(int.Parse).Sum();
            if (gunnar == emma) Console.WriteLine("Tie");
            else if (gunnar > emma) Console.WriteLine("Gunnar");
            else Console.WriteLine("Emma");
        }
    }
}
