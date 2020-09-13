using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ITipoRelacaoDAL
    {
        TipoDeRelacao Consultar(string nomeRelacao);
    }
}
