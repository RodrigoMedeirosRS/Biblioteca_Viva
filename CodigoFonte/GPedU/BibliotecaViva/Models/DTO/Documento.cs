using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Documento
    {
        public Documento()
        {
            Audio = new HashSet<Audio>();
            Documentodossie = new HashSet<Documentodossie>();
            Documentoglossario = new HashSet<Documentoglossario>();
            Dossie = new HashSet<Dossie>();
            Eventodocumento = new HashSet<Eventodocumento>();
            Imagem = new HashSet<Imagem>();
            Linhadotempodocumento = new HashSet<Linhadotempodocumento>();
            Texto = new HashSet<Texto>();
            Video = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Dataregistro { get; set; }
        public DateTime Datadigitalizacao { get; set; }

        public virtual ICollection<Audio> Audio { get; set; }
        public virtual ICollection<Documentodossie> Documentodossie { get; set; }
        public virtual ICollection<Documentoglossario> Documentoglossario { get; set; }
        public virtual ICollection<Dossie> Dossie { get; set; }
        public virtual ICollection<Eventodocumento> Eventodocumento { get; set; }
        public virtual ICollection<Imagem> Imagem { get; set; }
        public virtual ICollection<Linhadotempodocumento> Linhadotempodocumento { get; set; }
        public virtual ICollection<Texto> Texto { get; set; }
        public virtual ICollection<Video> Video { get; set; }
    }
}
