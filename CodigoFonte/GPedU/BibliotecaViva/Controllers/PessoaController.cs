using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Pessoa")]
    [ApiController]
    public class PessoaController : Controller
    {
        private IPerssoaBLL _BLL;
        public PessoaController(IPerssoaBLL bll)
        {
            _BLL = bll;
        }

        [HttpPost("CadastrarPessoa")]
        public async Task<IActionResult> CadastrarPessoa(PessoaDTO pessoa)
        {
            try
            {
                return Ok(await Task.Run(async () => await _BLL.Cadastrar(pessoa)));
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("ConsultarPessoa")]
        public async Task<IActionResult> Consultar(PessoaDTO pessoa)
        {
            try
            {
                return Ok(await Task.Run(async () => await _BLL.Consultar(pessoa)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}