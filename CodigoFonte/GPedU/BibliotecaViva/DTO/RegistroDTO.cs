using System;

namespace BibliotecaViva.DTO
{
    public class RegistroDTO : BaseDTO
    {
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public string Tipo { get; set; }
        public string Conteudo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInsercao { get; set; }
    }
}