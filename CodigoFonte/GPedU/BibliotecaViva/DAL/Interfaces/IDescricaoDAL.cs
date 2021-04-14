using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL
{
    public interface IDescricaoDAL
    {
        void Cadastrar(DescricaoDTO descricaoDTO);
        void Remover(int? codigoRegistro);
    }
}