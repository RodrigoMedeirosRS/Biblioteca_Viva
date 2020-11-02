using BibliotecaViva.DTO;
using System.Collections.Generic;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ISignificadoDAL
    {
        void Cadastrar(ConceitoDTO conceitoDTO, IdiomaDTO idiomaDTO, SignificadoDTO significadoDTO);
        List<SignificadoDTO> Consultar(IdiomaDTO idiomaDTO, ConceitoDTO conceitoDTO);
    }
}