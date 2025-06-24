using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

public class ArrayProcessor
{
	private static Random random = new Random();

	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		List<int> array = new List<int>();

		Console.WriteLine("Оберіть спосіб введення даних:");
		Console.WriteLine("1. Зчитати з файлу");
		Console.WriteLine("2. Ввести з клавіатури");
		Console.WriteLine("3. Заповнити випадковими числами");
		Console.Write("Ваш вибір (1, 2 або 3): ");

		string choice = Console.ReadLine();

		switch (choice)
		{
			case "1":
				array = ReadArrayFromFile();
				break;
			case "2":
				array = ReadArrayFromKeyboard();
				break;
			case "3":
				array = GenerateRandomArray();
				break;
			default:
				Console.WriteLine("Невірний вибір. Програма завершує роботу.");
				return;
		}

		if (array == null || array.Count == 0)
		{
			Console.WriteLine("Масив не було заповнено. Програма завершує роботу.");
			return;
		}

		Console.WriteLine("\nПочатковий масив:");
		PrintArray(array);

		ProcessArray(array);

		Console.WriteLine("\nМасив після обробки (заміна та сортування):");
		PrintArray(array);

		Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}

	private static List<int> ReadArrayFromFile()
	{
		Console.Write("Введіть ім'я файлу (наприклад, input_small.txt): ");
		string fileName = Console.ReadLine();
		List<int> result = new List<int>();

		try
		{
			string fileContent = File.ReadAllText(fileName);
			result = fileContent.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
								 .Select(s => int.Parse(s, CultureInfo.InvariantCulture))
								 .ToList();
			Console.WriteLine($"Дані успішно зчитано з файлу '{fileName}'.");
		}
		catch (FileNotFoundException)
		{
			Console.WriteLine($"Помилка: Файл '{fileName}' не знайдено.");
			return null;
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Помилка формату даних у файлі: {ex.Message}. Переконайтеся, що файл містить лише числа.");
			return null;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Виникла помилка при читанні файлу: {ex.Message}");
			return null;
		}
		return result;
	}

	private static List<int> ReadArrayFromKeyboard()
	{
		Console.WriteLine("Введіть елементи масиву, розділяючи їх пробілами або комами. Натисніть Enter, коли закінчите:");
		string input = Console.ReadLine();
		List<int> result = new List<int>();

		try
		{
			result = input.Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
						  .Select(s => int.Parse(s, CultureInfo.InvariantCulture))
						  .ToList();
		}
		catch (FormatException ex)
		{
			Console.WriteLine($"Помилка формату введення: {ex.Message}. Будь ласка, вводьте лише числа.");
			return null;
		}
		return result;
	}

	private static List<int> GenerateRandomArray()
	{
		Console.Write("Введіть бажану кількість елементів у масиві: ");
		int count;
		if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
		{
			Console.WriteLine("Некоректна кількість елементів. Використано значення за замовчуванням: 16.");
			count = 16;
		}

		Console.Write("Введіть максимальне значення для випадкових чисел (наприклад, 100): ");
		int maxValue;
		if (!int.TryParse(Console.ReadLine(), out maxValue) || maxValue <= 0)
		{
			Console.WriteLine("Некоректне максимальне значення. Використано значення за замовчуванням: 100.");
			maxValue = 100;
		}

		List<int> result = new List<int>();
		for (int i = 0; i < count; i++)
		{
			result.Add(random.Next(-maxValue, maxValue + 1));
		}
		Console.WriteLine($"Масив заповнено {count} випадковими числами.");
		return result;
	}

	private static void ProcessArray(List<int> arr)
	{
		for (int i = 3; i < arr.Count; i += 4)
		{
			if (i >= 3)
			{
				int sumOfPrevious = arr[i - 3] + arr[i - 2] + arr[i - 1];
				Console.WriteLine($"\nІндекс {i}: {arr[i]} замінюється на суму {arr[i - 3]}+{arr[i - 2]}+{arr[i - 1]}={sumOfPrevious}");
				arr[i] = sumOfPrevious;

				List<int> subArray = new List<int> { arr[i - 3], arr[i - 2], arr[i - 1] };
				subArray.Sort();

				Console.WriteLine($"Елементи {arr[i - 3]}, {arr[i - 2]}, {arr[i - 1]} (індекси {i - 3}, {i - 2}, {i - 1}) сортуються...");

				arr[i - 3] = subArray[0];
				arr[i - 2] = subArray[1];
				arr[i - 1] = subArray[2];
			}
		}
	}

	private static void PrintArray(List<int> arr)
	{
		if (arr == null || arr.Count == 0)
		{
			Console.WriteLine("[Масив порожній]");
			return;
		}
		Console.WriteLine(string.Join(", ", arr));
	}
}
