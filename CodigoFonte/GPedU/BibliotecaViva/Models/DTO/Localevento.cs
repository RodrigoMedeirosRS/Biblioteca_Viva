using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Localevento
    {
        public int Id { get; set; }
        public int LocalizacaoId { get; set; }
        public int EventoId { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Localizacao Localizacao { get; set; }
    }
}
