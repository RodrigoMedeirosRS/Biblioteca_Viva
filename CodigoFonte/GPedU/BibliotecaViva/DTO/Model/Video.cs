using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Video
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        public string Url { get; set; }
    }
}
