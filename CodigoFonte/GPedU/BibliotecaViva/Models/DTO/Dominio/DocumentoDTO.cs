using System;
namespace BibliotecaViva.Models.DTO.Dominio
{
    public abstract class DocumentoDTO
    {
        protected DocumentoDTO(int id, string nome, DateTime dataRegistro, DateTime dataDataDigtalizacao)
        {
            ID = id;
            Nome = nome;
            DataRegistro = dataRegistro;
            DataDigitalizacao = dataDataDigtalizacao;
        }
        protected DocumentoDTO(string nome, DateTime dataRegistro, DateTime dataDataDigtalizacao)
        {
            Nome = nome;
            DataRegistro = dataRegistro;
            DataDigitalizacao = dataDataDigtalizacao;
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataDigitalizacao { get; set; }
    }
}