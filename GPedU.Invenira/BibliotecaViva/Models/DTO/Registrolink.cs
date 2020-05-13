using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registrolink
    {
        public int Codlink { get; set; }
        public int Codregistro { get; set; }
        public string Link { get; set; }
        public string Titulolink { get; set; }

        public virtual Registro CodregistroNavigation { get; set; }
    }
}
