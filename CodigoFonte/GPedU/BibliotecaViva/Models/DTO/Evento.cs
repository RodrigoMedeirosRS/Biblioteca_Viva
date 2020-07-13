using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Evento
    {
        public Evento()
        {
            Eventodocumento = new HashSet<Eventodocumento>();
            Linhadotempoevento = new HashSet<Linhadotempoevento>();
            Localevento = new HashSet<Localevento>();
            Participacao = new HashSet<Participacao>();
        }

        public int Id { get; set; }
        public int TipoeventoId { get; set; }
        public string Nome { get; set; }
        public DateTime Datahora { get; set; }
        public string Descricao { get; set; }

        public virtual Tipoevento Tipoevento { get; set; }
        public virtual ICollection<Eventodocumento> Eventodocumento { get; set; }
        public virtual ICollection<Linhadotempoevento> Linhadotempoevento { get; set; }
        public virtual ICollection<Localevento> Localevento { get; set; }
        public virtual ICollection<Participacao> Participacao { get; set; }
    }
}
