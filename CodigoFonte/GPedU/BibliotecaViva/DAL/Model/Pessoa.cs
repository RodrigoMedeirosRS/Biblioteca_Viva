using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobre { get; set; }
    }
}
