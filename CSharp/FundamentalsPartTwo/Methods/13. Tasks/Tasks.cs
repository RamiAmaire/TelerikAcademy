using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Tasks
{
    static string[] ReverseDigits(string number)
    {
        string[] result = new string[number.Length];
        int k = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            result[k] = Convert.ToString(number[i]);
            k++;
        }
        return result;
    }
    static double FindingAverage(double[] arr, int length)
    {
        double sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        double result = sum / length;
        return result;
    }
    static void ReadArr(double[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Enter numbers: ");
            arr[i] = double.Parse(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.WriteLine("Hello,to which one of the tasks do you want to proceed ?");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("For reversing digits press 1");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("For calculating the median of an subsequence press 2");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("For (a * x + b) press 3");
        Console.WriteLine(new string('-', 40));
        int n = int.Parse(Console.ReadLine());
        if ((n < 1) || (n > 3))
        {
            Console.WriteLine("Error ! ");
        }
        else
        {
            if (n == 1)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Congratulations (task1), lets Do it !");
                Console.Write("Now give me a number= ");
                string number = Console.ReadLine();
                string[] result = ReverseDigits(number);
                Console.Write("Digits reversed= ");
                for (int i = 0; i < number.Length; i++)
                {
                    Console.Write(result[i]);
                }
            }
            if (n == 2)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Congratulations (task2), lets Do it !");
                Console.Write("Now give me length= ");
                int len = int.Parse(Console.ReadLine());
                double[] arr = new double[len];
                ReadArr(arr);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("The average is= {0}", FindingAverage(arr, len));
            }
            if (n == 3)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Congratulations (task3), lets Do it ! ");
                Console.Write("a= ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b= ");
                int b = int.Parse(Console.ReadLine());
                int x = -(b / a);
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("x= {0}", x);
            }
        }
    }
}
