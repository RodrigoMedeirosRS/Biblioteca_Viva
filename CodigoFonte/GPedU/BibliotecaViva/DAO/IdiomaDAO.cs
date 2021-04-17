using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Idioma
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Unique]
        public string Nome { get; set; }
    }
}