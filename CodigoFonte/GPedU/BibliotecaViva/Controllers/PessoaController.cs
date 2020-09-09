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
            return Ok(Task.Run(async () => await _BLL.Cadastrar(pessoa)));
        }

        [HttpPost("EditarPessoa")]
        public async Task<IActionResult> EditarPessoa(PessoaDTO pessoa)
        {
            return Ok(await Task.Run(async () => await _BLL.Editar(pessoa)));
        }

        [HttpPost("ConsultarPessoa")]
        public async Task<IActionResult> Consultar(PessoaDTO pessoa)
        {
            return Ok(await Task.Run(async () => await _BLL.Consultar(pessoa)));
        }
    }
}