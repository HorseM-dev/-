using System;
using System.Globalization;

public class FunctionCalculator2_1
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		double[] a_values = { 0.0, 2.5 };
		double[] x_values = { 0.5, 1.0, 1.5, 2.0 };

		Console.WriteLine("--- Розрахунок функції y(x) = arctan(x^2 / (2*a)) / (x^3 + a) ---");
		Console.WriteLine(" ");

		foreach (double a in a_values)
		{
			Console.WriteLine($"*** Для параметра a = {a:F1} ***");
			Console.WriteLine(new string('-', 30));
			Console.WriteLine("{0,-10} {1,-15}", "x", "y(x)");
			Console.WriteLine(new string('-', 30));

			foreach (double x in x_values)
			{
				double y;
				try
				{
					double numerator;
					double denominator = (x * x * x) + a;

					if (denominator == 0)
					{
						y = double.NaN;
					}
					else if (a == 0)
					{
						numerator = Math.PI / 2;
						y = numerator / denominator;
					}
					else
					{
						double arctanArg = (x * x) / (2 * a);
						numerator = Math.Atan(arctanArg);
						y = numerator / denominator;
					}
				}
				catch (Exception)
				{
					y = double.NaN;
				}

				Console.WriteLine("{0,-10:F2} {1,-15:F6}", x, y);
			}
			Console.WriteLine(new string('-', 30));
			Console.WriteLine();
		}

		Console.WriteLine("Розрахунки завершено. Натисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}
}
