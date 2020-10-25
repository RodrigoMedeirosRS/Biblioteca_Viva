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
    public class LinhaDoTempoBLL : ILinhaDoTempoBLL
    {
        private ILinhaDoTempoDAL LinhaDoTempoDAL { get; set; }
        public LinhaDoTempoBLL(ILinhaDoTempoDAL linhaDoTempoDAL)
        {
            LinhaDoTempoDAL = linhaDoTempoDAL;
        }
        public async Task<string> Cadastrar(LinhaDoTempoDTO linhaDoTempo)
        {
            LinhaDoTempoDAL.Cadastrar(TratarSwagger(linhaDoTempo));
            return "Sucesso!";
        }
        public async Task<string> Consultar(LinhaDoTempoConsulta linhaDoTempoEntrada)
        {
            var linhaDoTempo = AutoMapperGenerico.Mapear<LinhaDoTempoConsulta, LinhaDoTempoDTO>(linhaDoTempoEntrada);
            return JsonConvert.SerializeObject(LinhaDoTempoDAL.Consultar(TratarSwagger(linhaDoTempo)));
        }
        public async Task<string> VincularPessoa(LinhaDoTempoPessoaConsulta linhaDoTempoPessoaEntrda)
        {
            var linhaDoTempo = AutoMapperGenerico.Mapear<LinhaDoTempoConsulta, LinhaDoTempoDTO>(linhaDoTempoPessoaEntrda.LinhaDoTempo);
            var pessoa = AutoMapperGenerico.Mapear<PessoaConsulta, PessoaDTO>(linhaDoTempoPessoaEntrda.Pessoa);
            try
            {
                LinhaDoTempoDAL.VincularPessoa(linhaDoTempo, pessoa);
                return  "Sucesso!";
            }
            catch
            {
                throw new Exception("Linha do Tempo ou Pessoa não Encontrada.");
            }
        }
        public async Task<string> VincularDocumento(LinhaDoTempoDocumentoConsulta linhaDoTempoDocumentoEntrada)
        {
            var linhaDoTempo = AutoMapperGenerico.Mapear<LinhaDoTempoConsulta, LinhaDoTempoDTO>(linhaDoTempoDocumentoEntrada.LinhaDoTempo);
            var documento = AutoMapperGenerico.Mapear<DocumentoConsulta, DocumentoDTO>(linhaDoTempoDocumentoEntrada.Documento);

            try
            {
                LinhaDoTempoDAL.VincularDocumento(linhaDoTempo, documento);
                return  "Sucesso!";
            }
            catch
            {
                throw new Exception("Linha do Tempo ou Documento não Encontrado.");
            }
        }
        public async Task<string> VincularEvento(LinhaDoTempoEventoConsulta linhaDoTempoEventoEntrada)
        {
            try
            {
                return "Método não implementado.";
            }
            catch
            {
                throw new Exception("Linha do Tempo ou Evento não Encontrado.");
            }
        }

        private LinhaDoTempoDTO TratarSwagger(LinhaDoTempoDTO entrada)
        {
            if (entrada.Nome == "string" || string.IsNullOrEmpty(entrada.Nome))
                entrada.Nome = "";
            if (entrada.Descricao == "string" || string.IsNullOrEmpty(entrada.Descricao))
                entrada.Descricao = "";
            return entrada;
        }

    }
}