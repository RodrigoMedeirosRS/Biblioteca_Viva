using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class TipoEvento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
