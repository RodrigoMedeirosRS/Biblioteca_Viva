using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class GlossarioLocal
    {
        [PrimaryKey, Indexed]
        public int Glossario { get; set; }
        
        [Indexed]
        public int Localizacao { get; set; }
    }
}
