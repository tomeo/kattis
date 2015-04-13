using System;
using System.Linq;

namespace reversebinary
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToInt32(new string(Convert.ToString(int.Parse(Console.ReadLine()), 2).ToCharArray().Reverse().ToArray()), 2));
        }
    }
}