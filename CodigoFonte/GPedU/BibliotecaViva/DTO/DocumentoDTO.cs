using BibliotecaViva.DTO.Model;
using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public abstract class DocumentoDTO : CabecalhoDTO
    {        
        public string NomeAutor { get; set; }
        public string SobreNomeAutor { get; set; }
        public List<string> NomeMencao { get; set; }
        public List<string> SobrenomeMencao { get; set; }
        public DateTime DataDigitalizacao { get; set; }
    }
}