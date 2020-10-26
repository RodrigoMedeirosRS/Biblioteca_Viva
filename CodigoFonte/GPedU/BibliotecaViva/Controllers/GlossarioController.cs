using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.Interface;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Glossario")]
    [ApiController]
    public class GlossarioController : Controller
    {
        private IGlossarioBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public GlossarioController(IGlossarioBLL bLL, IRequisicao requisicao)
        {
            _BLL = bLL;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(GlossarioDTO glossarioDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<GlossarioDTO>(glossarioDTO, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(GlossarioConsulta glossarioEntrada)
        {
            return Ok(_Requisicao.ExecutarRequisicao<GlossarioConsulta>(glossarioEntrada, _BLL.Consultar));
        }

        [HttpPost("CadastrarConceito")]
        public async Task<IActionResult> CadastrarConceito(ConceitoEntrada conceitoEntrada)
        {
            return Ok(_Requisicao.ExecutarRequisicao<ConceitoEntrada>(conceitoEntrada, _BLL.CadastrarConceito));
        }

        [HttpPost("ConsultarConceito")]
        public async Task<IActionResult> ConsultarConceito(ConceitoConsulta conceitoConsulta)
        {
            return Ok(_Requisicao.ExecutarRequisicao<ConceitoConsulta>(conceitoConsulta, _BLL.ConsultarConceito));
        }
    }
}