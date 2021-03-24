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
        private IDocumentoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        
        public RegistroController(IDocumentoBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(TextoDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TextoDTO>(documento, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(TextoConsulta documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TextoConsulta>(documento, _BLL.Consultar));
        }

        [HttpPost("Editar")]
        public async Task<IActionResult> Editar(TextoConsulta documento)
        {
            return Ok();
        }
    }
}
