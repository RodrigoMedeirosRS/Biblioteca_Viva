using DTO;
using SAL;
using Godot;
using BLL.Utils;
using DTO.Dominio;
using BLL.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BLL
{
	public class BarraDeBuscaBLL : IBarraDeBuscaBLL
	{
		public LineEdit BarraDeBusca { get; set; }

		public BarraDeBuscaBLL(LineEdit barraDeBusca)
		{
			BarraDeBusca = barraDeBusca;
		}

		public void ObterPessoas(PessoaConsulta pessoaConsulta)
		{
			var corpo = JsonConvert.SerializeObject(pessoaConsulta);
			StaticSAL.CriarRequest("ConsultarPessoaResult", "/Api/Pessoa/Consultar", corpo, BarraDeBusca, CriaHTTPRequest(true));
		}

		public void ObterRegistro(RegistroConsulta registroConsulta)
		{
			var corpo = JsonConvert.SerializeObject(registroConsulta);
			StaticSAL.CriarRequest("ConsultarRegistroResult", "/Api/Registro/Consultar", corpo, BarraDeBusca, CriaHTTPRequest(false));
		}

		private HTTPRequest CriaHTTPRequest(bool pessoa)
		{
			var request = new HTTPRequest();
			BarraDeBusca.AddChild(request);
			return request;
		}
	}
}
