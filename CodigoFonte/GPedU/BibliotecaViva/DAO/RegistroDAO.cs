using System;
using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAO
{
    public class Registro
    {
        [PrimaryKey, AutoIncrement]
        public int? Codigo { get; set; }

        [Indexed]
        public int Idioma { get; set; }

        [Indexed]
        public int Tipo { get; set; }

        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataInsercao { get; set; }
    }
}