using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Video : CorpoDocumento
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        public string Url { get; set; }
    }
}
