using BibliotecaViva.DTO.Model;

namespace BibliotecaViva.DTO
{
    public class TextoDTO : DocumentoDTO
    {
        public TextoDTO()
        {

        }
        public TextoDTO(Documento documento, string idioma, Pessoa autor) : base(documento, idioma, autor)
        {

        }
        public string Texto { get; set; }
    }
}