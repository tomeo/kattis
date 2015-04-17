using System;

namespace doorman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());
            var queue = Console.ReadLine();
            Console.WriteLine(CalculateIntake(queue, x));
        }

        public static int CalculateIntake(string queue, int maxDifference)
        {
            var i = 0;
            var g = new int[2];
            while (i < queue.Length)
            {
                g[(queue[i] == 'M') ? 0 : 1]++;
                if (Math.Abs(g[0]-g[1]) > maxDifference)
                {
                    if ((i + 1) == queue.Length || queue[i] == queue[i + 1])
                    {
                        return i;
                    }
                    g[(queue[i + 1] == 'M') ? 0 : 1]++;
                    i++;
                }
                i++;
            }
            return i;
        }
    }
}