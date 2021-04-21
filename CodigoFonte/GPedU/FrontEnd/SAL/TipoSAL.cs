using DTO;
using SAL.Interface;
using Newtonsoft.Json;

namespace SAL
{
    public class TipoSAL : BaseSAL, ITipoSAL
    {
		public TipoSAL(ResultSAL nodoPai) : base(nodoPai)
		{
			
		}
		public void CadastrarTipo(TipoDTO tipoDTO)
        {
            CriarRequest("CadastrarTipoResult", "/Api/Tipo/CadastrarTipo", JsonConvert.SerializeObject(tipoDTO));
        }

        public void CadastrarTipoRelacao(TipoRelacaoDTO tipoRelacaoDTO)
        {
            CriarRequest("CadastrarTipoRelacaoResult", "/Api/Tipo/CadastrarTipoRelacao", JsonConvert.SerializeObject(tipoRelacaoDTO));
        }

        public void CadastrarIdioma(IdiomaDTO idiomaDTO)
        {
            CriarRequest("CadastrarIdiomaResult", "/Api/Tipo/CadastrarIdioma", JsonConvert.SerializeObject(idiomaDTO));
        }

        public void ConsultarTipo()
        {
            CriarRequest("ConsultarTipoResult", "/Api/Tipo/ConsultarTipos", JsonConvert.SerializeObject("Tipo"));
        }

        public void ConsultarTipoRelacao()
        {
            CriarRequest("ConsultarTipoRelacaoResult", "/Api/Tipo/ConsultarTiposRelacao", JsonConvert.SerializeObject("TipoRelacao"));
        }

        public void ConsultarIdioma()
        {
            CriarRequest("ConsultarIdiomaResult", "/Api/Tipo/ConsultarIdiomas", JsonConvert.SerializeObject("Idioma"));
        }
    }
}