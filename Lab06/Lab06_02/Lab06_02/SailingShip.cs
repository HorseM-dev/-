public class SailingShip : Ship
{
	public int MastCount { get; set; }

	public SailingShip(string name, double displacement, int masts)
		: base(name, displacement)
	{
		if (masts <= 0) throw new ArgumentException("Кількість щогл має бути > 0");
		MastCount = masts;
	}

	public override string Type => "Вітрильник";

	public override string ToString() =>
		base.ToString() + $", щогл: {MastCount}";
}
