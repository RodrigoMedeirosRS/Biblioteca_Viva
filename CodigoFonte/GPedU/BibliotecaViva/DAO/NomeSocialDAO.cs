using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class NomeSocial
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Pessoa { get; set; }

        public string Nome { get; set; }
    }
}