using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }
        public string Genero { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}