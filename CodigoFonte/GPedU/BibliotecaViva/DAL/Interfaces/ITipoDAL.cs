using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITipoDAL
    {
        TipoDTO ObterTipo(TipoDTO tipoDTO);
    }
}