using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IDocumentoDAL
    {
        void Cadastrar(DocumentoDTO documentoDTO);
        DocumentoDTO Consultar(DocumentoDTO documentoDTO);
        Documento Consultar(DocumentoDTO documentoDTO, int idioma);
    }
}
