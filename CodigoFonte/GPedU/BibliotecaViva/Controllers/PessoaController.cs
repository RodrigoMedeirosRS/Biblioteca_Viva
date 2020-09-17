using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BibliotecaViva.DTO;
using BibliotecaViva.Interface;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Pessoa")]
    [ApiController]
    public class PessoaController : Controller
    {
        private IPerssoaBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        public PessoaController(IPerssoaBLL bll)
        {
            _BLL = bll;
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Cadastrar(PessoaDTO pessoa)
        {
            return Ok(_Requisicao.ExecutarRequisicao<PessoaDTO>(pessoa, _BLL.Cadastrar));
        }

        [HttpPost("Consultar")]
        public async Task<IActionResult> Consultar(PessoaDTO pessoa)
        {
            return Ok(_Requisicao.ExecutarRequisicao<PessoaDTO>(pessoa, _BLL.Cadastrar));
        }
    }
}