using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IDocumentoBLL
    {
        Task<string> Cadastrar(DocumentoDTO documento);
        Task<string> Consultar(DocumentoConsulta documento);
        Task<string> Editar(DocumentoDTO documento);
    }
}
