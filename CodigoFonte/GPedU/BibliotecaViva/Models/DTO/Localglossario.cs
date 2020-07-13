using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Localglossario
    {
        public int Id { get; set; }
        public int GlossarioId { get; set; }
        public int LocalizacaoId { get; set; }

        public virtual Glossario Glossario { get; set; }
        public virtual Localizacao Localizacao { get; set; }
    }
}
