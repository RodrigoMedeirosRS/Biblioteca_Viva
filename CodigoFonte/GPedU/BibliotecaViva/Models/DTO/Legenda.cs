using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Legenda
    {
        public int Id { get; set; }
        public int TextoId { get; set; }
        public int VideoId { get; set; }

        public virtual Texto Texto { get; set; }
        public virtual Video Video { get; set; }
    }
}
