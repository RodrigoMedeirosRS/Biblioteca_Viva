using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class AudioDTO : DocumentoDTO
    {
        public AudioDTO()
        {

        }
        public AudioDTO(Documento documento, string idioma, Pessoa autor) : base(documento, idioma, autor)
        {

        }
        public string Base64 { get; set; }
    }
}