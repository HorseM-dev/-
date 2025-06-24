using System;

class Program
{
	static SongCollection collection = new();
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		while (true)
		{
			Console.WriteLine("\n📻 Меню:");
			Console.WriteLine("1. Додати пісню");
			Console.WriteLine("2. Видалити пісню");
			Console.WriteLine("3. Редагувати пісню");
			Console.WriteLine("4. Пошук за назвою");
			Console.WriteLine("5. Пошук за виконавцем");
			Console.WriteLine("6. Показати всі пісні");
			Console.WriteLine("7. Зберегти у файл");
			Console.WriteLine("8. Завантажити з файлу");
			Console.WriteLine("9. Вихід");
			Console.Write("➡ Оберіть опцію: ");

			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					AddSong();
					break;
				case "2":
					RemoveSong();
					break;
				case "3":
					EditSong();
					break;
				case "4":
					SearchByTitle();
					break;
				case "5":
					SearchByPerformer();
					break;
				case "6":
					collection.PrintAll();
					break;
				case "7":
					collection.Save("songs.json");
					Console.WriteLine("💾 Збережено.");
					break;
				case "8":
					collection.Load("songs.json");
					Console.WriteLine("📂 Завантажено.");
					break;
				case "9":
					return;
				default:
					Console.WriteLine("❌ Невірна опція.");
					break;
			}
		}
	}

	static void AddSong()
	{
		Console.Write("Назва пісні: ");
		string title = Console.ReadLine();

		Console.Write("Автор (ПІБ): ");
		string author = Console.ReadLine();

		Console.Write("Композитор: ");
		string composer = Console.ReadLine();

		Console.Write("Рік написання: ");
		int year = int.TryParse(Console.ReadLine(), out int y) ? y : DateTime.Now.Year;

		Console.Write("Текст пісні:\n");
		string lyrics = Console.ReadLine();

		Console.Write("Виконавці (через кому): ");
		var performers = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

		var song = new Song
		{
			Title = title,
			AuthorFullName = author,
			Composer = composer,
			Year = year,
			Lyrics = lyrics,
			Performers = new System.Collections.Generic.List<string>(performers.Select(p => p.Trim()))
		};

		collection.Add(song);
		Console.WriteLine("✅ Додано.");
	}

	static void RemoveSong()
	{
		Console.Write("Введіть назву пісні для видалення: ");
		string title = Console.ReadLine();
		bool success = collection.Remove(title);
		Console.WriteLine(success ? "🗑️ Видалено." : "❌ Не знайдено.");
	}

	static void EditSong()
	{
		Console.Write("Введіть назву пісні для редагування: ");
		string title = Console.ReadLine();

		bool success = collection.Edit(title, song =>
		{
			Console.Write("Нова назва (Enter — без змін): ");
			string newTitle = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(newTitle)) song.Title = newTitle;

			Console.Write("Новий автор: ");
			string newAuthor = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(newAuthor)) song.AuthorFullName = newAuthor;

			Console.Write("Новий композитор: ");
			string newComposer = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(newComposer)) song.Composer = newComposer;

			Console.Write("Новий рік (Enter — без змін): ");
			if (int.TryParse(Console.ReadLine(), out int newYear)) song.Year = newYear;

			Console.Write("Новий текст (Enter — без змін): ");
			string newText = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(newText)) song.Lyrics = newText;

			Console.Write("Нові виконавці (через кому): ");
			string newPerf = Console.ReadLine();
			if (!string.IsNullOrWhiteSpace(newPerf))
				song.Performers = new System.Collections.Generic.List<string>(newPerf.Split(',').Select(p => p.Trim()));
		});

		Console.WriteLine(success ? "✏️ Оновлено." : "❌ Не знайдено.");
	}

	static void SearchByTitle()
	{
		Console.Write("🔍 Назва: ");
		string title = Console.ReadLine();

		var matches = collection.Search(s => s.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
		if (matches.Count == 0) Console.WriteLine("🚫 Нічого не знайдено.");
		else matches.ForEach(s => Console.WriteLine("\n---\n" + s));
	}

	static void SearchByPerformer()
	{
		Console.Write("🔍 Виконавець: ");
		string performer = Console.ReadLine();

		var matches = collection.GetByPerformer(performer);
		if (matches.Count == 0) Console.WriteLine("🚫 Немає пісень цього виконавця.");
		else matches.ForEach(s => Console.WriteLine("\n---\n" + s));
	}
}
