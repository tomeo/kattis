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
            Console.WriteLine(((n%2 != 0) ? (before & after) == 0 : before == after) ? "Deletion succeeded" : "Deletion failed");
        }
    }
}