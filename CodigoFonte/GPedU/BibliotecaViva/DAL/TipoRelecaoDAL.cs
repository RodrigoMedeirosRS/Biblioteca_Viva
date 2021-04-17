using BibliotecaViva.DTO;
using BibliotecaViva.DAO;
using BibliotecaViva.DAL.Interfaces;
namespace BibliotecaViva.DAL
{
    public class TipoRelecaoDAL : BaseDAL, ITipoRelacaoDAL
    {
        public TipoRelecaoDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }
        public TipoRelacaoDTO ObterTipo(TipoRelacaoDTO tipoRelacaoDTO)
        {
            var resultado = new TipoRelacao();

            if (string.IsNullOrEmpty(tipoRelacaoDTO.Nome))
                resultado = DataContext.ObterDataContext().Table<TipoRelacao>().FirstOrDefault(tipo => tipo.Codigo == tipoRelacaoDTO.Codigo);
            else
                resultado = DataContext.ObterDataContext().Table<TipoRelacao>().FirstOrDefault(tipo => tipo.Nome == tipoRelacaoDTO.Nome);
            
            return Mapear<TipoRelacao, TipoRelacaoDTO>(resultado);
        }
    }
}