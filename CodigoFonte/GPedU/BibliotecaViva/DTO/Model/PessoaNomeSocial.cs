using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class PessoaNomeSocial
    {
        [PrimaryKey, Indexed]
        public int Pessoa { get; set; }

        [Indexed]
        public int NomeSocial { get; set; }
    }
}
