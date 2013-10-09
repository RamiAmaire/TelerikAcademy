using System;

class SequenceOfFibonacci
{
    static void Main()
    {
        long a = 0;
        long b = 1;
        long temp;

        Console.WriteLine(a);
        for (int i = 0; i < 100; i++)
        {
            temp = a;
            a = b;
            b = temp + b;
            Console.WriteLine(a);
        }
    }
}
