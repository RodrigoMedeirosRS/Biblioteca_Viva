using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Dossie
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        public string Texto { get; set; }
    }
}
