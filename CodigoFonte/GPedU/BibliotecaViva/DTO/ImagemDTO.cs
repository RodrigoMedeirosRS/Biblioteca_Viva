using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class ImagemDTO : DocumentoDTO
    {
        public ImagemDTO()
        {

        }
        public ImagemDTO(Documento documento, string idioma, Pessoa autor) : base(documento, idioma, autor)
        {

        }
        public string Base64 { get; set; }
        public string Termo { get; set; }
    }
}