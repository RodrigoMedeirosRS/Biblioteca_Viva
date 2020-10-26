using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class GlossarioBLL : IGlossarioBLL
    {
        private IGlossarioDAL GlossarioDAL { get; set; }
        public GlossarioBLL(IGlossarioDAL glossarioDAL)
        {
            GlossarioDAL = glossarioDAL;
        }
        public async Task<string> Cadastrar(GlossarioDTO glossario)
        {
            GlossarioDAL.Cadastrar(TratarSwagger(glossario));
            return "Sucesso!";
        }
        public async Task<string> Consultar(GlossarioConsulta glossarioEntrada)
        {
            var glossario = AutoMapperGenerico.Mapear<GlossarioConsulta, GlossarioDTO>(glossarioEntrada);
            return JsonConvert.SerializeObject(GlossarioDAL.Consultar(TratarSwagger(glossario)));
        }

        private GlossarioDTO TratarSwagger(GlossarioDTO entrada)
        {
            if (entrada.Nome == "string" || string.IsNullOrEmpty(entrada.Nome))
                entrada.Nome = "";
            if (entrada.Descricao == "string" || string.IsNullOrEmpty(entrada.Descricao))
                entrada.Descricao = "";
            return entrada;
        }
    }
}