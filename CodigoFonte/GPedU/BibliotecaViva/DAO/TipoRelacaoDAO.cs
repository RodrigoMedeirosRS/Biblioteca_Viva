using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class TipoRelacao
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
    }
}