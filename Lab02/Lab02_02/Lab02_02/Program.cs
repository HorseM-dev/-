using System;
using System.Globalization;

public class SeriesApproximation
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		double[] x_values = { 0.2, 0.6, 0.9 };
		const double EPSILON = 1e-6;

		Console.WriteLine("--- Наближений підрахунок функції y(x) за допомогою ряду S(x) ---");
		Console.WriteLine($"--- Умова зупинки: |поточний член| < {EPSILON:E1} ---");
		Console.WriteLine(" ");

		foreach (double x in x_values)
		{
			Console.WriteLine($"*** Для x = {x:F1} ***");
			Console.WriteLine(new string('-', 70));
			Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15}", "Кількість членів", "Сума ряду S(x)", "Функція y(x)", "Різниця");
			Console.WriteLine(new string('-', 70));

			double sumS = 0;
			double currentTerm;
			int n = 0;

			do
			{
				n++;
				currentTerm = n * (n + 2) * Math.Pow(x, n);
				sumS += currentTerm;

			} while (Math.Abs(currentTerm) >= EPSILON);

			double y_x;
			try
			{
				double denominator = Math.Pow((1 - x), 3);
				if (denominator == 0)
				{
					y_x = double.NaN;
				}
				else
				{
					y_x = x * (3 - x) / denominator;
				}
			}
			catch (Exception)
			{
				y_x = double.NaN;
			}

			double difference = y_x - sumS;

			Console.WriteLine("{0,-15} {1,-15:F8} {2,-15:F8} {3,-15:E2}", n, sumS, y_x, difference);
			Console.WriteLine(new string('-', 70));
			Console.WriteLine();
		}

		Console.WriteLine("Розрахунки завершено. Натисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}
}
