using System;
using System.Linq;

namespace trainpassengers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var c = int.Parse(input[0]);
            var n = int.Parse(input[1]);
            var onTrain = 0;
            var possible = true;
            for (var i = 0; i < n; i++)
            {
                var train = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                onTrain = Math.Max(onTrain-train[0], 0);
                onTrain += train[1];
                if (onTrain > c)
                {
                    possible = false;
                    break;
                }
                // 1 = entered
                // 2 = stayed at station
            }
            Console.WriteLine(possible ? "possible" : "impossible");
        }
    }
}
