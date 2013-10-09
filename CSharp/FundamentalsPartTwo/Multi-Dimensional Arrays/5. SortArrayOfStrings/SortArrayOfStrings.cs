using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SortArrayOfStrings
{
    static void ReadList(List<string>arr, int len)
    {
        for (int i = 0; i < len; i++)
        {
            arr.Add(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.Write("Enter length of arr= ");
        int len = int.Parse(Console.ReadLine());
        List<string> arr = new List<string>();
        ReadList(arr, len);
        Dictionary<string, int> dic = new Dictionary<string, int>();
        for (int i = 0; i < arr.Count; i++)
        {
            dic.Add(arr[i], arr[i].Length);
        }
        var items = from pair in dic
                    orderby pair.Value ascending
                    select pair;
        Console.WriteLine("Sorted: ");
        foreach (KeyValuePair<string, int> pair in items)
        {
            Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
        }
    }
}
