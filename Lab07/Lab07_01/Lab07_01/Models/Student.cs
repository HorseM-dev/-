using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentContainerApp.Models
{
	public class Student
	{
		public Person Info { get; set; }
		public string Faculty { get; set; }
		public List<Exam> Exams { get; set; } = new();

		public double AvgMark => Exams.Count == 0 ? 0 : Exams.Average(e => e.Mark);

		public Student(Person info, string faculty)
			=> (Info, Faculty) = (info, faculty);

		public override string ToString()
		{
			var examsStr = Exams.Count == 0 ? "—" : string.Join(", ", Exams);
			return $"{Info} | Факультет: {Faculty}, Середній бал: {AvgMark:F2} \n  Іспити: {examsStr}";
		}

		public override bool Equals(object obj) =>
			obj is Student s && Info.Equals(s.Info) && Faculty == s.Faculty;

		public override int GetHashCode() => HashCode.Combine(Info, Faculty);
	}
}
