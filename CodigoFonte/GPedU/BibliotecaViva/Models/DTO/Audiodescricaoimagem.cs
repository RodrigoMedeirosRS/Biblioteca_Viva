using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Audiodescricaoimagem
    {
        public int Id { get; set; }
        public int IdiomaId { get; set; }
        public int AudioId { get; set; }
        public int ImagemId { get; set; }

        public virtual Audio Audio { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual Imagem Imagem { get; set; }
    }
}
