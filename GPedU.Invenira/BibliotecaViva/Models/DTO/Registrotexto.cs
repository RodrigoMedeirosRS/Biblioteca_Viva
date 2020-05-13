using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registrotexto
    {
        public int Codtexto { get; set; }
        public int Codregistro { get; set; }
        public string Texto { get; set; }
        public string Titulotexto { get; set; }

        public virtual Registro CodregistroNavigation { get; set; }
    }
}
