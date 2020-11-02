using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IConceitoDAL
    {
        void Cadastrar(ConceitoDTO conceitoDTO, GlossarioDTO glossarioDTO);
        List<ConceitoDTO> Consultar(ConceitoDTO conceitoDTO);
    }
}