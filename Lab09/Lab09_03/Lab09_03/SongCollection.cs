using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class SongCollection
{
	private List<Song> songs = new();

	public void Add(Song song) => songs.Add(song);

	public bool Remove(string title)
	{
		var song = songs.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
		return song != null && songs.Remove(song);
	}

	public bool Edit(string title, Action<Song> update)
	{
		var song = songs.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
		if (song == null) return false;
		update(song);
		return true;
	}

	public List<Song> Search(Func<Song, bool> predicate) =>
		songs.Where(predicate).ToList();

	public void Save(string filePath)
	{
		var json = JsonSerializer.Serialize(songs, new JsonSerializerOptions { WriteIndented = true });
		File.WriteAllText(filePath, json);
	}

	public void Load(string filePath)
	{
		if (!File.Exists(filePath)) return;
		string json = File.ReadAllText(filePath);
		songs = JsonSerializer.Deserialize<List<Song>>(json) ?? new();
	}

	public List<Song> GetByPerformer(string performer) =>
		songs.Where(s => s.Performers.Any(p => p.Equals(performer, StringComparison.OrdinalIgnoreCase))).ToList();

	public void PrintAll()
	{
		if (songs.Count == 0)
			Console.WriteLine("Колекція порожня.");
		else
			songs.ForEach(s =>
			{
				Console.WriteLine("\n---");
				Console.WriteLine(s);
			});
	}
}
