using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class RegiaoLocal
    {
        [PrimaryKey, Indexed]
        public int Regiao { get; set; }

        [Indexed]
        public int Local { get; set; }
    }
}
