using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IPerssoaBLL
    {
        Task<string> Cadastrar(PessoaDTO pessoa);
        Task<string> Editar(PessoaDTO pessoa);
        Task<string> Consultar(PessoaDTO pessoa);
    }
}
