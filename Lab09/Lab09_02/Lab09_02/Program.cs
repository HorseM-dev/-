using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.Write("🔹 Введіть шлях до текстового файлу: ");
		string textPath = Console.ReadLine();

		Console.Write("🔹 Введіть шлях до файлу із забороненими словами: ");
		string bannedPath = Console.ReadLine();

		if (!File.Exists(textPath) || !File.Exists(bannedPath))
		{
			Console.WriteLine("❌ Один із файлів не знайдено.");
			return;
		}

		string text = File.ReadAllText(textPath);
		string[] bannedWords = File.ReadAllLines(bannedPath);

		foreach (var word in bannedWords)
		{
			if (string.IsNullOrWhiteSpace(word)) continue;

			string pattern = $@"\b{Regex.Escape(word)}\b";
			string replacement = new string('*', word.Length);
			text = Regex.Replace(text, pattern, replacement, RegexOptions.IgnoreCase);
		}

		Console.WriteLine("\n📄 Цензурований текст:\n");
		Console.WriteLine(text);
	}
}
