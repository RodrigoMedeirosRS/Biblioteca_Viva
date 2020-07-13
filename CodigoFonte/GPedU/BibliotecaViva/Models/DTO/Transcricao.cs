using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Transcricao
    {
        public int Id { get; set; }
        public int TextoId { get; set; }
        public int AudioId { get; set; }

        public virtual Audio Audio { get; set; }
        public virtual Texto Texto { get; set; }
    }
}
