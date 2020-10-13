using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class PessoaTermo
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; } 
        
        [Indexed]
        public int? Pessoa { get; set; }

        [Indexed]
        public int Termo { get; set; }
        public bool Aceito { get; set; }
    }
}
