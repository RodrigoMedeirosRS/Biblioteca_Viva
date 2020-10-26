using System.Linq;
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
        private IIdiomaDAL IdiomaDAL { get; set; }
        private IConceitoDAL ConceitoDAL { get; set; }
        public GlossarioBLL(IGlossarioDAL glossarioDAL, IIdiomaDAL idiomaDAL, IConceitoDAL conceitoDAL)
        {
            IdiomaDAL = idiomaDAL;
            ConceitoDAL = conceitoDAL;
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

        public async Task<string> CadastrarConceito(ConceitoEntrada conceitoEntrada)
        {
            var conceito = new ConceitoDTO(){
                Nome = conceitoEntrada.Nome };
            var glossario = GlossarioDAL.Consultar(new GlossarioDTO(){
                Nome = conceitoEntrada.Glossario }).FirstOrDefault();
            if (glossario == null)
                throw new Exception("Erro: Glossário inválido!");

            ConceitoDAL.Cadastrar(conceito, glossario);

            //Inserir Busca do significado do conceito
            //var idioma = IdiomaDAL.Consultar(conceitoEntrada.Idioma);
            return "Sucesso";
        }
        public async Task<string> ConsultarConceito(ConceitoConsulta conceitoConsulta)
        {
            var conceito = AutoMapperGenerico.Mapear<ConceitoConsulta, ConceitoDTO>(conceitoConsulta);
            var glossario = AutoMapperGenerico.Mapear<GlossarioConsulta, GlossarioDTO>(new GlossarioConsulta(){
                Nome = conceitoConsulta.Glossario });
            return JsonConvert.SerializeObject(ConceitoDAL.Consultar(conceito));
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