using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.DTO;
using BibliotecaViva.Interface;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Documento/Imagem")]
    [ApiController]
    public class ImagemController : Controller
    {
        private IDocumentoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public ImagemController(IDocumentoBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(ImagemDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<ImagemDTO>(documento, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(ImagemDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<ImagemDTO>(documento, _BLL.Cadastrar));
        }
    }
}
