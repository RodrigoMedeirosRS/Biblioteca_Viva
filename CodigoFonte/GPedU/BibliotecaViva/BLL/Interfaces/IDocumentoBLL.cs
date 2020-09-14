using System.Threading.Tasks;

using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IDocumentoBLL
    {
        Task<string> Cadastrar(DocumentoDTO documento);
        Task<string> Consultar(DocumentoDTO documento);
    }
}
