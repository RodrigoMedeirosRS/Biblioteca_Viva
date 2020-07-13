using System;

namespace BibliotecaViva.Models.DTO.Dominio
{
    public class EventoDTO
    {
        public EventoDTO(string nome, DateTime dataHora, string descricao, string tipo)
        {
            Nome = nome;
            DataHora = dataHora;
            Descricao = descricao;
            Tipo = tipo;
        }
        public EventoDTO(int id, string nome, DateTime dataHora, string descricao, string tipo)
        {
            ID = id;
            Nome = nome;
            DataHora = dataHora;
            Descricao = descricao;
            Tipo = tipo;
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
    }
}