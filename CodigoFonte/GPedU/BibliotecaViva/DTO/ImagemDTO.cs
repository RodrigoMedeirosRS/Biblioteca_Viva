using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class ImagemDTO : DocumentoDTO
    {
        public string Base64 { get; set; }
        public string Termo { get; set; }
    }
}