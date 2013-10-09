namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var itm in this.items)
            {
                if ((dynamic)itm == (dynamic)item)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            List<T> collection = this.items as List<T>;
            collection.Sort();
            return BinSearch(collection, item);
        }

        private bool BinSearch(List<T> collection, T searchedItem)
        {
            int left = 0;
            int right = collection.Count - 1;
            int mid = 0;

            while (left <= right)
            {
                mid = (left + right) / 2;
                if ((dynamic)collection[mid] == (dynamic)searchedItem )
                {
                    return true;
                }
                else if ((dynamic)searchedItem < (dynamic)collection[mid])
                {
                    right = mid - 1;
                }
                else if ((dynamic)searchedItem > (dynamic)collection[mid])
                {
                    left = mid + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var rand = new Random();
            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int randNumber = rand.Next(i + 1);
                T temp = this.items[i];
                this.items[i] = this.items[randNumber];
                this.items[randNumber] = temp;
            }

            // Linear complexity.
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
