using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class EventoDocumento
    {
        [PrimaryKey, Indexed]
        public int Evento { get; set; }
        
        [Indexed]
        public int Documento { get; set; }
    }
}
