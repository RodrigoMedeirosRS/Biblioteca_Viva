using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IPessoaDAL
    {
        void Cadastrar(PessoaDTO pessoa);
        PessoaDTO Consultar(PessoaDTO pessoa);
    }
}
