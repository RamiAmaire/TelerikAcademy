namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int min = 0;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if ((dynamic)collection[j] < (dynamic)collection[min])
                    {
                        min = j;
                    }
                }

                T temp = collection[i];
                collection[i] = collection[min];
                collection[min] = temp;
            }
        }
    }
}
