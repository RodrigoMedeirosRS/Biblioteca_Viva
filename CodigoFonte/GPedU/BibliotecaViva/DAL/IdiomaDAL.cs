using System;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DAL
{
    public class IdiomaDAL : IIdiomaDAL
    {
        private ISQLiteDataContext DataContext { get; set; }
        public IdiomaDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }
        public Idioma Consultar(string idioma)
        {
            return DataContext.ObterDataContext().Table<Idioma>().FirstOrDefault(idiomaDB => idiomaDB.Nome == idioma) ?? throw new Exception("Idioma não cadastrado!");
        }
    }
}
