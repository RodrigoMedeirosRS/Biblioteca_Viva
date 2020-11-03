using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using System.Threading.Tasks;

namespace BibliotecaViva.BLL.Interfaces
{
    public interface IEventoBLL
    {
        Task<string> CadastrarTipo(TipoEventoDTO tipo);
        Task<string> CadastrarTipoParticipacao(TipoParticipacaoDTO tipo);
        Task<string> Cadastrar(EventoDTO eventoDTO);
        Task<string> VincularPessoa(VincularPessoaEntrada vincularPessoaEntrada);
        Task<string> VincularDocumento(VincularDocumentoEntrada vincularDocumentoEntrada);
        Task<string> Consultar(EventoConsulta evento);
    }
}