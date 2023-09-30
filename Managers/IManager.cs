namespace HTTPServer.Managers
{
	public interface IManager
	{
		string Load();

		void Save(string data);
	}
}