using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Texto
    {
        public Texto()
        {
            Legenda = new HashSet<Legenda>();
            Transcricao = new HashSet<Transcricao>();
        }

        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public string Texto1 { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual ICollection<Legenda> Legenda { get; set; }
        public virtual ICollection<Transcricao> Transcricao { get; set; }
    }
}
