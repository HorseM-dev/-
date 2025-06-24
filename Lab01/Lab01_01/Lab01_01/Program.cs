using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Console.WriteLine("Обчислення виразу h:");
		Console.Write("Введіть x: ");
		double x = double.Parse(Console.ReadLine());

		Console.Write("Введіть y: ");
		double y = double.Parse(Console.ReadLine());
			
		Console.Write("Введіть z (у градусах): ");
		double zDegrees = double.Parse(Console.ReadLine());
		double zRad = zDegrees * Math.PI / 180.0;

		// Частини виразу
		double dyx = Math.Abs(y - x);
		double num1 = Math.Pow(x, y + 1);
		double num2 = Math.Exp(y - 1);
		double tanZ = Math.Tan(zRad);

		double numerator = num1 + num2;
		double denominator = 1 + x;

		double part1 = (numerator / denominator) * Math.Abs(y - tanZ) * (1 + dyx);
		double part2 = Math.Pow(dyx, 2) / 2.0;
		double part3 = Math.Pow(dyx, 3) / 3.0;

		double h = part1 + part2 - part3;

		Console.WriteLine($"\nh = {h:F6}");
	}
}
