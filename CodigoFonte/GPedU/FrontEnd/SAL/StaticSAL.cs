using Godot;
using System.Collections.Generic;

namespace SAL
{
	public static class StaticSAL
	{
		private static string Host { get; set; }
		private static string[] PopularHeader(int tamanho)
		{
			return new string[]
			{
				"Content-Type: application/json",
				//"Accept: */*",
				//"Accept-Encoding: gzip, deflate, br",
				//"Connection: keep-alive",
				//"Content-Length: " + tamanho
			};
		}

		public static void CriarRequest(string metodoDeRetorno, string endpoint, string body, Node requisitor, HTTPRequest request)
		{
			VerificarHost();
			ExecutarRequest(metodoDeRetorno, endpoint, body, requisitor, request);
		}

		private static void VerificarHost()
		{
			if (string.IsNullOrEmpty(Host))
				Host = false ? "20.62.91.99​:8080" : "localhost:5000";
		}

		private static void ExecutarRequest(string metodoDeRetorno, string endpoint, string body, Node requisitor, HTTPRequest request)
		{
			request.Connect("request_completed", requisitor, metodoDeRetorno);
			var a = request.Request("http://" + Host + endpoint, new string[] { "Content-Type: application/json" }, false, HTTPClient.Method.Post, body);
		}
	}
}
