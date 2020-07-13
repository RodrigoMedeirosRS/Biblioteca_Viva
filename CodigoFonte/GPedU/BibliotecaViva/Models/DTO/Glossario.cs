using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Glossario
    {
        public Glossario()
        {
            Conceito = new HashSet<Conceito>();
            Documentoglossario = new HashSet<Documentoglossario>();
            Localglossario = new HashSet<Localglossario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Conceito> Conceito { get; set; }
        public virtual ICollection<Documentoglossario> Documentoglossario { get; set; }
        public virtual ICollection<Localglossario> Localglossario { get; set; }
    }
}
