using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Participacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [Unique]
        public int Evento { get; set; }

        [Unique]
        public int TipoParticipacao { get; set; }

        [Unique]
        public int Pessoa { get; set; }
    }
}
