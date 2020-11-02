using System;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TipoEventoDAL : ITipoEventoDAL
    {
        private ISQLiteDataContext DataContext { get; set; }

        public TipoEventoDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        
        public void Cadastrar(TipoEventoDTO tipoEventoDTO)
        {
            var tipoEvento = ObterTipoEvento(tipoEventoDTO) ?? new TipoEvento(){ Nome = tipoEventoDTO.Nome };
            DataContext.ObterDataContext().InsertOrReplace(tipoEvento);
        }
        public TipoEventoDTO Consultar(TipoEventoDTO tipoEventoDTO)
        {
            var tipoEvento = ObterTipoEvento(tipoEventoDTO);
            if (tipoEvento != null)
                return new TipoEventoDTO(tipoEvento.Id) { Nome = tipoEvento.Nome };
            throw new Exception("Tipo de evento não cadastrado.");
        }

        private TipoEvento ObterTipoEvento(TipoEventoDTO tipoEventoDTO)
        {
            return DataContext.ObterDataContext().Table<TipoEvento>().Where(tipoEvento => tipoEvento.Nome == tipoEventoDTO.Nome).FirstOrDefault();
        }
    }
}