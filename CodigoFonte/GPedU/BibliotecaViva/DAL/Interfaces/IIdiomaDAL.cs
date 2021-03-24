using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IIdiomaDAL
    {
        List<IdiomaDTO> Consultar(string idioma);
    }
}
