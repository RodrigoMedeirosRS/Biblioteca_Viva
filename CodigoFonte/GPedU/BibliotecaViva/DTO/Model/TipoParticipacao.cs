using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class TipoParticipacao
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        [Unique]
        public string Nome { get; set; }
    }
}
