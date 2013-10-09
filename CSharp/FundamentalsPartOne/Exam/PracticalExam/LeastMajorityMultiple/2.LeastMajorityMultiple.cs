using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());
        int br = 0;
        for (int i = 1; i < int.MaxValue; i++)
        {
            if (i % a == 0)
            {
                br++;
            }
            if (i % b == 0)
            {
                br++;
            }
            if (i % c == 0)
            {
                br++;
            }
            if (br == 3)
            {
                Console.WriteLine(i);
                return;
            }
            if (i % d == 0)
            {
                br++;
            }
            if (br == 3)
            {
                Console.WriteLine(i);
                return;
            }
            if (i % e == 0)
            {
                br++;
            }
            if (br == 3)
            {
                Console.WriteLine(i);
                return;
            }
            br = 0;
        }
    }
}

