using System;
namespace BibliotecaViva.Models.DTO.Dominio
{
    public class ImagemDTO : DocumentoDTO
    {
        public ImagemDTO(int id, string nome, string base64, TermoDTO termo, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(id, nome, dataRegistro, dataDataDigtalizacao)
        {
            Base64 = base64;
            Termo = termo;
        }
        public ImagemDTO(string nome, string base64, TermoDTO termo, DateTime dataRegistro, DateTime dataDataDigtalizacao) : base(nome, dataRegistro, dataDataDigtalizacao)
        {
            Base64 = base64;
            Termo = termo;
        }
        public TermoDTO Termo { get; set; }
        public string Base64 { get; set; }
    }
}