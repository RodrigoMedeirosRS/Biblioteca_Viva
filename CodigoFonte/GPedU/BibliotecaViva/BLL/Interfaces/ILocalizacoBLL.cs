using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using System.Threading.Tasks;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface ILocalizacaoBLL
    {
        Task<string> Cadastrar(LocalizacaoDTO localizacaoDTO);
        Task<string> Consultar(LocalizacaoConsulta localizacao);
    }
}