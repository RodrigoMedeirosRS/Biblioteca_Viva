using DTO;
using Godot;
using DTO.Dominio;
using Newtonsoft.Json;
using BLL.Extension;

namespace SAL
{
    public class SonarSAL : BaseSAL
    {
        public SonarSAL(SALResultsController pai, string host = "http://20.62.91.99​:8080/") : base(host, pai)
        {

        }

        public void ConsultarSonar(SonarConsulta sonarConsulta)
        {
            CriarRequest("ConsultarSonarResult", Host + "Api/Sonar/Consultar", JsonConvert.SerializeObject(sonarConsulta));
        }
    }
}