using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IRegistroBLL
    {
        Task<string> Cadastrar(RegistroDTO registro);
        Task<string> Consultar(RegistroConsulta registro);
    }
}
