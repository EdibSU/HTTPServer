using System.Runtime.CompilerServices;

namespace HTTPServer.Loggers
{
	public interface ILogger
	{
		void Log(string message, [CallerMemberName] string? callerName = null);
	}
}