using System.Data.SQLite.Tools;

namespace BibliotecaViva.DTO.Model
{
    public class DocumentoGlossario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int? Glossario { get; set; }

        [Indexed]
        public int? Documento { get; set; }
    }
}
