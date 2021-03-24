using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Documento/Video")]
    [ApiController]
    public class VideoController : Controller
    {
        private IDocumentoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public VideoController(IDocumentoBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(VideoDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<VideoDTO>(documento, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(VideoConsulta documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<VideoConsulta>(documento, _BLL.Consultar));
        }
    }
}
