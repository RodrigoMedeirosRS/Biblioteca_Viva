using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class PessoaTermo
    {
        [PrimaryKey, Indexed]
        public int Pessoa { get; set; }

        [Indexed]
        public int Termo { get; set; }
        public bool Aceito { get; set; }
    }
}
