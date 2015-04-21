using System;

namespace peg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var b = new String[7];
            for (var i = 0; i < b.Length; i++)
            {
                b[i] = Console.ReadLine();
            }
            var board = new Board(b);
            Console.WriteLine(board.CalculateLegalMoves());
        }

        public class Board
        {
            private string[] _board;

            public Board(string[] board)
            {
                _board = board;
            }

            public int CalculateLegalMoves()
            {
                var moves = 0;
                for (var x = 0; x < _board[0].Length; x++)
                {
                    for (var y = 0; y < _board.Length; y++)
                    {
                        if (_board[y][x] == 'o')
                        {
                            if (IsLegalMove(x, y, x, y - 2)) moves++;
                            if (IsLegalMove(x, y, x, y + 2)) moves++;
                            if (IsLegalMove(x, y, x + 2, y)) moves++;
                            if (IsLegalMove(x, y, x - 2, y)) moves++;
                        }
                    }
                }
                return moves;
            }

            public bool IsLegalMove(int x1, int y1, int x2, int y2)
            {
                if (x1 > _board[0].Length - 1) return false;
                if (y1 > _board.Length - 1) return false;
                if (x2 > _board[0].Length - 1) return false;
                if (y2 > _board.Length - 1) return false;
                if (x1 < 0) return false;
                if (y1 < 0) return false;
                if (x2 < 0) return false;
                if (y2 < 0) return false;
                if (_board[y1][x1] != 'o') return false;
                if (_board[y2][x2] != '.') return false;
                if (_board[y2][x2] == ' ') return false;
                if (x1 == x2)
                {
                    if (y1 < y2 && _board[y1 + 1][x1] != 'o') return false;
                    if (y2 < y1 && _board[y2 + 1][x1] != 'o') return false;
                }
                if (y1 == y2)
                {
                    if (x1 < x2 && _board[y1][x1+1] != 'o') return false;
                    if (x2 < x1 && _board[y1][x2+1] != 'o') return false;
                }
                return true;
            }
        }
    }
}