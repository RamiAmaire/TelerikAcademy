using System;
using System.Text;

public class Demo
{
    private static void FindPath(string[,] lab, int currentRow, int currentCol, StringBuilder currentArea, ref string largestArea)
    {
        if (CheckIfInsideLab(lab, currentRow, currentCol))
        {
            if (lab[currentRow, currentCol] == " ")
            {
                lab[currentRow, currentCol] = "visited";
                currentArea.Append(string.Format(" -> ({0},{1})", currentRow, currentCol));

                FindPath(lab, currentRow - 1, currentCol, currentArea, ref largestArea); // UP
                FindPath(lab, currentRow, currentCol + 1, currentArea, ref largestArea); // Right
                FindPath(lab, currentRow + 1, currentCol, currentArea, ref largestArea); // Down
                FindPath(lab, currentRow, currentCol - 1, currentArea, ref largestArea); // Left

                if (currentArea.Length > largestArea.Length)
                {
                    largestArea = currentArea.ToString();
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

    public static void Main()
    {
        string[,] lab =  
        {
            {" ", " ", " ", "*", "*", " ", " ", " "},
            {"*", "*", " ", "*", "*", " ", "*", " "},
            {" ", " ", " ", "*", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", "*", " ", " ", " ", " "},
        };

        string currentLargestArea = string.Empty;
        string largestArea = string.Empty;

        for (int row = 0; row < lab.GetLength(0); row++)
        {
            for (int col = 0; col < lab.GetLength(1); col++)
            {
                if (lab[row, col] == " ")
                {
                    FindPath(lab, row, col, new StringBuilder(), ref currentLargestArea);
                    if (currentLargestArea.Length > largestArea.Length)
                    {
                        largestArea = currentLargestArea;
                    }
                } 
            }
        }

        Console.WriteLine(largestArea.Substring(4));
    }
}

