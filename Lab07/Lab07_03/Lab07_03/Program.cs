using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		string original = "Привіт, світе!";

		ICipher aCipher = new ACipher();
		ICipher bCipher = new BCipher();

		Console.WriteLine("🔤 Початковий текст:       " + original);

		// ACipher
		string aEncoded = aCipher.Encode(original);
		string aDecoded = aCipher.Decode(aEncoded);

		Console.WriteLine("\n🔁 ACipher:");
		Console.WriteLine("  Зашифровано:             " + aEncoded);
		Console.WriteLine("  Розшифровано:            " + aDecoded);

		// BCipher
		string bEncoded = bCipher.Encode(original);
		string bDecoded = bCipher.Decode(bEncoded);

		Console.WriteLine("\n🔁 BCipher:");
		Console.WriteLine("  Зашифровано:             " + bEncoded);
		Console.WriteLine("  Розшифровано:            " + bDecoded);
	}
}
