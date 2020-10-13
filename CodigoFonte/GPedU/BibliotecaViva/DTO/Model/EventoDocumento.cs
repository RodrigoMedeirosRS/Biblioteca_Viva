using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class EventoDocumento
    {
        [PrimaryKey, AutoIncrement]
        public int? Id {get; set; }

        [Indexed]
        public int? Evento { get; set; }
        
        [Indexed]
        public int Documento { get; set; }
    }
}
