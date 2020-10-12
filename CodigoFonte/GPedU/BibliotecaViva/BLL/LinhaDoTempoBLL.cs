using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            LinhaDoTempoDAL.Cadastrar(linhaDoTempo);
            return "Sucesso!";
        }
        public async Task<string> Consultar(LinhaDoTempoDTO linhaDoTempo)
        {
            return JsonConvert.SerializeObject(LinhaDoTempoDAL.Consultar(linhaDoTempo));
        }
        public async Task<string> VincularPessoa(LinhaDoTempoPessoaDTO linhaDoTempoPessoa)
        {
            try
            {
                LinhaDoTempoDAL.VincularPessoa(linhaDoTempoPessoa.LinhaDoTempo, linhaDoTempoPessoa.Pessoa);
                return  "Sucesso!";
            }
            catch
            {
                throw new Exception("Linha do Tempo ou Pessoa não Encontrada.");
            }
        }
        public async Task<string> VincularDocumento(LinhaDoTempoDocumentoDTO linhaDoTempoDocumento)
        {
            try
            {
                LinhaDoTempoDAL.VincularDocumento(linhaDoTempoDocumento.LinhaDoTempo, linhaDoTempoDocumento.Documento);
                return  "Sucesso!";
            }
            catch
            {
                throw new Exception("Linha do Tempo ou Documento não Encontrado.");
            }
        }
        public async Task<string> VincularEvento(LinhaDoTempoEventoDTO linhaDoTempoEvento)
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
    }
}