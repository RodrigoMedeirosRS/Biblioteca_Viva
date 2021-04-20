using DTO;
using BLL;
using BLL.Utils;
using BLL.Interface;
using Godot;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Controller
{
    public class ServiceController : Node2D
    {
        protected IMainBLL BLL { get; set; }
        protected HTTPRequest Request { get; set; }

        protected void CriarRequest()
		{
			Request = new HTTPRequest();
			this.AddChild(Request);
			Request.Connect("request_completed", this, "RequestResult");
			var error = Request.Request("http://localhost:5000/Api/Tipo/ConsultarIdiomas", null, false, HTTPClient.Method.Post, "vivo");
		}

		protected void RequestResult(int result, int response_code, string[] headers, byte[] body)
		{
			var json = System.Text.Encoding.UTF8.GetString(body);
			BLL.Idiomas = JsonConvert.DeserializeObject<List<IdiomaDTO>>(json);
			BLL.PopularDropDownIdioma(GetNode<OptionButton>("./Controles/Idioma"));
		}
    }
}