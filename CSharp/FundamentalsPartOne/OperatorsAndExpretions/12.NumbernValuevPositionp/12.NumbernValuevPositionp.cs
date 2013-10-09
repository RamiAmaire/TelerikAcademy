using System;
class NumbernValuevPositionp
{
    static void Main()
    {
        Console.Write("Enter Number= ");
        int n = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Value= ");
        int v = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Position= ");
        int p = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Number in binary is = " + System.Convert.ToString(n, 2));
        int m = 1;
        m = 1 << p;
        int result = 0;
        Console.WriteLine("Mask in binary is = " + System.Convert.ToString(m, 2));
        Console.WriteLine(new string('-', 40));
        if (v == 1)
        {
            m = 1 << p;
            result = n | m;
            Console.WriteLine("The result is= " + System.Convert.ToString(result, 2));
        }
        else
        {
            m = ~(1 << p);
            result = n & m;
            Console.WriteLine("The result is= " + result + " or " + System.Convert.ToString(result, 2));
        }
    }
}