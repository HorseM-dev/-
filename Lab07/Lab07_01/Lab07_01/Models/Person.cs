using System;

namespace StudentContainerApp.Models
{
	public class Person : IComparable<Person>, ICloneable
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }

		public Person(string first, string last, DateTime birth)
			=> (FirstName, LastName, BirthDate) = (first, last, birth);

		public override string ToString() =>
			$"{LastName} {FirstName}, народився: {BirthDate:d}";

		public int CompareTo(Person other) =>
			string.Compare(LastName, other?.LastName, StringComparison.Ordinal);

		public object Clone() =>
			new Person(FirstName, LastName, BirthDate);

		public override bool Equals(object obj) =>
			obj is Person p && FirstName == p.FirstName && LastName == p.LastName && BirthDate == p.BirthDate;

		public override int GetHashCode() =>
			HashCode.Combine(FirstName, LastName, BirthDate);
	}
}
