using System;

namespace BibliotecaViva.Models.DTO.Dominio
{
    public class LinhaDoTempoDTO
    {
        public LinhaDoTempoDTO(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
        public LinhaDoTempoDTO(int id, string nome, string descricao)
        {
            ID = id;
            Nome = nome;
            Descricao = descricao;
        }
        public int ID {get; set;}
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}