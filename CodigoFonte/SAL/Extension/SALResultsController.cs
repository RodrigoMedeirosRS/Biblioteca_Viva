using DTO;
using DTO.Dominio;
using BLL;
using BLL.Utils;
using BLL.Interface;

using Godot;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BLL.Extension
{
    public class SALResultsController : Node2D
    {
        protected IMainBLL BLL { get; set; }
        List<IdiomaDTO> IdiomasDTO { get; set; }
        #region Pessoa
        public void CadastrarPessoaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

        public void ConsultarPessoaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    var retorno = JsonConvert.DeserializeObject<List<PessoaDTO>>(json);
        }

        public void ObterRelacoesPessoaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    var retorno = JsonConvert.DeserializeObject<List<RegistroDTO>>(json);
        }
        #endregion

        #region Regitro
        public void CadastrarRegistroResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

        public void ConsultarRegistroResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    var retorno = JsonConvert.DeserializeObject<List<RegistroDTO>>(json);
        }

        public void ObterReferenciasRegistroResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    var retorno = JsonConvert.DeserializeObject<List<RegistroDTO>>(json);
        }
        #endregion

        #region Sontar
        public void ConsultarSonarResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            var retorno = JsonConvert.DeserializeObject<SonarRetorno>(json);
        }
        #endregion
        
        #region Tipo
	    public void CadastrarTipoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

	    public void CadastrarTipoRelacaoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

	    public void CadastrarIdiomaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

	    public void ConsultarTipoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            var retorno = JsonConvert.DeserializeObject<List<TipoDTO>>(json);
        }

	    public void ConsultarTipoRelacaoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            var retorno = JsonConvert.DeserializeObject<List<TipoRelacaoDTO>>(json);
        }

	    public void ConsultarIdiomaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            IdiomasDTO = JsonConvert.DeserializeObject<List<IdiomaDTO>>(json);
            
        }
        #endregion
    }
}