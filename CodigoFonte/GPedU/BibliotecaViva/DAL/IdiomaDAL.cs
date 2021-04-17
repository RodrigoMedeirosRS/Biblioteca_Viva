using BibliotecaViva.DAO;
using BibliotecaViva.DTO;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class IdiomaDAL : BaseDAL, IIdiomaDAL
    {
        public IdiomaDAL(ISQLiteDataContext dataContext) : base(dataContext)
        {
        }

        public IdiomaDTO ObterIdioma(IdiomaDTO idiomaDTO)
        {
            var resultado = new Idioma();

            if (string.IsNullOrEmpty(idiomaDTO.Nome))
                resultado = DataContext.ObterDataContext().Table<Idioma>().FirstOrDefault(idioma => idioma.Codigo == idiomaDTO.Codigo);
            else
                resultado = DataContext.ObterDataContext().Table<Idioma>().FirstOrDefault(idioma => idioma.Nome == idiomaDTO.Nome);
            
            return Mapear<Idioma, IdiomaDTO>(resultado);
        }
    }
}