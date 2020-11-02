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
        private IDocumentoDAL DocumentoDAL { get; set; }
        private IPessoaDAL PessoaDAL { get; set; }
        private ISQLiteDataContext DataContext { get; set; }

        public EventoDAL(ISQLiteDataContext dataContext, ILocalizacaoDAL localizacaoDAL, IDocumentoDAL documentoDAL, IPessoaDAL pessoaDAL)
        {
            LocalizacaoDAL = localizacaoDAL;
            DocumentoDAL = documentoDAL;
            DataContext = dataContext;
            PessoaDAL = PessoaDAL;
        }

        public void Cadastrar(EventoDTO eventoDTO)
        {

        }

        public void VincularPessoa(PessoaDTO pessoaDTO, EventoDTO eventoDTO)
        {

        }

        public void VincularDocumento(DocumentoDTO documentoDTO, EventoDTO eventoDTO)
        {

        }

        public List<EventoDTO> Consultar(EventoDTO glossarioDTO)
        {
            return new List<EventoDTO>();
        }
    }
}