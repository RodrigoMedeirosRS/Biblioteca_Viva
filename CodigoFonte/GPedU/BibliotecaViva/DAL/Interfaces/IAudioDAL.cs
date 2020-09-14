using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IAudioDAL
    {
        void Cadastrar(Audio audio);
        Audio Consultar(int? documentoId);
    }
}
