using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class EventoDAL : IEventoDAL
    {
        private ILocalizacaoDAL LocalizacaoDAL { get; set; }
        private IPessoaDAL PessoaDAL { get; set; }
        private ISQLiteDataContext DataContext { get; set; }

        public EventoDAL(ISQLiteDataContext dataContext, ILocalizacaoDAL localizacaoDAL, IPessoaDAL pessoaDAL)
        {
            LocalizacaoDAL = localizacaoDAL;
            DataContext = dataContext;
            PessoaDAL = PessoaDAL;
        }

        public void Cadastrar(EventoDTO eventoDTO)
        {
            
        }
        public List<EventoDTO> Consultar(EventoDTO eventoDTO)
        {
            var retorno = new List<EventoDTO>();

            foreach(var eventoDB in ObterEvento(eventoDTO))
            {
                var consultaEvento = (from evento in DataContext.ObterDataContext().Table<Evento>()
                    join
                        tipoEvento in DataContext.ObterDataContext().Table<Evento>()
                        on evento.TipoEvento equals tipoEvento.Id
                    join
                        eventoLocalizacao in DataContext.ObterDataContext().Table<EventoLocalizacao>()
                        on evento.Id equals eventoLocalizacao.Evento
                    join
                        localizacao in DataContext.ObterDataContext().Table<Localizacao>()
                        on eventoLocalizacao.Localizacao equals localizacao.Id
                    where eventoDB.Id == evento.Id select new EventoDTO(evento.Id)
                    {
                        Nome = evento.Nome,
                        DataHora = evento.DataHora,
                        Destricao = evento.Descricao,
                        Localizacao = localizacao.Nome
                    }).FirstOrDefault();
                
                if (consultaEvento != null)
                {
                    consultaEvento.Participantes = ObterParticipantes(consultaEvento);
                    consultaEvento.Documentos = ObterDocumentos(consultaEvento);
                    retorno.Add(consultaEvento);
                }
            }
            return retorno;
        }

        public void VincularPessoa(PessoaDTO pessoaDTO, EventoDTO eventoDTO, TipoParticipacaoDTO tipoParticipacaoDTO)
        {
            var eventoId = eventoDTO.GetID();
            var tipoParticipacaoId = tipoParticipacaoDTO.GetID();

            var participacao = ListarParticipacoes(eventoDTO).Where(participacaoDB =>
                participacaoDB.Pessoa == pessoaDTO.Id &&
                participacaoDB.Evento == eventoId &&
                participacaoDB.TipoParticipacao == tipoParticipacaoId
            ).FirstOrDefault() ?? new Participacao()
            {
                Evento = eventoId,
                TipoParticipacao = tipoParticipacaoId,
                Pessoa = pessoaDTO.Id
            };

            DataContext.ObterDataContext().InsertOrReplace(participacao);
        }

        public void VincularDocumento(DocumentoDTO documentoDTO, EventoDTO eventoDTO)
        {
            var eventoId = eventoDTO.GetID();

            var documento = ListarDocumentos(eventoDTO).Where(documentoDB =>
                documentoDB.Evento == eventoId &&
                documentoDB.Documento == documentoDTO.Id
            ).FirstOrDefault() ?? new EventoDocumento()
            {
                Evento = eventoId,
                Documento = documentoDTO.Id
            };
            
            DataContext.ObterDataContext().InsertOrReplace(documento);
        }

        private List<Evento> ObterEvento(EventoDTO eventoDTO)
        {
            if (eventoDTO.DataHora != null)
                return DataContext.ObterDataContext().Table<Evento>().Where(evento => 
                evento.Nome == eventoDTO.Nome && evento.DataHora.Date == ((DateTime)eventoDTO.DataHora).Date).ToList();
            
            if (string.IsNullOrEmpty(eventoDTO.Nome))
                return DataContext.ObterDataContext().Table<Evento>().Where(evento => 
                    evento.DataHora.Date == ((DateTime)eventoDTO.DataHora).Date).ToList();
            
            return DataContext.ObterDataContext().Table<Evento>().Where(evento => 
                evento.Nome == eventoDTO.Nome).ToList();
        }

        private List<PessoaDTO> ObterParticipantes(EventoDTO evento)
        {
            var resultado = new List<PessoaDTO>();
            
            var pessoas = (from participante in ListarParticipacoes(evento)
                join
                    pessoa in DataContext.ObterDataContext().Table<Pessoa>()
                    on participante.Pessoa equals pessoa.Id
                select pessoa).ToList();
            
            foreach(var pessoa in pessoas)
                resultado.Add(PessoaDAL.Consultar(new PessoaDTO()
                {
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome
                }));
            
            return resultado;
        }

        private List<DocumentoDTO> ObterDocumentos(EventoDTO evento)
        {
            var resultado = new List<DocumentoDTO>();
            
            var documentos = (from eventoDocumento in ListarDocumentos(evento)
                join
                    documento in DataContext.ObterDataContext().Table<Documento>()
                    on eventoDocumento.Documento equals documento.Id
                join
                    idioma in DataContext.ObterDataContext().Table<Idioma>()
                    on documento.Idioma equals idioma.Id
                select new DocumentoDTO(documento.Id){
                    Nome = documento.Nome,
                    Idioma = idioma.Nome,
                    DataDigitalizacao = documento.DataDigitalizacao,
                    DataRegistro = documento.DataRegistro
                }).ToList();
                         
            return resultado;
        }

        private List<Participacao> ListarParticipacoes(EventoDTO eventoDTO)
        {
            var id = eventoDTO.GetID();
            return DataContext.ObterDataContext().Table<Participacao>().Where(participacao =>
                participacao.Evento == id
            ).ToList();
        }

        private List<EventoDocumento> ListarDocumentos(EventoDTO eventoDTO)
        {
            var id = eventoDTO.GetID();
            return DataContext.ObterDataContext().Table<EventoDocumento>().Where(participacao =>
                participacao.Evento == id
            ).ToList();
        }
    }
}