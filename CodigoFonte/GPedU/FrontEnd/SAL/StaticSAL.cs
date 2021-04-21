using Godot;

namespace SAL
{
    public static class StaticSAL
    {
        private static string Host { get; set; }
        private static string[] Headers { get; set; }
        private static void PopularHeaders()
		{
			
			Host = false ? "20.62.91.99​:8080" : "localhost:5000";
			Headers = new string[]
			{
				"Content-Type: application/json",
				"Accept: */*",
				"Accept-Encoding: gzip, deflate, br",
				"Connection: keep-alive",
				"Content-Length: " + 6
			};
		}

        public static void CriarRequest(string metodoDeRetorno, string endpoint, string body, Node requisitor, HTTPRequest request)
        {
            PopularHeaders();
		    request.Connect("request_completed", requisitor, metodoDeRetorno);
		    request.Request("http://"+ Host + endpoint, Headers, false, HTTPClient.Method.Post, body);
        }
    }
}