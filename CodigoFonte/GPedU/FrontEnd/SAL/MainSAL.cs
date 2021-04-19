using DTO;
using SAL.Interface;
using Godot;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAL
{
	public class MainSAL : IMainSAL
	{
		private string URL { get; set; }
		
		public MainSAL()
		{
			URL = "http://20.62.91.99​:8080/Api/";
		}
		public List<IdiomaDTO> ObterIdiomas()
		{
			var values = new Dictionary<string, string>();
			//var retorno = EnviarSAL.WSPost(URL + "Tipo/ConsultarIdiomas", string.Empty);

			EnviarSAL.Post("http://20.62.91.99​:8080/Api/Tipo/ConsultarIdiomas", values);
			GD.Print();
			return new List<IdiomaDTO>();
		}

		public List<TipoDTO> ObterTipos()
		{
			//var retorno = EnviarSAL.WSPost(URL + "Tipo/ConsultarTipos", string.Empty);
			return new List<TipoDTO>();
		}

		public List<TipoRelacaoDTO> ObterTiposRelacao()
		{
			//var retorno = EnviarSAL.WSPost(URL + "Tipo/ConsultarTiposRelacao", string.Empty);
			return new List<TipoRelacaoDTO>();
		}

	}
}
