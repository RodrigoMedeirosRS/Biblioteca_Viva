using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Audio
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        public string Base64 { get; set; }
    }
}
