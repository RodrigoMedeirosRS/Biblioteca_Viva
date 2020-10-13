using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITextoDAL
    {
        void Cadastrar(Texto texto);
        Texto Consultar(int? documento);
        List<TextoDTO> Listar(List<DocumentoDTO> documentosDTO);
    }
}
