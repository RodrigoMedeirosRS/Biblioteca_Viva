using System;
using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Documento
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        
        [Indexed]
        public int Idioma { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataDigitalizacao { get; set; }
    }
}
