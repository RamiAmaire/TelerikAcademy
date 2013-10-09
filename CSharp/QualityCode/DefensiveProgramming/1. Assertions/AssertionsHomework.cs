using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr.Length != 0, "Array does not contain any elements");
        Debug.Assert(arr != null, "Array is not initialized");
        
        for (int index = 0; index < arr.Length-1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }
  
    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is not initialized");
        Debug.Assert(arr.Length != 0, "Array does not contain any elements");
        Debug.Assert(startIndex >= 0 || startIndex < arr.Length,
            "Start index must be bigger than -1 and smaller than array's length");
        Debug.Assert(
            endIndex > startIndex|| endIndex < arr.Length,
            "End index must be bigger than start index and smaller than array's length.");

        T[] savedArr = arr;
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        Debug.Assert(savedArr == arr, "The array values must not be changed.");

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "Array is not initialized");
        Debug.Assert(arr.Length != 0, "Array does not contain any elements");

        T[] sortedArr = arr.OrderBy(x => x).ToArray();
        Debug.Assert(sortedArr == arr,
            "Binary search only works with sorted arrays.");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(startIndex >= 0 || startIndex < arr.Length,
            "Start index must be bigger than -1 and smaller than array's length");
        Debug.Assert(
            endIndex > startIndex || endIndex < arr.Length,
            "End index must be bigger than start index and smaller than array's length.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the left half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[1]); // Test sorting single element array
        //SelectionSort(new int[0]); // Test sorting empty array


        int[] arr1 = new int[] {8, 3, 5};

        //Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr1, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
