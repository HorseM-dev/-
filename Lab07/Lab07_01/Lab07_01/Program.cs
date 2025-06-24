using System;
using System.Linq;
using StudentContainerApp.Containers;
using StudentContainerApp.Models;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		var container = new StudentContainer();

		container.Add(CreateStudent("Іван", "Іваненко", "ІТ", new[] { (90, "Алгебра"), (85, "Інформатика") }));
		container.Add(CreateStudent("Олена", "Петренко", "Фізика", new[] { (75, "Фізика"), (88, "Хімія") }));
		container.Add(CreateStudent("Юрій", "Коваленко", "ІТ", new[] { (95, "Математика") }));
		container.Add(CreateStudent("Тетяна", "Лисенко", "Фізика", new[] { (82, "Біологія") }));

		Console.WriteLine("🟢 Вміст контейнера:");
		Print(container);

		var sorted = container.OrderBy(s => s.AvgMark).ToList();

		Console.WriteLine("\n🔃 Після сортування за середнім балом:");
		foreach (var s in sorted)
			Console.WriteLine("• " + s.Info + $" (Середній бал: {s.AvgMark:F2})");

		// Зберегти
		container.Save("students.json");
		Console.WriteLine("\n💾 Збережено до students.json");

		// Скопіювати перші 2
		var topTwo = new StudentContainer();
		foreach (var s in sorted.Take(2))
			topTwo.Add(s);

		Console.WriteLine("\n📋 Новий контейнер (перші 2):");
		Print(topTwo);
		topTwo.Save("top2.json");
		Console.WriteLine("💾 Збережено до top2.json");
	}

	static Student CreateStudent(string first, string last, string faculty, (int, string)[] exams)
	{
		var s = new Student(new Person(first, last, new DateTime(2002, 1, 1)), faculty);
		foreach (var (mark, subj) in exams)
			s.Exams.Add(new Exam(subj, mark, DateTime.Today));
		return s;
	}

	static void Print(StudentContainer cont)
	{
		foreach (var s in cont)
			Console.WriteLine("• " + s);
	}
}
