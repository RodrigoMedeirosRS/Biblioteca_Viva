using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IVideoDAL
    {
        void Cadastrar(Video video);
        Video Consultar(int? documentoId);
    }
}
