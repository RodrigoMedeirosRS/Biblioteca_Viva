using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Apelido
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }
        
        [Unique]
        public string Nome { get; set; }
    }
}