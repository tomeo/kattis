using System;
using System.Threading;

namespace flipfive
{
    public class Solver
    {
        private readonly int _solution;

        public Solver()
        {
            var solution = 0;
            var l1 = "*..";
            var l2 = "**.";
            var l3 = "*..";
            solution += l1.ToCharArray()[0] == '*' ? 1 : 0;
            solution += l1.ToCharArray()[1] == '*' ? 2 : 0;
            solution += l1.ToCharArray()[2] == '*' ? 4 : 0;
            solution += l2.ToCharArray()[0] == '*' ? 8 : 0;
            solution += l2.ToCharArray()[1] == '*' ? 16 : 0;
            solution += l2.ToCharArray()[2] == '*' ? 32 : 0;
            solution += l3.ToCharArray()[0] == '*' ? 64 : 0;
            solution += l3.ToCharArray()[1] == '*' ? 128 : 0;
            solution += l3.ToCharArray()[2] == '*' ? 256 : 0;
            _solution = solution;
        }

        public int Solve()
        {
            var board = 0;
            var clicks = 1;
            for (var i = 0; i < 9; i++)
            {
                board ^= CalculateMove(i);
                if (board == _solution)
                {
                    return clicks;
                }
                board = 0;
            }
            return Solve(++clicks, board, 0);
        }

        private int Solve(int clicks, int board, int position)
        {
            if (board == _solution) return clicks;
            if (position > 8)
            {
                position = 0;
                ++clicks;
            }
            

            return Solve(clicks, board, ++position);
        }

        private static int CalculateMove(int position)
        {
            switch (position)
            {
                case 1:
                    return 11;
                case 2:
                    return 23;
                case 3:
                    return 38;
                case 4:
                    return 89;
                case 5:
                    return 186;
                case 6:
                    return 308;
                case 7:
                    return 200;
                case 8:
                    return 464;
                case 9:
                    return 416;
            }
            return 0;
        }
    }
}
