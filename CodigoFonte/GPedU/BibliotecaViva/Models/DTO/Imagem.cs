using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Imagem
    {
        public Imagem()
        {
            Audiodescricaoimagem = new HashSet<Audiodescricaoimagem>();
        }

        public int Id { get; set; }
        public int TermoId { get; set; }
        public int DocumentoId { get; set; }
        public string Base64 { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual Termo Termo { get; set; }
        public virtual ICollection<Audiodescricaoimagem> Audiodescricaoimagem { get; set; }
    }
}
