using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/LinhaDoTempo")]
    [ApiController]
    public class LinhaDoTempoController : Controller
    {
        private ILinhaDoTempoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public LinhaDoTempoController(ILinhaDoTempoBLL bLL, IRequisicao requisicao)
        {
            _BLL = bLL;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(LinhaDoTempoDTO linhaDoTempoDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LinhaDoTempoDTO>(linhaDoTempoDTO, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(LinhaDoTempoConsulta linhaDoTempoDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LinhaDoTempoConsulta>(linhaDoTempoDTO, _BLL.Consultar));
        }

        [HttpPost("VincularPessoa")]
        public async Task<IActionResult> VincularPessoa(LinhaDoTempoPessoaConsulta linhaDoTempoPessoa)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LinhaDoTempoPessoaConsulta>(linhaDoTempoPessoa, _BLL.VincularPessoa));
        }

        [HttpPost("VincularDocumento")]
        public async Task<IActionResult> VincularDocumento(LinhaDoTempoDocumentoConsulta linhaDoTempoDocumento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LinhaDoTempoDocumentoConsulta>(linhaDoTempoDocumento, _BLL.VincularDocumento));
        }

        [HttpPost("VincularEvento")]
        public async Task<IActionResult> VincularEvento(LinhaDoTempoEventoConsulta linhaDoTempoEvento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LinhaDoTempoEventoConsulta>(linhaDoTempoEvento, _BLL.VincularEvento));
        }
    }
}