using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registroimagem
    {
        public int Codimagem { get; set; }
        public int Codregistro { get; set; }
        public string Imagembase64 { get; set; }
        public string Tituloimagem { get; set; }

        public virtual Registro CodregistroNavigation { get; set; }
    }
}
