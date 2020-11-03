using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITipoEventoDAL
    {
        void Cadastrar(TipoEventoDTO tipoEventoDTO);
        TipoEventoDTO Consultar(TipoEventoDTO tipoEventoDTO);
    }
}