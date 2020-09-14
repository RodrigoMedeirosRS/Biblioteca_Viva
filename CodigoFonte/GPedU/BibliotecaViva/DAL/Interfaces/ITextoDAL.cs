using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITextoDAL
    {
        void Cadastrar(Texto texto);
        Texto Consultar(int? documentoId);
    }
}
