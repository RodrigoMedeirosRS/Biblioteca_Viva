using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BibliotecaViva.BLL.Utils;

namespace BibliotecaViva.BLL
{
    public class LocalizacaoBLL : ILocalizacaoBLL
    {
        private ILocalizacaoDAL LocalizacaoDAL { get; set; }
        public LocalizacaoBLL(ILocalizacaoDAL localizacaoDAL)
        {
            LocalizacaoDAL = localizacaoDAL;
        }
        public async Task<string> Cadastrar(LocalizacaoDTO localizacaoDTO)
        {
            LocalizacaoDAL.Cadastrar(TratarSwagger(localizacaoDTO));
            return "sucesso";
        }
        public async Task<string> Consultar(LocalizacaoConsulta localizacao)
        {
            return SerializarRetorno(LocalizacaoDAL.Consultar(
                AutoMapperGenerico.Mapear<LocalizacaoConsulta, LocalizacaoDTO>(localizacao),
                localizacao.InicioX,
                localizacao.InicioY,
                localizacao.FimX,
                localizacao.FimY
            ));
        }

        private string SerializarRetorno(List<LocalizacaoDTO> localizacao)
        {
            return localizacao.Count > 0 ? JsonConvert.SerializeObject(localizacao) : throw new Exception("Localizacao Não Encontrada");
        }

        private LocalizacaoDTO TratarSwagger(LocalizacaoDTO entrada)
        {
            if (entrada.Nome == "string" || string.IsNullOrEmpty(entrada.Nome))
                entrada.Nome = "";
            return entrada;
        }
    }
}