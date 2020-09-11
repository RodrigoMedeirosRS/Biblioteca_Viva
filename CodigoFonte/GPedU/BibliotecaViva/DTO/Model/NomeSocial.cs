using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class NomeSocial
    {
        [PrimaryKey, AutoIncrement]
        public int? Pessoa { get; set; }

        public string Nome { get; set; }
    }
}
