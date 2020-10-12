using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface IGeneroDAL
    {
        Genero Consultar(string nome);
    }
}
