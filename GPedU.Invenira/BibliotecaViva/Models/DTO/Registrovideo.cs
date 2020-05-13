using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registrovideo
    {
        public int Codvideo { get; set; }
        public int Codregistro { get; set; }
        public string Videobase64 { get; set; }
        public string Titulovideo { get; set; }

        public virtual Registro CodregistroNavigation { get; set; }
    }
}
