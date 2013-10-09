using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Tasks
{
    static double Minimum(params double[] arr)
    {
        double lowest = double.MaxValue;
        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[j] <= lowest)
            {
                lowest = arr[j];
            }
        }
        return lowest;
    }
    static double Maximum(params double[] arr)
    {
        double greatest = double.MinValue;
        for (int j = 0; j < arr.Length; j++)
        {
            if (arr[j] >= greatest)
            {
                greatest = arr[j];
            }
        }
        return greatest;
    }
    static double Sum(params double[] arr)
    {
        double sum = 0;
        for (int k = 0; k < arr.Length; k++)
        {
            sum = sum + arr[k];
        }
        return sum;
    }
    static double Average(params double[] arr)
    {
        double average = Sum(arr) / arr.Length;
        return average;
    }
    static double Product(params double[] arr)
    {
        double product = 1;
        for (int i = 0; i < arr.Length; i++)
        {
            product = product * arr[i];
        }
        return product;
    }
    static void Main()
    {
        Console.Write("Enter length of array= ");
        int len = int.Parse(Console.ReadLine());
        double[] arr = new double[len];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        double finalMin = Minimum(arr);
        Console.WriteLine("The lowest number is: {0}", finalMin);
        double finalmax = Maximum(arr);
        Console.WriteLine("The greatest number is: {0}", finalmax);
        double finalSum = Sum(arr);
        Console.WriteLine("The sum of all the numbers is: {0}", finalSum);
        double finalAverage = Average(arr);
        Console.WriteLine("The average value of all the numbers is: {0}", finalAverage);
        double finalProduct = Product(arr);
        Console.WriteLine("The product of all the numbers is: {0}", finalProduct);
    }
}
