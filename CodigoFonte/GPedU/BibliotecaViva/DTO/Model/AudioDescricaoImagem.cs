using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class AudioDescricaoImagem
    {
        [PrimaryKey, Indexed]
        public int Imagem { get; set; }
        
        [Indexed]
        public int Audio { get; set; }
    }
}
