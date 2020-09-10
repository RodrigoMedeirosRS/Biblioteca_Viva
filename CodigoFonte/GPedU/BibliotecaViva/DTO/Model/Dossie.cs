using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Dossie
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        public string Texto { get; set; }
    }
}
