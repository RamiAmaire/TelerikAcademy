using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    public static dynamic WithLambda(int[] arr)
    {
        var numbers = arr.Where(num => ((num % 3 == 0) && (num % 7 == 0)));
        return numbers;
    }
    public static dynamic WithLINQ(int[] arr)
    {
        var numbers =
            from number in arr
            where ((number % 3 == 0) && (number % 7 == 0))
            select number;
        return numbers;
    }
    public static int[] FillArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }
        return arr;
    }
    static void Main()
    {
        int[] arr = new int[100];
        arr = FillArray(arr);
        dynamic numbers = WithLINQ(arr);
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
