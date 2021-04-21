using DTO;
using DTO.Dominio;
using SAL.Interface;
using Newtonsoft.Json;

namespace SAL
{
    public class PessoalSAL : BaseSAL
    {
        public PessoalSAL(ResultSAL nodoPai) : base(nodoPai)
        {

        }
        
        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            CriarRequest("CadastrarPessoaResult", "/Api/Pessoa/Cadastrar", JsonConvert.SerializeObject(pessoaDTO));
        }

        public void Consultar(PessoaConsulta pessoaConsulta)
        {
            CriarRequest("ConsultarPessoaResult", "/Api/Pessoa/Consultar", JsonConvert.SerializeObject(pessoaConsulta));
        }

        public void ObterRelacoes(int codRegistro)
        {
            CriarRequest("ObterRelacoesPessoaResult", "/Api/Pessoa/ObterRelacoes", codRegistro.ToString());
        }
    }
}