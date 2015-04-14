using System;

namespace kemija08
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine()
                .Replace("apa", "a")
                .Replace("epe", "e")
                .Replace("ipi", "i")
                .Replace("opo", "o")
                .Replace("upu", "u"));
        }
    }
}