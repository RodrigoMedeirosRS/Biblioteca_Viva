using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITipoRelacaoDAL
    {
        TipoRelacaoDTO ObterTipo(TipoRelacaoDTO tipoRelacaoDTO);
    }
}