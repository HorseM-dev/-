using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

public class MatrixOperations
{
	private static Random random = new Random();

	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("--- Операції з матрицями (Завдання 2, Варіант 15) ---");

		Console.Write("Оберіть тип масиву (1 - Прямокутний, 2 - Ступінчастий): ");
		string arrayTypeChoice = Console.ReadLine();
		bool useRectangular = (arrayTypeChoice == "1");

		if (arrayTypeChoice != "1" && arrayTypeChoice != "2")
		{
			Console.WriteLine("Невірний вибір типу масиву. Програма завершує роботу.");
			return;
		}

		int m, n;
		Console.Write("Введіть кількість рядків (m): ");
		if (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
		{
			Console.WriteLine("Некоректна кількість рядків. Програма завершує роботу.");
			return;
		}

		if (useRectangular)
		{
			Console.Write("Введіть кількість стовпців (n): ");
			if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
			{
				Console.WriteLine("Некоректна кількість стовпців. Програма завершує роботу.");
				return;
			}
		}
		else
		{
			n = 0;
		}

		Console.WriteLine("\nОберіть спосіб отримання початкових значень елементів:");
		Console.WriteLine("1. Діалог з користувачем (введення з клавіатури)");
		Console.WriteLine("2. Зчитати з файлу даних");
		Console.WriteLine("3. Згенерувати випадкові значення");
		Console.Write("Ваш вибір (1, 2 або 3): ");

		string inputChoice = Console.ReadLine();

		object matrixA = null;

		switch (inputChoice)
		{
			case "1":
				if (useRectangular) matrixA = ReadRectangularMatrixFromKeyboard(m, n);
				else matrixA = ReadJaggedMatrixFromKeyboard(m);
				break;
			case "2":
				if (useRectangular) matrixA = ReadRectangularMatrixFromFile(out m, out n);
				else matrixA = ReadJaggedMatrixFromFile(out m);
				break;
			case "3":
				int maxRandomValue;
				Console.Write("Введіть максимальне значення для випадкових чисел (наприклад, 100): ");
				if (!int.TryParse(Console.ReadLine(), out maxRandomValue))
				{
					maxRandomValue = 100;
					Console.WriteLine("Некоректне значення. Використано 100.");
				}

				if (useRectangular) matrixA = GenerateRandomRectangularMatrix(m, n, maxRandomValue);
				else matrixA = GenerateRandomJaggedMatrix(m, maxRandomValue);
				break;
			default:
				Console.WriteLine("Невірний вибір. Програма завершує роботу.");
				return;
		}

		if (matrixA == null)
		{
			Console.WriteLine("Матриця не була успішно заповнена. Програма завершує роботу.");
			return;
		}

		Console.WriteLine("\n--- Початкова матриця A ---");
		if (useRectangular) PrintRectangularMatrix((int[,])matrixA);
		else PrintJaggedMatrix((int[][])matrixA);

		Console.WriteLine("\n--- Матриця C (елементи A^2) ---");
		if (useRectangular) CalculateAndPrintSquaredRectangularMatrix((int[,])matrixA);
		else CalculateAndPrintSquaredJaggedMatrix((int[][])matrixA);

		Console.WriteLine("\n--- Зміни у матриці A згідно з правилами ---");
		if (useRectangular) SwapRowsOrColumnsRectangular((int[,])matrixA);
		else SwapRowsOrColumnsJagged((int[][])matrixA);

		Console.WriteLine("\n--- Матриця A після змін ---");
		if (useRectangular) PrintRectangularMatrix((int[,])matrixA);
		else PrintJaggedMatrix((int[][])matrixA);

		Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}

	private static int[,] ReadRectangularMatrixFromKeyboard(int m, int n)
	{
		int[,] matrix = new int[m, n];
		Console.WriteLine($"Введіть {m}x{n} елементів матриці рядок за рядком:");
		for (int i = 0; i < m; i++)
		{
			Console.Write($"Рядок {i + 1} (розділіть числа пробілами): ");
			string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (line.Length != n)
			{
				Console.WriteLine($"Помилка: Потрібно {n} елементів у рядку. Спробуйте знову.");
				i--;
				continue;
			}
			for (int j = 0; j < n; j++)
			{
				if (!int.TryParse(line[j], out matrix[i, j]))
				{
					Console.WriteLine($"Помилка: '{line[j]}' не є дійсним числом. Спробуйте знову.");
					i--;
					break;
				}
			}
		}
		return matrix;
	}

