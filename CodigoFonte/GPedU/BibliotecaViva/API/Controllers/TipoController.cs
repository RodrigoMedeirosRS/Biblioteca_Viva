using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Tipo")]
    [ApiController]
    public class TipoController : Controller
    {
        private IRegistroBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        
        public TipoController(IRegistroBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(RegistroDTO registro)
        {
            return Ok(_Requisicao.ExecutarRequisicao<RegistroDTO>(registro, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(RegistroConsulta registro)
        {
            return Ok(_Requisicao.ExecutarRequisicao<RegistroConsulta>(registro, _BLL.Consultar));
        }
    }
}