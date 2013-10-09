using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MergeSort
{
    static void Sort(int[] arr)
    {
        int min;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
    }
    static void MergeSrt(int leftLen, int rightLen, int sortedLen, int[] leftArray, int[] rightArray, int[] sortedArray)
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int sortedIndex = 0;
        while (sortedIndex < sortedLen)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                sortedArray[sortedIndex] = leftArray[leftIndex];
                leftIndex++;
                sortedIndex++;
            }
            else
            {
                sortedArray[sortedIndex] = rightArray[rightIndex];
                rightIndex++;
                sortedIndex++;
            }
            if (leftIndex > leftArray.Length - 1)
            {
                for (int i = rightIndex; i < rightArray.Length; i++)
                {
                    sortedArray[sortedIndex] = rightArray[i];
                    sortedIndex++;
                }
            }
            if (rightIndex > rightArray.Length - 1)
            {
                for (int j = leftIndex; j < leftArray.Length; j++)
                {
                    sortedArray[sortedIndex] = leftArray[j];
                    sortedIndex++;
                }
            }
        }
    }
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.Write("Enter array length: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] array = new int[arrLen];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(array);
        int lastElement = array.Length - 1;
        int firstElement = 0;
        int mid = (lastElement + firstElement + 1) / 2;
        int[] leftArray = new int[(array.Length / 2) + 1];
        int[] rightArray = new int[(array.Length / 2)];
        for (int i = 0; i <= mid; i++)
        {
            leftArray[i] = array[i];
        }
        int index = -1;
        for (int i = mid + 1; i < array.Length; i++)
        {
            index++;
            rightArray[index] = array[i];
        }
        Sort(leftArray);
        Sort(rightArray);
        int[] sortedArray = new int[array.Length];
        MergeSrt(leftArray.Length, rightArray.Length, sortedArray.Length, leftArray, rightArray, sortedArray);
        Console.Write("MergeSorted: {");
        for (int i = 0; i < sortedArray.Length; i++)
        {
            if (i < sortedArray.Length - 1)
            {
                Console.Write(sortedArray[i] + ",");
            }
            else
            {
                Console.Write(sortedArray[i]);
            }
        }
        Console.WriteLine("}");
    }
}
