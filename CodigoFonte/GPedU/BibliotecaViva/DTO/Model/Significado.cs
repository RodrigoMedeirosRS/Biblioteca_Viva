using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class Significado
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; } 
        
        [Indexed]
        public int? Conceito { get; set; }

        [Indexed]
        public int? Idioma { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}
