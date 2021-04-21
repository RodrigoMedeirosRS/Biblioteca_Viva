using DTO;
using DTO.Dominio;
using SAL.Interface;
using Newtonsoft.Json;

namespace SAL
{
    public class RegistroSAL : BaseSAL, IRegistroSAL
    {
        public RegistroSAL(ResultSAL nodoPai) : base(nodoPai)
        {

        }
        public void Cadastrar(RegistroDTO registroDTO)
        {
            CriarRequest("CadastrarRegistroResult", "/Api/Registro/Cadastrar", JsonConvert.SerializeObject(registroDTO));
        }

        public void Consultar(RegistroConsulta registroConsulta)
        {
            CriarRequest("ConsultarRegistroResult", "/Api/Registro/Consultar", JsonConvert.SerializeObject(registroConsulta));
        }

        public void ObterReferenciasRegistroResult(int codRegistro)
        {
            CriarRequest("ObterRelacoesPessoaResult", "/Api/Registro/ObterReferencias", codRegistro.ToString());
        }
    }
}