namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            int currentLeftIndex = left;
            int currentRightIndex = right;
            T pivot = collection[(left + right) / 2];

            while (currentLeftIndex <= currentRightIndex)
            {
                while (collection[currentLeftIndex].CompareTo(pivot) < 0)
                {
                    currentLeftIndex++;
                }

                while (collection[currentRightIndex].CompareTo(pivot) > 0)
                {
                    currentRightIndex--;
                }

                if (currentLeftIndex <= currentRightIndex)
                {
                    // Swap
                    T oldValue = collection[currentLeftIndex];
                    collection[currentLeftIndex] = collection[currentRightIndex];
                    collection[currentRightIndex] = oldValue;

                    currentLeftIndex++;
                    currentRightIndex--;
                }
            }

            // Recursive calls
            if (left < currentRightIndex)
            {
                this.QuickSort(collection, left, currentRightIndex);
            }

            if (currentLeftIndex < right)
            {
                this.QuickSort(collection, currentLeftIndex, right);
            }
        }
    }
}
