using System;
using System.Collections.Generic;

namespace BibliotecaViva.Models.DTO
{
    public class LocalizacaoDTO
    {
        public LocalizacaoDTO()
        {

        }
        public LocalizacaoDTO(string nome, double latitude, double longitude, DateTime dataHora, List<LocalizacaoDTO> locais = null)
        {
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
            DataHora = dataHora;
            Locais = locais ?? new List<LocalizacaoDTO>();
        }
        public LocalizacaoDTO(int id, string nome, double latitude, double longitude, DateTime dataHora, List<LocalizacaoDTO> locais = null)
        {
            ID = id;
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
            DataHora = dataHora;
            Locais = locais ?? new List<LocalizacaoDTO>();
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataHora { get; set; }
        public List<LocalizacaoDTO> Locais { get; set; }
    }
}