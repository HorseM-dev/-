public class HotAirBalloon : Device
{
	public string GasType { get; }

	public HotAirBalloon(string name, string gasType)
		: base(name, false)
	{
		GasType = gasType;
	}

	public override string ToString() =>
		$"Куля {Name} | Газ: {GasType}";
}
