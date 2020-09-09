using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class RegiaoLocal
    {
        [PrimaryKey, Indexed]
        public int Regiao { get; set; }

        [Indexed]
        public int Local { get; set; }
    }
}
