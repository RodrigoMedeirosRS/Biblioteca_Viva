using System.Collections.Generic;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IDocumentoDAL
    {
        void Cadastrar(DocumentoDTO documentoDTO);
        List<DocumentoDTO> Consultar(DocumentoDTO documentoDTO);
    }
}
