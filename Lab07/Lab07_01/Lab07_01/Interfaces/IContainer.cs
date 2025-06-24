namespace StudentContainerApp.Interfaces
{
	public interface IContainer<T>
	{
		int Count { get; }
		T this[int index] { get; set; }
		void Add(T element);
		void Delete(T element);
	}

	public interface IFileContainer<T> : IContainer<T>
	{
		void Save(string fileName);
		void Load(string fileName);
		bool IsDataSaved { get; }
	}
}
