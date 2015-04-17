using System;

namespace erase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var before = Convert.ToInt32(Console.ReadLine(), 2);
            var after = Convert.ToInt32(Console.ReadLine(), 2);
            if (n%2 != 0)
            {
                Console.WriteLine((before & after) == 0 ? "Deletion succeeded" : "Deletion failed");
            }
            else
            {
                Console.WriteLine(before == after ? "Deletion succeeded" : "Deletion failed");
            }
        }
    }
}