using System;
using System.Collections.Generic;

namespace cd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ');
            var n = int.Parse(inputs[0]);
            var m = int.Parse(inputs[1]);
            var jack = new HashSet<string>();
            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                var cd = Console.ReadLine();
                if (!jack.Contains(cd))
                {
                    jack.Add(cd);
                }
                else
                {
                    sum++;
                }
            }
            var jill = new HashSet<string>();
            for (var i = 0; i < m; i++)
            {
                var cd = Console.ReadLine();
                if (jack.Contains(cd) || jill.Contains(cd))
                {
                    sum++;
                }
                else
                {
                    jill.Add(cd);
                }
            }
            Console.WriteLine(sum);
        }
    }
}