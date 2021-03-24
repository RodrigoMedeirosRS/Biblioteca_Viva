using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Descricao
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Registro { get; set; }

        public string Conteudo { get; set; }
    }
}