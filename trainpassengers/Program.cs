using System;
using System.Collections.Generic;
using System.Linq;

namespace trainpassengers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stations = new List<int[]>();
            for (var i = 0; i < input[1]; i++)
            {
                stations.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());    
            }

            Console.WriteLine(Solve(input[0], stations) ? "possible" : "impossible");
        }

        public static bool Solve(int c, IEnumerable<int[]> stations)
        {
            var passengers = 0;
            foreach (var station in stations)
            {
                passengers = passengers - station[0];
                if (passengers < 0) return false;
                passengers += station[1];
                if (passengers > c) return false;
                if ((c - passengers) != 0 && station[2] != 0) return false;
            }
            return passengers == 0;
        }
    }
}
