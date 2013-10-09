using System;

public class Demo
{
    private static void FindPath(string[,] lab, int currentRow, int currentCol)
    {
        if (CheckIfInsideLab(lab, currentRow, currentCol))
        {
            if (currentRow == 99 && currentCol == 99)
            {
                Console.WriteLine("Found exit.");
            }
            else
            {
                if (lab[currentRow, currentCol] == " ")
                {
                    lab[currentRow, currentCol] = "visited";

                    FindPath(lab, currentRow - 1, currentCol); // UP
                    FindPath(lab, currentRow, currentCol + 1); // Right
                    FindPath(lab, currentRow + 1, currentCol); // Down
                    FindPath(lab, currentRow, currentCol - 1); // Left
                }
            }
        }
    }

    private static bool CheckIfInsideLab(string[,] lab, int row, int col)
    {
        bool isInside = false;
        if (row >= 0 && col >= 0 && row < lab.GetLength(0) && col < lab.GetLength(1))
        {
            isInside = true;

        }

        return isInside;
    }

    private static string[,] GenerateLab(int rows, int cols)
    {
        string[,] lab = new string[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                lab[row, col] = " ";
            }
        }

        return lab;
    }

    public static void Main()
    {
        string[,] lab = GenerateLab(100, 100);
        FindPath(lab, 0, 0);
    }
}

