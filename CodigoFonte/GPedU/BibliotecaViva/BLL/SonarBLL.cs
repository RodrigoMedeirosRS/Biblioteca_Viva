using BibliotecaViva.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class SonarBLL : BaseBLL, ISonarBLL
    {
        public ISonarDAL SonarDAL { get; set; } 

        public SonarBLL(ISonarDAL sonarDAL)
        {
            SonarDAL = sonarDAL;
        }
        public async Task<SonarRetorno> Consultar(SonarConsulta sonar)
        {
            return SonarDAL.Consultar(sonar);
        }

        public async Task<List<LocalizacaoGeograficaDTO>> Rastrear(int codRegistro)
        {
            return SonarDAL.Rastrear(codRegistro);
        }
    }
}