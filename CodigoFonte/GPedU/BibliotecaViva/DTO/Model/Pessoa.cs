using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
