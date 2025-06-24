using System;

namespace StudentContainerApp.Models
{
	public class Exam : IComparable<Exam>, ICloneable
	{
		public string Subject { get; set; }
		public int Mark { get; set; }
		public DateTime Date { get; set; }

		public Exam(string subject, int mark, DateTime date)
			=> (Subject, Mark, Date) = (subject, mark, date);

		public override string ToString() => $"{Subject} — {Mark} балів ({Date:d})";

		public int CompareTo(Exam other) =>
			string.Compare(Subject, other?.Subject, StringComparison.Ordinal);

		public object Clone() => new Exam(Subject, Mark, Date);

		public override bool Equals(object obj) =>
			obj is Exam e && Subject == e.Subject && Mark == e.Mark && Date == e.Date;

		public override int GetHashCode() => HashCode.Combine(Subject, Mark, Date);
	}
}
