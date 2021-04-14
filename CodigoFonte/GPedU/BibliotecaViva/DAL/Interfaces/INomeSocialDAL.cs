using BibliotecaViva.DTO;

namespace BibliotecaViva.DAL
{
    public interface INomeSocialDAL
    {
        void Cadastrar(NomeSocialDTO nomeSocial);
        void Remover(int? codigoPessoa);
    }
}