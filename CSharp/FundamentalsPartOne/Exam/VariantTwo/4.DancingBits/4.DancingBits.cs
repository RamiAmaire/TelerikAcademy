using System;

class DancingBits
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        string bits = "";
        for (int i = 1; i <= n; i++)
        {
            long value = long.Parse(Console.ReadLine());
            bits += Convert.ToString(value, 2);
        }
        int lenght = 0;
        char pbit = '2';
        int res = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] == pbit)
            {
                lenght += 1;
            }
            else
            {
                if (lenght == k)
                {
                    res += 1;
                }
                lenght = 1;
            }
            pbit = bits[i];
        }
        if (lenght == k)
        {
            res += 1;
        }
        Console.WriteLine(res);
    }
}

