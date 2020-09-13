using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class ImagemDTO : DocumentoDTO
    {
        public ImagemDTO()
        {

        }
        public ImagemDTO(Documento documento, string idioma, Pessoa autor, string base64) : base(documento, idioma, autor)
        {
            Base64 = base64;
        }
        public string Base64 { get; set; }
        public string Termo { get; set; }
    }
}