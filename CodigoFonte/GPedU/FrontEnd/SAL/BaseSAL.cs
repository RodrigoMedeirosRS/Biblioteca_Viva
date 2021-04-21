using Godot;

namespace SAL
{
    public abstract class BaseSAL
    {
        protected HTTPRequest Request { get; set; }
        protected ResultSAL NodoPai { get; set; }
        protected string Host { get; set; }
        protected string[] Headers { get; set; }

        public BaseSAL(ResultSAL nodoPai)
        {
            PopularVariaveis(nodoPai);
            PopularHeaders();
        }

        protected void PopularVariaveis(ResultSAL nodoPai)
        {
            NodoPai = nodoPai;
            Request = new HTTPRequest();
            NodoPai.AddChild(Request);
        }

        protected void PopularHeaders()
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

        protected void CriarRequest(string metodoDeRetorno, string endpoint, string body)
        {
		    Request.Connect("request_completed", NodoPai, metodoDeRetorno);
		    Request.Request("http://"+ Host + endpoint, Headers, false, HTTPClient.Method.Post, body);
        }
    }
}