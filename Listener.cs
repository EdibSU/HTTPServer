using System;
using System.Net;

using HTTPServer.Formatters;
using HTTPServer.Loggers;
using HTTPServer.Providers;

namespace HTTPServer
{
	public sealed class Listener
	{
		private static readonly HttpListener? _listener;
		private static readonly ILogger? _logger;

		private Listener() { }

		static Listener() 
		{
			try
			{
				_logger = new ConsoleLogger("Listener", new LoggerFormatter());

				_listener = new HttpListener();
				_listener.Prefixes.Add(string.Format($"{ConfigurationProvider.Domain}:{ConfigurationProvider.Port}/"));
				_listener.Start();

				_logger.Log("Listener started at port: " + ConfigurationProvider.Port);
			}
			catch (Exception ex)
			{
				_logger?.Log("Unable to start the listener: " + ex.Message);
			}
		}

		public static HttpListener Get => _listener ?? throw new Exception("Listener not initialized.");
	}
}