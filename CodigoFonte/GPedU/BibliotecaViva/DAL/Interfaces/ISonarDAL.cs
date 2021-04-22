using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using System.Collections.Generic;

namespace BibliotecaViva.DAL.Interfaces
{
    public interface ISonarDAL
    {
        SonarRetorno Consultar(SonarConsulta registroDTO);
        List<LocalizacaoGeograficaDTO> Rastrear(int codRegistro);
    }
}