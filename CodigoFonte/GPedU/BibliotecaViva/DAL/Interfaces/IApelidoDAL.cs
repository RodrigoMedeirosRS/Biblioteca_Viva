using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IApelidoDAL : IBaseDAL
    {
        void Cadastrar(ApelidoDTO apelidoDTO);
        void Remover(int? codigoPessoa);
        void VincularPessoaApelido(ApelidoDTO apelidoDTO, PessoaDTO pessoaDTO);
    }
}