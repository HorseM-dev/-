﻿using System;

public class Person
{
	private string firstName;
	private string lastName;
	private DateTime birthDate;

	public Person()
	{
		firstName = "Іван";
		lastName = "Іваненко";
		birthDate = new DateTime(2000, 1, 1);
	}

	public Person(string firstName, string lastName, DateTime birthDate)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.birthDate = birthDate;
	}

	public string FirstName
	{
		get => firstName;
		set => firstName = value;
	}

	public string LastName
	{
		get => lastName;
		set => lastName = value;
	}

	public DateTime BirthDate
	{
		get => birthDate;
		set => birthDate = value;
	}

	public int BirthYear
	{
		get => birthDate.Year;
		set => birthDate = new DateTime(value, birthDate.Month, birthDate.Day);
	}

	public override string ToString()
	{
		return $"{firstName} {lastName}, народився {birthDate:d}";
	}

	public string ToShortString()
	{
		return $"{firstName} {lastName}";
	}
}
