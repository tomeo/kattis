using System;

namespace flipfive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problems = Int32.Parse("1");
            for (var problem = 1; problem <= problems; problem++)
            {
                Console.WriteLine(new Solver().Solve());
            }
        }
    }
}