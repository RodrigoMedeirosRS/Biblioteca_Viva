using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Aplicacao
    {
        public Aplicacao()
        {
            Registro = new HashSet<Registro>();
        }

        public int Codaplicacao { get; set; }
        public string Nomeaplicacao { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
