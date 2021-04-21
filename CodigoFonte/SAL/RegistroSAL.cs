using DTO;
using Godot;
using DTO.Dominio;
using Newtonsoft.Json;
using BLL.Extension;

namespace SAL
{
    public class RegistroSAL: BaseSAL
    {
        public RegistroSAL(SALResultsController pai, string host = "http://20.62.91.99​:8080/") : base(host, pai)
        {

        }
        public void Cadastrar(RegistroDTO registroDTO)
        {
            CriarRequest("CadastrarRegistroResult", Host + "Api/Registro/Cadastrar", JsonConvert.SerializeObject(registroDTO));
        }

        public void Consultar(RegistroConsulta registroConsulta)
        {
            CriarRequest("ConsultarRegistroResult", Host + "Api/Registro/Consultar", JsonConvert.SerializeObject(registroConsulta));
        }

        public void ObterReferenciasRegistroResult(int codRegistro)
        {
            CriarRequest("ObterRelacoesPessoaResult", Host + "Api/Registro/ObterReferencias", codRegistro.ToString());
        }
    }
}