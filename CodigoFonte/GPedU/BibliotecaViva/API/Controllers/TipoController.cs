using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Tipo")]
    [ApiController]
    public class TipoController : Controller
    {
        private ITipoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        
        public TipoController(ITipoBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("CadastrarIdioma")]
        public async Task<IActionResult> Cadastrar(IdiomaDTO idioma)
        {
            return Ok(_Requisicao.ExecutarRequisicao<IdiomaDTO>(idioma, _BLL.Cadastrar));
        }


        [HttpPost("CadastrarTipo")]
        public async Task<IActionResult> Cadastrar(TipoDTO tipo)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TipoDTO>(tipo, _BLL.Cadastrar));
        }

        [HttpPost("CadastrarTipoRelacao")]
        public async Task<IActionResult> Cadastrar(TipoRelacaoDTO tipoRelacao)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TipoRelacaoDTO>(tipoRelacao, _BLL.Cadastrar));
        }

        [HttpPost("ConsultarIdiomas")]
        public async Task<IActionResult> ConsultarIdiomas()
        {
            return Ok(_Requisicao.ExecutarRequisicao(_BLL.ConsultarIdiomas));
        }

        [HttpPost("ConsultarTipos")]
        public async Task<IActionResult> ConsultarTipos()
        {
            return Ok(_Requisicao.ExecutarRequisicao(_BLL.ConsultarTipos));
        }

        [HttpPost("ConsultarTiposRelacao")]
        public async Task<IActionResult> ConsultarTiposRelacao()
        {
            return Ok(_Requisicao.ExecutarRequisicao(_BLL.ConsultarTiposRelacao));
        }
    }
}