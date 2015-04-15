using System;
using System.Collections.Generic;
using System.Linq;

namespace busnumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            var buses = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(buses);
            var output = new List<string>();
            var i = 0;
            while(i < buses.Length)
            {
                var j = i+1;
                while (j < buses.Length && buses[j] - buses[j - 1] == 1) j++;
                if (buses[j-1] - buses[i] == 0)
                {
                    output.Add(buses[i].ToString());
                    i++;
                }
                else if (buses[j-1]-buses[i] == 1)
                {
                    output.Add(buses[i].ToString());
                    output.Add(buses[j-1].ToString());
                    i+=2;
                }
                else
                {
                    output.Add(string.Format("{0}-{1}", buses[i], buses[j-1]));
                    i += (j - i);
                }
            }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
