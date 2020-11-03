using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.DAL.Interfaces;
using BibliotecaViva.BLL.Interfaces;

namespace BibliotecaViva.BLL
{
    public class EventoBLL : IEventoBLL
    {
        private ITipoParticipacaoDAL TipoParticipacaoDAL { get; set;}
        private ITipoEventoDAL TipoEventoDAL { get; set; }
        private IEventoDAL EventoDAL { get; set; }
        public EventoBLL(IEventoDAL eventoDAL, ITipoParticipacaoDAL tipoParticipacaoDAL, ITipoEventoDAL tipoEventoDAL)
        {
            EventoDAL = eventoDAL;
            TipoEventoDAL = tipoEventoDAL;
            TipoParticipacaoDAL = tipoParticipacaoDAL;
        }
        
        public async Task<string> CadastrarTipo(TipoEventoDTO tipo)
        {
            TipoEventoDAL.Cadastrar(tipo);
            return "sucesso";
        }

        public async Task<string> CadastrarTipoParticipacao(TipoParticipacaoDTO tipo)
        {
            TipoParticipacaoDAL.Cadastrar(tipo);
            return "sucesso";
        }

        public async Task<string> Cadastrar(EventoDTO eventoDTO)
        {
            EventoDAL.Cadastrar(eventoDTO);
            return "sucesso";
        }

        public async Task<string> VincularPessoa(VincularPessoaEntrada vincularPessoaEntrada)
        {
            var pessoaDTO = AutoMapperGenerico.Mapear<PessoaConsulta, PessoaDTO>(vincularPessoaEntrada.Pessoa);
            var eventoDTO = AutoMapperGenerico.Mapear<EventoConsulta, EventoDTO>(vincularPessoaEntrada.Evento);
            EventoDAL.VincularPessoa(pessoaDTO, eventoDTO, vincularPessoaEntrada.TipoParticipacao);
            return "sucesso";
        }

        public async Task<string> VincularDocumento(VincularDocumentoEntrada vincularDocumentoEntrada)
        {
            var documentoDTO = AutoMapperGenerico.Mapear<DocumentoConsulta, DocumentoDTO>(vincularDocumentoEntrada.Documento);
            var eventoDTO = AutoMapperGenerico.Mapear<EventoConsulta, EventoDTO>(vincularDocumentoEntrada.Evento);
            EventoDAL.VincularDocumento(documentoDTO, eventoDTO);
            return "sucesso";
        }

        public async Task<string> Consultar(EventoConsulta evento)
        {
            return JsonConvert.SerializeObject(EventoDAL.Consultar(AutoMapperGenerico.Mapear<EventoConsulta, EventoDTO>(evento)));
        }

        
    }
}