using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class AudioDescricaoVideo
    {
        [PrimaryKey, Indexed]
        public int Video { get; set; }

        [Indexed]
        public int Audio { get; set; }
    }
}
