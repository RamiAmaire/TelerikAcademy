using System;
class IntThirdDigit7
{
    static void Main()
    {
        Console.Write("Vuvedete chislo: ");
        int chislo = System.Convert.ToInt32(Console.ReadLine());
        int chislo1 = chislo / 100;
        if (chislo1 % 10 == 7)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}
