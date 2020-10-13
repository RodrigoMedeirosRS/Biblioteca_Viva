using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class LinhaDoTempoDocumento
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; } 
        
        [Indexed]
        public int? LinhaDoTempo { get; set; }

        [Indexed]
        public int? Documento { get; set; }
    }
}
