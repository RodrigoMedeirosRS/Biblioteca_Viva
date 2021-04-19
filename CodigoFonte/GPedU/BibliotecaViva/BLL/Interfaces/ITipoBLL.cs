using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface ITipoBLL
    {
        Task<string> Cadastrar(IdiomaDTO idiomaDTO);
        Task<string> Cadastrar(TipoDTO tipoDTO);
        Task<string> Cadastrar(TipoRelacaoDTO tipoRelacaoDTO);
        Task<string> ConsultarIdiomas();
        Task<string> ConsultarTipos();
        Task<string> ConsultarTiposRelacao();
    }
}