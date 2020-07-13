using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Linhadotempopessoa
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public int LinhadotempoId { get; set; }

        public virtual Linhadotempo Linhadotempo { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
