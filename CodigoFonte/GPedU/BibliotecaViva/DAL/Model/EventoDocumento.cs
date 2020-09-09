using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class EventoDocumento
    {
        [PrimaryKey, Indexed]
        public int Evento { get; set; }
        
        [Indexed]
        public int Documento { get; set; }
    }
}
