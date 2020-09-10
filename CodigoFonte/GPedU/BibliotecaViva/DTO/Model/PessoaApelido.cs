using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class PessoaApelido
    {
        [PrimaryKey, Indexed]
        public int Pessoa { get; set; }

        [Indexed]
        public int Apelido { get; set; }
    }
}
