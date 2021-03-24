using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class PessoaRegistro
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }
        
        [Indexed]
        public int TipoRelacao { get; set; }
        
        [Indexed]
        public int Pessoa { get; set; }
                
        [Indexed]
        public int Registro { get; set; }
    }
}