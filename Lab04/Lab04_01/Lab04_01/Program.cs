using System;
using System.Text.RegularExpressions;

public class RegexValidator
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("--- Перевірка рядків за допомогою регулярних виразів ---");

		bool exit = false;
		while (!exit)
		{
			Console.WriteLine("\nОберіть дію:");
			Console.WriteLine("1. Перевірити, чи є рядок GUID");
			Console.WriteLine("2. Перевірити, чи є рядок MAC-адресою");
			Console.WriteLine("3. Перевірити, чи є рядок шістнадцятковим ідентифікатором кольору HTML");
			Console.WriteLine("0. Вийти");
			Console.Write("Ваш вибір: ");

			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					CheckGuid();
					break;
				case "2":
					CheckMacAddress();
					break;
				case "3":
					CheckHtmlColor();
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

	private static void CheckGuid()
	{
		Console.Write("Введіть рядок для перевірки на GUID: ");
		string input = Console.ReadLine();

		string guidPattern = @"^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\}?$";

		if (Regex.IsMatch(input, guidPattern))
		{
			Console.WriteLine($"'{input}' є дійсним GUID.");
		}
		else
		{
			Console.WriteLine($"'{input}' НЕ є дійсним GUID.");
		}
	}

	private static void CheckMacAddress()
	{
		Console.Write("Введіть рядок для перевірки на MAC-адресу: ");
		string input = Console.ReadLine();

		string macPattern = @"^([0-9a-fA-F]{2}[:-]){5}[0-9a-fA-F]{2}$";

		if (Regex.IsMatch(input, macPattern))
		{
			Console.WriteLine($"'{input}' є правильною MAC-адресою.");
		}
		else
		{
			Console.WriteLine($"'{input}' НЕ є правильною MAC-адресою.");
		}
	}

	private static void CheckHtmlColor()
	{
		Console.Write("Введіть рядок для перевірки на HTML Hex Color: ");
		string input = Console.ReadLine();


		string htmlColorPattern = @"^#[0-9a-fA-F]{6}$";

		if (Regex.IsMatch(input, htmlColorPattern))
		{
			Console.WriteLine($"'{input}' є дійсним шістнадцятковим ідентифікатором кольору HTML.");
		}
		else
		{
			Console.WriteLine($"'{input}' НЕ є дійсним шістнадцятковим ідентифікатором кольору HTML.");
		}
	}
}
