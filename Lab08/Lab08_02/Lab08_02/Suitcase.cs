using System;
using System.Collections.Generic;

public class Suitcase
{
	public string Color { get; private set; }
	public string Brand { get; private set; }
	public double Weight { get; private set; }     // Вага порожньої валізи
	public double Capacity { get; private set; }   // Об’єм у літрах

	public List<LuggageItem> Contents { get; } = new();

	// Подія для додавання
	public event EventHandler<LuggageItem> ItemAdded;

	public Suitcase(string color, string brand, double weight, double capacity)
	{
		if (weight < 0 || capacity <= 0)
			throw new ArgumentException("Характеристики валізи некоректні.");

		Color = color;
		Brand = brand;
		Weight = weight;
		Capacity = capacity;
	}

	public double OccupiedVolume =>
		Contents.Sum(i => i.Volume);

	public double RemainingVolume => Capacity - OccupiedVolume;

	public void AddItem(LuggageItem item)
	{
		if (OccupiedVolume + item.Volume > Capacity)
			throw new InvalidOperationException($"⛔ Неможливо додати '{item.Name}': недостатньо місця у валізі.");

		Contents.Add(item);
		ItemAdded?.Invoke(this, item);
	}

	public override string ToString()
	{
		return $"🎒 Валіза: {Brand}, колір: {Color}, вага: {Weight} кг, місткість: {Capacity} л\n" +
			   $"   Заповнено: {OccupiedVolume:F1} л / {Capacity} л, предметів: {Contents.Count}";
	}
}
