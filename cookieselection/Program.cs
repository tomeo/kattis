using System;
using System.Collections;
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
                    Console.WriteLine("Shipping cookie with median {0}", warehouse.Median());
                }
                else
                {
                    warehouse.Insert(int.Parse(input));
                    warehouse.Rebalance();
                }
            }
        }
    }

    public class CookieWarehouse
    {
        // Every element in the min-heap is greater or equal to the median
        private BinaryHeap<int> _min;
        // Every element in the max-heap is less or equal to the median
        private BinaryHeap<int> _max;

        public CookieWarehouse()
        {
            _min = new BinaryHeap<int>();
            _max = new BinaryHeap<int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        }

        public void Insert(int element)
        {
            if (_min.Count == 0)
            {
                Console.WriteLine("Adding {0} to min", element);
                _min.Insert(element);
                return;
            }
            if (_max.Count == 0)
            {
                Console.WriteLine("Adding {0} to max", element);
                _max.Insert(element);
                return;
            }
            if (element == _min.Peek())
            {
                Console.WriteLine("Adding duplicate {0} to min", element);
                _min.Insert(element);
                return;
            }
            if (element == _max.Peek())
            {
                Console.WriteLine("Adding duplicate {0} to max", element);
                _max.Insert(element);
                return;
            }
            int median;
            if (_min.Count == _max.Count || _max.Count > _min.Count)
            {
                median = _max.Peek();
            }
            else
            {
                median = _min.Peek();
            }
            Console.WriteLine("Median is {0}", median);
            if (element > median)
            {
                Console.WriteLine("Adding {0} to min", element);
                _min.Insert(element);
            }
            else
            {
                Console.WriteLine("Adding {0} to max", element);
                _max.Insert(element);
            }
        }

        public int Median()
        {
            if (_max.Count > _min.Count) return _max.RemoveRoot();
            return _min.RemoveRoot();
        }

        public void Rebalance()
        {
            if (_min.Count > 0 && _min.Count == _max.Count)
            {
                if (_max.Peek() > _min.Peek())
                {
                    var min = _min.RemoveRoot();
                    var max = _max.RemoveRoot();
                    _min.Insert(max);
                    _max.Insert(min);
                    Console.WriteLine("Shifting {0} (min) with {1} (max)", min, max);
                }
            }
            if (_max.Count - _min.Count > 1)
            {
                var max = _max.RemoveRoot();
                Console.WriteLine("Moving {0} from max to min", max);
                _min.Insert(max);
            }
            else if (_min.Count - _max.Count > 1)
            {
                var min = _min.RemoveRoot();
                Console.WriteLine("Moving {0} from min to max", min);
                _max.Insert(_min.RemoveRoot());
            }
            else
            {
                Console.WriteLine("No rebalance needed");
            }
        }
    }

    public class BinaryHeap<T> : IEnumerable<T>
    {
        private readonly IComparer<T> Comparer;
        private List<T> Items = new List<T>();
        public BinaryHeap() : this(Comparer<T>.Default) {}

        public BinaryHeap(IComparer<T> comp)
        {
            Comparer = comp;
        }
        
        public int Count { get { return Items.Count; }}

        public void Clear()
        {
            Items.Clear();
        }
        
        public void TrimExcess()
        {
            Items.TrimExcess();
        }

        public void Insert(T newItem)
        {
            var i = Count;
            Items.Add(newItem);
            while (i > 0 && Comparer.Compare(Items[(i - 1) / 2], newItem) > 0)
            {
                Items[i] = Items[(i - 1) / 2];
                i = (i - 1) / 2;
            }
            Items[i] = newItem;
        }

        public T Peek()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }
            return Items[0];
        }
        
        public T RemoveRoot()
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }
            // Get the first item
            T rslt = Items[0];
            // Get the last item and bubble it down.
            T tmp = Items[Items.Count - 1];
            Items.RemoveAt(Items.Count - 1);
            if (Items.Count > 0)
            {
                var i = 0;
                while (i < Items.Count / 2)
                {
                    var j = (2 * i) + 1;
                    if ((j < Items.Count - 1) && (Comparer.Compare(Items[j], Items[j + 1]) > 0))
                    {
                        ++j;
                    }
                    if (Comparer.Compare(Items[j], tmp) >= 0)
                    {
                        break;
                    }
                    Items[i] = Items[j];
                    i = j;
                }
                Items[i] = tmp;
            }
            return rslt;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>) Items).GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}