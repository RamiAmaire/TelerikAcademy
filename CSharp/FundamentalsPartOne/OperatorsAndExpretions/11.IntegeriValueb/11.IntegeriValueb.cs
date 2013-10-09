using System;

class IntegeriValueb
{
    static void Main()
    {
        Console.Write("Enter number= ");
        int i = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter position= ");
        int position = System.Convert.ToInt32(Console.ReadLine());
        string binary = Convert.ToString(i, 2);
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Our number in binary= " + binary);
        int b = 1;
        int mask = b << position;
        Console.WriteLine("Our mask in binay= " + Convert.ToString(mask, 2));
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(new string('-', 40));
        if ((mask & i) == 0)
        {
            Console.WriteLine("Value= 0");
        }
        else
        {
            Console.WriteLine("Value= 1");
        }
    }
}
