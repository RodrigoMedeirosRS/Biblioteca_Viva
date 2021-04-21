using DTO;
using Godot;
using DTO.Dominio;
using Newtonsoft.Json;
using BLL.Extension;

namespace SAL
{
    public class PessoalSAL : BaseSAL
    {
        public PessoalSAL(SALResultsController pai, string host = "http://20.62.91.99​:8080/") : base(host, pai)
        {

        }

        public void Cadastrar(PessoaDTO pessoaDTO)
        {
            CriarRequest("CadastrarPessoaResult", Host + "Api/Pessoa/Cadastrar", JsonConvert.SerializeObject(pessoaDTO));
        }

        public void Consultar(PessoaConsulta pessoaConsulta)
        {
            CriarRequest("ConsultarPessoaResult", Host + "Api/Pessoa/Consultar", JsonConvert.SerializeObject(pessoaConsulta));
        }

        public void ObterRelacoes(int codRegistro)
        {
            CriarRequest("ObterRelacoesPessoaResult", Host + "Api/Pessoa/ObterRelacoes", codRegistro.ToString());
        }
    }
}