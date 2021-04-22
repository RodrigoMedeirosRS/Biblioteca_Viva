using BibliotecaViva.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface ISonarBLL
    {
        Task<SonarRetorno> Consultar(SonarConsulta sonar);
        Task<List<LocalizacaoGeograficaDTO>> Rastrear(int codRegistro);
    }
}