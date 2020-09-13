using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IPessoaDAL
    {
        void Cadastrar(PessoaDTO pessoaDTO);
        PessoaDTO Consultar(PessoaDTO pessoaDTO);
        Pessoa Consultar(int? pessoaID);
    }
}
