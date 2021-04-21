using DTO;
using Godot;
using Newtonsoft.Json;
using BLL.Extension;

namespace SAL
{
    public class TipoSAL : BaseSAL
    {
        public TipoSAL(SALResultsController pai, string host = "http://20.62.91.99​:8080/") : base(host, pai)
        {

        }

        public void CadastrarTipo(TipoDTO tipoDTO)
        {
            CriarRequest("CadastrarTipoResult", Host + "Api/Tipo/CadastrarTipo", JsonConvert.SerializeObject(tipoDTO));
        }

        public void CadastrarTipoRelacao(TipoRelacaoDTO tipoRelacaoDTO)
        {
            CriarRequest("CadastrarTipoRelacaoResult", Host + "Api/Tipo/CadastrarTipoRelacao", JsonConvert.SerializeObject(tipoRelacaoDTO));
        }

        public void CadastrarIdioma(IdiomaDTO idiomaDTO)
        {
            CriarRequest("CadastrarIdiomaResult", Host + "Api/Tipo/CadastrarIdioma", JsonConvert.SerializeObject(idiomaDTO));
        }

        public void ConsultarTipo()
        {
            CriarRequest("ConsultarTipoResult", Host + "Api/Tipo/Consultar", JsonConvert.SerializeObject("Tipo"));
        }

        public void ConsultarTipoRelacao()
        {
            CriarRequest("ConsultarTipoRelacaoResult", Host + "Api/TipoRelacao/Consultar", JsonConvert.SerializeObject("TipoRelacao"));
        }

        public void ConsultarIdioma()
        {
            CriarRequest("ConsultarIdiomaResult", Host + "Api/Pessoa/Consultar", JsonConvert.SerializeObject("Idioma"));
        }
    }
}