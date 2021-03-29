using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IRegistroDAL
    {
        List<RegistroDTO> Consultar(RegistroDTO documentoDTO);
        void Cadastrar(RegistroDTO documentoDTO);
        void Editar(RegistroDTO documentoDTO);
    }
}
