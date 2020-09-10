using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Genero
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [Unique]
        public string Nome { get; set; }
    }
}
