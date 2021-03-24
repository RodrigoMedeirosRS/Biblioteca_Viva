using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IPessoaDAL
    {
        void Cadastrar(PessoaDTO pessoaDTO);
        void Editar(PessoaDTO pessoaDTO);
        PessoaDTO Consultar(PessoaDTO pessoaDTO);
        PessoaDTO Consultar(int? pessoaID);
        PessoaDTO Consultar(string nome, string sobrenome);
        
    }
}
