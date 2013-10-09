using System;

class Lines
{
    static void Main()
    {
        int[,] array = new int[8, 8];
        string str;
        int n;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            str = Console.ReadLine();
            n = int.Parse(str);
            for (int j = array.GetLength(1) - 1; j >= 0; j--)
            {
                array[i, j] = n % 2;
                n /= 2;
            }
        }
        int longest = 0;
        int length = 0;
        int lbit = 1;
        int maxlength = int.MinValue;
        int cbit = 0;
        for (int j = 0; j < 8; j++)
        {
            for (int i = 0; i < 8; i++)
            {
                cbit = array[i, j];

                if (lbit == 0 && cbit == 1)
                {
                    length++;
                }
                else if (lbit == 1 && cbit == 1)
                {
                    length++;
                }
                else if (lbit == 1 && cbit == 0)
                {
                    if (length == maxlength)
                    {
                        longest++;
                    }
                    if (length > maxlength)
                    {
                        maxlength = length;
                        longest = 1;
                    }
                    length = 0;
                }
                if (i == 7)
                {
                    if (length == maxlength)
                    {
                        longest++;
                    }
                    if (length > maxlength)
                    {
                        maxlength = length;
                        longest = 1;
                    }
                    length = 0;
                }
                lbit = cbit;
            }
            lbit = 1;
        }
        cbit = 0;
        lbit = 1;
        length = 0;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                cbit = array[i, j];

                if (lbit == 0 && cbit == 1)
                {
                    length++;
                }
                else if (lbit == 1 && cbit == 1)
                {
                    length++;
                }
                else if (lbit == 1 && cbit == 0)
                {
                    if (length == maxlength)
                    {
                        longest++;
                    }
                    if (length > maxlength)
                    {
                        maxlength = length;
                        longest = 1;
                    }
                    length = 0;
                }
                if (j == 7)
                {
                    if (length == maxlength)
                    {
                        longest++;
                    }
                    if (length > maxlength)
                    {
                        maxlength = length;
                        longest = 1;
                    }
                    length = 0;
                }
                lbit = cbit;
            }
            lbit = 1;
        }
        Console.WriteLine(maxlength);
        if (maxlength != 0)
        {
            if (maxlength == 1)
            {
                Console.WriteLine(longest / 2);
            }
            else
            {
                Console.WriteLine(longest);
            }
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}

