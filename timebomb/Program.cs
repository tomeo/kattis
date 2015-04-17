using System;
using System.Collections.Generic;

namespace timebomb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new string[5];
            for (var i = 0; i < 5; i++)
            {
                input[i] = Console.ReadLine();
            }
            var code = new List<int>(input[0].Length/4);
            for (var i = 0; i < input[0].Length; i += 4)
            {
                var number = Decode(input, i);
                if (number == -1)
                {
                    Console.WriteLine("BOOM!!");
                    return;
                }
                code.Add(number);
            }
            Console.WriteLine(int.Parse(string.Join("", code)) % 6 == 0 ? "BEER!!" : "BOOM!!");
        }

        private static int Decode(string[] s, int offset)
        {
            if (s[0][offset + 0] == '*')
            {
                if (s[0][offset + 1] == '*')
                {
                    if (s[0][offset + 2] == '*')
                    {
                        if (s[1][offset + 0] == '*')
                        {
                            if (Zero(s, offset)) return 0;
                            if (Five(s, offset)) return 5;
                            if (Six(s, offset)) return 6;
                            if (Eight(s, offset)) return 8;
                            if (Nine(s, offset)) return 9;
                        }
                        else
                        {
                            if (Two(s, offset)) return 2;
                            if (Three(s, offset)) return 3;
                            if (Seven(s, offset)) return 7;
                        }
                    }
                }
                else if (s[0][offset + 2] == '*')
                {
                    if (Four(s, offset)) return 4;
                }
            }
            else
            {
                if (One(s, offset)) return 1;
            }
            return -1;
        }

        private static bool Zero(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != ' ') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[3][offset + 0] != '*') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool One(string[] s, int offset)
        {
            if (s[0][offset + 1] != ' ') return false;
            if (s[0][offset + 2] != '*') return false;
            if (s[1][offset + 0] != ' ') return false;
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != ' ') return false;
            if (s[2][offset + 1] != ' ') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != ' ') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != ' ') return false;
            if (s[4][offset + 1] != ' ') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Two(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != '*') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != ' ') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Three(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != ' ') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Four(string[] s, int offset)
        {
            if (s[1][offset + 0] != '*') return false;
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != ' ') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != ' ') return false;
            if (s[4][offset + 1] != ' ') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Five(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != ' ') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != ' ') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Six(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != ' ') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != '*') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Seven(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != ' ') return false;
            if (s[2][offset + 1] != ' ') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != ' ') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != ' ') return false;
            if (s[4][offset + 1] != ' ') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Eight(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != '*') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }

        private static bool Nine(string[] s, int offset)
        {
            if (s[1][offset + 1] != ' ') return false;
            if (s[1][offset + 2] != '*') return false;
            if (s[2][offset + 0] != '*') return false;
            if (s[2][offset + 1] != '*') return false;
            if (s[2][offset + 2] != '*') return false;
            if (s[3][offset + 0] != ' ') return false;
            if (s[3][offset + 1] != ' ') return false;
            if (s[3][offset + 2] != '*') return false;
            if (s[4][offset + 0] != '*') return false;
            if (s[4][offset + 1] != '*') return false;
            return s[4][offset + 2] == '*';
        }
    }
}