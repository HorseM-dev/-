using System;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		// 1. Створення студента за замовчуванням
		var student = new Student();
		Console.WriteLine("➡️ ToShortString():");
		Console.WriteLine(student.ToShortString());

		// 2. Індексатор
		Console.WriteLine("\n➡️ Перевірка Education:");
		Console.WriteLine($"Specialist: {student[Education.Specialist]}");
		Console.WriteLine($"Bachelor:   {student[Education.Bachelor]}");
		Console.WriteLine($"SecondEd:   {student[Education.SecondEducation]}");

		// 3. Присвоєння всіх полів
		var person = new Person("Олена", "Петренко", new DateTime(2002, 5, 10));
		student.PersonalData = person;
		student.EducationForm = Education.Specialist;
		student.GroupNumber = 213;
		student.Exams = new List<Exam>
		{
			new Exam("Математика", 5, new DateTime(2023, 6, 1)),
			new Exam("Фізика", 4, new DateTime(2023, 6, 3))
		};

		Console.WriteLine("\n➡️ ToString():");
		Console.WriteLine(student);

		// 4. Додавання іспитів
		student.AddExams(
			new Exam("Програмування", 5, DateTime.Today),
			new Exam("Філософія", 3, DateTime.Today)
		);

		Console.WriteLine("\n➡️ Після додавання нових іспитів:");
		foreach (var exam in student.Exams)
			Console.WriteLine("  " + exam);

		// 5. Масив студентів та відбір на стипендію (бал ≥ 4.5)
		Console.WriteLine("\n➡️ Студенти з середнім балом ≥ 4.5:");
		var students = new List<Student>
		{
			student,
			new Student(
				new Person("Богдан", "Грищенко", new DateTime(2001, 3, 12)),
				Education.Bachelor, 202,
				new List<Exam>
				{
					new Exam("Алгебра", 3, DateTime.Today),
					new Exam("Географія", 4, DateTime.Today)
				}),

			new Student(
				new Person("Ліля", "Кравчук", new DateTime(2003, 7, 8)),
				Education.SecondEducation, 305,
				new List<Exam>
				{
					new Exam("Право", 5, DateTime.Today),
					new Exam("Етика", 5, DateTime.Today)
				})
		};

		foreach (var s in students)
		{
			if (s.AverageMark >= 4.5)
				Console.WriteLine("✅ " + s.ToShortString());
		}
	}
}
