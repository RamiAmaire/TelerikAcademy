using System;
using System.Collections.Generic;
using System.Text;

public class Demo
{
    private static void FindPath(string[,] lab, int currentRow, int currentCol, ref StringBuilder currentArea)
    {
        if (CheckIfInsideLab(lab, currentRow, currentCol))
        {
            if (lab[currentRow, currentCol] == " ")
            {
                lab[currentRow, currentCol] = "visited";
                currentArea.Append(string.Format(" -> ({0},{1})", currentRow, currentCol));

                FindPath(lab, currentRow - 1, currentCol, ref currentArea); // UP
                FindPath(lab, currentRow, currentCol + 1, ref currentArea); // Right
                FindPath(lab, currentRow + 1, currentCol, ref currentArea); // Down
                FindPath(lab, currentRow, currentCol - 1, ref currentArea); // Left
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

    public static void Main()
    {
        string[,] lab =  
        {
            {" ", " ", " ", "*", "*", " ", " ", " "},
            {"*", "*", " ", "*", "*", "*", "*", " "},
            {" ", " ", " ", "*", " ", " ", " ", "*"},
            {" ", "*", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", "*", " ", " ", " ", " "},
        };

        StringBuilder currentArea = new StringBuilder();
        List<string> allPassableAreas = new List<string>();

        for (int row = 0; row < lab.GetLength(0); row++)
        {
            for (int col = 0; col < lab.GetLength(1); col++)
            {
                if (lab[row, col] == " ")
                {
                    FindPath(lab, row, col, ref currentArea);
                    allPassableAreas.Add(currentArea.ToString().Substring(4));
                    currentArea.Clear();
                }
            }
        }

        Console.WriteLine("All passable areas: ");
        Console.WriteLine();
        foreach (var area in allPassableAreas)
        {
            Console.WriteLine(area);
            Console.WriteLine();
        }
    }
}

