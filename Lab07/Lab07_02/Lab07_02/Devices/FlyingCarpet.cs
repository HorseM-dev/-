public class FlyingCarpet : Device
{
	public FlyingCarpet(string name)
		: base(name, false) { }

	public override string ToString() =>
		$"Килим-літак {Name} (магічний 🌟)";
}
