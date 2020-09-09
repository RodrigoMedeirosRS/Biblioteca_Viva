using System.Data.SQLite.Tools;

namespace BibliotecaViva.DAL.Model
{
    public class DocumentoGlossario
    {
        [PrimaryKey, Indexed]
        public int Glossario { get; set; }

        [Indexed]
        public int Documento { get; set; }
    }
}
