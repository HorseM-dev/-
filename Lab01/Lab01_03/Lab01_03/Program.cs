using System;

public class HumorousTest
{
	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("Привіт! Давай перевіримо твої можливості!");
		Console.WriteLine("Відповідай на питання лише цифрами.");
		Console.WriteLine("Натисни Enter, щоб почати тест...");
		Console.ReadLine();

		int correctAnswers = 0;

		// Питання 1
		Console.WriteLine("\n1. Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин проспав професор?");
		Console.Write("Ваша відповідь: ");
		int answer1;
		if (int.TryParse(Console.ReadLine(), out answer1) && answer1 == 1)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 1");
		}

		// Питання 2
		Console.WriteLine("\n2. На двох руках десять пальців. Скільки пальців на 10?");
		Console.Write("Ваша відповідь: ");
		int answer2;
		if (int.TryParse(Console.ReadLine(), out answer2) && answer2 == 50)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 50");
		}

		// Питання 3
		Console.WriteLine("\n3. Скільки цифр у дюжині?");
		Console.Write("Ваша відповідь: ");
		int answer3;
		if (int.TryParse(Console.ReadLine(), out answer3) && answer3 == 2)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 2 (1 і 2, у слові 'дюжина')");
		}

		// Питання 4
		Console.WriteLine("\n4. Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?");
		Console.Write("Ваша відповідь: ");
		int answer4;
		if (int.TryParse(Console.ReadLine(), out answer4) && answer4 == 11)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 11");
		}

		// Питання 5
		Console.WriteLine("\n5. Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?");
		Console.Write("Ваша відповідь: ");
		int answer5;
		if (int.TryParse(Console.ReadLine(), out answer5) && answer5 == 30)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 30");
		}

		// Питання 6
		Console.WriteLine("\n6. Скільки цифр 9 в інтервалі 1100?");
		Console.Write("Ваша відповідь: ");
		int answer6;
		if (int.TryParse(Console.ReadLine(), out answer6) && answer6 == 1)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 1 (саме цифр 9, тобто одна цифра '9' у числі 9)");
		}

		// Питання 7
		Console.WriteLine("\n7. Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?");
		Console.Write("Ваша відповідь: ");
		int answer7;
		if (int.TryParse(Console.ReadLine(), out answer7) && answer7 == 1)
		{
			Console.WriteLine("Правильно!");
			correctAnswers++;
		}
		else
		{
			Console.WriteLine("Неправильно. Правильна відповідь: 1");
		}

		Console.WriteLine("\n--- Результати тесту ---");
		Console.WriteLine($"Ви набрали {correctAnswers} правильних відповідей з 7.");

		if (correctAnswers == 7)
		{
			Console.WriteLine("Геній");
		}
		else if (correctAnswers == 6)
		{
			Console.WriteLine("Ерудит");
		}
		else if (correctAnswers == 5)
		{
			Console.WriteLine("Нормальний");
		}
		else if (correctAnswers == 4)
		{
			Console.WriteLine("Здібності середні");
		}
		else if (correctAnswers == 3)
		{
			Console.WriteLine("Здібності нижче середнього");
		}
		else // correctAnswers < 3
		{
			Console.WriteLine("Вам треба відпочити!");
		}

		Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}
}
