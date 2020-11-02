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
            return "sucesso";
        }

        public async Task<string> VincularDocumento(VincularDocumentoEntrada vincularDocumentoEntrada)
        {
            return "sucesso";
        }

        public async Task<string> Consultar(EventoConsulta eventoDTO)
        {
            return "sucesso";
        }

        
    }
}