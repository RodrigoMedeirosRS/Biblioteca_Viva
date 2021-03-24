using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Localizacao")]
    [ApiController]
    public class LocalizacaoController : Controller
    {
        private ILocalizacaoBLL _LocalizacoBLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public LocalizacaoController(ILocalizacaoBLL bLL, IRequisicao requisicao)
        {
            _LocalizacoBLL = bLL;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(LocalizacaoDTO localizacaoDTO)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LocalizacaoDTO>(localizacaoDTO, _LocalizacoBLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(LocalizacaoConsulta localizacaoConsulta)
        {
            return Ok(_Requisicao.ExecutarRequisicao<LocalizacaoConsulta>(localizacaoConsulta, _LocalizacoBLL.Consultar));
        }
    }
}