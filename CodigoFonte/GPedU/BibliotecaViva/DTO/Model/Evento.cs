using System;
using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Evento
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        
        [Indexed]
        public int? TipoEvento { get; set; }

        [Unique]
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

    }
}
