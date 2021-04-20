using Godot;
using BLL.Extension;


namespace SAL
{
    public abstract class BaseSAL
    {
        protected HTTPRequest Request { get; set; }
        protected SALResultsController Pai { get; set; }
        public string Host { get; set; }
        public BaseSAL(string host, SALResultsController pai)
        {
            Host = host;
            Request = new HTTPRequest();
            pai.AddChild(Request);
        }

        public void CriarRequest(string metodoDeRetorno, string endpoint, string body)
        {
		    Request.Connect("request_completed", Pai, metodoDeRetorno);
		    var error = Request.Request(endpoint, null, false, HTTPClient.Method.Post, body);
            if (error != Error.Ok)
                GD.Print(error);
        }
    }
}