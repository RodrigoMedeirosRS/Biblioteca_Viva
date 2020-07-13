using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Audio
    {
        public Audio()
        {
            Audiodescricaoimagem = new HashSet<Audiodescricaoimagem>();
            Audiodescricaovideo = new HashSet<Audiodescricaovideo>();
            Transcricao = new HashSet<Transcricao>();
        }

        public int Id { get; set; }
        public int DocumentoId { get; set; }
        public string Base64 { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual ICollection<Audiodescricaoimagem> Audiodescricaoimagem { get; set; }
        public virtual ICollection<Audiodescricaovideo> Audiodescricaovideo { get; set; }
        public virtual ICollection<Transcricao> Transcricao { get; set; }
    }
}
