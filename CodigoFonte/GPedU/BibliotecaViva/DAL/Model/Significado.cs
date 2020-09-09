using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Significado
    {
        [PrimaryKey, Indexed]
        public int Conceito { get; set; }

        [Indexed]
        public int Idioma { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}
