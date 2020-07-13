using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Linhadotempoevento
    {
        public int Id { get; set; }
        public int LinhadotempoId { get; set; }
        public int EventoId { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Linhadotempo Linhadotempo { get; set; }
    }
}
