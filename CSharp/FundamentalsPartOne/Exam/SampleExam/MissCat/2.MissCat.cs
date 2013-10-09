using System;

class MissCat2011
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[11];
        int i = 0;
        string input;
        int votes;
        int s=0;
        int pos = 0;
        while (i<n)
        {
            input = Console.ReadLine();
            votes = int.Parse(input);
            arr[votes]++;
            i++;
        }
        for (int j = 0; j < arr.Length; j++)
        {
            if (s < arr[j])
            {
                s = arr[j];
                pos = j;
            }
        }
        Console.WriteLine(pos);
    }
}

