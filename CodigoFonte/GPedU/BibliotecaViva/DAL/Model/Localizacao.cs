using System;
using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class Localizacao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique]
        public string Nome { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataHora { get; set; }
    }
}
