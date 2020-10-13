using System.Threading.Tasks;
using BibliotecaViva.DTO.Dominio;

using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface ILinhaDoTempoBLL
    {
         Task<string> Cadastrar(LinhaDoTempoDTO linhaDoTempo);
         Task<string> Consultar(LinhaDoTempoDTO linhaDoTempo);
         Task<string> VincularPessoa(LinhaDoTempoPessoaDTO linhaDoTempoPessoa);
         Task<string> VincularDocumento(LinhaDoTempoDocumentoDTO linhaDoTempoDocumento);
         Task<string> VincularEvento(LinhaDoTempoEventoDTO linhaDoTempoEvento);
    }
}