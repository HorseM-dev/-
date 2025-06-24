using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		var quad1 = new Quadrilateral(
			new Point(0, 0),
			new Point(4, 0),
			new Point(4, 3),
			new Point(0, 3));

		var quad2 = new Quadrilateral(
			new Point(1, 1),
			new Point(6, 2),
			new Point(5, 5),
			new Point(0, 4));

		var square1 = new Square(new Point(0, 0), 5);
		var square2 = new Square(new Point(2, 2), 3);

		Quadrilateral[] shapes = { quad1, quad2, square1, square2 };

		foreach (var shape in shapes)
		{
			Console.WriteLine("🟦 " + shape);
			Console.WriteLine($"   Периметр = {shape.Perimeter():F2}");
			Console.WriteLine($"   Площа    = {shape.Area():F2}\n");
		}

		Console.WriteLine("✔️ Перевірка Equals & HashCode:");
		Console.WriteLine($"quad1 == quad2: {quad1.Equals(quad2)}");
		Console.WriteLine($"hash(quad1) = {quad1.GetHashCode()}");
		Console.WriteLine($"hash(quad2) = {quad2.GetHashCode()}");
	}
}
