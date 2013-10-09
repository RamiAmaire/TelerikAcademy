using System;

class SumofNFibonacciNumbers
{
    static void Main()
    {
        int i;
        int n;
        Console.Write("Enter n= ");
        n = int.Parse(Console.ReadLine());
        int a = 0;
        int temp;
        int b = 1;
        int s = 0;
        for (i = 0; i <= n - 1; i++)
        {
            temp = a;
            a = b;
            b = b + temp;
            Console.WriteLine(temp);
            s = s + temp;
        }
        Console.WriteLine("Sum is= " + s);
    }
}

