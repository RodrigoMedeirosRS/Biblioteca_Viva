using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class ImagemDTO : DocumentoDTO
    {
        public ImagemDTO()
        {
            Id = null;
        }
        public ImagemDTO(int? id)
        {
            Id = id;
        }
        public string Base64 { get; set; }
        public string Termo { get; set; }
    }
}