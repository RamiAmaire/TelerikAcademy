using System;

class BinaryDigitsCount
{
    static void Main()
    {
        string str = Console.ReadLine();
        byte A = byte.Parse(str);
        str = Console.ReadLine();
        ushort N = ushort.Parse(str);
        uint currNumber;
        Int64 binaryHolder;
        int[] Binarysum = new int[N];
        for (int i = 0; i < N; i++)
        {
            Binarysum[i] = 0;
        }
        for (int i = 0; i < N; i++)
        {
            str = Console.ReadLine();
            currNumber = uint.Parse(str);
            while (currNumber > 0)
            {
                binaryHolder = currNumber % 2;
                if (binaryHolder == A)
                {
                    Binarysum[i]++;
                }
                currNumber /= 2;
            }
        }
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(Binarysum[i]);
        }
    }
}

