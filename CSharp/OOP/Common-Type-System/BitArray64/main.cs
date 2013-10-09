using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        BitArray64 arr = new BitArray64(10);
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = (ulong)i+5;
        }
        var asd = arr.OrderByDescending(x => x);
        foreach (var item in asd)
        {
            Console.WriteLine(item);
        }
    }
}
