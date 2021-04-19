using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class LocalizacaoGeografica
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}