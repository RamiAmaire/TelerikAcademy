using System;

class IntegerOddOrEven
{
    static void Main()
    {
        Console.Write("Vuvedete chislo : ");
        int chislo = System.Convert.ToInt32(Console.ReadLine());
        if (chislo % 2 == 0)
        {
            Console.WriteLine("Chisloto e chetno");
        }
        else
        {
            Console.WriteLine("Chisloto e nechetno");
        }
    }
}
