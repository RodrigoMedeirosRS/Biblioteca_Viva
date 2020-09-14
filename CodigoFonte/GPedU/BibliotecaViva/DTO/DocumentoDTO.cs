using BibliotecaViva.DTO.Model;
using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public abstract class DocumentoDTO
    {        
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public string NomeAutor { get; set; }
        public string SobreNomeAutor { get; set; }
        public List<string> NomeMencao { get; set; }
        public List<string> SobrenomeMencao { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataDigitalizacao { get; set; }
    }
}