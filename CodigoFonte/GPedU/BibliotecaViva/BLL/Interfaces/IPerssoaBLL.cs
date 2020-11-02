using System.Threading.Tasks;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IPerssoaBLL
    {
        Task<string> Cadastrar(PessoaDTO pessoa);
        Task<string> Consultar(PessoaConsulta pessoa);
    }
}
