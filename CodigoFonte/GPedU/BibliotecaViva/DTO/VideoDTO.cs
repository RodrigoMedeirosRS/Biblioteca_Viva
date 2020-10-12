using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class VideoDTO : DocumentoDTO
    {
        public VideoDTO()
        {
            Id = null;
        }
        public VideoDTO(int? id)
        {
            Id = id;
        }
        public string Url { get; set; }
    }
}