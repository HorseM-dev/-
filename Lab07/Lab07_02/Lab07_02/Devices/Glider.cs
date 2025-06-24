public class Glider : Device, IPart
{
	public string Material { get; }

	public Glider(string name, string material)
		: base(name, false)
	{
		Material = material;
	}

	public override string ToString() =>
		$"Дельтаплан {Name} | Матеріал: {Material}";
}
