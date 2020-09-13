using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class AudioDTO : DocumentoDTO
    {
        public AudioDTO()
        {

        }
        public AudioDTO(Documento documento, string idioma, Pessoa autor, string base64) : base(documento, idioma, autor)
        {
            Base64 = base64;
        }
        public string Base64 { get; set; }
    }
}