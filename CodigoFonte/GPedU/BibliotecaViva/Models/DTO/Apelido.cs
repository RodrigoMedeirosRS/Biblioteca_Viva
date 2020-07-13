using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Apelido
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Nome { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
