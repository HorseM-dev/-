public class Steamship : Ship
{
	public int BoilerCount { get; set; }

	public Steamship(string name, double displacement, int boilers)
		: base(name, displacement)
	{
		if (boilers <= 0) throw new ArgumentException("Кількість котлів має бути > 0");
		BoilerCount = boilers;
	}

	public override string Type => "Пароплав";

	public override string ToString() =>
		base.ToString() + $", котлів: {BoilerCount}";
}
