using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class LinhaDoTempoPessoa
    {
        [PrimaryKey, Indexed]
        public int LinhaDoTempo { get; set; }

        [Indexed]
        public int Pessoa { get; set; }
    }
}
