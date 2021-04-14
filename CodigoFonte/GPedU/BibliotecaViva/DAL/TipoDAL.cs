using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class TipoDAL : BaseDAL, ITipoDAL
    {
        public TipoDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }
        public TipoDTO ObterTipo(TipoDTO tipoDTO)
        {
            var resultado = new Tipo();

            if (string.IsNullOrEmpty(tipoDTO.Nome))
                resultado = DataContext.ObterDataContext().Table<Tipo>().FirstOrDefault(tipo => tipo.Codigo == tipoDTO.Codigo);
            else
                resultado = DataContext.ObterDataContext().Table<Tipo>().FirstOrDefault(tipo => tipo.Nome == tipoDTO.Nome);
            
            return Mapear<Tipo, TipoDTO>(resultado);
        }
    }
}