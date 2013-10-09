using System;

class CatalanFormula
{
    static void Main()
    {
        Console.Write("Enter n= ");
        int n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            Console.WriteLine("Error!");
            return;
        }
        int up = 1;
        int down = 1;
        for (int i = 1; i <= n * 2; i++)
        {
            up *= i;
        }
        for (int j = 1; j <= n; j++)
        {
            down *= j;
        }
        int sup = up / down;
        int sdown = 1;
        for (int x = 1; x <= n + 1; x++)
        {
            sdown *= x;
        }
        Console.WriteLine("Cn= " + sup / sdown);
    }
}

