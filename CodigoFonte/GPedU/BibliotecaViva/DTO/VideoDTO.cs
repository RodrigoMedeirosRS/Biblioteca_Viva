using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class VideoDTO : DocumentoDTO
    {
        public VideoDTO()
        {

        }
        public VideoDTO(Documento documento, string idioma, Pessoa autor, string url) : base(documento, idioma, autor)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}