using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Evento")]
    [ApiController]
    public class EventoController : Controller
    {
        private IEventoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public EventoController(IEventoBLL bLL, IRequisicao requisicao)
        {
            _BLL = bLL;
            _Requisicao = requisicao;
        }

        [HttpPost("CadastrarTipo")]
        public async Task<IActionResult> CadastrarTipo(TipoEventoDTO tipoEventoDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TipoEventoDTO>(tipoEventoDTO, _BLL.CadastrarTipo));
        }

        [HttpPost("CadastrarTipoParticipacao")]
        public async Task<IActionResult> CadastrarTipoParticipacao(TipoParticipacaoDTO tipoParticipacaoDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TipoParticipacaoDTO>(tipoParticipacaoDTO, _BLL.CadastrarTipoParticipacao));
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(EventoDTO eventoDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<EventoDTO>(eventoDTO, _BLL.Cadastrar));
        }

        [HttpPost("VincularPessoa")]
        public async Task<IActionResult> VincularPessoa(VincularPessoaEntrada vincularPessoaEntrada)
        {
            return Ok(_Requisicao.ExecutarRequisicao<VincularPessoaEntrada>(vincularPessoaEntrada, _BLL.VincularPessoa));
        }
        
        [HttpPost("VincularDocumento")]
        public async Task<IActionResult> VincularDocumento(VincularDocumentoEntrada vincularDocumentoEntrada)
        {
            return Ok(_Requisicao.ExecutarRequisicao<VincularDocumentoEntrada>(vincularDocumentoEntrada, _BLL.VincularDocumento));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(EventoConsulta eventoConsulta)
        {
            return Ok(_Requisicao.ExecutarRequisicao<EventoConsulta>(eventoConsulta, _BLL.Consultar));
        }
    }
}