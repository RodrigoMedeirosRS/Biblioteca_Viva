using DTO;

namespace SAL.Interface
{
    public interface ITipoSAL
    {
        void CadastrarTipo(TipoDTO tipoDTO);
        void CadastrarTipoRelacao(TipoRelacaoDTO tipoRelacaoDTO);
        void CadastrarIdioma(IdiomaDTO idiomaDTO);
        void ConsultarTipo();
        void ConsultarTipoRelacao();
        void ConsultarIdioma();
    }
}