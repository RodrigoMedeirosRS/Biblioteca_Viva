using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Video
    {
        public Video()
        {
            Audiodescricaovideo = new HashSet<Audiodescricaovideo>();
            Legenda = new HashSet<Legenda>();
        }

        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public string Url { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual ICollection<Audiodescricaovideo> Audiodescricaovideo { get; set; }
        public virtual ICollection<Legenda> Legenda { get; set; }
    }
}
