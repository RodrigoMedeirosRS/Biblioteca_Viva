using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class PessoaLocalizao
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Pessoa { get; set; }

        [Indexed]
        public int LocalizacaoGeografica { get; set; }
    }
}