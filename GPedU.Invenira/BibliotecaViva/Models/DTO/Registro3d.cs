using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registro3d
    {
        public int Codregistro3d { get; set; }
        public int Codregistro { get; set; }
        public string Regsitro3dbase64 { get; set; }
        public string Titloregistro { get; set; }

        public virtual Registro CodregistroNavigation { get; set; }
    }
}
