using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class RegistroLocalizacao
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Registro { get; set; }

        [Indexed]
        public int LocalizacaoGeografica { get; set; }
    }
}