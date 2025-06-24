using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using StudentContainerApp.Interfaces;
using StudentContainerApp.Models;
using System.Text.Json;

namespace StudentContainerApp.Containers
{
	public class StudentContainer : IFileContainer<Student>, IEnumerable<Student>
	{
		private List<Student> _students = new();
		public bool IsDataSaved { get; private set; } = false;

		public int Count => _students.Count;

		public Student this[int index]
		{
			get => (index >= 0 && index < Count) ? _students[index] : throw new IndexOutOfRangeException();
			set
			{
				if (index >= 0 && index < Count) _students[index] = value;
				else throw new IndexOutOfRangeException();
			}
		}

		public void Add(Student element)
		{
			if (element != null) _students.Add(element);
			IsDataSaved = false;
		}

		public void Delete(Student element)
		{
			_students.Remove(element);
			IsDataSaved = false;
		}

		public void Save(string fileName)
		{
			var json = JsonSerializer.Serialize(_students, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(fileName, json);
			IsDataSaved = true;
		}

		public void Load(string fileName)
		{
			if (File.Exists(fileName))
			{
				string json = File.ReadAllText(fileName);
				_students = JsonSerializer.Deserialize<List<Student>>(json) ?? new();
				IsDataSaved = true;
			}
		}

		public IEnumerator<Student> GetEnumerator() => _students.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
