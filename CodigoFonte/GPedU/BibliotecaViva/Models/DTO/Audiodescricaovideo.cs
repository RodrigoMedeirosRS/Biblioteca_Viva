using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Audiodescricaovideo
    {
        public int Id { get; set; }
        public int IdiomaId { get; set; }
        public int AudioId { get; set; }
        public int VideoId { get; set; }

        public virtual Audio Audio { get; set; }
        public virtual Idioma Idioma { get; set; }
        public virtual Video Video { get; set; }
    }
}
