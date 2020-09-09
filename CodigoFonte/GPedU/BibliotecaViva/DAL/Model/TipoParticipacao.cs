using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class TipoParticipacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
