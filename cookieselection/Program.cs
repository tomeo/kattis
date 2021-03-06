﻿using System;
using System.Collections.Generic;

namespace cookieselection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var warehouse = new CookieWarehouse();
            string input;
            while ((input = Console.ReadLine()) != null)
            {
                if (input == "#")
                {
                    Console.WriteLine(warehouse.GetAndRemoveMedian());
                }
                else
                {
                    warehouse.Insert(int.Parse(input));
                }
            }
        }
    }

    public class MinCompare : IComparer<int>
    {
      public int Compare(int x, int y)
      {
          return x.CompareTo(y);
      }
    }

    public class MaxCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class CookieWarehouse
    {
        private BinaryHeap _min;
        private BinaryHeap _max;

        public CookieWarehouse()
        {
            _min = new BinaryHeap(new MinCompare());
            _max = new BinaryHeap(new MaxCompare());
        }

        public void Insert(int element)
        {
            var median = Median();
            if (_min.Count == 0 || element == _min.Peek())
            {
                _min.Insert(element);
            }
            else if (_max.Count == 0 || element == _max.Peek())
            {
                _max.Insert(element);
            }
            else if (!median.HasValue || element > median)
            {
                _min.Insert(element);
            }
            else
            {
                _max.Insert(element);
            }
            ShiftHeads();
            Rebalance();
        }

        private int? Median()
        {
            if (_min.Count > _max.Count) return _min.Peek();
            if (_max.Count > _min.Count) return _max.Peek();
            if (_min.Count > 0 && _min.Count == _max.Count) return _min.Peek();
            return null;
        }

        public int GetAndRemoveMedian()
        {
            return _max.Count > _min.Count ? _max.RemoveRoot() : _min.RemoveRoot();
        }

        private void ShiftHeads()
        {
            if (_min.Count <= 0 || _max.Count <= 0) return;
            if (_min.Peek() >= _max.Peek()) return;
            var min = _min.RemoveRoot();
            var max = _max.RemoveRoot();
            _min.Insert(max);
            _max.Insert(min);
        }

        private void Rebalance()
        {
            if (_max.Count - _min.Count > 1)
            {
                _min.Insert(_max.RemoveRoot());
            }
            else if (_min.Count - _max.Count > 1)
            {
                _max.Insert(_min.RemoveRoot());
            }
        }
    }

    public class BinaryHeap
    {
        private readonly IComparer<int> _comparer;
        private List<int> _nodes = new List<int>();

        public BinaryHeap(IComparer<int> comp)
        {
            _comparer = comp;
        }
        
        public int Count { get { return _nodes.Count; }}

        public void Insert(int newItem)
        {
            var i = Count;
            _nodes.Add(newItem);
            while (i > 0 && _comparer.Compare(_nodes[(i - 1) / 2], newItem) > 0)
            {
                _nodes[i] = _nodes[(i - 1) / 2];
                i = (i - 1) / 2;
            }
            _nodes[i] = newItem;
        }

        public int Peek()
        {
            if (_nodes.Count == 0)
            {
                return -1;
            }
            return _nodes[0];
        }
        
        public int RemoveRoot()
        {
            if (_nodes.Count == 0)
            {
                return -1;
            }
            // Get the first item
            var rslt = _nodes[0];
            // Get the last item and bubble it down.
            var tmp = _nodes[_nodes.Count - 1];
            _nodes.RemoveAt(_nodes.Count - 1);
            if (_nodes.Count > 0)
            {
                var i = 0;
                while (i < _nodes.Count / 2)
                {
                    var j = (2 * i) + 1;
                    if ((j < _nodes.Count - 1) && (_comparer.Compare(_nodes[j], _nodes[j + 1]) > 0))
                    {
                        ++j;
                    }
                    if (_comparer.Compare(_nodes[j], tmp) >= 0)
                    {
                        break;
                    }
                    _nodes[i] = _nodes[j];
                    i = j;
                }
                _nodes[i] = tmp;
            }
            return rslt;
        }
    }
}