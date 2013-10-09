using System;

class Pillars
{
    static void Main()
    {
        int[,] array = new int[8, 8];
        int number;
        string str;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            str = Console.ReadLine();
            number = int.Parse(str);
            for (int j = array.GetLength(1) - 1; j >= 0; j--)
            {
                array[i, j] = number % 2;
                number /= 2;
            }
        }
        int leftCells = 0, rightCells = 0, pNumber = 20, currentCells = 0;
        for (int i = 0; i <= 7; i++)
        {
            leftCells = 0;
            rightCells = 0;
            for (int j = 0; j <= 7; j++)
            {
                for (int k = i + 1; k <= 7; k++)
                {
                    if (array[j, k] == 1)
                    {
                        leftCells++;
                    }
                }
            }
            for (int j = 0; j <= 7; j++)
            {
                for (int k = 0; k <= i - 1; k++)
                {
                    if (array[j, k] == 1)
                    {
                        rightCells++;
                    }
                }
            }
            if (leftCells == rightCells & i < pNumber)
            {
                pNumber = i;
                currentCells = rightCells;
            }
        }
        if (pNumber < 20)
        {
            Console.WriteLine(7 - pNumber);
            Console.WriteLine(currentCells);
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

