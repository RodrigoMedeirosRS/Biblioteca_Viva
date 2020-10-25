using System.Threading.Tasks;
using BibliotecaViva.DTO.Dominio;

using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface ILinhaDoTempoBLL
    {
         Task<string> Cadastrar(LinhaDoTempoDTO linhaDoTempo);
         Task<string> Consultar(LinhaDoTempoConsulta linhaDoTempoEntrada);
         Task<string> VincularPessoa(LinhaDoTempoPessoaConsulta linhaDoTempoPessoaEntrada);
         Task<string> VincularDocumento(LinhaDoTempoDocumentoDTO linhaDoTempoDocumento);
         Task<string> VincularEvento(LinhaDoTempoEventoDTO linhaDoTempoEvento);
    }
}