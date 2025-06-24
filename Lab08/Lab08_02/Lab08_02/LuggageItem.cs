public class LuggageItem
{
	public string Name { get; }
	public double Volume { get; }

	public LuggageItem(string name, double volume)
	{
		if (volume <= 0)
			throw new ArgumentException("Об’єм предмета має бути додатнім.");

		Name = name;
		Volume = volume;
	}

	public override string ToString() => $"{Name} ({Volume} л)";
}
