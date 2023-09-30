using System;
using System.Net;
using System.Text;

namespace HTTPServer
{
	public class Program
	{
		static void Main(string[] args)
		{
			var listener = Listener.Get;

			while (true)
			{
				var context = listener.GetContext();
				var request = context.Request;
				var response = context.Response;

				string responseString = string.Empty;

				switch (request?.RawUrl?.ToLower())
				{
					case "/api/services":
						responseString = "<div>/api/services</div>";
						break;
					case "/api/alarms/active":
						responseString = "<div>/api/alarms/active</div>";
						break;
					default:
						break;
				}

				byte[] buffer = Encoding.UTF8.GetBytes(responseString);
				response.ContentLength64 = buffer.Length;

				var responseOutput = response.OutputStream;
				responseOutput.Write(buffer, 0, buffer.Length);
				response.Close();
			}
		}

		void Foo()
		{
			var listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:8080/");
			listener.Start();

			Console.WriteLine("Server started on http://localhost:8080/");

			while (true)
			{
				var context = listener.GetContext();
				var request = context.Request;
				var response = context.Response;

				string responseString = string.Empty;

				switch (request?.RawUrl?.ToLower())
				{
					case "/api/services":
						responseString = "<div>/api/services</div>";
						break;
					case "/api/alarms/active":
						responseString = "<div>/api/alarms/active</div>";
						break;
					default:
						break;
				}

				byte[] buffer = Encoding.UTF8.GetBytes(responseString);
				response.ContentLength64 = buffer.Length;

				var responseOutput = response.OutputStream;
				responseOutput.Write(buffer, 0, buffer.Length);
				response.Close();
			}

		}
	}
}