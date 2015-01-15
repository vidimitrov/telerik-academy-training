using System;
using System.Collections.Generic;
using System.Linq;

namespace Mines
{
	public class Mine
	{
		public class MinesweeperPoints
		{
			string name;
			int points;

			public string Name
			{
				get { return name; }
				set { name = value; }
			}

			public int Points
			{
				get { return points; }
				set { points = value; }
			}

			public MinesweeperPoints() { }

			public MinesweeperPoints(string name, int points)
			{
				this.name = name;
				this.points = points;
			}
		}

		static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] field = CreateField();
			char[,] bombs = PlantBombs();
			int counter = 0;
			bool explosion = false;
			List<MinesweeperPoints> champions = new List<MinesweeperPoints>(6);
			int row = 0;
			int col = 0;
			bool firstFlag = true;
			const int max = 35;
			bool secondFlag = false;

			do
			{
				if (firstFlag)
				{
					Console.WriteLine("Let's play Minesweeper. Try your luck to find cells without mines." +
					" Command 'top' - shows highscores, 'restart' - restarts the game, 'exit' - quit!");
					InitializeField(field);
					firstFlag = false;
				}
				Console.Write("Enter row and col (space separated) : ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					    int.TryParse(command[2].ToString(), out col) &&
					    row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}
				switch (command)
				{
					case "top":
						ShowHighScores(champions);
						break;
					case "restart":
						field = CreateField();
						bombs = PlantBombs();
						InitializeField(field);
						explosion = false;
						firstFlag = false;
						break;
					case "exit":
						Console.WriteLine("Bye, bye!");
						break;
					case "turn":
						if (bombs[row, col] != '*')
						{
							if (bombs[row, col] == '-')
							{
								ChangeTurn(field, bombs, row, col);
								counter++;
							}
							if (max == counter)
							{
								secondFlag = true;
							}
							else
							{
								InitializeField(field);
							}
						}
						else
						{
							explosion = true;
						}
						break;
					default:
						Console.WriteLine("\nMistake! Invalid command\n");
						break;
				}
				if (explosion)
				{
					InitializeField(bombs);
					Console.Write("\nGame over! Your score - {0} points. " +
						"Enter your nickname: ", counter);
					string nickname = Console.ReadLine();
					MinesweeperPoints highscore = new MinesweeperPoints(nickname, counter);
					if (champions.Count < 5)
					{
						champions.Add(highscore);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
							if (champions[i].Points < highscore.Points)
							{
								champions.Insert(i, highscore);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
					champions.Sort((MinesweeperPoints r1, MinesweeperPoints r2) => r2.Name.CompareTo(r1.Name));
					champions.Sort((MinesweeperPoints r1, MinesweeperPoints r2) => r2.Points.CompareTo(r1.Points));
					ShowHighScores(champions);

					field = CreateField();
					bombs = PlantBombs();
					counter = 0;
					explosion = false;
					firstFlag = true;
				}
				if (secondFlag)
				{
					Console.WriteLine("\nCongratulation! You succeded.");
					InitializeField(bombs);
					Console.WriteLine("Enter your name: ");
					string username = Console.ReadLine();
					MinesweeperPoints points = new MinesweeperPoints(username, counter);
					champions.Add(points);
					ShowHighScores(champions);
					field = CreateField();
					bombs = PlantBombs();
					counter = 0;
					secondFlag = false;
					firstFlag = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria");
			Console.WriteLine("Vote us on www.minesweeper.com :)");
			Console.Read();
		}

		private static void ShowHighScores(List<MinesweeperPoints> points)
		{
			Console.WriteLine("\nPoints:");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells",
						i + 1, points[i].Name, points[i].Points);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty HighScores!\n");
			}
		}

		private static void ChangeTurn(char[,] field,
			char[,] bombs, int row, int col)
		{
			char bombsScore = GetScore(bombs, row, col);
			bombs[row, col] = bombsScore;
			field[row, col] = bombsScore;
		}

		private static void InitializeField(char[,] board)
		{
			int boardRows = board.GetLength(0);
			int boardCols = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < boardRows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < boardCols; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardCols = 10;
			char[,] board = new char[boardRows, boardCols];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardCols; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlantBombs()
		{
			int boardRows = 5;
			int boardCols = 10;
			char[,] field = new char[boardRows, boardCols];

			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardCols; j++)
				{
					field[i, j] = '-';
				}
			}

			List<int> randomPositions = new List<int>();
			while (randomPositions.Count < 15)
			{
				Random randomGenerator = new Random();
				int randomPosition = randomGenerator.Next(50);
				if (!randomPositions.Contains(randomPosition))
				{
					randomPositions.Add(randomPosition);
				}
			}

			foreach (int position in randomPositions)
			{
				int col = (position / boardCols);
				int row = (position % boardCols);
				if (row == 0 && position != 0)
				{
					col--;
					row = boardCols;
				}
				else
				{
					row++;
				}
				field[col, row - 1] = '*';
			}

			return field;
		}

		private static void CalculateScore(char[,] field)
		{
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					if (field[i, j] != '*')
					{
						char currentScore = GetScore(field, i, j);
						field[i, j] = currentScore;
					}
				}
			}
		}

		private static char GetScore(char[,] field, int row, int col)
		{
			int scores = 0;
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			if (row - 1 >= 0)
			{
				if (field[row - 1, col] == '*')
				{ 
					scores++; 
				}
			}
			if (row + 1 < rows)
			{
				if (field[row + 1, col] == '*')
				{ 
					scores++; 
				}
			}
			if (col - 1 >= 0)
			{
				if (field[row, col - 1] == '*')
				{ 
					scores++;
				}
			}
			if (col + 1 < cols)
			{
				if (field[row, col + 1] == '*')
				{ 
					scores++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (field[row - 1, col - 1] == '*')
				{ 
					scores++; 
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (field[row - 1, col + 1] == '*')
				{ 
					scores++; 
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (field[row + 1, col - 1] == '*')
				{ 
					scores++; 
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (field[row + 1, col + 1] == '*')
				{ 
					scores++; 
				}
			}
			return char.Parse(scores.ToString());
		}
	}
}
