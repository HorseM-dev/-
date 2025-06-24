using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
	private Person person;
	private Education education;
	private int groupNumber;
	private List<Exam> exams;

	public Student()
	{
		person = new Person();
		education = Education.Bachelor;
		groupNumber = 101;
		exams = new List<Exam>();
	}

	public Student(Person person, Education education, int groupNumber, List<Exam> exams)
	{
		this.person = person;
		this.education = education;
		this.groupNumber = groupNumber;
		this.exams = exams ?? new List<Exam>();
	}

	public Person PersonalData
	{
		get => person;
		set => person = value ?? throw new ArgumentNullException();
	}

	public Education EducationForm
	{
		get => education;
		set => education = value;
	}

	public int GroupNumber
	{
		get => groupNumber;
		set
		{
			if (value <= 0) throw new ArgumentException("Номер групи повинен бути додатнім");
			groupNumber = value;
		}
	}

	public List<Exam> Exams
	{
		get => exams;
		set => exams = value ?? new List<Exam>();
	}

	public double AverageMark => exams.Count == 0 ? 0.0 : exams.Average(e => e.Mark);

	public bool this[Education edu] => education == edu;

	public void AddExams(params Exam[] newExams)
	{
		exams.AddRange(newExams);
	}

	public override string ToString()
	{
		string examsInfo = exams.Count == 0
			? "  Іспити відсутні."
			: string.Join("\n  ", exams.Select(e => e.ToString()));

		return $"Студент: {person}\nОсвіта: {education}\nГрупа: {groupNumber}\nІспити:\n  {examsInfo}";
	}

	public string ToShortString()
	{
		return $"Студент: {person.ToShortString()}\nОсвіта: {education}\nГрупа: {groupNumber}\nСередній бал: {AverageMark:F2}";
	}
}
	