namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private void FinishMerge(IList<T> collection, IList<T> side, int holderIndex, int sideIndex)
        {
            while (sideIndex < side.Count)
            {
                collection[holderIndex++] = side[sideIndex++];
            }
        }

        private void Merge(IList<T> collection, IList<T> leftSide, IList<T> rightSide)
        {
            int collectionIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (collectionIndex < collection.Count)
            {
                if ((dynamic)leftSide[leftIndex] < (dynamic)rightSide[rightIndex])
                {
                    collection[collectionIndex++] = leftSide[leftIndex++];
                    if (leftIndex == leftSide.Count)
                    {
                        this.FinishMerge(collection, rightSide, collectionIndex, rightIndex);
                        return;
                    }
                }
                else
                {
                    collection[collectionIndex++] = rightSide[rightIndex++];
                    if (rightIndex == rightSide.Count)
                    {
                        this.FinishMerge(collection, leftSide, collectionIndex, leftIndex);
                        return;
                    }
                }
            }
        }

        private void SelectionSort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                T minElement = collection[i];
                int minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if ((dynamic)collection[j] < (dynamic)minElement)
                    {
                        minElement = collection[j];
                        minElementIndex = j;
                    }
                }

                T temp = collection[i];
                collection[i] = minElement;
                collection[minElementIndex] = temp;
            }
        }

        private IList<T> Split(IList<T> collection, int start, int end)
        {
            IList<T> subCollection = new List<T>();
            for (int i = start; i < end; i++)
            {
                subCollection.Add(collection[i]);
            }

            return subCollection;
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count < 2)
            {
                return;
            }

            IList<T> leftSide = this.Split(collection, 0, collection.Count / 2);
            IList<T> rightSide = this.Split(collection, collection.Count / 2, collection.Count);

            this.MergeSort(leftSide);
            this.MergeSort(rightSide);

            this.SelectionSort(leftSide);
            this.SelectionSort(rightSide);
            this.Merge(collection, leftSide, rightSide);
        }

        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection);
        }
    }
}
