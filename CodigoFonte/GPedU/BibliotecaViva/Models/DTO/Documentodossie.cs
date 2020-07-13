using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Documentodossie
    {
        public int Id { get; set; }
        public int DossieId { get; set; }
        public int DocumentoId { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Dossie Dossie { get; set; }
    }
}
