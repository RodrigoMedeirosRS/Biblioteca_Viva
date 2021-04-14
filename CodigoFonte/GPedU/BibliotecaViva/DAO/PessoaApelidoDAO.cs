using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class PessoaApelido
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Pessoa { get; set; }

        [Indexed]
        public int Apelido { get; set; }
    }
}