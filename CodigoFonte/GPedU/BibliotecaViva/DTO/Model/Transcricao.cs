using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Transcricao
    {
        [PrimaryKey, Indexed]
        public int? Audio { get; set; }

        [Indexed]
        public int Texto { get; set; }
    }
}
