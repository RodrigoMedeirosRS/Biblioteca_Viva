using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class EventoLocalizacao
    {
        [PrimaryKey, Indexed]
        public int Evento { get; set; }
        
        [Indexed]
        public int Localizacao { get; set; }
    }
}
