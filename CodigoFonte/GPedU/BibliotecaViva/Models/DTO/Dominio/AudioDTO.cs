using System;
namespace BibliotecaViva.Models.DTO.Dominio
{
    public class AudioDTO : DocumentoDTO
    {
        public AudioDTO(string nome, string base64, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(nome, dataRegistro, dataDataDigtalizacao)
        {
            Base64 = base64;
        }

        public string Base64 { get; set; }
    }
}