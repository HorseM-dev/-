using System;

public class Exam
{
	public string Subject { get; set; }
	public int Mark { get; set; }
	public DateTime Date { get; set; }

	public Exam()
	{
		Subject = "Інформатика";
		Mark = 5;
		Date = DateTime.Now;
	}

	public Exam(string subject, int mark, DateTime date)
	{
		Subject = subject;
		Mark = mark;
		Date = date;
	}

	public override string ToString()
	{
		return $"{Subject}, оцінка: {Mark}, дата: {Date:d}";
	}
}
