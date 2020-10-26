using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IConceitoDAL
    {
        void Cadastrar(ConceitoDTO conceito);
        List<ConceitoDTO> Consultar(ConceitoDTO conceitoDTO);
    }
}