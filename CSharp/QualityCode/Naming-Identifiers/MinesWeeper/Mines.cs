namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class makes console implementation of the game 
    /// "Minesweeper".
    /// First we introduce variables and generate the playing
    /// and bombing fields. The engine of the game is runned on
    /// the do/while loop where the player is asked to give
    /// position via row and col. If the input is valid the
    /// game will procceed and will check if the player stepped
    /// on a bomb, if so the game ends, the player's points and
    /// name are saved in the rankings of the game and everything
    /// starts again.
    /// </summary>
	public class Mines
	{
        public const int MAX = 35;

		private static void Main()
		{
			char[,] playField = CreatePlayField();
            char[,] bombField = CreateBombField();
            List<Score> champions = new List<Score>();

            string command = string.Empty;

            int row = 0;
            int col = 0;
            int turnCounter = 0;

            bool isFirstTurn = true;
            bool boom = false;
            bool isLastTurn = false;

			do
			{
				if (isFirstTurn)
				{
                    Console.WriteLine("Let's play 'Mines'! " + 
                        "Try your luck finding fields without bombs." +
					" Command 'top' shows the standing, 'restart' starts" +
                    " a new game and 'exit' closes the game and says " + 
                    "'Goodbye and thank you !'");

					PrintField(playField);
					isFirstTurn = false;
				}

				Console.Write("Please, enter row and column (separated by space) : ");
                command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= playField.GetLength(0) &&
                        col <= playField.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						Standing(champions);
						break;

					case "restart":
						playField = CreatePlayField();
						bombField = CreateBombField();
						PrintField(playField);
						boom = false;
						isFirstTurn = false;
						break;

					case "exit":
						Console.WriteLine("Bye, bye!");
						break;

					case "turn":
						if (bombField[row, col] != '*')
						{
							if (bombField[row, col] == '-')
							{
								SetSurroundingBombsCount(playField, bombField, row, col);
								turnCounter++;
							}

							if (MAX == turnCounter)
							{
								isLastTurn = true;
							}
							else
							{
								PrintField(playField);
							}
						}
						else
						{
							boom = true;
						}

						break;

					default:
						Console.WriteLine(
                            Environment.NewLine +
                            "Error! Invalid command, please try again" +
                            Environment.NewLine);
						break;
				}

				if (boom)
				{
					PrintField(bombField);
					Console.Write(
                        Environment.NewLine +
                        "Grrrrr! You died heroically with {0} points. " +
						"Please, give your nickname : ",
                        turnCounter);

					string nickName = Console.ReadLine();
					Score result = new Score(nickName, turnCounter);

					if (champions.Count < 5)
					{
						champions.Add(result);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Points < result.Points)
							{
								champions.Insert(i, result);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}

                    // Sorting the current result by name and points
					champions.Sort((Score firstResult, Score secondResult) =>
                        secondResult.Name.CompareTo(firstResult.Name));
					champions.Sort((Score firstResult, Score secondResult) =>
                        secondResult.Points.CompareTo(firstResult.Points));

					Standing(champions);

                    // Setting the variables to their default values
					playField = CreatePlayField();
					bombField = CreateBombField();
					turnCounter = 0;
					boom = false;
					isFirstTurn = true;
				}

				if (isLastTurn)
				{
					Console.WriteLine(Environment.NewLine +
                        "Well done ! You've reached to the end.");
					PrintField(bombField);

					Console.WriteLine("Give your nickname, tough guy : ");
					string nickName = Console.ReadLine();

					Score result = new Score(nickName, turnCounter);
					champions.Add(result);

					Standing(champions);

                    // Resetting 
					playField = CreatePlayField();
					bombField = CreateBombField();
					turnCounter = 0;
					isLastTurn = false;
					isFirstTurn = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria motherfuckers!");
			Console.WriteLine("Yeah!!!");
			Console.Read();
		}

        private static char[,] CreatePlayField()
        {
            int rows = 5;
            int cols = 10;

            char[,] playField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playField[i, j] = '?';
                }
            }

            return playField;
        }

        private static char[,] CreateBombField()
        {
            int rows = 5;
            int cols = 10;

            char[,] bombField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bombField[i, j] = '-';
                }
            }

            List<int> numbers = new List<int>();
            while (numbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);

                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }

            foreach (int number in numbers)
            {
                int row = number / cols;
                int col = number % cols;

                if (col == 0 && number != 0)
                {
                    row--;
                    col = cols;
                }
                else
                {
                    col++;
                }

                bombField[row, col - 1] = '*';
            }

            return bombField;
        }

		private static void PrintField(char[,] playField)
		{
			int row = playField.GetLength(0);
			int col = playField.GetLength(1);

			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");

			for (int i = 0; i < row; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < col; j++)
				{
					Console.Write(string.Format("{0} ", playField[i, j]));
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine("   ---------------------");
		}

        private static void SetSurroundingBombsCount(
            char[,] playField,
            char[,] bombField,
            int row,
            int col)
        {
            char bombsCount = CountTheBombsSurrounding(
                bombField,
                row,
                col);

            bombField[row, col] = bombsCount;
            playField[row, col] = bombsCount;
        }

		private static char CountTheBombsSurrounding(
            char[,] field,
            int currentRow,
            int currentCol)
		{
			int bombs = 0;
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			if (currentRow - 1 >= 0)
			{
				if (field[currentRow - 1, currentCol] == '*')
				{ 
					bombs++; 
				}
			}

			if (currentRow + 1 < rows)
			{
				if (field[currentRow + 1, currentCol] == '*')
				{ 
					bombs++; 
				}
			}

			if (currentCol - 1 >= 0)
			{
				if (field[currentRow, currentCol - 1] == '*')
				{ 
					bombs++;
				}
			}

			if (currentCol + 1 < cols)
			{
				if (field[currentRow, currentCol + 1] == '*')
				{ 
					bombs++;
				}
			}

			if ((currentRow - 1 >= 0) && (currentCol - 1 >= 0))
			{
				if (field[currentRow - 1, currentCol - 1] == '*')
				{ 
					bombs++; 
				}
			}

			if ((currentRow - 1 >= 0) && (currentCol + 1 < cols))
			{
				if (field[currentRow - 1, currentCol + 1] == '*')
				{ 
					bombs++; 
				}
			}

			if ((currentRow + 1 < rows) && (currentCol - 1 >= 0))
			{
				if (field[currentRow + 1, currentCol - 1] == '*')
				{ 
					bombs++; 
				}
			}

			if ((currentRow + 1 < rows) && (currentCol + 1 < cols))
			{
				if (field[currentRow + 1, currentCol + 1] == '*')
				{ 
					bombs++; 
				}
			}

			return char.Parse(bombs.ToString());
		}

        private static void Standing(List<Score> points)
        {
            Console.WriteLine(Environment.NewLine + "Score : ");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} cells",
                        i + 1,
                        points[i].Name,
                        points[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty standing." + Environment.NewLine);
            }
        }
	}
}
