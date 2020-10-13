using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Participacao
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        
        [Indexed]
        public int? Evento { get; set; }

        [Indexed]
        public int? TipoParticipacao { get; set; }

        [Indexed]
        public int? Pessoa { get; set; }
    }
}
