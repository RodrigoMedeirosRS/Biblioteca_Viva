using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Apelido = new HashSet<Apelido>();
            Genero = new HashSet<Genero>();
            Linhadotempopessoa = new HashSet<Linhadotempopessoa>();
            Nomesocial = new HashSet<Nomesocial>();
            Participacao = new HashSet<Participacao>();
            Termopessoa = new HashSet<Termopessoa>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public virtual ICollection<Apelido> Apelido { get; set; }
        public virtual ICollection<Genero> Genero { get; set; }
        public virtual ICollection<Linhadotempopessoa> Linhadotempopessoa { get; set; }
        public virtual ICollection<Nomesocial> Nomesocial { get; set; }
        public virtual ICollection<Participacao> Participacao { get; set; }
        public virtual ICollection<Termopessoa> Termopessoa { get; set; }
    }
}
