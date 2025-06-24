public class Airplane : Device, IEngine
{
	public string EngineType { get; }
	public double Power { get; }

	public Airplane(string name, string engineType, double power)
		: base(name, true)
	{
		EngineType = engineType;
		Power = power;
	}

	public override string ToString() =>
		$"Літак {Name} | Двигун: {EngineType}, {Power} к.с.";
}
