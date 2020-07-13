using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Conceito
    {
        public Conceito()
        {
            Significado = new HashSet<Significado>();
        }

        public int Id { get; set; }
        public int GlossarioId { get; set; }
        public string Nome { get; set; }

        public virtual Glossario Glossario { get; set; }
        public virtual ICollection<Significado> Significado { get; set; }
    }
}
