using System.Threading.Tasks;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IGlossarioBLL
    {
        Task<string> Cadastrar(GlossarioDTO glossario);
        Task<string> Consultar(GlossarioConsulta glossarioEntrada);
    }
}