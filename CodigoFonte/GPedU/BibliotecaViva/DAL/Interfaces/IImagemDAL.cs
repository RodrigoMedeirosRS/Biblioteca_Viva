using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IImagemDAL
    {
        void Cadastrar(Imagem imagem);
        Imagem Consultar(int? documentoId);
    }
}
