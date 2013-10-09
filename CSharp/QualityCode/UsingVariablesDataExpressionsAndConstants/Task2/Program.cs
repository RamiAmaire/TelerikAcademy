using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    /// <summary>
    ///  Print's statistics for max, min and average 
    ///  of a given double array.
    /// </summary>
    /// <param name="arr">Double array.</param>
    public static void PrintStatistics(double[] arr)
    {
        // Getting values
        double max = GetMax(arr);
        double min = GetMin(arr);
        double average = GetAverage(arr);

        // Printing values
        Console.WriteLine("Max = " + max);
        Console.WriteLine("Min = " + min);
        Console.WriteLine("Average = " + average);
    }

    private static double GetMax(double[] arr)
    {
        double max = double.MinValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        return max;
    }

    private static double GetMin(double[] arr)
    {
        double min = double.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }

    private static double GetAverage(double[] arr)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        double average = sum / arr.Length;

        return average;
    }

    private static void Main()
    {
        double[] arr = new double[] 
        { 
            1, 2, 3, 4, 5, 32, 4, 5, 6, 32, 33, 6, 32, 1 
        };

        PrintStatistics(arr);
    }
}
