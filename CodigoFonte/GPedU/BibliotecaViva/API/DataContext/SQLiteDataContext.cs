using System;
using System.IO;
using System.Data.SQLite.Tools;

using BibliotecaViva.DAL.Interfaces;

namespace BibliotecaViva.DataContext
{
    public class SQLiteDataContext : ISQLiteDataContext
    {
        private SQLiteConnection BancoDeDadosLocal { get; set; }

        public SQLiteDataContext()
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "BibliotecaViva.db");
            if (!File.Exists(caminho))
            {
                throw new Exception("Banco de Dados não encontrado.");
            }
            BancoDeDadosLocal = new SQLiteConnection(caminho);
        }
        public SQLiteConnection ObterDataContext()
        {
            return BancoDeDadosLocal;
        }
    }
}
