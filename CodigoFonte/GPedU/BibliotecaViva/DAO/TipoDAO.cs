using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Tipo
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        public string Nome { get; set; }
        
        public string Extensao { get; set; }
    }
}