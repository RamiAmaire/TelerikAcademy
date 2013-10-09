using System;
using System.Text;

public class Demo
{
    private static void FindAllPaths(string[,] lab, Cell currentCell, Cell wantedCell, string path)
    {
        int currentRow = currentCell.Row;
        int currentCol = currentCell.Col;

        if (CheckIfInsideLab(lab, currentRow, currentCol))
        {
            if (currentRow == wantedCell.Row && currentCol == wantedCell.Col)
            {
                path += string.Format(" -> ({0},{1})", currentRow, currentCol);
                Console.WriteLine(path.Substring(4));
                Console.WriteLine();
            }
            else
            {
                if (lab[currentRow, currentCol] == " ")
                {
                    lab[currentRow, currentCol] = "visited";
                    path += string.Format(" -> ({0},{1})", currentRow, currentCol);

                    FindAllPaths(lab, new Cell(currentRow - 1, currentCol), wantedCell, path); // UP
                    FindAllPaths(lab, new Cell(currentRow, currentCol + 1), wantedCell, path); // Right
                    FindAllPaths(lab, new Cell(currentRow + 1, currentCol), wantedCell, path); // Down
                    FindAllPaths(lab, new Cell(currentRow, currentCol - 1), wantedCell, path); // Left

                    lab[currentRow, currentCol] = " ";
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
            {" ", " ", " ", " ", " ", " ", " ", " "},
            {" ", "*", "*", "*", "*", "*", "*", " "},
            {" ", " ", " ", " ", " ", " ", " ", " "},
        };

        Cell startingCell = new Cell(0, 0);
        Cell endCell = new Cell(4, 7);
        string path = string.Empty;
        FindAllPaths(lab, startingCell, endCell, path);
    }
}

