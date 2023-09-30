using System;
using HTTPServer.Formatters.Logger;

namespace HTTPServer.Formatters
{
    public class LoggerFormatter : ILoggerFormatter
	{
		private ILoggerFormattable? _formattable = null;

		public LoggerFormatter() { }

		public string Format(string message)
		{
			if (_formattable == null) 
				throw new Exception("Formattable has not been set. Call ILoggerFormatter.SetFormattable before using IloggerFormatter.Format.");

			string source = _formattable.Source + "." + _formattable.Caller;

			return $"{_formattable.Counter, 3} | {source, 20} | {message}" + Environment.NewLine;
		}

		public ILoggerFormatter Init(ILoggerFormattable formattable)
		{
			_formattable = formattable;

			return this;
		}
	}
}