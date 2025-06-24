using System;
using System.Collections.Generic;

public class Song
{
	public string Title { get; set; }
	public string AuthorFullName { get; set; }
	public string Composer { get; set; }
	public int Year { get; set; }
	public string Lyrics { get; set; }
	public List<string> Performers { get; set; } = new();

	public override string ToString()
	{
		string perf = string.Join(", ", Performers);
		return $"🎵 Назва: {Title}\nАвтор: {AuthorFullName}\nКомпозитор: {Composer}\nРік: {Year}\nВиконавці: {perf}\nТекст:\n{Lyrics}";
	}
}
