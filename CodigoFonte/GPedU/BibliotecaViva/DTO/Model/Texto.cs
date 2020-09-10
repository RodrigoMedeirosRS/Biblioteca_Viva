using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Texto
    {
        [PrimaryKey, Indexed]
        public int Documento { get; set; }
        public string Corpo { get; set; }
    }
}
