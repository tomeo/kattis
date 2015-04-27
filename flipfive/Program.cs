using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace flipfive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problems = Int32.Parse(Console.ReadLine());
            for (var problem = 0; problem < problems; problem++)
            {
                var sb = new StringBuilder();
                sb.Append(Console.ReadLine());
                sb.Append(Console.ReadLine());
                sb.Append(Console.ReadLine());
                Console.WriteLine(
                    Solve(
                        Convert.ToInt32(
                            sb.ToString()
                                .Replace("*", "1")
                                .Replace(".", "0"),
                            2
                            ),
                        1));
            }
        }

        private static int Solve(int board, int clicks)
        {
            foreach (var permutation in GetPermutations(Enumerable.Range(1, 9), clicks))
            {
                var tmpBoard = board;
                foreach (var move in permutation)
                {
                    tmpBoard ^= CalculateMove(move);
                }
                if (tmpBoard == 0) return clicks;
            }
            return Solve(board, ++clicks);
        }

        private static IEnumerable<IEnumerable<T>>
            GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new[] {t});

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new[] {t2}));
        }

        private static int CalculateMove(int position)
        {
            switch (position)
            {
                case 1:
                    return 416;
                case 2:
                    return 464;
                case 3:
                    return 200;
                case 4:
                    return 308;
                case 5:
                    return 186;
                case 6:
                    return 89;
                case 7:
                    return 38;
                case 8:
                    return 23;
                case 9:
                    return 11;
            }
            return 0;
        }
    }
}