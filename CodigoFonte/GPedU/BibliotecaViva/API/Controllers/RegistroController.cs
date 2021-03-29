using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Registro")]
    [ApiController]
    public class RegistroController : Controller
    {
        private IRegistroBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        
        public RegistroController(IRegistroBLL bll, IRequisicao requisicao)
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

        [HttpPost("Editar")]
        public async Task<IActionResult> Editar(RegistroDTO registro)
        {
            return Ok();
        }
    }
}
