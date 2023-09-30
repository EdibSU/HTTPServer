using System;
using System.Runtime.CompilerServices;
using HTTPServer.Formatters.Logger;

namespace HTTPServer.Loggers
{
    public class ConsoleLogger : ILogger, ILoggerFormattable
	{
		private readonly string _source;
		private int _counter = 0;
		private string? _caller = null;
		private ILoggerFormatter _formatter;

		public ConsoleLogger(string source, ILoggerFormatter formatter)
		{
			_source = source[0..System.Math.Min(10, source.Length)];

			_formatter = formatter.Init(this);
		}

		int ILoggerFormattable.Counter => _counter;

		string ILoggerFormattable.Source => _source;

		string ILoggerFormattable.Caller => _caller ?? string.Empty;

		public void Log(string message, [CallerMemberName] string? caller = null)
		{
			_counter++;
			_caller = caller ?? string.Empty;

			Console.Write(_formatter.Format(message));
        }
	}
}