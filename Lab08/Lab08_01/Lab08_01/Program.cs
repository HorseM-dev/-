using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		// Action — методи без повернення
		Action showTime = () => Console.WriteLine("⏰ Час: " + DateTime.Now.ToString("HH:mm:ss"));
		Action showDate = () => Console.WriteLine("📅 Дата: " + DateTime.Today.ToShortDateString());
		Action showDay = () => Console.WriteLine("🗓️ День тижня: " + DateTime.Today.DayOfWeek);

		// Predicate<int> — перевірка простого числа
		Predicate<int> isPrime = (num) =>
		{
			if (num < 2) return false;
			for (int i = 2; i <= Math.Sqrt(num); i++)
				if (num % i == 0) return false;
			return true;
		};

		// Predicate<int> — перевірка на число Фібоначчі
		Predicate<int> isFibonacci = (n) =>
		{
			// Формула: чи 5n^2±4 — квадрат
			bool IsPerfectSquare(int x) => Math.Sqrt(x) % 1 == 0;
			return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
		};

		// Func<double, double, double> — площа трикутника (за основою і висотою)
		Func<double, double, double> triangleArea = (baseLength, height) => 0.5 * baseLength * height;

		// Func<double, double, double> — площа прямокутника
		Func<double, double, double> rectangleArea = (width, height) => width * height;

		// 🔎 Демонстрація
		showTime();
		showDate();
		showDay();

		int number = 13;
		Console.WriteLine($"\nЧисло {number} просте: {isPrime(number)}");
		Console.WriteLine($"Число {number} — Фібоначчі: {isFibonacci(number)}");

		Console.WriteLine($"\n📐 Площа трикутника (a=6, h=3): {triangleArea(6, 3)}");
		Console.WriteLine($"⬛ Площа прямокутника (a=5, b=4): {rectangleArea(5, 4)}");
	}
}
