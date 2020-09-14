using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Documento/Audio")]
    [ApiController]
    public class AudioController : Controller
    {
        private IDocumentoBLL _BLL { get; set; }
        public AudioController(IDocumentoBLL bll)
        {
            _BLL = bll;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(AudioDTO documento)
        {
            try
            {
                return Ok(await Task.Run(async () => await _BLL.Cadastrar(documento)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(AudioDTO documento)
        {
            try
            {
                return Ok(await Task.Run(async () => await _BLL.Consultar(documento)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
