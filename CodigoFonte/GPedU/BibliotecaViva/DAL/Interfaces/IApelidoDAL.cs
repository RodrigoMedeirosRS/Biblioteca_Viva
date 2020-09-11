using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IApelidoDAL
    {
        Apelido Consultar(int? pessoaId);
        void Deletar(PessoaDTO pessoaDTO);
        void Cadastrar(PessoaDTO pessoaDTO);
    }
}
