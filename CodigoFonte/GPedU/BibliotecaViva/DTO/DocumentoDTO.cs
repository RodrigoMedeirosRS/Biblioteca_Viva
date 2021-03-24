using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class DocumentoDTO : BaseDTO
    {
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public string Tipo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataInsercao { get; set; }
    }
}