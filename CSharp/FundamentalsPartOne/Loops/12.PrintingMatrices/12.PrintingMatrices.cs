using System;

class PrintingMatrices
{
    static void Main()
    {
        Console.Write("Enter n= ");
        int n = int.Parse(Console.ReadLine());
        if (n > 19)
        {
            Console.WriteLine("Error!");
            return;
        }
        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col <= n + row - 1; col++)
            {
                Console.Write("  " + col);
            }
            Console.WriteLine();
        }
    }
}

