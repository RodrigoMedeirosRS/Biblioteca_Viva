using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITipoParticipacaoDAL
    {
        void Cadastrar(TipoParticipacaoDTO tipoParticipacaoDTO);
        TipoParticipacaoDTO Consultar(TipoParticipacaoDTO tipoParticipacaoDTO);
    }
}