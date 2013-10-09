using System;

class SubsetSums
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        long n = long.Parse(Console.ReadLine());
        long[] arr = new long[n];
        long[] sumarr = new long[n * n];
        for (long i = 0; i < arr.Length; i++)
        {
            arr[i] = long.Parse(Console.ReadLine());
        }
        long br = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if ((arr[i] == s) && (br==0))
            {
                br++;
            }
        }
        long br1 = 0;
        for (long i = 0; i < arr.Length - 1; i++)
        {
            for (long j = i+1; j < arr.Length; j++)
            {
                if ((arr[i] + arr[j])==s)
                {
                    br1++;
                }
            }
        }
        Console.WriteLine(br+br1);
    }
}

