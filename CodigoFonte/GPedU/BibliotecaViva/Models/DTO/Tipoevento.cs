using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Tipoevento
    {
        public Tipoevento()
        {
            Evento = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
