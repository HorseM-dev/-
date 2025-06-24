using System;

public abstract class Ship
{
	public string Name { get; set; }
	public double Displacement { get; set; } // водотоннажність у тоннах

	protected Ship(string name, double displacement)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Ім’я судна не може бути порожнім.");
		if (displacement <= 0) throw new ArgumentOutOfRangeException(nameof(displacement), "Водотоннажність має бути додатньою.");
		Name = name;
		Displacement = displacement;
	}

	public abstract string Type { get; }

	public override string ToString() => $"{Type} \"{Name}\" ({Displacement} т)";
	public override bool Equals(object obj) => obj is Ship s && Name == s.Name && Displacement == s.Displacement;
	public override int GetHashCode() => HashCode.Combine(Name, Displacement);
}
