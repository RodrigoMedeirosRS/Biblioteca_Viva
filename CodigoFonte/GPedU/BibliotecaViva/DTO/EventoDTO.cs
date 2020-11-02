using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class EventoDTO
    {
        public EventoDTO()
        {
            Participantes = new List<PessoaDTO>();
            Documentos = new List<DocumentoDTO>();
        }
        public EventoDTO(int? id)
        {
            Id = id;
            Participantes = new List<PessoaDTO>();
            Documentos = new List<DocumentoDTO>();
        }

        public void SetID(int? id)
        {
            Id = id;
        }

        public int? GetID()
        {
            return Id;
        }
        private int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
        public string Destricao { get; set; }
        public string Localizacao { get; set; }
        public List<PessoaDTO> Participantes { get; set; }
        public List<DocumentoDTO> Documentos { get; set; }
    }
}