using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Conceito
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        
        [Indexed]
        public int? Glossario { get; set; }
        public string Nome { get; set; }
    }
}
