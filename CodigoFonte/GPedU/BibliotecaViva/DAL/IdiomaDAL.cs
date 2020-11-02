using System;
using BibliotecaViva.DTO;
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
        public IdiomaDTO Consultar(string idioma)
        {
            var resultado = DataContext.ObterDataContext().Table<Idioma>().FirstOrDefault(idiomaDB => idiomaDB.Nome == idioma) 
            ?? throw new Exception("Idioma não cadastrado!");
            
            return new IdiomaDTO(resultado.Id)
            {
                Nome = resultado.Nome
            };
        }
    }
}
