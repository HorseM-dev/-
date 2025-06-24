using System;
using System.Linq;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		int[] numbers = { -7, 0, 7, 14, 21, 5, -3, 13, 28, 35 };

		// 🔢 Кількість чисел, кратних 7
		Func<int[], int> countMultiplesOfSeven = arr => arr.Count(n => n % 7 == 0 && n != 0);
		Console.WriteLine("🔹 Кратних 7: " + countMultiplesOfSeven(numbers));

		// ➕ Кількість позитивних чисел
		Func<int[], int> countPositive = arr => arr.Count(n => n > 0);
		Console.WriteLine("🔹 Позитивних чисел: " + countPositive(numbers));

		// 📆 Перевірка на день програміста (256-й день року)
		Func<DateTime, bool> isProgrammersDay = date =>
			date.DayOfYear == 256;

		var testDate = new DateTime(2025, 9, 13); // 256-й день 2025 року
		Console.WriteLine($"\n📅 {testDate:d} — день програміста: {isProgrammersDay(testDate)}");

		// 🔍 Перевірка, чи текст містить задане слово або масив слів
		Func<string, string[], bool> containsAnyWord = (text, keywords) =>
			keywords.Any(word => text.Contains(word, StringComparison.OrdinalIgnoreCase));

		string message = "Сьогодні ми вивчаємо делегати, лямбди та інтерфейси в C#.";
		string[] keywords = { "інтерфейс", "асинхронний", "лямбда" };

		Console.WriteLine($"\n📘 Текст: \"{message}\"");
		Console.WriteLine("🔹 Містить хоча б одне ключове слово: " + containsAnyWord(message, keywords));
	}
}
