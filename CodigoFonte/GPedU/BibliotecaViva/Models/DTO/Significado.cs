using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Significado
    {
        public int Id { get; set; }
        public int ConceitoId { get; set; }
        public int IdiomaId { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }

        public virtual Conceito Conceito { get; set; }
        public virtual Idioma Idioma { get; set; }
    }
}
