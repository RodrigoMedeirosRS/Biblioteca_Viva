using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class LinhaDoTempoDocumento
    {
        [PrimaryKey, Indexed]
        public int LinhaDoTempo { get; set; }

        [Indexed]
        public int Documento { get; set; }
    }
}
