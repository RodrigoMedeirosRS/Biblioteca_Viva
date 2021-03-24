using System.Collections.Generic;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IApelidoDAL
    {
        List<PessoaDTO> Consultar(PessoaDTO pessoaDTO);
        void Deletar(PessoaDTO pessoaDTO);
        void Cadastrar(PessoaDTO pessoaDTO);
        void Editar(PessoaDTO pessoaDTO);
    }
}
