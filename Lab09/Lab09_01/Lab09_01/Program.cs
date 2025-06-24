using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.Write("Введіть повний шлях до файлу: ");
		string path = Console.ReadLine();

		if (!File.Exists(path))
		{
			Console.WriteLine("❌ Файл не знайдено.");
			return;
		}

		string text = File.ReadAllText(path);

		int sentenceCount = Regex.Matches(text, @"[\.!?]+").Count;
		int upperCount = text.Count(char.IsUpper);
		int lowerCount = text.Count(char.IsLower);
		int digitCount = text.Count(char.IsDigit);

		string vowels = "аеєиіїоуюяАЕЄИІЇОУЮЯ";
		string consonants = "бвгґджзйклмнпрстфхцчшщБВГҐДЖЗЙКЛМНПРСТФХЦЧШЩ";

		int vowelCount = text.Count(c => vowels.Contains(c));
		int consonantCount = text.Count(c => consonants.Contains(c));

		Console.WriteLine("\n📊 Статистика:");
		Console.WriteLine($"▪ Речень:             {sentenceCount}");
		Console.WriteLine($"▪ Великих літер:      {upperCount}");
		Console.WriteLine($"▪ Маленьких літер:    {lowerCount}");
		Console.WriteLine($"▪ Голосних літер:     {vowelCount}");
		Console.WriteLine($"▪ Приголосних літер:  {consonantCount}");
		Console.WriteLine($"▪ Цифр:               {digitCount}");
	}
}
