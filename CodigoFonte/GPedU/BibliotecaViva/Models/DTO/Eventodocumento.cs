using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Eventodocumento
    {
        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public int EventoId { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Evento Evento { get; set; }
    }
}
