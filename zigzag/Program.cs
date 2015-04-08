using System;

namespace zigzag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var value = int.Parse(Console.ReadLine());
            Console.WriteLine(GenerateString(77, "A".ToCharArray()).ToLower());

            //Console.WriteLine(Calculate(new[] {'A', 'O', 'A', 'Z'}, 'B'));

            //var value = 77;
            //var curVal = 0;
            //var currentString = "aoazb";
            //var curStr = "AA";
            //while (curVal != value && curStr.Length < 5)
            //{
            //    curStr = NextString(curStr);
            //    Console.WriteLine(curStr);
            //    curVal = Calculate(curStr);
            //}
            //Console.WriteLine(curStr.ToLower());

            //Console.WriteLine((char)('A'+2));
        }

        public static string GenerateString(int value, char[] arr)
        {
            for (var c = 65; c <= 90; c++)
            {
                if (Calculate(arr, (char)c) == value)
                {
                    return new string(arr) + (char)c;
                }
            }
            if (arr.Length < 4)
            {
                return GenerateString(value, (new string(arr) + 'A').ToCharArray());    
            }
            return "";
        }

        public static string NextString(string str)
        {
            var arr = str.ToCharArray();
            var last = arr[arr.Length - 1];
            if (last != 'Z')
            {
                arr[arr.Length - 1] = (char)(last + 1);
                return new string(arr);
            }
            arr[arr.Length - 1] = 'A';
            return new string(arr) + 'A';
        }

        public static int Calculate(char[] carr, int c)
        {
            var sum = 0;
            var str = new string(carr) + (char)c;
            Console.WriteLine("Calculating {0}", str);
            for (var i = 0; i < str.Length - 1; i++)
            {
                var tmp = (str[i] - 64) - (str[i + 1] - 64);
                if (tmp < 0) tmp *= (-1);
                sum += tmp;
            }
            return sum;
        }
    }
}
