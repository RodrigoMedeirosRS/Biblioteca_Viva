using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Referencia
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }
        [Indexed]
        public int? ProximaReferencia { get; set; }
        [Indexed]
        public int Registro { get; set; }
    }
}