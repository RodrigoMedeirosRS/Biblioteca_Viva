using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Tipoparticipacao
    {
        public Tipoparticipacao()
        {
            Participacao = new HashSet<Participacao>();
        }

        public int Id { get; set; }
        public int Nome { get; set; }

        public virtual ICollection<Participacao> Participacao { get; set; }
    }
}
