using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Termo
    {
        public Termo()
        {
            Imagem = new HashSet<Imagem>();
            Termopessoa = new HashSet<Termopessoa>();
        }

        public int Id { get; set; }
        public int Nome { get; set; }
        public int Texto { get; set; }

        public virtual ICollection<Imagem> Imagem { get; set; }
        public virtual ICollection<Termopessoa> Termopessoa { get; set; }
    }
}
