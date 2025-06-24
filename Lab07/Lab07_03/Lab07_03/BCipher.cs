using System;
using System.Text;

public class BCipher : ICipher
{
	private const string upper = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
	private const string lower = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";

	public string Encode(string source)
	{
		return Transform(source);
	}

	public string Decode(string encoded)
	{
		return Transform(encoded); // дзеркальне — один і той самий метод
	}

	private string Transform(string input)
	{
		StringBuilder result = new StringBuilder();

		foreach (char ch in input)
		{
			if (char.IsUpper(ch) && upper.Contains(ch))
			{
				int i = upper.IndexOf(ch);
				result.Append(upper[upper.Length - 1 - i]);
			}
			else if (char.IsLower(ch) && lower.Contains(ch))
			{
				int i = lower.IndexOf(ch);
				result.Append(lower[lower.Length - 1 - i]);
			}
			else
			{
				result.Append(ch);
			}
		}

		return result.ToString();
	}
}
