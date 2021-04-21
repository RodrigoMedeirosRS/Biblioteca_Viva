using DTO.Dominio;
using SAL.Interface;
using Newtonsoft.Json;

namespace SAL
{
    public class SonarSAL : BaseSAL, ISonarSAL
    {
        public SonarSAL(ResultSAL nodoPai) : base(nodoPai)
		{
			
		}
        public void ConsultarSonar(SonarConsulta sonarConsulta)
        {
            CriarRequest("ConsultarSonarResult", "/Api/Sonar/Consultar", JsonConvert.SerializeObject(sonarConsulta));
        }
    }
}