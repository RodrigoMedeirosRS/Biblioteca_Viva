using Godot;
using System.Collections.Generic;

namespace SAL
{
	public static class StaticSAL
	{
		private static string Host { get; set; }
		private static List<string> Headers { get; set; }
		private static void PopularHeaders()
		{
			
			Host = false ? "20.62.91.99​:8080" : "localhost:5000";
			Headers = new List<string>()
			{
				"Content-Type: application/json",
				"Accept: */*",
				"Accept-Encoding: gzip, deflate, br",
				"Connection: keep-alive"
			};
		}

		public static void CriarRequest(string metodoDeRetorno, string endpoint, string body, Node requisitor, HTTPRequest request)
		{
			if (Headers == null)
				PopularHeaders();
			ExecutarRequest(metodoDeRetorno, endpoint, body, requisitor, request);
		}

		private static void ExecutarRequest(string metodoDeRetorno, string endpoint, string body, Node requisitor, HTTPRequest request)
		{
			Headers.Add("Content-Length: " + body.Length);
			request.Connect("request_completed", requisitor, metodoDeRetorno);
			request.Request("http://" + Host + endpoint, Headers.ToArray(), false, HTTPClient.Method.Post, body);
		}
	}
}
