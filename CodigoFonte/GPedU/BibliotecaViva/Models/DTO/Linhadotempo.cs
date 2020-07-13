using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Linhadotempo
    {
        public Linhadotempo()
        {
            Linhadotempodocumento = new HashSet<Linhadotempodocumento>();
            Linhadotempoevento = new HashSet<Linhadotempoevento>();
            Linhadotempopessoa = new HashSet<Linhadotempopessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricacao { get; set; }

        public virtual ICollection<Linhadotempodocumento> Linhadotempodocumento { get; set; }
        public virtual ICollection<Linhadotempoevento> Linhadotempoevento { get; set; }
        public virtual ICollection<Linhadotempopessoa> Linhadotempopessoa { get; set; }
    }
}
