using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Registro
    {
        public Registro()
        {
            Registro3d = new HashSet<Registro3d>();
            Registroaudio = new HashSet<Registroaudio>();
            Registroimagem = new HashSet<Registroimagem>();
            Registrolink = new HashSet<Registrolink>();
            Registrotexto = new HashSet<Registrotexto>();
            Registrovideo = new HashSet<Registrovideo>();
        }

        public int Codregistro { get; set; }
        public int Codaplicacao { get; set; }
        public int Codtrilha { get; set; }
        public string Tituloregistro { get; set; }
        public DateTime? Dataregistro { get; set; }
        public string Sinopseregistro { get; set; }

        public virtual Aplicacao CodaplicacaoNavigation { get; set; }
        public virtual Trilha CodtrilhaNavigation { get; set; }
        public virtual ICollection<Registro3d> Registro3d { get; set; }
        public virtual ICollection<Registroaudio> Registroaudio { get; set; }
        public virtual ICollection<Registroimagem> Registroimagem { get; set; }
        public virtual ICollection<Registrolink> Registrolink { get; set; }
        public virtual ICollection<Registrotexto> Registrotexto { get; set; }
        public virtual ICollection<Registrovideo> Registrovideo { get; set; }
    }
}
