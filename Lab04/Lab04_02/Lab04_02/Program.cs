using System;
using System.IO; // Для роботи з файлами
using System.Text.RegularExpressions;
using System.Collections.Generic; // Для List<string>
using System.Linq; // Необхідний для деяких LINQ-операцій, але для Sort() не критично

public class TextProcessor
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("--- Аналіз та перетворення тексту (Завдання 2.15) ---");

		bool exit = false;
		while (!exit)
		{
			Console.WriteLine("\nОберіть дію:");
			Console.WriteLine("1. Обробка тексту: Знайти та відсортувати слова (лише букви/лише цифри)");
			Console.WriteLine("0. Вийти");
			Console.Write("Ваш вибір: ");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					ProcessAndSortWords();
					break;
				case "0":
					exit = true;
					Console.WriteLine("Вихід з програми.");
					break;
				default:
					Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
					break;
			}
		}

		Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
		Console.ReadKey();
	}

	/// <summary>
	/// Основний метод для обробки та сортування слів з тексту.
	/// </summary>
	private static void ProcessAndSortWords()
	{
		string inputText = GetTextFromUser();

		if (string.IsNullOrEmpty(inputText))
		{
			Console.WriteLine("Текст для обробки порожній.");
			return;
		}

		// Регулярний вираз для пошуку слів, що складаються лише з букв АБО лише з цифр.
		// \b - межа слова (щоб не захоплювати частини слів або слова з розділовими знаками)
		// [a-zA-Z]+ - одна або більше латинських букв
		// | - АБО
		// [0-9]+ - одна або більше цифр
		string wordPattern = @"\b([a-zA-Z]+|[0-9]+)\b";

		List<string> foundWords = new List<string>();

		// Знайти всі відповідності в тексті
		MatchCollection matches = Regex.Matches(inputText, wordPattern);

		foreach (Match match in matches)
		{
			foundWords.Add(match.Value);
		}

		if (foundWords.Count == 0)
		{
			Console.WriteLine("\nУ введеному тексті не знайдено слів, що складаються лише з букв або лише з цифр.");
			Console.WriteLine("Результати не будуть збережені у файл.");
			return;
		}

		Console.WriteLine("\nЗнайдені слова (несортовані):");
		Console.WriteLine(string.Join(", ", foundWords));

		// Сортування в алфавітному порядку
		foundWords.Sort(StringComparer.OrdinalIgnoreCase); // Сортування без урахування регістру

		Console.WriteLine("\nЗнайдені слова (відсортовані в алфавітному порядку):");
		string resultText = string.Join(", ", foundWords);
		Console.WriteLine(resultText);

		SaveResultToFile(resultText);
	}

	/// <summary>
	/// Запитує у користувача, звідки взяти текст (клавіатура або файл) і повертає його.
	/// </summary>
	/// <returns>Введений або зчитаний текст.</returns>
	private static string GetTextFromUser()
	{
		Console.WriteLine("\nЯк ви бажаєте ввести текст?");
		Console.WriteLine("1. З клавіатури");
		Console.WriteLine("2. З файлу");
		Console.Write("Ваш вибір (1 або 2): ");
		string inputChoice = Console.ReadLine();

		string text = "";

		switch (inputChoice)
		{
			case "1":
				Console.WriteLine("Введіть текст (для завершення введіть пустий рядок і натисніть Enter двічі):");
				string line;
				while ((line = Console.ReadLine()) != null && line != "")
				{
					text += line + Environment.NewLine;
				}
				break;
			case "2":
				Console.Write("Введіть повний шлях до файлу (наприклад, C:\\MyTexts\\input.txt): ");
				string filePath = Console.ReadLine();
				try
				{
					text = File.ReadAllText(filePath);
					Console.WriteLine($"Текст успішно зчитано з файлу: '{filePath}'");
				}
				catch (FileNotFoundException)
				{
					Console.WriteLine($"Помилка: Файл '{filePath}' не знайдено.");
				}
				catch (IOException ex)
				{
					Console.WriteLine($"Помилка при читанні файлу: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Виникла неочікувана помилка: {ex.Message}");
				}
				break;
			default:
				Console.WriteLine("Невірний вибір. Текст не буде введено.");
				break;
		}
		return text;
	}

	/// <summary>
	/// Зберігає результуючий текст у вказаний файл.
	/// </summary>
	/// <param name="textToSave">Текст, який потрібно зберегти.</param>
	private static void SaveResultToFile(string textToSave)
	{
		Console.Write("\nВведіть ім'я файлу для збереження результатів (наприклад, result.txt): ");
		string outputFileName = Console.ReadLine();

		if (string.IsNullOrWhiteSpace(outputFileName))
		{
			Console.WriteLine("Ім'я файлу не вказано. Результати не будуть збережені.");
			return;
		}

		try
		{
			File.WriteAllText(outputFileName, textToSave);
			Console.WriteLine($"Результати успішно збережено у файл: '{Path.GetFullPath(outputFileName)}'");
		}
		catch (IOException ex)
		{
			Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
		}
		catch (UnauthorizedAccessException)
		{
			Console.WriteLine("Помилка: Відмовлено в доступі до файлу. Перевірте дозволи або оберіть інший шлях.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Виникла неочікувана помилка при збереженні файлу: {ex.Message}");
		}
	}
}
