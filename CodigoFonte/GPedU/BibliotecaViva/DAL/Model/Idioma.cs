using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Idioma
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Nome { get; set; }
    }
}
