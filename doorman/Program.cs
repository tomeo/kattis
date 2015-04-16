using System;

namespace doorman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());
            var queue = Console.ReadLine();
            var men = 0;
            var women = 0;
            var i = 0;
            while(i < queue.Length)
            {
                if (queue[i] == 'M') men++;
                else women++;
                if (Math.Abs(men - women) > x && (i + 1) != queue.Length && queue[i] != queue[i + 1])
                {
                    
                }
                i++;
            }
            Console.WriteLine(i+1);
        }
    }
}
