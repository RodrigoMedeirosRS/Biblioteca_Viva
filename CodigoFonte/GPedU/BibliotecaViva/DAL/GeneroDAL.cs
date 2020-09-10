using System;
using System.Linq;
using System.Data.SQLite.Tools;
using System.Collections.Generic;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Model;
using BibliotecaViva.DAL.Interfaces;


namespace BibliotecaViva.DAL
{
    public class GeneroDAL : IGeneroDAL
    {

        private ISQLiteDataContext DataContext;

        public GeneroDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public Genero Consultar(string nome)
        {
            return DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(genero => genero.Nome == nome);
        }

        public Genero Consultar(int id)
        {
            return DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(genero => genero.Id == id);
        }
    }
}