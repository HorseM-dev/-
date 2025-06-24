using System;
using System.Globalization;
using System.IO;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		string inputPath = "LAB2.TXT";
		string outputPath = "LAB2.RES";

		// Зчитуємо вхідні дані
		if (!File.Exists(inputPath))
		{
			Console.WriteLine("Файл LAB2.TXT не знайдено.");
			return;
		}

		string[] tokens = File.ReadAllText(inputPath).Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

		if (tokens.Length < 3 ||
			!double.TryParse(tokens[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double xmin) ||
			!double.TryParse(tokens[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double xmax) ||
			!int.TryParse(tokens[2], out int N) || N < 2)
		{
			Console.WriteLine("Неправильний формат вхідних даних.");
			return;
		}

		double step = (xmax - xmin) / (N - 1);

		using (StreamWriter writer = new StreamWriter(outputPath))
		{
			writer.WriteLine("  x\t\t   y = 2·arctg(x) + sin(πx)");
			writer.WriteLine(new string('-', 40));

			for (int i = 0; i < N; i++)
			{
				double x = xmin + i * step;
				double y = 2 * Math.Atan(x) + Math.Sin(Math.PI * x);
				writer.WriteLine($"{x,8:F4}\t{y,12:F6}");
			}
		}

		Console.WriteLine("Обчислення завершено. Результат записано у LAB2.RES.");
	}
}
