using System;
namespace BibliotecaViva.Models.DTO
{
    public class AudioDTO : DocumentoDTO
    {
        public AudioDTO()
        {

        }
        public AudioDTO(int id, string nome, string base64, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(id, nome, dataRegistro, dataDataDigtalizacao)
        {
            Base64 = base64;
        }
        public AudioDTO(string nome, string base64, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(nome, dataRegistro, dataDataDigtalizacao)
        {
            Base64 = base64;
        }

        public string Base64 { get; set; }
    }
}