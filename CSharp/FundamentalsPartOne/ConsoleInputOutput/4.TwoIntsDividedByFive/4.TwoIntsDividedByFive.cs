using System;

class TwoIntsDividedByFive
{
    static void Main()
    {
        Console.Write("Enter 1st number= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter 2nd number= ");
        int m = int.Parse(Console.ReadLine());
        int i;
        int br = 0;
        if (m > n)
        {
            for (i = n; i <= m; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                    br++;
                }
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Broqt e = " + br);
        }
        if (n > m)
        {
            for (i = m; i <= n; i++)
            {
                if (i % 5 == 0)
                {
                    Console.WriteLine(i);
                    br++;
                }
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Broqt e = " + br);
        }
    }
}
