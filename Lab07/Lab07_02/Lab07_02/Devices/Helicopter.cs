public class Helicopter : Device, IEngine
{
	public string EngineType { get; }
	public double Power { get; }

	public Helicopter(string name, string engineType, double power)
		: base(name, true)
	{
		EngineType = engineType;
		Power = power;
	}

	public override string ToString() =>
		$"Вертоліт {Name} | Двигун: {EngineType}, {Power} к.с.";
}
