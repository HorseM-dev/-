using System;
using System.Collections.Generic;
using System.Linq;

public class Registry
{
	private List<Device> devices = new();

	public void Add(Device device) => devices.Add(device);

	public void ShowAll()
	{
		Console.WriteLine("📋 Усе обладнання:");
		foreach (var d in devices)
			Console.WriteLine("  • " + d);
	}

	public void ShowElectronic()
	{
		Console.WriteLine("🔌 Електронне обладнання:");
		foreach (var d in devices.Where(d => d.IsElectronic))
			Console.WriteLine("  • " + d);
	}

	public void ShowWithoutEngine()
	{
		Console.WriteLine("🛠️ Обладнання без двигуна:");
		foreach (var d in devices.Where(d => d is not IEngine))
			Console.WriteLine("  • " + d);
	}

	public void SortByName() => devices.Sort();

	public void SortByTypeThenName()
	{
		devices.Sort((a, b) =>
		{
			int t = a.GetType().Name.CompareTo(b.GetType().Name);
			return t == 0 ? a.Name.CompareTo(b.Name) : t;
		});
	}
}
