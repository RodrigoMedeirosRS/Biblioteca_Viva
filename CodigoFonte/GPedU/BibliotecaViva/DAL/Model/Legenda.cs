using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Legenda
    {
        [PrimaryKey, Indexed]
        public int Video { get; set; }

        [Indexed]
        public int Texto { get; set; }
    }
}
