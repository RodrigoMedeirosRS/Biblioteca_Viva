using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.Models.BLL;
using BibliotecaViva.Models.DTO;
using BibliotecaViva.Models.DTO.Dominio;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Pessoa")]
    [ApiController]
    public class PessoaController : Controller
    {
        private biblioteca_vivaContext DataContext;

        public PessoaController(biblioteca_vivaContext dataContext)
        {
            DataContext = dataContext;
        }

        [HttpPost("CadastrarPessoa")]
        public async Task<IActionResult> CadastrarPessoa(PessoaDTO pessoa)
        {
            var retorno = "";
            await Task.Run(() => { retorno = new PessoaBLL(DataContext).Cadastrar(pessoa); });
            return Ok(retorno);
        }

        public async Task<IActionResult> EditarPessoa(PessoaDTO pessoa)
        {
            var retorno = "";
            await Task.Run(() => { retorno = new PessoaBLL(DataContext).Editar(pessoa); });
            return Ok(retorno);
        }

        public async Task<IActionResult> Consultar(PessoaDTO pessoa)
        {
            var retorno = "";
            await Task.Run(() => { retorno = new PessoaBLL(DataContext).Consultar(pessoa); });
            return Ok(retorno);
        }
    }
}