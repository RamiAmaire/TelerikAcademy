using System;

class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int s = int.Parse(Console.ReadLine());
            int snew = 0;
            while (s > 0)
            {
                snew <<= 1;
                if ((s & 1) == 1)
                {
                    snew |= 1;
                }
                s >>= 1;
            }
            Console.WriteLine(snew);
        }
    }
}

