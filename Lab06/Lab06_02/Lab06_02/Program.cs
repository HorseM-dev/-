using System;
using System.Linq;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Ship[] fleet = new Ship[]
		{
			new Steamship("Кобзар", 1200, 3),
			new Steamship("Океан", 1500, 4),
			new SailingShip("Гетьман", 900, 2),
			new SailingShip("Фрегат", 1100, 3),
			new Corvette("Сокол", 800, 6),
			new Corvette("Молнія", 950, 4)
		};

		Console.WriteLine("⚓️ Усі кораблі у порту:");
		foreach (var ship in fleet)
			Console.WriteLine($"  • {ship}");

		Console.WriteLine("\n🔍 Середня водотоннажність вітрильників:");
		var sailingShips = fleet.OfType<SailingShip>().ToArray();

		if (sailingShips.Length == 0)
		{
			Console.WriteLine("  ❌ Вітрильників немає.");
		}
		else
		{
			double avg = sailingShips.Average(s => s.Displacement);
			Console.WriteLine($"  ✅ Середня = {avg:F2} тонн");
		}

		Console.WriteLine("\n🛠️ Тест винятків:");
		try
		{
			var invalid = new SailingShip("", -200, 0); // неправильні дані
		}
		catch (Exception ex)
		{
			Console.WriteLine("  ➤ " + ex.Message);
		}
	}
}
