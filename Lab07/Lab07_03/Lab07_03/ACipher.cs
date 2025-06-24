using System;
using System.Text;

public class ACipher : ICipher
{
	public string Encode(string source)
	{
		StringBuilder result = new StringBuilder();

		foreach (char ch in source)
		{
			if (char.IsLetter(ch))
			{
				char baseChar = char.IsUpper(ch) ? 'А' : 'а';
				int offset = ch - baseChar;
				char shifted = (char)(baseChar + (offset + 1) % 32); // для укр. алфавіту (32 літери)
				result.Append(shifted);
			}
			else
			{
				result.Append(ch);
			}
		}

		return result.ToString();
	}

	public string Decode(string encoded)
	{
		StringBuilder result = new StringBuilder();

		foreach (char ch in encoded)
		{
			if (char.IsLetter(ch))
			{
				char baseChar = char.IsUpper(ch) ? 'А' : 'а';
				int offset = ch - baseChar;
				char shifted = (char)(baseChar + (offset - 1 + 32) % 32);
				result.Append(shifted);
			}
			else
			{
				result.Append(ch);
			}
		}

		return result.ToString();
	}
}
