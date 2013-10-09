using System;

class PositiveIntIsPrime
{
static void Main()
{
    Console.Write("Vuvedete chislo= ");
    int n = System.Convert.ToInt32(Console.ReadLine());
    int i;
    int s = 0;
    for (i = 1; i <= 100; i++)
    {
        if (n % i == 0)
        {
            s = s + i;
        }
    }
    Console.WriteLine(new string('-', 40));
    if (s == n + 1)
    {
        Console.WriteLine("Chisloto e prosto ");
    }
    else
    {
        Console.WriteLine("Chisloto ne e prosto ");
    }
}
}
