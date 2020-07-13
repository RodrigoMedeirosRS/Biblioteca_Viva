using System;

namespace BibliotecaViva.Models.DTO.Dominio
{
    public class VideoDTO : DocumentoDTO
    {
        public VideoDTO (string nome, string url, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(nome, dataRegistro, dataDataDigtalizacao)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}