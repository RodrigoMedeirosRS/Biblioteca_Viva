using BibliotecaViva.DTO.Model;
using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class DocumentoDTO
    {
        public DocumentoDTO()
        {
            Id = null;
        }
        public DocumentoDTO(int? id)
        {
            Id = id;
        }
        public void AtualizarId(int? id)
        {
            Id = Id ?? id;
        }
        public int? Id { get; protected set;}
        public string Nome { get; set; }
        public string Idioma { get; set; }
        public List<PessoaVinculadaDTO> PessoaVinculadas { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataDigitalizacao { get; set; }
        public List<GlossarioDTO> Glossarios {get; set; }
    }
}