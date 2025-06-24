using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		var suitcase = new Suitcase("синій", "Samsonite", 3.2, 35.0);

		// Слухач події
		suitcase.ItemAdded += (sender, item) =>
		{
			Console.WriteLine($"✅ Додано до валізи: {item}");
		};

		Console.WriteLine(suitcase);

		try
		{
			suitcase.AddItem(new LuggageItem("Футболка", 1.2));
			suitcase.AddItem(new LuggageItem("Ноутбук", 3.5));
			suitcase.AddItem(new LuggageItem("Взуття", 5.0));
			suitcase.AddItem(new LuggageItem("Гантелі", 30));  // Перевищує!
		}
		catch (Exception ex)
		{
			Console.WriteLine($"⚠️ Помилка: {ex.Message}");
		}

		Console.WriteLine("\n🧳 Вміст валізи:");
		foreach (var item in suitcase.Contents)
			Console.WriteLine("• " + item);

		Console.WriteLine($"\n📦 Залишилось місця: {suitcase.RemainingVolume:F1} л");
	}
}
