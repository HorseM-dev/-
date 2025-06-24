using System;
using System.IO;
using System.Globalization;

public class FlightCalculator
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		string inputFileName = "LAB4.TXT";

		int tankCapacity;
		int distanceAB;
		int distanceBC;
		int cargoWeight;

		try
		{
			// Зчитування даних з файлу
			string[] lines = File.ReadAllLines(inputFileName);
			if (lines.Length < 4)
			{
				Console.WriteLine($"Помилка: Файл '{inputFileName}' повинен містити щонайменше 4 рядки даних.");
				Console.WriteLine("Будь ласка, перевірте формат файлу: Ємність бака, Відстань А-В, Відстань В-С, Вага вантажу.");
				return;
			}

			tankCapacity = int.Parse(lines[0], CultureInfo.InvariantCulture);
			distanceAB = int.Parse(lines[1], CultureInfo.InvariantCulture);
			distanceBC = int.Parse(lines[2], CultureInfo.InvariantCulture);
			cargoWeight = int.Parse(lines[3], CultureInfo.InvariantCulture);
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine($"Помилка: Файл '{inputFileName}' не знайдено.");
			Console.WriteLine("Будь ласка, створіть файл з вхідними даними у форматі:");
			Console.WriteLine("Ємність бака (літрів)");
			Console.WriteLine("Відстань А-В (км)");
			Console.WriteLine("Відстань В-С (км)");
			Console.WriteLine("Вага вантажу (кг)");
			return;
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Помилка формату даних у файлі '{inputFileName}': {ex.Message}");
			Console.WriteLine("Переконайтеся, що всі значення є цілими числами.");
			return;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Виникла неочікувана помилка при читанні файлу '{inputFileName}': {ex.Message}");
			return;
		}

		Console.WriteLine("--- Дані польоту ---");
		Console.WriteLine($"Ємність бака літака: {tankCapacity} літрів");
		Console.WriteLine($"Відстань А-В: {distanceAB} км");
		Console.WriteLine($"Відстань В-С: {distanceBC} км");
		Console.WriteLine($"Вага вантажу: {cargoWeight} кг");
		Console.WriteLine(new string('-', 30));

		// Перевірка на максимально допустиму вагу вантажу
		if (cargoWeight > 2000)
		{
			Console.WriteLine("Неможливо здійснити політ: Літак не піднімає вантаж більше 2000 кг.");
			return;
		}

		// Визначення споживання палива
		double fuelConsumptionPerKm; // літрів/км
		if (cargoWeight <= 500)
		{
			fuelConsumptionPerKm = 1;
		}
		else if (cargoWeight <= 1000)
		{
			fuelConsumptionPerKm = 4;
		}
		else if (cargoWeight <= 1500)
		{
			fuelConsumptionPerKm = 7;
		}
		else // cargoWeight <= 2000
		{
			fuelConsumptionPerKm = 9;
		}

		Console.WriteLine($"Споживання палива: {fuelConsumptionPerKm:F1} літрів/км");

		// Розрахунок палива для першого етапу (А до В)
		double fuelNeededAB = distanceAB * fuelConsumptionPerKm;
		Console.WriteLine($"Потрібно палива для А-В: {fuelNeededAB:F2} літрів");

		if (fuelNeededAB > tankCapacity)
		{
			Console.WriteLine("Неможливо здійснити політ: Недостатньо палива в баку для польоту з А до В.");
			return;
		}

		double fuelRemainingAtB = tankCapacity - fuelNeededAB;
		Console.WriteLine($"Залишок палива після прибуття в В: {fuelRemainingAtB:F2} літрів");

		// Розрахунок палива для другого етапу (В до С)
		double fuelNeededBC = distanceBC * fuelConsumptionPerKm;
		Console.WriteLine($"Потрібно палива для В-С: {fuelNeededBC:F2} літрів");

		double fuelToRefuelAtB = 0;

		if (fuelRemainingAtB < fuelNeededBC)
		{
			fuelToRefuelAtB = fuelNeededBC - fuelRemainingAtB;
			// Перевіряємо, чи поміститься дозаправка в бак
			if (fuelToRefuelAtB > (tankCapacity - fuelRemainingAtB)) // Це завжди буде правдою, якщо fuelNeededBC не перевищує tankCapacity
			{
				// Цей блок коду може бути зайвим, якщо припустити, що літак завжди дозаправляється "до повного" для наступного сегменту,
				// якщо цього сегменту вистачає одного повного баку.
				// Але якщо потрібно залити більше, ніж вільний об'єм, то це проблема.
				// Однак, логічніше перевіряти, чи fuelNeededBC <= tankCapacity, перш ніж взагалі розглядати можливість польоту В-С.
			}
		}

		// Фінальна перевірка, чи взагалі можливо долетіти з В до С з одним повним баком
		if (fuelNeededBC > tankCapacity)
		{
			Console.WriteLine("Неможливо здійснити політ: Відстань В-С занадто велика для повного бака.");
			return;
		}

		Console.WriteLine(new string('-', 30));
		Console.WriteLine($"Мінімальна кількість палива для дозаправки в пункті В: {fuelToRefuelAtB:F2} літрів");

		Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}
}