	private static int[,] ReadRectangularMatrixFromFile(out int m, out int n)
	{
		m = 0; n = 0;
		Console.Write("Введіть ім'я файлу для прямокутної матриці (наприклад, matrix_input_rect.txt): ");
		string fileName = Console.ReadLine();
		try
		{
			string[] lines = File.ReadAllLines(fileName);
			if (lines.Length < 1) throw new FormatException("Файл порожній або не містить розмірів.");

			string[] dimensions = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (dimensions.Length < 2 || !int.TryParse(dimensions[0], out m) || !int.TryParse(dimensions[1], out n) || m <= 0 || n <= 0)
			{
				throw new FormatException("Некоректний формат розмірів у першому рядку файлу. Очікується 'm n'.");
			}

			if (lines.Length < m + 1) throw new FormatException("Кількість рядків у файлі не відповідає оголошеним розмірам.");

			int[,] matrix = new int[m, n];
			for (int i = 0; i < m; i++)
			{
				string[] rowElements = lines[i + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				if (rowElements.Length != n) throw new FormatException($"Рядок {i + 1} у файлі має {rowElements.Length} елементів, очікується {n}.");
				for (int j = 0; j < n; j++)
				{
					if (!int.TryParse(rowElements[j], out matrix[i, j]))
					{
						throw new FormatException($"Некоректне число у рядку {i + 1}, стовпці {j + 1}: '{rowElements[j]}'.");
					}
				}
			}
			Console.WriteLine($"Прямокутна матриця {m}x{n} успішно зчитана з файлу '{fileName}'.");
			return matrix;
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine($"Помилка: Файл '{fileName}' не знайдено.");
			return null;
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Помилка формату даних у файлі: {ex.Message}");
			return null;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Виникла помилка при читанні файлу: {ex.Message}");
			return null;
		}
	}

	private static int[,] GenerateRandomRectangularMatrix(int m, int n, int maxVal)
	{
		int[,] matrix = new int[m, n];
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				matrix[i, j] = random.Next(-maxVal, maxVal + 1);
			}
		}
		Console.WriteLine($"Прямокутна матриця {m}x{n} заповнена випадковими числами.");
		return matrix;
	}

	private static void PrintRectangularMatrix(int[,] matrix)
	{
		if (matrix == null)
		{
			Console.WriteLine("Матриця порожня.");
			return;
		}
		int m = matrix.GetLength(0);
		int n = matrix.GetLength(1);
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				Console.Write($"{matrix[i, j],6}");
			}
			Console.WriteLine();
		}
	}

	private static void CalculateAndPrintSquaredRectangularMatrix(int[,] matrixA)
	{
		int m = matrixA.GetLength(0);
		int n = matrixA.GetLength(1);
		int[,] matrixC = new int[m, n];

		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				matrixC[i, j] = matrixA[i, j] * matrixA[i, j];
				Console.Write($"{matrixC[i, j],6}");
			}
			Console.WriteLine();
		}
	}

	private static void SwapRowsOrColumnsRectangular(int[,] matrix)
	{
		if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
		{
			Console.WriteLine("Матриця порожня, зміна неможлива.");
			return;
		}

		int m = matrix.GetLength(0);
		int n = matrix.GetLength(1);

		int minVal = matrix[0, 0];
		int maxVal = matrix[0, 0];
		int minRow = 0, minCol = 0;
		int maxRow = 0, maxCol = 0;

		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (matrix[i, j] < minVal)
				{
					minVal = matrix[i, j];
					minRow = i;
					minCol = j;
				}
				if (matrix[i, j] > maxVal)
				{
					maxVal = matrix[i, j];
					maxRow = i;
					maxCol = j;
				}
			}
		}

		Console.WriteLine($"Знайдено: Мін. елемент ({minVal}) в [{minRow},{minCol}], Макс. елемент ({maxVal}) в [{maxRow},{maxCol}]");

		if (minRow != maxRow)
		{
			Console.WriteLine($"Міняємо місцями рядок {minRow} та рядок {maxRow}.");
			for (int j = 0; j < n; j++)
			{
				int temp = matrix[minRow, j];
				matrix[minRow, j] = matrix[maxRow, j];
				matrix[maxRow, j] = temp;
			}
		}
		else
		{
			Console.WriteLine($"Мін. та макс. елементи в одному рядку ({minRow}). Міняємо місцями стовпець {minCol} та стовпець {maxCol}.");
			for (int i = 0; i < m; i++)
			{
				int temp = matrix[i, minCol];
				matrix[i, minCol] = matrix[i, maxCol];
				matrix[i, maxCol] = temp;
			}
		}
	}

	private static int[][] ReadJaggedMatrixFromKeyboard(int m)
	{
		int[][] matrix = new int[m][];
		Console.WriteLine($"Введіть {m} рядків матриці. Для кожного рядка спочатку введіть кількість стовпців, потім елементи:");
		for (int i = 0; i < m; i++)
		{
			Console.Write($"Рядок {i + 1}: Введіть кількість стовпців: ");
			int rowLength;
			if (!int.TryParse(Console.ReadLine(), out rowLength) || rowLength <= 0)
			{
				Console.WriteLine("Некоректна кількість стовпців. Спробуйте знову.");
				i--;
				continue;
			}
			matrix[i] = new int[rowLength];
			Console.Write($"Введіть {rowLength} елементів для рядка {i + 1} (розділіть числа пробілами): ");
			string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (line.Length != rowLength)
			{
				Console.WriteLine($"Помилка: Потрібно {rowLength} елементів у рядку. Спробуйте знову.");
				i--;
				continue;
			}
			for (int j = 0; j < rowLength; j++)
			{
				if (!int.TryParse(line[j], out matrix[i][j]))
				{
					Console.WriteLine($"Помилка: '{line[j]}' не є дійсним числом. Спробуйте знову.");
					i--;
					break;
				}
			}
		}
		return matrix;
	}

	private static int[][] ReadJaggedMatrixFromFile(out int m)
	{
		m = 0;
		Console.Write("Введіть ім'я файлу для ступінчастої матриці (наприклад, matrix_input_jagged.txt): ");
		string fileName = Console.ReadLine();
		try
		{
			string[] lines = File.ReadAllLines(fileName);
			if (lines.Length < 1) throw new FormatException("Файл порожній або не містить кількості рядків.");

			if (!int.TryParse(lines[0], out m) || m <= 0)
			{
				throw new FormatException("Некоректний формат кількості рядків у першому рядку файлу.");
			}

			if (lines.Length < m + 1) throw new FormatException("Кількість рядків у файлі не відповідає оголошеній кількості.");

			int[][] matrix = new int[m][];
			for (int i = 0; i < m; i++)
			{
				string[] rowParts = lines[i + 1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				if (rowParts.Length < 1) throw new FormatException($"Рядок {i + 1} у файлі порожній.");

				int rowLength;
				if (!int.TryParse(rowParts[0], out rowLength) || rowLength < 0)
				{
					throw new FormatException($"Некоректна кількість стовпців для рядка {i + 1}: '{rowParts[0]}'.");
				}

				if (rowParts.Length - 1 != rowLength) throw new FormatException($"Кількість елементів у рядку {i + 1} ({rowParts.Length - 1}) не відповідає оголошеній кількості стовпців ({rowLength}).");

				matrix[i] = new int[rowLength];
				for (int j = 0; j < rowLength; j++)
				{
					if (!int.TryParse(rowParts[j + 1], out matrix[i][j]))
					{
						throw new FormatException($"Некоректне число у рядку {i + 1}, стовпці {j + 1}: '{rowParts[j + 1]}'.");
					}
				}
			}
			Console.WriteLine($"Ступінчаста матриця з {m} рядками успішно зчитана з файлу '{fileName}'.");
			return matrix;
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine($"Помилка: Файл '{fileName}' не знайдено.");
			return null;
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Помилка формату даних у файлі: {ex.Message}");
			return null;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Виникла помилка при читанні файлу: {ex.Message}");
			return null;
		}
	}

	private static int[][] GenerateRandomJaggedMatrix(int m, int maxVal)
	{
		int[][] matrix = new int[m][];
		int maxColLength = 0;
		Console.Write("Введіть максимальну кількість стовпців для рядка: ");
		if (!int.TryParse(Console.ReadLine(), out maxColLength) || maxColLength <= 0)
		{
			maxColLength = 5;
			Console.WriteLine("Некоректна кількість стовпців. Використано 5.");
		}

		for (int i = 0; i < m; i++)
		{
			int colCount = random.Next(1, maxColLength + 1);
			matrix[i] = new int[colCount];
			for (int j = 0; j < colCount; j++)
			{
				matrix[i][j] = random.Next(-maxVal, maxVal + 1);
			}
		}
		Console.WriteLine($"Ступінчаста матриця з {m} рядками заповнена випадковими числами.");
		return matrix;
	}

	private static void PrintJaggedMatrix(int[][] matrix)
	{
		if (matrix == null || matrix.Length == 0)
		{
			Console.WriteLine("Матриця порожня.");
			return;
		}
		for (int i = 0; i < matrix.Length; i++)
		{
			for (int j = 0; j < matrix[i].Length; j++)
			{
				Console.Write($"{matrix[i][j],6}");
			}
			Console.WriteLine();
		}
	}

	private static void CalculateAndPrintSquaredJaggedMatrix(int[][] matrixA)
	{
		if (matrixA == null || matrixA.Length == 0)
		{
			Console.WriteLine("Матриця порожня.");
			return;
		}

		for (int i = 0; i < matrixA.Length; i++)
		{
			for (int j = 0; j < matrixA[i].Length; j++)
			{
				Console.Write($"{matrixA[i][j] * matrixA[i][j],6}");
			}
			Console.WriteLine();
		}
	}

	private static void SwapRowsOrColumnsJagged(int[][] matrix)
	{
		if (matrix == null || matrix.Length == 0)
		{
			Console.WriteLine("Матриця порожня, зміна неможлива.");
			return;
		}

		int minVal = matrix[0][0];
		int maxVal = matrix[0][0];
		int minRow = 0, minCol = 0;
		int maxRow = 0, maxCol = 0;

		for (int i = 0; i < matrix.Length; i++)
		{
			for (int j = 0; j < matrix[i].Length; j++)
			{
				if (matrix[i][j] < minVal)
				{
					minVal = matrix[i][j];
					minRow = i;
					minCol = j;
				}
				if (matrix[i][j] > maxVal)
				{
					maxVal = matrix[i][j];
					maxRow = i;
					maxCol = j;
				}
			}
		}
		Console.WriteLine($"Знайдено: Мін. елемент ({minVal}) в [{minRow},{minCol}], Макс. елемент ({maxVal}) в [{maxRow},{maxCol}]");

		if (minRow != maxRow)
		{
			Console.WriteLine($"Міняємо місцями рядок {minRow} та рядок {maxRow}.");
			int[] tempRow = matrix[minRow];
			matrix[minRow] = matrix[maxRow];
			matrix[maxRow] = tempRow;
		}
		else
		{
			Console.WriteLine($"Мін. та макс. елементи в одному рядку ({minRow}). Міняємо місцями стовпець {minCol} та стовпець {maxCol}.");
			for (int i = 0; i < matrix.Length; i++)
			{
				bool minColExists = (minCol < matrix[i].Length);
				bool maxColExists = (maxCol < matrix[i].Length);

				if (minColExists && maxColExists)
				{
					int temp = matrix[i][minCol];
					matrix[i][minCol] = matrix[i][maxCol];
					matrix[i][maxCol] = temp;
				}
				else if (minColExists)
				{
					Console.WriteLine($"Попередження: Стовпець {maxCol} не існує в рядку {i}. Обмін неможливий.");
				}
				else if (maxColExists)
				{
					Console.WriteLine($"Попередження: Стовпець {minCol} не існує в рядку {i}. Обмін неможливий.");
				}
			}
		}
	}
}
