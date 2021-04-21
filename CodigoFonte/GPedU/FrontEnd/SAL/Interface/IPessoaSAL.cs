using DTO;
using DTO.Dominio;

namespace SAL.Interface
{
    public interface IPessoaSAL
    {
        void Cadastrar(PessoaDTO pessoaDTO);
        void Consultar(PessoaConsulta pessoaConsulta);
        void ObterRelacoes(int codRegistro);
    }
}