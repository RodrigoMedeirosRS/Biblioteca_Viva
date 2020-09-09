using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Imagem
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        
        [Indexed]
        public int Termo { get; set; }
        public string Base64 { get; set; }
    }
}
