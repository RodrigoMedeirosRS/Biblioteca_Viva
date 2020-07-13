using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Linhadotempodocumento
    {
        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public int LinhadotempoId { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Linhadotempo Linhadotempo { get; set; }
    }
}
