public class Corvette : Ship
{
	public int MissileCount { get; set; }

	public Corvette(string name, double displacement, int missiles)
		: base(name, displacement)
	{
		if (missiles < 0) throw new ArgumentException("Кількість ракет не може бути від’ємною");
		MissileCount = missiles;
	}

	public override string Type => "Корвет";

	public override string ToString() =>
		base.ToString() + $", ракет: {MissileCount}";
}
