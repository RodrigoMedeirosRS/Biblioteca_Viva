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
        private ISignificadoDAL SignificadoDAL { get; set; }
        public GlossarioBLL(IGlossarioDAL glossarioDAL, IIdiomaDAL idiomaDAL, IConceitoDAL conceitoDAL, ISignificadoDAL significadoDAL)
        {
            IdiomaDAL = idiomaDAL;
            ConceitoDAL = conceitoDAL;
            GlossarioDAL = glossarioDAL;
            SignificadoDAL = significadoDAL;
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
                Nome = conceitoEntrada.Glossario }).FirstOrDefault() ??
                throw new Exception("Erro: Glossário inválido!");

            
            var idioma = IdiomaDAL.Consultar(conceitoEntrada.Idioma) ?? 
                throw new Exception("Idioma não cadastrado, por favor insira um idioma válido");
            
            var significado = new SignificadoDTO(){
                Idioma = idioma.Id,
                NomeIdioma = idioma.Nome,
                Descricao = conceitoEntrada.Significado,
                Link = conceitoEntrada.LinkSignificado };

            ConceitoDAL.Cadastrar(conceito, glossario);
            conceito.Id = ConceitoDAL.Consultar(conceito).FirstOrDefault().Id;
            SignificadoDAL.Cadastrar(conceito, idioma, significado);

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