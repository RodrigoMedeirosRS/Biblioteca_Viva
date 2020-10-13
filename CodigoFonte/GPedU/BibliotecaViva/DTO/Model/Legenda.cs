using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Legenda
    {
        [PrimaryKey, Indexed]
        public int? Video { get; set; }

        [Indexed]
        public int Texto { get; set; }
    }
}
