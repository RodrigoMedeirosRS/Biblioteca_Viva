using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.DTO;
using BibliotecaViva.Interface;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Documento/Texto")]
    [ApiController]
    public class TextoController : Controller
    {
        private IDocumentoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        
        public TextoController(IDocumentoBLL bll, IRequisicao requisicao)
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
        public async Task<IActionResult> Consultar(TextoDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<TextoDTO>(documento, _BLL.Consultar));
        }
    }
}
