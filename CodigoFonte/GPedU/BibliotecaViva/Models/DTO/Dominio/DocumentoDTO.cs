using System;
namespace BibliotecaViva.Models.DTO.Dominio
{
    public abstract class DocumentoDTO
    {
        protected DocumentoDTO(string nome, DateTime dataRegistro, DateTime dataDataDigtalizacao)
        {
            Nome = nome;
            DataRegistro = dataRegistro;
            DataDigitalizacao = dataDataDigtalizacao;
        }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataDigitalizacao { get; set; }
    }
}