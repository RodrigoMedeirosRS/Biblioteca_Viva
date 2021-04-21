using DTO;
using DTO.Dominio;
using Godot;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SAL
{
    public abstract class ResultSAL : Node2D
    {
        #region Pessoa
        protected virtual void CadastrarPessoaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

        protected virtual List<PessoaDTO> ConsultarPessoaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    return JsonConvert.DeserializeObject<List<PessoaDTO>>(json);
        }

        protected virtual List<RegistroDTO> ObterRelacoesPessoaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    return JsonConvert.DeserializeObject<List<RegistroDTO>>(json);
        }
        #endregion

        #region Regitro
        protected virtual void CadastrarRegistroResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

        protected virtual List<RegistroDTO> ConsultarRegistroResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    return JsonConvert.DeserializeObject<List<RegistroDTO>>(json);
        }

        protected virtual List<RegistroDTO> ObterReferenciasRegistroResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
		    return JsonConvert.DeserializeObject<List<RegistroDTO>>(json);
        }
        #endregion

        #region Sontar
        protected virtual SonarRetorno ConsultarSonarResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            return JsonConvert.DeserializeObject<SonarRetorno>(json);
        }
        #endregion
        
        #region Tipo
	    protected virtual void CadastrarTipoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

	    protected virtual void CadastrarTipoRelacaoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

	    protected virtual void CadastrarIdiomaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
        }

	    protected virtual List<TipoDTO> ConsultarTipoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            return JsonConvert.DeserializeObject<List<TipoDTO>>(json);
        }

	    protected virtual List<TipoRelacaoDTO> ConsultarTipoRelacaoResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            return JsonConvert.DeserializeObject<List<TipoRelacaoDTO>>(json);
        }

	    protected virtual List<IdiomaDTO> ConsultarIdiomaResult(int result, int response_code, string[] headers, byte[] body)
        {
		    var json = System.Text.Encoding.UTF8.GetString(body);
            return JsonConvert.DeserializeObject<List<IdiomaDTO>>(json);    
        }
        #endregion
    }
}