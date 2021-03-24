using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface INomeSocialDAL
    {
        string Consultar(PessoaDTO pessoaDTO);
        void Deletar(PessoaDTO pessoaDTO);
        void Cadastrar(PessoaDTO pessoaDTO);
        void Editar(PessoaDTO pessoaDTO);
    }
}
