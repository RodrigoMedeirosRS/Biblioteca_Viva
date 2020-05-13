using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Trilha
    {
        public Trilha()
        {
            Registro = new HashSet<Registro>();
        }

        public int Codtrilha { get; set; }
        public string Nometrilha { get; set; }

        public virtual ICollection<Registro> Registro { get; set; }
    }
}
