using System;

namespace BibliotecaViva.Models.DTO.Dominio
{
    public class VideoDTO : DocumentoDTO
    {
        public VideoDTO()
        {

        }
        public VideoDTO (int id, string nome, string url, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(id, nome, dataRegistro, dataDataDigtalizacao)
        {
            Url = url;
        }
        public VideoDTO (string nome, string url, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(nome, dataRegistro, dataDataDigtalizacao)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}