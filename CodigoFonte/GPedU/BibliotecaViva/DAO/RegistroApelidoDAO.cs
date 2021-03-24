using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class RegistroApelido
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Registro { get; set; }

        [Indexed]
        public int Apelido { get; set; }
    }
}