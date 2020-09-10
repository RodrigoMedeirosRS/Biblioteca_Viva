using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
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
