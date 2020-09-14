using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class PessoaDocumento
    {
        [PrimaryKey, Indexed]
        public int? Pessoa { get; set; }

        [Indexed]
        public int TipoDeRelacao { get; set; }

        [Indexed]
        public int? Documento { get; set; }
    }
}
