using System;

namespace BibliotecaViva.Models.DTO.Dominio
{
    public class LocalizacaoDTO
    {
        public LocalizacaoDTO(string nome, double latitude, double longitude, DateTime dataHora)
        {
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
            DataHora = dataHora;
        }
        public LocalizacaoDTO(int id, string nome, double latitude, double longitude, DateTime dataHora)
        {
            ID = id;
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
            DataHora = dataHora;
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataHora { get; set; }
    }
}