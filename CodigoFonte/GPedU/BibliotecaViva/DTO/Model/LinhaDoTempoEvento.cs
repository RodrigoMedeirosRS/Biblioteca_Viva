using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class LinhaDoTempoEvento
    {
        [PrimaryKey, Indexed]
        public int LinhaDoTempo { get; set; }

        [Indexed]
        public int Evento { get; set; }
    }
}
