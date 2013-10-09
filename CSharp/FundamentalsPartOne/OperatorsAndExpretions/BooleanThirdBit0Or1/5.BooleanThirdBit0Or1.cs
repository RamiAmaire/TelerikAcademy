using System;

class BooleanThirdBit0Or1
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = System.Convert.ToInt32(Console.ReadLine());
        string binary = Convert.ToString(number, 2);
        string binary1 = Convert.ToString(8, 2);
        Console.WriteLine(binary + Environment.NewLine + binary1);
        Console.WriteLine(new string('-', 40));
        int result = (number & 8);
        if (result == 0)
        {
            Console.WriteLine("The 3rd bit is = 0 ");
        }
        else
        {
            Console.WriteLine("The 3rd bit is = 1 ");
        }
    }
}
