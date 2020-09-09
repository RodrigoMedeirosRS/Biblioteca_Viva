using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class LinhaDoTempoEvento
    {
        [PrimaryKey, Indexed]
        public int LinhaDoTempo { get; set; }

        [Indexed]
        public int Evento { get; set; }
    }
}
