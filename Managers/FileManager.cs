using System.IO;

using HTTPServer.Providers;

namespace HTTPServer.Managers
{
	public class FileManager : IManager
	{
		private readonly string _directory;
		private readonly string _path;

		public FileManager(string file, string directory = "", bool relative = false)
		{
			if (relative) _directory = directory;
			else _directory = Path.Combine(PathProvider.Solution, directory);

			_path = Path.Combine(_directory, file);

			CreateFile();
		}

		public string Load()
		{
			CreateFile();

			return File.ReadAllText(_path);
		}

		public void Save(string data)
		{
			CreateFile();

			File.AppendAllText(_path, data);
		}

		public bool Clear()
		{
			if (!File.Exists(_path)) return false;

			File.WriteAllText(_path, string.Empty);

			return true;
		}

		private void CreateFile()
		{
			if (!Directory.Exists(_directory))
			{
				Directory.CreateDirectory(_directory);
			}

			if (!File.Exists(_path))
			{
				File.Create(_path).Close();
				
			}
		}
	}
}