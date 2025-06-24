using System;

public class GuessMyNumber
{
	private static Random random = new Random();
	private static int playerTotalScore = 0;
	private static int computerTotalScore = 0;

	public static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.InputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("Ласкаво просимо до гри 'Вгадай моє число'!");
		Console.WriteLine("------------------------------------------");

		bool playerWonLevel1 = PlayLevel(1);

		if (playerWonLevel1)
		{
			Console.WriteLine("\nВітаємо! Ви успішно пройшли Перший рівень!");
			Console.WriteLine($"Ваші поточні очки: {playerTotalScore}");
			Console.WriteLine($"Очки комп'ютера: {computerTotalScore}");
			Console.Write("Бажаєте перейти на Другий рівень? (Так/Ні): ");
			string choice = Console.ReadLine()?.ToLower();

			if (choice == "так" || choice == "yes")
			{
				PlayLevel(2); // Переходимо на Другий рівень
			}
			else
			{
				Console.WriteLine("\nДякуємо за гру! Ви завершили гру після Першого рівня.");
			}
		}
		else
		{
			Console.WriteLine("\nВи програли на Першому рівні. Гра завершена.");
		}

		DisplayFinalResult();

		Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
		Console.ReadKey();
	}

	/// <summary>
	/// Запускає один рівень гри.
	/// </summary>
	/// <param name="level">Номер рівня (1 або 2).</param>
	/// <returns>True, якщо гравець виграв усі раунди рівня, False інакше.</returns>
	private static bool PlayLevel(int level)
	{
		int minRange, maxRange, numRounds, scoreMultiplier;
		double livesPercentage;

		if (level == 1)
		{
			minRange = 1;
			maxRange = 10;
			numRounds = 3;
			livesPercentage = 0.50; // 50% від довжини діапазону
			scoreMultiplier = 5;
			Console.WriteLine("\n--- Починається Перший рівень (число від 1 до 10) ---");
		}
		else // level == 2
		{
			minRange = 10;
			maxRange = 100;
			numRounds = 2;
			livesPercentage = 0.25; // 25% від довжини діапазону
			scoreMultiplier = 10;
			Console.WriteLine("\n--- Починається Другий рівень (число від 10 до 100) ---");
		}

		int rangeLength = maxRange - minRange + 1;
		int initialLives = (int)Math.Ceiling(rangeLength * livesPercentage);
		Console.WriteLine($"На цьому рівні у вас є {initialLives} життів на кожен раунд.");

		for (int round = 1; round <= numRounds; round++)
		{
			Console.WriteLine($"\n--- Рівень {level}, Раунд {round} ---");
			Console.WriteLine($"Ваші поточні очки: {playerTotalScore} | Очки комп'ютера: {computerTotalScore}");

			int currentLives = initialLives;
			int secretNumber = random.Next(minRange, maxRange + 1);
			bool roundWon = false;

			Console.WriteLine($"Я загадав число від {minRange} до {maxRange}. У вас є {currentLives} життів.");

			while (currentLives > 0)
			{
				Console.Write("Введіть ваше припущення: ");
				string input = Console.ReadLine();
				int guess;

				if (!int.TryParse(input, out guess))
				{
					Console.WriteLine("Будь ласка, введіть дійсне число.");
					continue;
				}

				if (guess == secretNumber)
				{
					Console.WriteLine($"Вітаємо! Ви вгадали число {secretNumber}!");
					playerTotalScore += currentLives * scoreMultiplier;
					roundWon = true;
					break;
				}
				else
				{
					currentLives--;
					Console.WriteLine($"Неправильно! Залишилось життів: {currentLives}");

					if (currentLives > 0) // Пропонуємо підказку, якщо є життя
					{
						Console.Write("Бажаєте отримати підказку? Втратите 1 життя (Так/Ні): ");
						string hintChoice = Console.ReadLine()?.ToLower();
						if (hintChoice == "так" || hintChoice == "yes")
						{
							currentLives--;
							Console.WriteLine($"Витрачено 1 життя. Залишилось життів: {currentLives}");
							if (guess < secretNumber)
							{
								Console.WriteLine("Підказка: Загадане число БІЛЬШЕ, ніж ваше припущення.");
							}
							else
							{
								Console.WriteLine("Підказка: Загадане число МЕНШЕ, ніж ваше припущення.");
							}
						}
					}
				}
			}

			if (!roundWon)
			{
				Console.WriteLine($"\nВи програли раунд. Загадане число було: {secretNumber}");
				computerTotalScore += initialLives * scoreMultiplier;
				return false; // Гравець програв раунд, рівень вважається програним
			}
			else
			{
				Console.WriteLine($"Раунд {round} завершено. Ваші очки: {playerTotalScore} | Очки комп'ютера: {computerTotalScore}");
			}
		}

		Console.WriteLine($"\n--- Рівень {level} завершено! ---");
		Console.WriteLine($"Ваші очки після рівня {level}: {playerTotalScore}");
		Console.WriteLine($"Очки комп'ютера після рівня {level}: {computerTotalScore}");
		return true; // Гравець виграв усі раунди рівня
	}

	/// <summary>
	/// Виводить кінцевий результат гри.
	/// </summary>
	private static void DisplayFinalResult()
	{
		Console.WriteLine("\n========== КІНЕЦЬ ГРИ ==========");
		if (playerTotalScore > computerTotalScore)
		{
			Console.WriteLine("Вітаємо! Ви ВИГРАЛИ гру!");
		}
		else if (computerTotalScore > playerTotalScore)
		{
			Console.WriteLine("Комп'ютер ВИГРАВ гру. Спробуйте ще раз!");
		}
		else
		{
			Console.WriteLine("Гра завершилася НІЧИЄЮ!");
		}
		Console.WriteLine($"Ваші фінальні очки: {playerTotalScore}");
		Console.WriteLine($"Фінальні очки комп'ютера: {computerTotalScore}");
		Console.WriteLine("================================");
	}
}
