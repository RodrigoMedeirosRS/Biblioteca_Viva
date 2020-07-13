using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Termo
    {
        public Termo()
        {
            Imagem = new HashSet<Imagem>();
        }

        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int Nome { get; set; }
        public int Texto { get; set; }
        public bool Aceito { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Imagem> Imagem { get; set; }
    }
}
