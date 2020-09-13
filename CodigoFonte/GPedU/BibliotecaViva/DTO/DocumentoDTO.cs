using BibliotecaViva.DTO.Model;
using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public abstract class DocumentoDTO
    {
        protected DocumentoDTO()
        {

        }

        protected DocumentoDTO(Documento documento, string idioma, Pessoa autor)
        {
            Nome = documento.Nome;
            Idioma = idioma;
            NomeAutor = autor.Nome;
            SobreNomeAutor = autor.Sobrenome;
            DataRegistro = documento.DataRegistro;
            DataDigitalizacao = documento.DataDigitalizacao;
        }
        
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