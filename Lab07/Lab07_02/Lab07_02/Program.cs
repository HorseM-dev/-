using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		var reg = new Registry();

		reg.Add(new Airplane("Сокіл", "ROTAX", 100));
		reg.Add(new Helicopter("Мі-2", "Газотурбінний", 400));
		reg.Add(new Glider("DeltaX", "Алюміній"));
		reg.Add(new HotAirBalloon("SkyBall", "Пропан"));
		reg.Add(new FlyingCarpet("Шовковий 3000"));

		reg.ShowAll();

		Console.WriteLine("\n🔠 Сортування за назвою:");
		reg.SortByName();
		reg.ShowAll();

		Console.WriteLine("\n📂 Сортування за типом + назвою:");
		reg.SortByTypeThenName();
		reg.ShowAll();

		Console.WriteLine();
		reg.ShowElectronic();
		Console.WriteLine();
		reg.ShowWithoutEngine();

		Console.WriteLine("\n🪞 Копіювання пристрою:");
		var original = new Glider("DeltaX", "Алюміній");
		var copy = (Device)original.Clone();
		Console.WriteLine($"  Оригінал: {original}");
		Console.WriteLine($"  Копія:    {copy}");
	}
}
