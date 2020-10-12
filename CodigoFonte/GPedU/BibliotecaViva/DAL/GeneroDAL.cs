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

        private ISQLiteDataContext DataContext { get; set; }

        public GeneroDAL(ISQLiteDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public Genero Consultar(string nome)
        {
            return DataContext.ObterDataContext().Table<Genero>().FirstOrDefault(genero => genero.Nome == nome) ?? throw new Exception("Genero n�o cadastrado!");
        }
    }
}