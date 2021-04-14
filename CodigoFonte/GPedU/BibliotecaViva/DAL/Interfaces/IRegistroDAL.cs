using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IRegistroDAL
    {
        List<RegistroDTO> Consultar(RegistroDTO registroDTO);
        void Cadastrar(RegistroDTO registroDTO);
    }
}
