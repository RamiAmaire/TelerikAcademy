using System;

class FallDown
{
    static void Main()
    {
        int[,] arr = new int[8, 8];
        int number;
        string str;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            str = Console.ReadLine();
            number = int.Parse(str);
            for (int j = arr.GetLength(1) - 1; j >= 0; j--)
            {
                arr[i, j] = number % 2;
                number /= 2;
            }
        }
        for (int k = 0; k < 8; k++)
        {
            for (int i = arr.GetLength(0) - 2; i >= 0; i--)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 1 && arr[i + 1, j] == 0)
                    {
                        arr[i, j] = 0;
                        arr[i + 1, j] = 1;
                    }
                }
            }
        }
        string res = "";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                res += arr[i, j];
            }
            res = Convert.ToInt32(res, 2).ToString();
            Console.WriteLine(res);
            res = "";
        }
    }
}
