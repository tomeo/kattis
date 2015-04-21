using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace t9spelling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            string input;
            var count = 1;
            var t9 = new T9Mapper();
            while ((input = Console.ReadLine()) != null)
            {
                Console.WriteLine("Case #{0}: {1}", count++, t9.Map(input.ToLower()));
            }
        }

        public class T9Mapper
        {
            private Dictionary<char, string> _map = new Dictionary<char, string>
            {
                {'a', "2"},
                {'b', "22"},
                {'c', "222"},
                {'d', "3"},
                {'e', "33"},
                {'f', "333"},
                {'g', "4"},
                {'h', "44"},
                {'i', "444"},
                {'j', "5"},
                {'k', "55"},
                {'l', "555"},
                {'m', "6"},
                {'n', "66"},
                {'o', "666"},
                {'p', "7"},
                {'q', "77"},
                {'r', "777"},
                {'s', "7777"},
                {'t', "8"},
                {'u', "88"},
                {'v', "888"},
                {'w', "9"},
                {'x', "99"},
                {'y', "999"},
                {'z', "9999"},
                {' ', "0"}
            };

            public string Map(string s)
            {
                var sb = new StringBuilder();
                var last = '\0';
                foreach (var c in s)
                {
                    string value;
                    _map.TryGetValue(c, out value);
                    if (value.First() == last)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(value);
                    last = value.Last();
                }
                return sb.ToString().Trim();
            }
        }
    }
}