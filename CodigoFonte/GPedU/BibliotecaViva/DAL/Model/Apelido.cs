using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Apelido
    {
        [PrimaryKey, Indexed]
        public int Pessoa { get; set; }
        public string Nome { get; set; }
    }
}
