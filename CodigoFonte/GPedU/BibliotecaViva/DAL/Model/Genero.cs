using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Genero
    {
        [PrimaryKey, Indexed]
        public int Pessoa { get; set; }
        
        [Unique]
        public string Nome { get; set; }
    }
}
