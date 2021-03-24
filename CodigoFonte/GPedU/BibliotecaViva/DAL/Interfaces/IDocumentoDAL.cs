using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IDocumentoDAL
    {
        List<DocumentoDTO> Consultar(DocumentoDTO documentoDTO);
        void Cadastrar(DocumentoDTO documentoDTO);
        void Editar(DocumentoDTO documentoDTO);
    }
}
