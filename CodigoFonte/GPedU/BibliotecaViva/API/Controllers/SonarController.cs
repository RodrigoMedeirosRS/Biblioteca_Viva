using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using API.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.Controllers
{
    [Route("Api/Sonar")]
    [ApiController]
    public class SonarController : Controller
    {
        private ISonarBLL _BLL { get; set; }
        private IRequisicao _Requisicao { get; set; }
        
        public SonarController(ISonarBLL bll, IRequisicao requisicao)
        {
            _BLL = bll;
            _Requisicao = requisicao;
        }

        [HttpPost("Consultar")] //Quase lá, ainda precisa ser revista.
        public async Task<SonarRetorno> Consultar(SonarConsulta sonar)
        {
            return _Requisicao.ExecutarRequisicao<SonarConsulta, SonarRetorno>(sonar, _BLL.Consultar).Result;
        }
        [HttpPost("Rastros")] //Precisa ser revista, esta confundido registros com pessoas.
        public async Task<List<LocalizacaoGeograficaDTO>> Rastrear(string codRegistro)
        {
            return _Requisicao.ExecutarRequisicao<int, List<LocalizacaoGeograficaDTO>>(Convert.ToInt32(codRegistro), _BLL.Rastrear).Result;
        }
    }
}