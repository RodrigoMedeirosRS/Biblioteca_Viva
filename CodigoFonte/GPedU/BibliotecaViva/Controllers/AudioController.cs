using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.DTO;
using BibliotecaViva.Interface;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Documento/Audio")]
    [ApiController]
    public class AudioController : Controller
    {
        private IDocumentoBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public AudioController(IDocumentoBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(AudioDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<AudioDTO>(documento, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(AudioDTO documento)
        {
            return Ok(_Requisicao.ExecutarRequisicao<AudioDTO>(documento, _BLL.Consultar));
        }
    }
}
