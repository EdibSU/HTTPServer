using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using HTTPServer.Formatters.Logger;
using HTTPServer.Managers;

namespace HTTPServer.Loggers
{
	public class FileLogger : ILogger, ILoggerFormattable
	{
		private static Dictionary<string, int> _counter = new Dictionary<string, int>();

		private readonly FileManager _fileManager;
		private readonly string _fileName;
		private readonly string _source;
		private string? _caller = null;
		private ILoggerFormatter _formatter;

		public FileLogger(string fileName, string source, ILoggerFormatter formatter)
		{
			_fileName = fileName;
			_fileManager = new FileManager(_fileName + ".txt", "Logs");
			_source = source[0..Math.Min(10, source.Length)];

			if (!_counter.ContainsKey(_fileName))
			{
				_fileManager.Clear();
				_counter.Add(_fileName, 0);
			}
			
			_formatter = formatter.Init(this);
		}

		int ILoggerFormattable.Counter => _counter[_fileName];

		string ILoggerFormattable.Source => _source;

		string ILoggerFormattable.Caller => _caller ?? string.Empty;

		public void Log(string message, [CallerMemberName] string? caller = null)
		{
			_counter[_fileName]++;
			_caller = caller ?? string.Empty;

			_fileManager.Save(_formatter.Format(message));
		}
	}
}