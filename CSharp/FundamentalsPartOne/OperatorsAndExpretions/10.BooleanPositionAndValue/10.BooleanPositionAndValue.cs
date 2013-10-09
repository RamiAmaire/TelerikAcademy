using System;

class BooleanPositionAndValue
{
    static void Main()
    {
        Console.Write("Enter a number= ");
        int v = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter a position= ");
        int p = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        int m = 1;
        m = 1 << p;
        Console.WriteLine("The number in binary is= " + System.Convert.ToString(v, 2));
        Console.WriteLine("The mask in binary is= " + System.Convert.ToString(m, 2));
        bool one = ((v & m) != 0);
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(one);
    }
}
