using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Documentoglossario
    {
        public int Id { get; set; }
        public int GlossarioId { get; set; }
        public int DocumentoId { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Glossario Glossario { get; set; }
    }
}
