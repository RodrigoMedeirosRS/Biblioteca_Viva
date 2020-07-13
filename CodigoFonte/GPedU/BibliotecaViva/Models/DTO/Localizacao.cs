using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Localizacao
    {
        public Localizacao()
        {
            Localevento = new HashSet<Localevento>();
            Localglossario = new HashSet<Localglossario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Datahora { get; set; }

        public virtual ICollection<Localevento> Localevento { get; set; }
        public virtual ICollection<Localglossario> Localglossario { get; set; }
    }
}
