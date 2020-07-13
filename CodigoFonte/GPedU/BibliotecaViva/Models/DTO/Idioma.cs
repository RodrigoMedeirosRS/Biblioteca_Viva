using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Idioma
    {
        public Idioma()
        {
            Audiodescricaoimagem = new HashSet<Audiodescricaoimagem>();
            Audiodescricaovideo = new HashSet<Audiodescricaovideo>();
            Significado = new HashSet<Significado>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Audiodescricaoimagem> Audiodescricaoimagem { get; set; }
        public virtual ICollection<Audiodescricaovideo> Audiodescricaovideo { get; set; }
        public virtual ICollection<Significado> Significado { get; set; }
    }
}
