using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Participacao
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int TipoparticipacaoId { get; set; }
        public int EventoId { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Tipoparticipacao Tipoparticipacao { get; set; }
    }
}
