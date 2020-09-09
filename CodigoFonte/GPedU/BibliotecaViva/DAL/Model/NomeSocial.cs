using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class NomeSocial
    {
        [PrimaryKey, Indexed]
        public int Pessoa { get; set; }

        [Unique]
        public string Nome { get; set; }
    }
}
