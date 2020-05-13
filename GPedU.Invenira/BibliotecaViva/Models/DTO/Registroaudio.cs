using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registroaudio
    {
        public int Codaudio { get; set; }
        public int Codregistro { get; set; }
        public string Audiobase64 { get; set; }
        public string Tituloaudio { get; set; }

        public virtual Registro CodregistroNavigation { get; set; }
    }
}
