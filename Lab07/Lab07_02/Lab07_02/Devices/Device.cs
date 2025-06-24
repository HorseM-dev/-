using System;

public class Device : IDevice, ICloneable, IComparable<Device>
{
	public string Name { get; set; }
	public bool IsElectronic { get; set; }

	public Device(string name, bool isElectronic)
	{
		Name = name;
		IsElectronic = isElectronic;
	}

	public virtual object Clone() => MemberwiseClone();

	public virtual int CompareTo(Device other) =>
		Name.CompareTo(other.Name);

	public override string ToString() => $"{Name} (Електронний: {IsElectronic})";

	public override bool Equals(object obj) =>
		obj is Device d && Name == d.Name && IsElectronic == d.IsElectronic;

	public override int GetHashCode() => HashCode.Combine(Name, IsElectronic);
}
