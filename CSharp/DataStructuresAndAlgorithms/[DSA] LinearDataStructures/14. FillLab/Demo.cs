using System;
using System.Collections.Generic;

namespace FillLabyrinth
{
    public class Demo
    {
        private static Position GetStartPosition(string[,] lab)
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == "*")
                    {
                        for (int i = 0; i < directions.Count; i++)
                        {
                            if (ValidatePosition(lab, row + directions[i].Top, col + directions[i].Left))
                            {
                                return new Position(row + directions[i].Top, col + directions[i].Left);
                            }
                        }
                    }
                }
            }

            return new Position(0, 0);
        }

        private static bool ValidatePosition(string[,] lab, int row, int col)
        {
            bool isValid = false;
            if (
                row >= 0 &&
                col >= 0 &&
                row < lab.GetLength(0) &&
                col < lab.GetLength(1) &&
                lab[row, col] == "0")
            {
                isValid = true;
            }

            return isValid;
        }

        private static void FinishFilling(string[,] lab)
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == "0")
                    {
                        lab[row, col] = "u";
                    }
                }
            }
        }

        private static void PrintLab(string[,] lab)
        {
            Console.Clear();
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    Console.Write(lab[row, col] + "  ");
                }

                Console.WriteLine();
            }
        }

        private static void FillLab(string[,] lab, Position startPosition)
        {
            Queue<Position> que = new Queue<Position>();
            que.Enqueue(startPosition);
            int counter = 1;
            lab[startPosition.Row, startPosition.Col] = counter.ToString();

            while (que.Count > 0)
            {
                Position currentPositon = que.Dequeue();
                int currRow = currentPositon.Row;
                int currCol = currentPositon.Col;

                for (int i = 0; i < directions.Count; i++)
                {
                    if (ValidatePosition(lab, currRow + directions[i].Top, currCol + directions[i].Left))
                    {
                        currentPositon = new Position(currRow + directions[i].Top, currCol + directions[i].Left);
                        que.Enqueue(currentPositon);
                        counter++;
                        lab[currRow + directions[i].Top, currCol + directions[i].Left] = counter.ToString();
                    }
                }

                PrintLab(lab);
            }

            FinishFilling(lab);
            PrintLab(lab);
        }

        private static List<Direction> directions = new List<Direction>()
        {
            new Direction(-1, 0),
            new Direction(0, 1),
            new Direction(1, 0),
            new Direction(0, -1),
        };

        public static void Main()
        {
            string[,] lab = new string[,]
            {
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "*", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"},
            };

            Position startPosition = GetStartPosition(lab);
            FillLab(lab, startPosition);

            // I know the numeration is not as it should be, but it's almost done.
            // I hope you can give me an advice. :)
        }
    }
}


