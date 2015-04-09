using System;

namespace zigzag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var value = int.Parse(Console.ReadLine());
            var length = CalculateMinLength(value);
            var current = GenerateNew(length);
            while (Calculate(current) != value)
            {
                current = Next(current);
            }
            Console.WriteLine(new string(current).ToLower());
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

        private static char IncrementChar(char c)
        {
            return (c == 'Z') ? 'A' : (char) (c + 1);
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
            for (var i = 0; i < length; i++) arr[i] = 'A';
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
