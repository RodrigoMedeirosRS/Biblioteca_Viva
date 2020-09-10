using System.Threading.Tasks;

using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IPerssoaBLL
    {
        Task<string> Cadastrar(PessoaDTO pessoa);
        Task<string> Consultar(PessoaDTO pessoa);
    }
}
