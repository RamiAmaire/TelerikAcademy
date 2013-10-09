using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FindLargestNumberSmallerThenK
{
    static void ReadList(List<int> arr,int len)
    {
        for (int i = 0; i < len; i++)
        {
            Console.Write("arr[{0}]= ",i);
            arr.Add(int.Parse(Console.ReadLine()));
        }
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K= ");
        int k = int.Parse(Console.ReadLine());
        List<int> arr = new List<int>();
        ReadList(arr,n);
        arr.Sort();
        int max = 0;
        for (int i = arr.Count-1; i >= 0; i--)
        {
            if (arr[i]<k)
            {
                max = arr[i];
                break;
            }
        }
        int position = arr.BinarySearch(max);
        Console.WriteLine("Element {0} at position {1}",max,position);
    }
}
