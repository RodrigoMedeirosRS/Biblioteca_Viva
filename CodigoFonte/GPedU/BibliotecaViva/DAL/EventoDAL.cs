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
        private IIdiomaDAL IdiomaDAL { get; set; }
        private ILocalizacaoDAL LocalizacaoDAL { get; set; }
        private IPessoaDAL PessoaDAL { get; set; }
        private ISQLiteDataContext DataContext { get; set; }

        public EventoDAL(ISQLiteDataContext dataContext, ILocalizacaoDAL localizacaoDAL, IPessoaDAL pessoaDAL, IIdiomaDAL idiomaDAL)
        {
            LocalizacaoDAL = localizacaoDAL;
            DataContext = dataContext;
            PessoaDAL = pessoaDAL;
            IdiomaDAL = idiomaDAL;
        }

        public void Cadastrar(EventoDTO eventoDTO)
        {
            var evento = PopularEvento(eventoDTO, (ObterEvento(eventoDTO).FirstOrDefault() ?? new Evento()));
            var localizacao = LocalizacaoDAL.Consultar(new LocalizacaoDTO() { Nome = eventoDTO.Localizacao }, 0, 0, 0, 0).FirstOrDefault().GetID();
            DataContext.ObterDataContext().InsertOrReplace(evento);
            
            PopulaveEventoLocalizacao(ObterEvento(eventoDTO).FirstOrDefault().Id, localizacao);
        }

        private void PopulaveEventoLocalizacao(int? eventoID, int? localizacaoID)
        {
            var localizacaoEvento = DataContext.ObterDataContext().Table<EventoLocalizacao>().Where(eventoLocalizacao => eventoLocalizacao.Evento == eventoID).FirstOrDefault() ?? new EventoLocalizacao();
            localizacaoEvento.Evento = eventoID;
            localizacaoEvento.Localizacao = localizacaoID;
            DataContext.ObterDataContext().InsertOrReplace(localizacaoEvento);
        }

        private Evento PopularEvento(EventoDTO eventoDTO, Evento evento)
        {
            evento.Nome = eventoDTO.Nome;
            evento.Descricao = eventoDTO.Destricao;
            evento.DataHora = (DateTime)eventoDTO.DataHora;
            evento.TipoEvento = DataContext.ObterDataContext().Table<TipoEvento>().Where(tipoEvento => tipoEvento.Nome == eventoDTO.TipoEvento).FirstOrDefault().Id;
            
            return evento;
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
            pessoaDTO.SetID(PessoaDAL.Consultar(pessoaDTO.Nome, pessoaDTO.Sobrenome).Id);
            var eventoId = ObterEvento(eventoDTO).FirstOrDefault().Id;
            var tipoParticipacaoId = DataContext.ObterDataContext().Table<TipoParticipacao>().Where(tipoParticipacao => tipoParticipacao.Nome == tipoParticipacaoDTO.Nome).FirstOrDefault().Id;

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
            var eventoId = ObterEvento(eventoDTO).FirstOrDefault().Id;
            var idiomaID = IdiomaDAL.Consultar(documentoDTO.Idioma).Id;
            documentoDTO.SetID(DataContext.ObterDataContext().Table<Documento>().Where(documentoDB => 
            documentoDB.Nome == documentoDTO.Nome && documentoDB.Idioma == idiomaID).FirstOrDefault().Id);

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
            {
                var pessoaDB = PessoaDAL.Consultar(pessoa.Nome,pessoa.Sobrenome);
                var pessoaDTO = new PessoaDTO(pessoaDB.Id){
                    Nome = pessoaDB.Nome,
                    Sobrenome = pessoaDB.Sobrenome,
                    Genero = DataContext.ObterDataContext().Table<Genero>().Where(genero => genero.Id == pessoaDB.Genero).FirstOrDefault().Nome
                };
                resultado.Add(PessoaDAL.Consultar(pessoaDTO));
            }
            
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

            resultado.AddRange(documentos);

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