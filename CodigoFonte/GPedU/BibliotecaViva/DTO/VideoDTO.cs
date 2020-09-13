using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class VideoDTO : DocumentoDTO
    {
        public VideoDTO()
        {

        }
        public VideoDTO(Documento documento, string idioma, Pessoa autor) : base(documento, idioma, autor)
        {

        }
        public string Url { get; set; }
    }
}