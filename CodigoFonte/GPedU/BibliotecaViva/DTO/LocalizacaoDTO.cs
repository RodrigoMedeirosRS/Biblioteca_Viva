using System;
using System.Collections.Generic;

namespace BibliotecaViva.DTO
{
    public class LocalizacaoDTO
    {
        public LocalizacaoDTO()
        {
            Regioes = new List<RegiaoDTO>();
        }
        public LocalizacaoDTO(int? id)
        {
            Id = id;
            Regioes = new List<RegiaoDTO>();
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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataRegistro { get; set;}
        public List<RegiaoDTO> Regioes { get; set; }
    }
}