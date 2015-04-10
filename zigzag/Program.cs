using System;
using System.Diagnostics;

namespace zigzag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sw = new Stopwatch();
            //var value = int.Parse(Console.ReadLine());
            sw.Start();
            for (var value = 1; value <= 500; value++)
            {
                var length = CalculateMinLength(value);
                var current = GenerateNew(length);
                while (Calculate(current) != value)
                {
                    current = Next(current);
                }
                Console.WriteLine("{0} = {1}", value, new string(current).ToLower());
            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
        }
        private static char[] Next(char[] arr)
        {
            var index = arr.Length - 1;
            while (arr[index] == 'Z')
            {
                arr[index] = 'A';
                --index;
            }
            arr[index] = (arr[index] == 'Z') ? 'A' : (char)(arr[index] + 1);
            return arr;
        }

        private static int CalculateMinLength(int value)
        {
            if (value <= 25) return 2;
            var quote = value/25;
            var rem = value%25;
            if (rem == 0) return quote + 1;
            return quote + 2;
        }

        private static char[] GenerateNew(int length)
        {
            var arr = new char[length];
            var current = 'Z';
            for (var i = arr.Length-1; i > 0; i--)
            {
                arr[i] = current;
                current = current == 'Z' ? 'A' : 'Z';
            }
            arr[0] = 'A';
            return arr;
        }

        public static int Calculate(char[] carr)
        {
            var str = new string(carr);
            var sum = 0;
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
