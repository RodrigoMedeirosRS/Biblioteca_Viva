using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Termopessoa
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int TermoId { get; set; }
        public bool Aceito { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Termo Termo { get; set; }
    }
}
