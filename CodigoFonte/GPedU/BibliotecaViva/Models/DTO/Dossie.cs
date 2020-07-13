using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Dossie
    {
        public Dossie()
        {
            Documentodossie = new HashSet<Documentodossie>();
        }

        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public string Nome { get; set; }
        public string Text { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual ICollection<Documentodossie> Documentodossie { get; set; }
    }
}
