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
            if (!File.Exists("./BibliotecaViva.db"))
                throw new Exception("Banco de Dados não encontrado.");

            BancoDeDadosLocal = new SQLiteConnection(Path.Combine("./BibliotecaViva.db"));
        }
        public SQLiteConnection ObterDataContext()
        {
            return BancoDeDadosLocal;
        }
    }
}
