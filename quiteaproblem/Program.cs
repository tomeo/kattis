using System;

namespace quiteaproblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (input.ToLower().Contains("problem"))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}