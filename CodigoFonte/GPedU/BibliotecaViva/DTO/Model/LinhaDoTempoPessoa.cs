using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class LinhaDoTempoPessoa
    {
        [PrimaryKey, Indexed]
        public int LinhaDoTempo { get; set; }

        [Indexed]
        public int Pessoa { get; set; }
    }
}
