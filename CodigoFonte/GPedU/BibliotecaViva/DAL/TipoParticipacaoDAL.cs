using System;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TipoParticipacaoDAL : ITipoParticipacaoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public TipoParticipacaoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        
        public void Cadastrar(TipoParticipacaoDTO tipoParticipacaoDTO)
        {
            var tipoParticipacao = ObterTipoParticipacao(tipoParticipacaoDTO) ?? new TipoParticipacao(){ Nome = tipoParticipacaoDTO.Nome };
            DataContext.ObterDataContext().InsertOrReplace(tipoParticipacao);
        }
        public TipoParticipacaoDTO Consultar(TipoParticipacaoDTO tipoParticipacaoDTO)
        {
            var tipoParticipacao = ObterTipoParticipacao(tipoParticipacaoDTO);
            if (tipoParticipacao != null)
                return new TipoParticipacaoDTO(tipoParticipacao.Id) { Nome = tipoParticipacao.Nome };
            throw new Exception("Tipo de participação não cadastrado.");
        }

        private TipoParticipacao ObterTipoParticipacao(TipoParticipacaoDTO tipoParticipacaoDTO)
        {
            return DataContext.ObterDataContext().Table<TipoParticipacao>().Where(tipoParticipacao => tipoParticipacao.Nome == tipoParticipacaoDTO.Nome).FirstOrDefault();
        }
    }
}